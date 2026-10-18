using System;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;

namespace SmartParking.Services
{
    public static class PricingCalculator
    {
        private static PricingRule? _cachedRule;

        public static PricingRule GetCurrentRules()
        {
            if (_cachedRule != null) return _cachedRule;

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT TOP 1 * FROM PricingRules WHERE RuleID = 1;";
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                _cachedRule = new PricingRule
                {
                    RuleID = reader.GetInt32(0),
                    BicycleDay = Convert.ToDecimal(reader["BicycleDay"]),
                    BicycleNight = Convert.ToDecimal(reader["BicycleNight"]),
                    BicycleOvernight = Convert.ToDecimal(reader["BicycleOvernight"]),
                    MotorDay = Convert.ToDecimal(reader["MotorDay"]),
                    MotorNight = Convert.ToDecimal(reader["MotorNight"]),
                    MotorOvernight = Convert.ToDecimal(reader["MotorOvernight"]),
                    CarFirst2Hours = Convert.ToDecimal(reader["CarFirst2Hours"]),
                    CarNextHour = Convert.ToDecimal(reader["CarNextHour"]),
                    CarOvernight = Convert.ToDecimal(reader["CarOvernight"]),
                    ElectricSurcharge = Convert.ToDecimal(reader["ElectricSurcharge"]),
                    FreeGraceMinutes = Convert.ToInt32(reader["FreeGraceMinutes"]),
                    LostTicketPenalty = Convert.ToDecimal(reader["LostTicketPenalty"]),
                    StandardMonthlyFee = Convert.ToDecimal(reader["StandardMonthlyFee"]),
                    OverQuotaMultiplier = Convert.ToDecimal(reader["OverQuotaMultiplier"]),
                    CardReplacementFee = Convert.ToDecimal(reader["CardReplacementFee"])
                };
            }
            else
            {
                _cachedRule = new PricingRule();
            }

            return _cachedRule;
        }

        public static void ClearCache()
        {
            _cachedRule = null;
        }

        public static (decimal totalAmount, string calculationDetail, bool isShipperFree) CalculateCasualFee(
            string vehicleType,
            DateTime checkInTime,
            DateTime checkOutTime,
            bool isCharging)
        {
            var rule = GetCurrentRules();
            TimeSpan duration = checkOutTime - checkInTime;

            // 1. Shipper / Short Delivery rule: <= FreeGraceMinutes (default 15 minutes) -> Free!
            if (duration.TotalMinutes <= rule.FreeGraceMinutes)
            {
                decimal chargingFee = isCharging ? rule.ElectricSurcharge : 0;
                return (chargingFee, $"Miễn phí giao hàng / Shipper (< {rule.FreeGraceMinutes} phút)" + (isCharging ? $" + Phụ phí sạc điện {chargingFee:N0}đ" : ""), true);
            }

            decimal baseFee = 0;
            string detail = "";

            bool isSameDay = checkInTime.Date == checkOutTime.Date;
            bool isOvernight = !isSameDay || checkInTime.Hour >= 23 || checkOutTime.Hour < 6 || (checkInTime.Hour < 23 && checkOutTime.Hour >= 23);

            if (isOvernight)
            {
                int nights = Math.Max(1, (int)Math.Ceiling(duration.TotalDays));
                if (vehicleType.Contains("đạp"))
                {
                    baseFee = nights * rule.BicycleOvernight;
                    detail = $"{nights} đêm x {rule.BicycleOvernight:N0}đ";
                }
                else if (vehicleType.Contains("Ô tô"))
                {
                    baseFee = nights * rule.CarOvernight;
                    detail = $"{nights} đêm x {rule.CarOvernight:N0}đ";
                }
                else
                {
                    baseFee = nights * rule.MotorOvernight;
                    detail = $"{nights} đêm x {rule.MotorOvernight:N0}đ";
                }
            }
            else
            {
                // Day or Night within same day
                bool isNight = checkInTime.Hour >= 18 || checkOutTime.Hour >= 18;
                if (vehicleType.Contains("đạp"))
                {
                    baseFee = isNight ? rule.BicycleNight : rule.BicycleDay;
                    detail = isNight ? "Khung giờ tối (18h-23h)" : "Khung giờ ngày (06h-18h)";
                }
                else if (vehicleType.Contains("Ô tô"))
                {
                    double totalHours = Math.Ceiling(duration.TotalHours);
                    if (totalHours <= 2)
                    {
                        baseFee = rule.CarFirst2Hours;
                        detail = "Ô tô 2 giờ đầu";
                    }
                    else
                    {
                        baseFee = rule.CarFirst2Hours + (decimal)(totalHours - 2) * rule.CarNextHour;
                        detail = $"Ô tô 2h đầu ({rule.CarFirst2Hours:N0}đ) + {totalHours - 2}h tiếp theo";
                    }
                }
                else // Xe máy xăng hoặc điện
                {
                    baseFee = isNight ? rule.MotorNight : rule.MotorDay;
                    detail = isNight ? "Xe máy khung giờ tối (18h-23h)" : "Xe máy khung giờ ngày (06h-18h)";
                }
            }

            // 2. Electric charging surcharge
            decimal electricFee = 0;
            if (isCharging)
            {
                electricFee = rule.ElectricSurcharge;
                detail += $" + Phụ phí sạc điện ({electricFee:N0}đ)";
            }

            return (baseFee + electricFee, detail, false);
        }

