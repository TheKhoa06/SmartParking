using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;
using SmartParking.UI.Forms;

namespace SmartParking.UI.UserControls
{
    public partial class ucGateControl : UserControl
    {
        private User currentUser;
        private Bitmap? currentInSnapshot = null;
        private Bitmap? currentOutSnapshot = null;

        private ParkingSession? currentOutSession = null;
        private decimal currentOutTotal = 0;
        private string currentOutDetail = "";

        public ucGateControl() : this(new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin", IsActive = true })
        {
        }

        public ucGateControl(User user)
        {
            currentUser = user ?? new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin", IsActive = true };
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            RefreshSuggestedSlots();
            EventAggregator.PricingRulesUpdated += () => { /* auto-reloads next calc */ };
        }

        private void SetupEvents()
        {
            cboVehicleTypeIn.Items.AddRange(new object[] { "Xe máy xăng", "Xe máy điện", "Xe đạp điện", "Ô tô dưới 9 chỗ" });
            cboVehicleTypeIn.SelectedIndex = 0;
            cboVehicleTypeIn.SelectedIndexChanged += (s, e) => RefreshSuggestedSlots();
            chkChargingIn.CheckedChanged += (s, e) => RefreshSuggestedSlots();

            btnSnapIn.Click += (s, e) =>
            {
                picCamIn.Image?.Dispose();
                currentInSnapshot = CameraService.CaptureCameraFrame(txtPlateIn.Text.Trim(), "Làn Vào");
                picCamIn.Image = (Bitmap)currentInSnapshot.Clone();
            };

            btnScanQrIn.Click += BtnScanQrIn_Click;
            btnCheckIn.Click += BtnCheckIn_Click;

            txtSearchOut.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnFindSessionOut_Click(s, e); };
            btnFindSessionOut.Click += BtnFindSessionOut_Click;
            btnCheckOut.Click += BtnCheckOut_Click;
            btnLostTicket.Click += BtnLostTicket_Click;

            picCamIn.Image = CameraService.CaptureCameraFrame("29B1-555.66", "Làn Vào");
            currentInSnapshot = (Bitmap)picCamIn.Image.Clone();

            Load += (s, e) =>
            {
                if (splitContainer.Width > 200)
                    splitContainer.SplitterDistance = splitContainer.Width / 2;
            };
        }

        public void SetLedStatus(string message, Color bgColor, Color textColor)
        {
            lblLedMessage.Text = message;
            pnlLedBanner.BackColor = Color.FromArgb(15, 23, 42);
            lblLedMessage.ForeColor = textColor == Color.White ? (bgColor == UITheme.Danger ? Color.FromArgb(248, 113, 113) : (bgColor == UITheme.Warning ? Color.FromArgb(251, 191, 36) : Color.FromArgb(52, 211, 153))) : textColor;
            lblLedMessage.Font = new Font("Segoe UI", message.Length > 45 ? 10f : 11.5f, FontStyle.Bold);
        }

        private void RefreshSuggestedSlots()
        {
            cboSuggestedSlot.Items.Clear();
            string selectedVeh = cboVehicleTypeIn.SelectedItem?.ToString() ?? "Xe máy xăng";
            bool isCharging = chkChargingIn.Checked;

            string targetZone = "A";
            if (isCharging) targetZone = "B";
            else if (selectedVeh.Contains("Ô tô")) targetZone = "B1";
            else if (selectedVeh.Contains("đạp")) targetZone = "B";

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SlotID, SlotCode, SlotType FROM ParkingSlots WHERE Zone = @Zone AND Status = 0 ORDER BY SlotID ASC;";
                cmd.Parameters.AddWithValue("@Zone", targetZone);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboSuggestedSlot.Items.Add(new ComboBoxItem(reader["SlotCode"].ToString()!, Convert.ToInt32(reader["SlotID"])));
                }

