using System;
using System.IO;
using ClosedXML.Excel;
using System.Data.SqlClient;
using SmartParking.Data;

namespace SmartParking.Services
{
    public static class ExcelExportService
    {
        public static string ExportMultiSheetAccountingReport(string staffName, string filePath)
        {
            using var workbook = new XLWorkbook();

            // ==========================================
            // SHEET 1: DOANH THU VÉ LƯỢT
            // ==========================================
            var ws1 = workbook.Worksheets.Add("Doanh Thu Vé Lượt");

            // Header Banner
            ws1.Cell("A1").Value = "BAN QUẢN LÝ TÒA NHÀ & KÝ TÚC XÁ - HỆ THỐNG SMARTPARKING";
            ws1.Cell("A1").Style.Font.Bold = true;
            ws1.Cell("A1").Style.Font.FontSize = 14;
            ws1.Cell("A1").Style.Font.FontColor = XLColor.FromArgb(41, 128, 185);

            ws1.Cell("A2").Value = $"BÁO CÁO CHI TIẾT DOANH THU VÉ LƯỢT (Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm} - Người lập: {staffName})";
            ws1.Cell("A2").Style.Font.Italic = true;

            // Table Header
            string[] headers1 = { "Mã GD", "Biển số", "Loại xe", "Vị trí ô", "Giờ vào", "Giờ ra", "Sạc điện ⚡", "Thành tiền (VNĐ)", "Trạng thái", "Ghi chú" };
            for (int c = 0; c < headers1.Length; c++)
            {
                var cell = ws1.Cell(4, c + 1);
                cell.Value = headers1[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(46, 204, 113);
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row1 = 5;
            using (var conn = DatabaseHelper.GetConnection())
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT p.SessionID, p.PlateNumber, p.VehicleType, s.SlotCode, p.CheckInTime, p.CheckOutTime, p.IsCharging, p.TotalAmount, p.Status, p.Notes
                    FROM ParkingSessions p
                    LEFT JOIN ParkingSlots s ON p.SlotID = s.SlotID
                    WHERE p.CardCode IS NULL OR p.CardCode = ''
                    ORDER BY p.SessionID DESC;
                ";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ws1.Cell(row1, 1).Value = reader.GetInt32(0);
                    ws1.Cell(row1, 2).Value = reader["PlateNumber"].ToString();
                    ws1.Cell(row1, 3).Value = reader["VehicleType"].ToString();
                    ws1.Cell(row1, 4).Value = reader["SlotCode"]?.ToString() ?? "N/A";
                    ws1.Cell(row1, 5).Value = reader["CheckInTime"].ToString();
                    ws1.Cell(row1, 6).Value = reader["CheckOutTime"]?.ToString() ?? "Đang đỗ trong bãi";
                    ws1.Cell(row1, 7).Value = Convert.ToInt32(reader["IsCharging"]) == 1 ? "Có sạc" : "Không";
                    ws1.Cell(row1, 8).Value = Convert.ToDouble(reader["TotalAmount"]);
                    ws1.Cell(row1, 8).Style.NumberFormat.Format = "#,##0";

                    int status = Convert.ToInt32(reader["Status"]);
                    string stStr = status == 0 ? "Đang đỗ" : (status == 1 ? "Đã ra an toàn" : "Mất vé");
                    ws1.Cell(row1, 9).Value = stStr;
                    ws1.Cell(row1, 10).Value = reader["Notes"]?.ToString() ?? "";

                    row1++;
                }
            }

            // Total SUM formula
            ws1.Cell(row1, 7).Value = "TỔNG CỘNG:";
            ws1.Cell(row1, 7).Style.Font.Bold = true;
            ws1.Cell(row1, 8).FormulaA1 = $"SUM(H5:H{row1 - 1})";
            ws1.Cell(row1, 8).Style.Font.Bold = true;
            ws1.Cell(row1, 8).Style.NumberFormat.Format = "#,##0 VNĐ";
            ws1.Cell(row1, 8).Style.Fill.BackgroundColor = XLColor.FromArgb(241, 196, 15);

            ws1.Columns().AdjustToContents();

            // ==========================================
            // SHEET 2: DOANH THU THẺ THÁNG
            // ==========================================
            var ws2 = workbook.Worksheets.Add("Doanh Thu Vé Tháng");

            ws2.Cell("A1").Value = "DANH SÁCH THU TIỀN ĐĂNG KÝ & GIA HẠN THẺ THÁNG CƯ DÂN / KTX";
            ws2.Cell("A1").Style.Font.Bold = true;
            ws2.Cell("A1").Style.Font.FontSize = 14;
            ws2.Cell("A1").Style.Font.FontColor = XLColor.FromArgb(142, 68, 173);

            string[] headers2 = { "Mã Thẻ QR", "Họ Tên", "Phòng/Căn Hộ", "Biển Số", "Loại Xe", "Gói Cước", "Ngày Cấp", "Hạn Sử Dụng", "Định Mức", "Số Tiền Thu (VNĐ)", "Trạng Thái" };
            for (int c = 0; c < headers2.Length; c++)
            {
                var cell = ws2.Cell(3, c + 1);
                cell.Value = headers2[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(155, 89, 182);
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row2 = 4;
            using (var conn = DatabaseHelper.GetConnection())
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT m.CardCode, r.FullName, rm.RoomNumber, v.PlateNumber, v.VehicleType, m.PricingPlan, m.IssueDate, m.ExpireDate, m.VehicleOrderInRoom, m.TotalPaid, m.Status
                    FROM MonthlyCards m
                    JOIN Vehicles v ON m.VehicleID = v.VehicleID
                    JOIN Residents r ON v.ResidentID = r.ResidentID
                    JOIN Rooms rm ON r.RoomID = rm.RoomID
                    ORDER BY m.CardID DESC;
                ";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ws2.Cell(row2, 1).Value = reader["CardCode"].ToString();
                    ws2.Cell(row2, 2).Value = reader["FullName"].ToString();
                    ws2.Cell(row2, 3).Value = reader["RoomNumber"].ToString();
                    ws2.Cell(row2, 4).Value = reader["PlateNumber"].ToString();
                    ws2.Cell(row2, 5).Value = reader["VehicleType"].ToString();
                    ws2.Cell(row2, 6).Value = reader["PricingPlan"].ToString();
                    ws2.Cell(row2, 7).Value = reader["IssueDate"].ToString();
                    ws2.Cell(row2, 8).Value = reader["ExpireDate"].ToString();
                    ws2.Cell(row2, 9).Value = $"Xe #{reader["VehicleOrderInRoom"]}";
                    ws2.Cell(row2, 10).Value = Convert.ToDouble(reader["TotalPaid"]);
                    ws2.Cell(row2, 10).Style.NumberFormat.Format = "#,##0";
                    ws2.Cell(row2, 11).Value = reader["Status"].ToString();
                    row2++;
                }
            }

            ws2.Cell(row2, 9).Value = "TỔNG THU VÉ THÁNG:";
            ws2.Cell(row2, 9).Style.Font.Bold = true;
            ws2.Cell(row2, 10).FormulaA1 = $"SUM(J4:J{row2 - 1})";
            ws2.Cell(row2, 10).Style.Font.Bold = true;
            ws2.Cell(row2, 10).Style.NumberFormat.Format = "#,##0 VNĐ";
            ws2.Cell(row2, 10).Style.Fill.BackgroundColor = XLColor.FromArgb(241, 196, 15);

            ws2.Columns().AdjustToContents();

            // ==========================================
            // SHEET 3: BIÊN BẢN MẤT VÉ & SỰ CỐ
            // ==========================================
            var ws3 = workbook.Worksheets.Add("Sự Cố & Mất Vé");

            ws3.Cell("A1").Value = "DANH SÁCH BIÊN BẢN XỬ LÝ MẤT VÉ XE VÀ SỰ CỐ LƯU BÃI";
            ws3.Cell("A1").Style.Font.Bold = true;
            ws3.Cell("A1").Style.Font.FontSize = 14;
            ws3.Cell("A1").Style.Font.FontColor = XLColor.FromArgb(192, 57, 43);

            string[] headers3 = { "Mã BB", "Mã Phiên", "Biển Số", "Người Nhận Xe", "CCCD / MSSV", "Số Điện Thoại", "Tiền Giờ (VNĐ)", "Tiền Phạt (VNĐ)", "Tổng Thu (VNĐ)", "Thời Gian Lập", "Bảo Vệ Xử Lý", "Ghi Chú" };
            for (int c = 0; c < headers3.Length; c++)
            {
                var cell = ws3.Cell(3, c + 1);
                cell.Value = headers3[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(231, 76, 60);
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int row3 = 4;
            using (var conn = DatabaseHelper.GetConnection())
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM IncidentReports ORDER BY IncidentID DESC;";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ws3.Cell(row3, 1).Value = reader.GetInt32(0);
                    ws3.Cell(row3, 2).Value = Convert.ToInt32(reader["SessionID"]);
                    ws3.Cell(row3, 3).Value = reader["PlateNumber"].ToString();
                    ws3.Cell(row3, 4).Value = reader["FinderName"].ToString();
                    ws3.Cell(row3, 5).Value = reader["IdentityCard"].ToString();
                    ws3.Cell(row3, 6).Value = reader["Phone"].ToString();
                    ws3.Cell(row3, 7).Value = Convert.ToDouble(reader["ParkingFee"]);
                    ws3.Cell(row3, 7).Style.NumberFormat.Format = "#,##0";
                    ws3.Cell(row3, 8).Value = Convert.ToDouble(reader["PenaltyAmount"]);
                    ws3.Cell(row3, 8).Style.NumberFormat.Format = "#,##0";
                    ws3.Cell(row3, 9).Value = Convert.ToDouble(reader["TotalPaid"]);
                    ws3.Cell(row3, 9).Style.NumberFormat.Format = "#,##0";
                    ws3.Cell(row3, 10).Value = reader["CreatedDate"].ToString();
                    ws3.Cell(row3, 11).Value = reader["CreatedByStaff"].ToString();
                    ws3.Cell(row3, 12).Value = reader["Notes"]?.ToString() ?? "";
                    row3++;
                }
            }

            if (row3 > 4)
            {
                ws3.Cell(row3, 8).Value = "TỔNG TIỀN PHẠT THU ĐƯỢC:";
                ws3.Cell(row3, 8).Style.Font.Bold = true;
                ws3.Cell(row3, 9).FormulaA1 = $"SUM(I4:I{row3 - 1})";
                ws3.Cell(row3, 9).Style.Font.Bold = true;
                ws3.Cell(row3, 9).Style.NumberFormat.Format = "#,##0 VNĐ";
                ws3.Cell(row3, 9).Style.Fill.BackgroundColor = XLColor.FromArgb(241, 196, 15);
            }

            ws3.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
            return filePath;
        }
    }
}
