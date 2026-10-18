using System;
using System.Drawing;
using System.Windows.Forms;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;

namespace SmartParking.UI.Forms
{
    public partial class frmLostTicket : Form
    {
        private User currentUser;
        private string prefillPlate;

        private ParkingSession? selectedSession = null;
        private Bitmap? faceSnapshot = null;
        private decimal calculatedNormalFee = 0;
        private decimal penaltyFee = 30000;

        public frmLostTicket() : this(new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin" }, "")
        {
        }

        public frmLostTicket(User user, string plate)
        {
            currentUser = user ?? new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin" };
            prefillPlate = plate ?? "";

            InitializeComponent();

            btnSearch.Click += (s, e) => SearchSessions();
            lstMatchingSessions.SelectedIndexChanged += LstMatchingSessions_SelectedIndexChanged;
            btnCaptureFace.Click += BtnCaptureFace_Click;
            btnConfirm.Click += BtnConfirm_Click;

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            if (!string.IsNullOrWhiteSpace(prefillPlate))
            {
                txtSearch.Text = prefillPlate;
                SearchSessions();
            }
        }

        private void SearchSessions()
        {
            lstMatchingSessions.Items.Clear();
            string query = txtSearch.Text.Trim();

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT p.SessionID, p.PlateNumber, p.VehicleType, s.SlotCode, p.CheckInTime, p.CheckInImageBase64, p.SlotID, p.IsCharging
                    FROM ParkingSessions p
                    LEFT JOIN ParkingSlots s ON p.SlotID = s.SlotID
                    WHERE p.Status = 0 AND (p.PlateNumber LIKE @Q OR @Q = '')
                    ORDER BY p.SessionID DESC;
                ";
                cmd.Parameters.AddWithValue("@Q", $"%{query}%");

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var sess = new ParkingSession
                    {
                        SessionID = reader.GetInt32(0),
                        PlateNumber = reader["PlateNumber"].ToString()!,
                        VehicleType = reader["VehicleType"].ToString()!,
                        SlotCode = reader["SlotCode"]?.ToString() ?? "N/A",
                        CheckInTime = DateTime.Parse(reader["CheckInTime"].ToString()!),
                        CheckInImageBase64 = reader["CheckInImageBase64"]?.ToString(),
                        SlotID = Convert.ToInt32(reader["SlotID"]),
                        IsCharging = Convert.ToInt32(reader["IsCharging"]) == 1
                    };
                    lstMatchingSessions.Items.Add(sess);
                }

                if (lstMatchingSessions.Items.Count > 0)
                    lstMatchingSessions.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstMatchingSessions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstMatchingSessions.SelectedItem is not ParkingSession sess) return;
            selectedSession = sess;

            picInImage.Image?.Dispose();
            if (!string.IsNullOrEmpty(sess.CheckInImageBase64))
                picInImage.Image = CameraService.Base64ToBitmap(sess.CheckInImageBase64);
            else
                picInImage.Image = CameraService.CaptureCameraFrame(sess.PlateNumber, "Ảnh Vào Đối Soát");

            var rule = PricingCalculator.GetCurrentRules();
            penaltyFee = rule.LostTicketPenalty;
            var casualFee = PricingCalculator.CalculateCasualFee(sess.VehicleType, sess.CheckInTime, DateTime.Now, sess.IsCharging);
            calculatedNormalFee = casualFee.totalAmount;

            decimal total = calculatedNormalFee + penaltyFee;
            lblTotalFee.Text = $"TỔNG THANH TOÁN: {total:N0} VNĐ";
        }

        private void BtnCaptureFace_Click(object? sender, EventArgs e)
        {
            picFaceCapture.Image?.Dispose();
            faceSnapshot = CameraService.CaptureCameraFrame(txtFinderName.Text.Trim(), "Ảnh Nhận Xe", true);
            picFaceCapture.Image = (Bitmap)faceSnapshot.Clone();
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            if (selectedSession == null)
            {
                MessageBox.Show("Vui lòng chọn xe trong danh sách tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFinderName.Text) || string.IsNullOrWhiteSpace(txtIdCard.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Số CCCD/MSSV của người nhận xe!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (faceSnapshot == null)
            {
                btnCaptureFace.PerformClick();
            }

            decimal totalPaid = calculatedNormalFee + penaltyFee;
            string faceB64 = CameraService.BitmapToBase64(faceSnapshot);
            string nowStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using var trans = conn.BeginTransaction();
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = trans;

                    cmd.CommandText = @"
                        INSERT INTO IncidentReports (SessionID, PlateNumber, FinderName, IdentityCard, Phone, FaceImageBase64, ParkingFee, PenaltyAmount, TotalPaid, CreatedDate, CreatedByStaff, Notes)
                        VALUES (@SessionID, @Plate, @Name, @IDCard, @Phone, @FaceImg, @ParkFee, @Penalty, @Total, @Created, @Staff, @Notes);
                    ";
                    cmd.Parameters.AddWithValue("@SessionID", selectedSession.SessionID);
                    cmd.Parameters.AddWithValue("@Plate", selectedSession.PlateNumber);
                    cmd.Parameters.AddWithValue("@Name", txtFinderName.Text.Trim());
                    cmd.Parameters.AddWithValue("@IDCard", txtIdCard.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@FaceImg", faceB64);
                    cmd.Parameters.AddWithValue("@ParkFee", calculatedNormalFee);
                    cmd.Parameters.AddWithValue("@Penalty", penaltyFee);
                    cmd.Parameters.AddWithValue("@Total", totalPaid);
                    cmd.Parameters.AddWithValue("@Created", nowStr);
                    cmd.Parameters.AddWithValue("@Staff", currentUser.FullName);
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
                        UPDATE ParkingSessions 
                        SET CheckOutTime = @Now, TotalAmount = @Total, Status = 2, StaffOutID = @StaffID, Notes = @Notes
                        WHERE SessionID = @SessionID;
                    ";
                    cmd.Parameters.AddWithValue("@Now", nowStr);
                    cmd.Parameters.AddWithValue("@StaffID", currentUser.UserID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
                        UPDATE ParkingSlots 
                        SET Status = 0, CurrentPlate = NULL, OccupiedSince = NULL 
                        WHERE SlotID = @SlotID;
                    ";
                    cmd.Parameters.AddWithValue("@SlotID", selectedSession.SlotID);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }

                EventAggregator.PublishSlotStatusChanged(selectedSession.SlotID, 0, null);

                MessageBox.Show($"LẬP BIÊN BẢN MẤT VÉ THÀNH CÔNG!\n\nNgười nhận xe: {txtFinderName.Text.Trim()} (CCCD: {txtIdCard.Text.Trim()})\nTổng tiền thu: {totalPaid:N0} VNĐ\nÔ đỗ {selectedSession.SlotCode} đã được giải phóng.", "Biên bản hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lập biên bản: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
