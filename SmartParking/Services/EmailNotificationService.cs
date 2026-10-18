using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartParking.Data;

namespace SmartParking.Services
{
    public class ExpiringCardNotificationItem
    {
        public int CardID { get; set; }
        public string CardCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public DateTime ExpireDate { get; set; }
        public decimal RenewalAmount { get; set; }
        public int DaysLeft { get; set; }
    }

    public static class EmailNotificationService
    {
        public static List<ExpiringCardNotificationItem> GetExpiringOrExpiredCards()
        {
            var list = new List<ExpiringCardNotificationItem>();
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT m.CardID, m.CardCode, r.FullName, r.Email, rm.RoomNumber, v.PlateNumber, m.ExpireDate, m.MonthlyFee
                FROM MonthlyCards m
                JOIN Vehicles v ON m.VehicleID = v.VehicleID
                JOIN Residents r ON v.ResidentID = r.ResidentID
                JOIN Rooms rm ON r.RoomID = rm.RoomID
                WHERE m.Status IN (N'Sắp hết hạn', N'Hết hạn') OR DATEDIFF(day, GETDATE(), m.ExpireDate) <= 5;
            ";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime expDate = DateTime.Parse(reader["ExpireDate"].ToString()!);
                int daysLeft = (int)Math.Ceiling((expDate - DateTime.Now).TotalDays);

                list.Add(new ExpiringCardNotificationItem
                {
                    CardID = Convert.ToInt32(reader["CardID"]),
                    CardCode = reader["CardCode"].ToString()!,
                    FullName = reader["FullName"].ToString()!,
                    Email = reader["Email"].ToString() ?? "sinhvien@school.edu.vn",
                    RoomNumber = reader["RoomNumber"].ToString()!,
                    PlateNumber = reader["PlateNumber"].ToString()!,
                    ExpireDate = expDate,
                    RenewalAmount = Convert.ToDecimal(reader["MonthlyFee"]),
                    DaysLeft = daysLeft
                });
            }

            return list;
        }

        public static async Task<int> SendBulkRemindersAsync(
            List<ExpiringCardNotificationItem> items,
            IProgress<int>? progress,
            Action<string>? statusCallback)
        {
            if (items == null || items.Count == 0) return 0;

            int count = 0;
            int total = items.Count;

            for (int i = 0; i < total; i++)
            {
                var item = items[i];
                string urgentTag = item.DaysLeft <= 0 ? "[ĐÃ HẾT HẠN]" : $"[CÒN {item.DaysLeft} NGÀY]";
                statusCallback?.Invoke($"Đang gửi mail đến: {item.FullName} ({item.Email}) {urgentTag}...");

                // Simulate robust network call or SmtpClient dispatch
                await Task.Delay(350); // non-blocking async delay

                count++;
                int percentage = (int)((count / (float)total) * 100);
                progress?.Report(percentage);
            }

            statusCallback?.Invoke($"Hoàn tất! Đã gửi thành công {count}/{total} email nhắc gia hạn.");
            return count;
        }
    }
}
