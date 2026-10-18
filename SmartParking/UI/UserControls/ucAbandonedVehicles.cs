using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;

namespace SmartParking.UI.UserControls
{
    public partial class ucAbandonedVehicles : UserControl
    {
        private Action<string>? onLocateSlotRequested;

        public ucAbandonedVehicles() : this(null)
        {
        }

        public ucAbandonedVehicles(Action<string>? locateSlotCallback)
        {
            onLocateSlotRequested = locateSlotCallback;
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadAbandonedVehicles();
        }

        private void SetupEvents()
        {
            ModernGridHelper.ApplyModernStyle(dgvAbandoned);
            dgvAbandoned.RowPrePaint += DgvAbandoned_RowPrePaint;
            btnRefresh.Click += (s, e) => LoadAbandonedVehicles();
            btnLocateSlot.Click += BtnLocateSlot_Click;
        }

        public void LoadAbandonedVehicles()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT 
                        p.SessionID AS [ID],
                        p.PlateNumber AS [Biển Số Xe],
                        p.VehicleType AS [Loại Xe],
                        s.SlotCode AS [Mã Ô Đỗ],
                        s.Zone AS [Khu Vực],
                        p.CheckInTime AS [Giờ Vào],
                        DATEDIFF(HOUR, p.CheckInTime, GETDATE()) AS [Số Giờ Lưu Bãi],
                        DATEDIFF(DAY, p.CheckInTime, GETDATE()) AS [Số Ngày Lưu Bãi],
                        (DATEDIFF(DAY, p.CheckInTime, GETDATE()) * 10000) AS [Tiền Lưu Bãi Tạm Tính (VNĐ)],
                        p.Notes AS [Ghi Chú]
                    FROM ParkingSessions p
                    JOIN ParkingSlots s ON p.SlotID = s.SlotID
                    WHERE p.Status = 0 
                      AND (p.CardCode IS NULL OR p.CardCode = '')
                      AND DATEDIFF(HOUR, p.CheckInTime, GETDATE()) >= 72
                    ORDER BY [Số Giờ Lưu Bãi] DESC;
                ";

                var dt = cmd.ExecuteDataTable();
                dgvAbandoned.DataSource = dt;

                int count = dt.Rows.Count;
                lblSummary.Text = $"⚠️ PHÁT HIỆN {count} XE VÉ LƯỢT LƯU BÃI QUÁ HẠN (> 72 GIỜ). BẢO VỆ CẦN XUỐNG KIỂM TRA TRỰC TIẾP TẠI CÁC Ô ĐỖ!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách xe quá hạn: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvAbandoned_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvAbandoned.Rows.Count) return;
            var row = dgvAbandoned.Rows[e.RowIndex];
            int hours = Convert.ToInt32(row.Cells["Số Giờ Lưu Bãi"].Value);

            if (hours >= 168) // >= 7 days
            {
                row.DefaultCellStyle.BackColor = UITheme.DangerLight;
                row.DefaultCellStyle.ForeColor = UITheme.DangerText;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
            }
            else // 3 - 7 days
            {
                row.DefaultCellStyle.BackColor = UITheme.WarningLight;
                row.DefaultCellStyle.ForeColor = UITheme.WarningText;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 9.25f, FontStyle.Bold);
            }
        }

        private void BtnLocateSlot_Click(object? sender, EventArgs e)
        {
            if (dgvAbandoned.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn xe trong danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string slotCode = dgvAbandoned.SelectedRows[0].Cells["Mã Ô Đỗ"].Value.ToString()!;
            string plate = dgvAbandoned.SelectedRows[0].Cells["Biển Số Xe"].Value.ToString()!;

            onLocateSlotRequested?.Invoke(slotCode);
            MessageBox.Show($"Đã gửi yêu cầu định vị ô đỗ {slotCode} của xe {plate} sang Sơ đồ bãi xe để nhấp nháy tìm kiếm!", "Định vị ô đỗ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