        public static (decimal monthlyFee, decimal totalPaid, string quotaMessage, int order) CalculateMonthlyPlanFee(
            int roomId,
            string pricingPlan,
            string vehicleType)
        {
            var rule = GetCurrentRules();

            // Count existing active monthly cards for this room
            int activeCardsInRoom = 0;
            using (var conn = DatabaseHelper.GetConnection())
            {
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT COUNT(*) 
                    FROM MonthlyCards m
                    JOIN Vehicles v ON m.VehicleID = v.VehicleID
                    JOIN Residents r ON v.ResidentID = r.ResidentID
                    WHERE r.RoomID = @RoomID AND m.Status != 'Bị khóa';
                ";
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                activeCardsInRoom = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
            }

            int vehicleOrder = activeCardsInRoom + 1;
            decimal baseMonthlyRate = rule.StandardMonthlyFee;

            if (vehicleType.Contains("Ô tô"))
                baseMonthlyRate = 1200000; // Car base monthly fee
            else if (vehicleType.Contains("đạp"))
                baseMonthlyRate = 40000;

            string quotaMessage = "";
            if (vehicleOrder <= 2)
            {
                quotaMessage = $"Xe thứ {vehicleOrder} của phòng (Định mức chuẩn ưu đãi cư dân/sinh viên)";
            }
            else if (vehicleOrder == 3)
            {
                baseMonthlyRate *= rule.OverQuotaMultiplier;
                quotaMessage = $"CẢNH BÁO: Xe thứ 3 của phòng (Phụ thu vượt định mức +{(int)((rule.OverQuotaMultiplier - 1) * 100)}%)";
            }
            else
            {
                baseMonthlyRate *= 2.0m;
                quotaMessage = $"CẢNH BÁO NGUY HIỂM: Xe thứ {vehicleOrder} vượt định mức tối đa! (Cần Ban Quản Lý duyệt)";
            }

            // Package discount
            int months = 1;
            decimal discount = 0;
            if (pricingPlan.Contains("3 tháng"))
            {
                months = 3;
                discount = 0.05m; // 5%
            }
            else if (pricingPlan.Contains("5 tháng") || pricingPlan.Contains("học kỳ") || pricingPlan.Contains("Học kỳ"))
            {
                months = 5;
                discount = 0.10m; // 10%
            }
            else if (pricingPlan.Contains("12 tháng") || pricingPlan.Contains("năm"))
            {
                months = 12;
                discount = 0.20m; // 20%
            }

            decimal total = (baseMonthlyRate * months) * (1 - discount);
            return (baseMonthlyRate, total, quotaMessage, vehicleOrder);
        }
    }
}
