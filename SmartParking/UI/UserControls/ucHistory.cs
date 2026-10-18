using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.Services;
using SmartParking.UI.Common;

namespace SmartParking.UI.UserControls
{
    public partial class ucHistory : UserControl
    {
        private User currentUser;

        public ucHistory() : this(new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin", IsActive = true })
        {
        }

        public ucHistory(User user)
        {
            currentUser = user ?? new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin", IsActive = true };
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadHistory();
        }

        private void SetupEvents()
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today.AddDays(1);
            if (cboStatus.SelectedIndex < 0) cboStatus.SelectedIndex = 0;

            ModernGridHelper.ApplyModernStyle(dgvHistory);
            dgvHistory.SelectionChanged += DgvHistory_SelectionChanged;

            btnFilter.Click += (s, e) => LoadHistory();
            btnExportExcel.Click += BtnExportExcel_Click;
        }

        private void LoadHistory()
        {
            string plate = txtPlate.Text.Trim();
            int statusIndex = cboStatus.SelectedIndex;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();

                string query = @"
                    SELECT 
                        p.SessionID AS [ID],
                        p.PlateNumber AS [Biển Số Xe],
                        p.VehicleType AS [Loại Xe],
                        s.SlotCode AS [Mã Ô Đỗ],
                        p.CheckInTime AS [Giờ Vào],
                        p.CheckOutTime AS [Giờ Ra],
                        CASE WHEN p.IsCharging = 1 THEN N'Có sạc ⚡' ELSE N'Không' END AS [Sạc Điện],
                        p.TotalAmount AS [Tổng Tiền (VNĐ)],
                        CASE 
                            WHEN p.Status = 0 THEN N'Đang trong bãi'
                            WHEN p.Status = 1 THEN N'Đã ra an toàn'
                            WHEN p.Status = 2 THEN N'Mất vé / Sự cố'
                            ELSE N'Khác' 
                        END AS [Trạng Thái],
                        p.Notes AS [Ghi Chú],
                        p.CheckInImageBase64,
                        p.CheckOutImageBase64
                    FROM ParkingSessions p
                    LEFT JOIN ParkingSlots s ON p.SlotID = s.SlotID
                    WHERE (p.PlateNumber LIKE @Plate OR @Plate = '')
                      AND p.CheckInTime >= @From AND p.CheckInTime <= @To
                ";

                if (statusIndex == 1) query += " AND p.Status = 0 ";
                else if (statusIndex == 2) query += " AND p.Status = 1 ";
                else if (statusIndex == 3) query += " AND p.Status = 2 ";

                query += " ORDER BY p.SessionID DESC;";

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Plate", $"%{plate}%");
                cmd.Parameters.AddWithValue("@From", dtpFrom.Value.Date.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@To", dtpTo.Value.Date.ToString("yyyy-MM-dd 23:59:59"));

                var dt = cmd.ExecuteDataTable();
                dgvHistory.DataSource = dt;

                if (dgvHistory.Columns.Contains("CheckInImageBase64")) dgvHistory.Columns["CheckInImageBase64"].Visible = false;
                if (dgvHistory.Columns.Contains("CheckOutImageBase64")) dgvHistory.Columns["CheckOutImageBase64"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử xe: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvHistory_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0) return;
            var row = dgvHistory.SelectedRows[0];

            string? inB64 = row.Cells["CheckInImageBase64"]?.Value?.ToString();
            string? outB64 = row.Cells["CheckOutImageBase64"]?.Value?.ToString();
            string plate = row.Cells["Biển Số Xe"].Value.ToString()!;
            string timeIn = row.Cells["Giờ Vào"].Value.ToString()!;
            string? timeOut = row.Cells["Giờ Ra"]?.Value?.ToString();

            lblImageInfo.Text = $"HÌNH ẢNH ĐỐI SOÁT XE {plate} (Vào: {timeIn} | Ra: {(string.IsNullOrEmpty(timeOut) ? "Đang trong bãi" : timeOut)}):";

            picIn.Image?.Dispose();
            if (!string.IsNullOrEmpty(inB64)) picIn.Image = CameraService.Base64ToBitmap(inB64);
            else picIn.Image = CameraService.CaptureCameraFrame(plate, "Lúc Vào");

            picOut.Image?.Dispose();
            if (!string.IsNullOrEmpty(outB64)) picOut.Image = CameraService.Base64ToBitmap(outB64);
            else if (!string.IsNullOrEmpty(timeOut)) picOut.Image = CameraService.CaptureCameraFrame(plate, "Lúc Ra");
            else picOut.Image = null;
        }

        private void BtnExportExcel_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"BaoCao_SmartParking_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = ExcelExportService.ExportMultiSheetAccountingReport(currentUser.FullName, sfd.FileName);
                    var res = MessageBox.Show($"XUẤT BÁO CÁO EXCEL THÀNH CÔNG!\n\nFile đã lưu tại: {path}\nBạn có muốn mở file ngay bây giờ không?", "Hoàn tất xuất Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
