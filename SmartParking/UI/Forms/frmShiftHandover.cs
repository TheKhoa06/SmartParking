using System;
using System.Drawing;
using System.Windows.Forms;
using SmartParking.Data;
using SmartParking.Models;

namespace SmartParking.UI.Forms
{
    public partial class frmShiftHandover : Form
    {
        private User currentUser;
        private int inCount = 0;
        private int outCount = 0;
        private decimal totalCash = 0;
        private DateTime shiftStart;

        public frmShiftHandover() : this(new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên (Admin)", Role = "Admin" })
        {
        }

        public frmShiftHandover(User user)
        {
            currentUser = user ?? new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin" };
            shiftStart = DateTime.Today.AddHours(DateTime.Now.Hour < 14 ? 6 : (DateTime.Now.Hour < 22 ? 14 : 22));

            InitializeComponent();

            lblSub.Text = $"Bảo vệ chốt ca: {currentUser.FullName} ({currentUser.Username})";
            lblStartTime.Text = shiftStart.ToString("dd/MM/yyyy HH:mm:ss");
            lblEndTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            btnConfirm.Click += BtnConfirm_Click;

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadShiftStatistics();
        }

        private void LoadShiftStatistics()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM ParkingSessions WHERE CheckInTime >= @Start;";
                cmd.Parameters.AddWithValue("@Start", shiftStart.ToString("yyyy-MM-dd HH:mm:ss"));
                inCount = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                lblInCount.Text = $"{inCount} lượt xe";

                cmd.CommandText = @"
                    SELECT COUNT(*), COALESCE(SUM(TotalAmount), 0) 
                    FROM ParkingSessions 
                    WHERE CheckOutTime >= @Start AND Status = 1;
                ";
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    outCount = Convert.ToInt32(reader[0]);
                    totalCash = Convert.ToDecimal(reader[1]);
                    lblOutCount.Text = $"{outCount} lượt xe";
                    lblCashAmount.Text = $"{totalCash:N0} VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê ca trực: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirm_Click(object? sender, EventArgs e)
        {
            string next = txtNextStaff.Text.Trim();
            if (string.IsNullOrWhiteSpace(next))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên nhận ca trực tiếp theo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO ShiftHandovers (StaffID, StartTime, EndTime, InCount, OutCount, TotalCashCollected, NextStaffID_Name, Notes)
                    VALUES (@Staff, @Start, @End, @In, @Out, @Cash, @Next, @Notes);
                ";
                cmd.Parameters.AddWithValue("@Staff", currentUser.UserID);
                cmd.Parameters.AddWithValue("@Start", shiftStart.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@End", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@In", inCount);
                cmd.Parameters.AddWithValue("@Out", outCount);
                cmd.Parameters.AddWithValue("@Cash", totalCash);
                cmd.Parameters.AddWithValue("@Next", next);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show($"BÀN GIAO CA THÀNH CÔNG!\n\nSố tiền mặt chốt ca: {totalCash:N0} VNĐ\nNgười nhận ca: {next}\nChúc ca làm việc tiếp theo an toàn!", "Hoàn tất giao ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu bàn giao ca: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