                if (cboSuggestedSlot.Items.Count > 0)
                    cboSuggestedSlot.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gợi ý ô đỗ: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnScanQrIn_Click(object? sender, EventArgs e)
        {
            string cardCode = txtQrCardIn.Text.Trim();
            if (string.IsNullOrWhiteSpace(cardCode))
            {
                MessageBox.Show("Vui lòng nhập hoặc quẹt mã thẻ tháng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT m.CardID, m.CardCode, m.ExpireDate, m.Status, v.PlateNumber, v.VehicleType, r.FullName, rm.RoomNumber
                    FROM MonthlyCards m
                    JOIN Vehicles v ON m.VehicleID = v.VehicleID
                    JOIN Residents r ON v.ResidentID = r.ResidentID
                    JOIN Rooms rm ON r.RoomID = rm.RoomID
                    WHERE m.CardCode = @Card;
                ";
                cmd.Parameters.AddWithValue("@Card", cardCode);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string status = reader["Status"].ToString()!;
                    DateTime expDate = DateTime.Parse(reader["ExpireDate"].ToString()!);
                    string regPlate = reader["PlateNumber"].ToString()!;
                    string vehType = reader["VehicleType"].ToString()!;
                    string owner = reader["FullName"].ToString()!;
                    string room = reader["RoomNumber"].ToString()!;

                    reader.Close();
                    cmd.CommandText = "SELECT SessionID, CheckInTime FROM ParkingSessions WHERE CardCode = @Card AND Status = 0;";
                    using var sessReader = cmd.ExecuteReader();
                    if (sessReader.Read())
                    {
                        string inTime = sessReader["CheckInTime"].ToString()!;
                        SystemSounds.Hand.Play();
                        SetLedStatus($"CHẶN XE: THẺ '{cardCode}' ĐANG CÓ XE TRONG BÃI (VÀO LÚC {inTime})!", UITheme.Danger, Color.White);
                        MessageBox.Show($"CẢNH BÁO GIAN LẬN THẺ THÁNG (ANTI-PASSBACK)!\nThẻ tháng '{cardCode}' này đang có 1 xe nằm trong bãi chưa lấy ra lúc {inTime}.\nHệ thống từ chối mở cổng!", "Anti-Passback Block", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sessReader.Close();

                    if (expDate < DateTime.Now || status == "Hết hạn" || status == "Bị khóa")
                    {
                        SystemSounds.Hand.Play();
                        SetLedStatus($"CHẶN XE: THẺ '{cardCode}' ĐÃ HẾT HẠN HOẶC BỊ KHÓA!", UITheme.Danger, Color.White);
                        MessageBox.Show($"Thẻ tháng của {owner} ({room}) đã hết hạn vào ngày {expDate:dd/MM/yyyy}. Vui lòng liên hệ Ban quản lý gia hạn!", "Thẻ hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtPlateIn.Text = regPlate;
                    cboVehicleTypeIn.SelectedItem = vehType;

                    int daysLeft = (int)Math.Ceiling((expDate - DateTime.Now).TotalDays);
                    if (daysLeft <= 5)
                    {
                        SetLedStatus($"CHÚ Ý: VÉ THÁNG SẮP HẾT HẠN (Phòng {room} - Còn {daysLeft} ngày) - MỜI XE VÀO", UITheme.Warning, Color.White);
                    }
                    else
                    {
                        SetLedStatus($"MỜI XE QUA - VÉ THÁNG HỢP LỆ (Phòng {room} - {owner})", UITheme.Success, Color.White);
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy dữ liệu thẻ tháng '{cardCode}' trong hệ thống!", "Không tìm thấy thẻ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi quẹt thẻ tháng: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCheckIn_Click(object? sender, EventArgs e)
        {
            string plate = txtPlateIn.Text.Trim();
            if (string.IsNullOrWhiteSpace(plate))
            {
                MessageBox.Show("Vui lòng nhập biển số xe vào bãi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboSuggestedSlot.SelectedItem is not ComboBoxItem selectedSlotItem)
            {
                MessageBox.Show("Không còn ô đỗ trống phù hợp cho loại xe này!", "Hết chỗ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? cardCode = string.IsNullOrWhiteSpace(txtQrCardIn.Text) ? null : txtQrCardIn.Text.Trim();
            string vehType = cboVehicleTypeIn.SelectedItem?.ToString() ?? "Xe máy xăng";
            bool isCharging = chkChargingIn.Checked;

            if (!string.IsNullOrEmpty(cardCode))
            {
                using var connCheck = DatabaseHelper.GetConnection();
                using var cmdCheck = connCheck.CreateCommand();
                cmdCheck.CommandText = @"
                    SELECT v.PlateNumber, r.FullName 
                    FROM MonthlyCards m 
                    JOIN Vehicles v ON m.VehicleID = v.VehicleID 
                    JOIN Residents r ON v.ResidentID = r.ResidentID
                    WHERE m.CardCode = @Card;
                ";
                cmdCheck.Parameters.AddWithValue("@Card", cardCode);
                using var readerCheck = cmdCheck.ExecuteReader();
                if (readerCheck.Read())
                {
                    string regPlate = readerCheck["PlateNumber"].ToString()!;
                    string residentName = readerCheck["FullName"].ToString()!;
                    if (!regPlate.Equals(plate, StringComparison.OrdinalIgnoreCase))
                    {
                        var dlg = new frmPlateWarning(regPlate, plate, residentName);
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (!dlg.ChoiceAllowPass)
                            {
                                cardCode = null;
                            }
                        }
                        else return;
                    }
                }
            }

            int newStatus = isCharging ? 3 : 1;
            string nowStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string inImageB64 = CameraService.BitmapToBase64(currentInSnapshot);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using var trans = conn.BeginTransaction();
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = trans;

                    cmd.CommandText = @"
                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, CheckInImageBase64, IsCharging, Status, StaffInID, Notes)
                        VALUES (@Card, @Plate, @Type, @SlotID, @TimeIn, @Img, @Charging, 0, @StaffID, @Notes);
                        SELECT SCOPE_IDENTITY();
                    ";
                    cmd.Parameters.AddWithValue("@Card", cardCode == null ? DBNull.Value : (object)cardCode);
                    cmd.Parameters.AddWithValue("@Plate", plate);
                    cmd.Parameters.AddWithValue("@Type", vehType);
                    cmd.Parameters.AddWithValue("@SlotID", selectedSlotItem.Value);
                    cmd.Parameters.AddWithValue("@TimeIn", nowStr);
                    cmd.Parameters.AddWithValue("@Img", inImageB64);
                    cmd.Parameters.AddWithValue("@Charging", isCharging ? 1 : 0);
                    cmd.Parameters.AddWithValue("@StaffID", currentUser.UserID);
                    cmd.Parameters.AddWithValue("@Notes", cardCode == null ? "Vé lượt vào bãi" : "Vé tháng vào bãi");
                    long sessionId = Convert.ToInt64(cmd.ExecuteScalar());

                    cmd.CommandText = @"
                        UPDATE ParkingSlots 
                        SET Status = @Status, CurrentPlate = @Plate, OccupiedSince = @TimeIn 
                        WHERE SlotID = @SlotID;
                    ";
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }

                EventAggregator.PublishSlotStatusChanged(selectedSlotItem.Value, newStatus, plate + (isCharging ? " ⚡" : ""));

                SetLedStatus($"MỜI XE {plate} VÀO VỊ TRÍ [{selectedSlotItem.Text}] - BARIE ĐANG MỞ", UITheme.Success, Color.White);
                MessageBox.Show($"ĐÃ CHO XE VÀO BÃI THÀNH CÔNG!\n\nBiển số: {plate}\nVị trí đỗ: {selectedSlotItem.Text}\nThời gian vào: {nowStr}", "Check-in Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPlateIn.Clear();
                txtQrCardIn.Clear();
                chkChargingIn.Checked = false;
                RefreshSuggestedSlots();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu lượt xe vào: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFindSessionOut_Click(object? sender, EventArgs e)
        {
            string query = txtSearchOut.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Vui lòng nhập biển số xe hoặc mã thẻ cần cho ra!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT TOP 1 p.SessionID, p.CardCode, p.PlateNumber, p.VehicleType, p.SlotID, s.SlotCode, p.CheckInTime, p.CheckInImageBase64, p.IsCharging
                    FROM ParkingSessions p
                    LEFT JOIN ParkingSlots s ON p.SlotID = s.SlotID
                    WHERE (p.PlateNumber = @Q OR p.CardCode = @Q) AND p.Status = 0
                    ORDER BY p.SessionID DESC;
                ";
                cmd.Parameters.AddWithValue("@Q", query);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentOutSession = new ParkingSession
                    {
                        SessionID = reader.GetInt32(0),
                        CardCode = reader["CardCode"] == DBNull.Value ? null : reader["CardCode"].ToString(),
                        PlateNumber = reader["PlateNumber"].ToString()!,
                        VehicleType = reader["VehicleType"].ToString()!,
                        SlotID = Convert.ToInt32(reader["SlotID"]),
                        SlotCode = reader["SlotCode"]?.ToString() ?? "N/A",
                        CheckInTime = DateTime.Parse(reader["CheckInTime"].ToString()!),
                        CheckInImageBase64 = reader["CheckInImageBase64"]?.ToString(),
                        IsCharging = Convert.ToInt32(reader["IsCharging"]) == 1
                    };

                    picInCompare.Image?.Dispose();
                    if (!string.IsNullOrEmpty(currentOutSession.CheckInImageBase64))
                        picInCompare.Image = CameraService.Base64ToBitmap(currentOutSession.CheckInImageBase64);
                    else
                        picInCompare.Image = CameraService.CaptureCameraFrame(currentOutSession.PlateNumber, "Ảnh Lúc Vào");

                    picCamOut.Image?.Dispose();
                    currentOutSnapshot = CameraService.CaptureCameraFrame(currentOutSession.PlateNumber, "Làn Ra");
                    picCamOut.Image = (Bitmap)currentOutSnapshot.Clone();

                    DateTime now = DateTime.Now;
                    TimeSpan duration = now - currentOutSession.CheckInTime;
                    lblDurationOut.Text = $"Vào: {currentOutSession.CheckInTime:dd/MM HH:mm} -> Ra: {now:dd/MM HH:mm} (Lưu bãi: {(int)duration.TotalHours}h {duration.Minutes}p)";

                    if (!string.IsNullOrEmpty(currentOutSession.CardCode))
                    {
                        currentOutTotal = currentOutSession.IsCharging ? 5000 : 0;
                        currentOutDetail = "Vé tháng cư dân/sinh viên hợp lệ" + (currentOutSession.IsCharging ? " + Phụ phí sạc điện (5.000đ)" : "");
                        lblCalcDetailOut.Text = currentOutDetail;
                        lblBigAmount.Text = $"{currentOutTotal:N0} VNĐ";
                        SetLedStatus($"MỜI XE QUA - VÉ THÁNG HỢP LỆ ({currentOutSession.PlateNumber})", UITheme.Success, Color.White);
                    }
                    else
                    {
                        var calc = PricingCalculator.CalculateCasualFee(currentOutSession.VehicleType, currentOutSession.CheckInTime, now, currentOutSession.IsCharging);
                        currentOutTotal = calc.totalAmount;
                        currentOutDetail = calc.calculationDetail;
                        lblCalcDetailOut.Text = currentOutDetail;
                        lblBigAmount.Text = $"{currentOutTotal:N0} VNĐ";

                        if (calc.isShipperFree)
                        {
                            SetLedStatus($"MIỄN PHÍ SHIPPER (< 15 PHÚT) - XE {currentOutSession.PlateNumber}", UITheme.Warning, Color.White);
                        }
                        else
                        {
                            SetLedStatus($"THU PHÍ XE {currentOutSession.PlateNumber}: {currentOutTotal:N0} VNĐ", UITheme.Primary, Color.White);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy xe '{query}' đang đỗ trong bãi!\nVui lòng kiểm tra lại biển số hoặc chọn 'Mất Vé' để tra cứu sâu hơn.", "Không tìm thấy xe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu xe ra: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCheckOut_Click(object? sender, EventArgs e)
        {
            if (currentOutSession == null)
            {
                MessageBox.Show("Vui lòng quét hoặc tìm xe ra trước khi xác nhận thu phí!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime now = DateTime.Now;
            string outImageB64 = CameraService.BitmapToBase64(currentOutSnapshot);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    using var trans = conn.BeginTransaction();
                    using var cmd = conn.CreateCommand();
                    cmd.Transaction = trans;

                    cmd.CommandText = @"
                        UPDATE ParkingSessions 
                        SET CheckOutTime = @TimeOut, CheckOutImageBase64 = @ImgOut, TotalAmount = @Total, Status = 1, StaffOutID = @StaffID, Notes = @Notes
                        WHERE SessionID = @SessionID;
                    ";
                    cmd.Parameters.AddWithValue("@TimeOut", now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@ImgOut", outImageB64);
                    cmd.Parameters.AddWithValue("@Total", currentOutTotal);
                    cmd.Parameters.AddWithValue("@StaffID", currentUser.UserID);
                    cmd.Parameters.AddWithValue("@Notes", currentOutDetail);
                    cmd.Parameters.AddWithValue("@SessionID", currentOutSession.SessionID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "SELECT AssignedRoomID FROM ParkingSlots WHERE SlotID = @SlotID;";
                    cmd.Parameters.AddWithValue("@SlotID", currentOutSession.SlotID);
                    object? assignedRoom = cmd.ExecuteScalar();
                    int restoredStatus = (assignedRoom != null && assignedRoom != DBNull.Value) ? 2 : 0;

                    cmd.CommandText = @"
                        UPDATE ParkingSlots 
                        SET Status = @Status, CurrentPlate = NULL, OccupiedSince = NULL 
                        WHERE SlotID = @SlotID;
                    ";
                    cmd.Parameters.AddWithValue("@Status", restoredStatus);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }

                EventAggregator.PublishSlotStatusChanged(currentOutSession.SlotID, 0, null);

                currentOutSession.CheckOutTime = now;
                currentOutSession.TotalAmount = currentOutTotal;

                SetLedStatus($"XE {currentOutSession.PlateNumber} ĐÃ RA AN TOÀN - BARIE ĐANG ĐÓNG", UITheme.Success, Color.White);

                var receiptDlg = new frmQuickReceipt(currentOutSession, currentOutDetail);
                receiptDlg.ShowDialog();

                currentOutSession = null;
                picInCompare.Image = null;
                picCamOut.Image = null;
                lblDurationOut.Text = "Thời gian lưu bãi: Đã hoàn tất xe ra";
                lblCalcDetailOut.Text = "Công thức tính phí: Đã thanh toán";
                lblBigAmount.Text = "0 VNĐ";
                txtSearchOut.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán xe ra: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLostTicket_Click(object? sender, EventArgs e)
        {
            var dlg = new frmLostTicket(currentUser, txtSearchOut.Text.Trim());
            dlg.ShowDialog();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString() => Text;
    }
}
