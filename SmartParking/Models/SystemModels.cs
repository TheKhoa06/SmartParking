using System;

namespace SmartParking.Models
{
    public class PricingRule
    {
        public int RuleID { get; set; } = 1;
        public decimal BicycleDay { get; set; } = 1000;
        public decimal BicycleNight { get; set; } = 2000;
        public decimal BicycleOvernight { get; set; } = 3000;

        public decimal MotorDay { get; set; } = 3000;
        public decimal MotorNight { get; set; } = 5000;
        public decimal MotorOvernight { get; set; } = 10000;

        public decimal CarFirst2Hours { get; set; } = 20000;
        public decimal CarNextHour { get; set; } = 10000;
        public decimal CarOvernight { get; set; } = 50000;

        public decimal ElectricSurcharge { get; set; } = 5000; // Sạc xe điện phụ phí
        public int FreeGraceMinutes { get; set; } = 15; // Miễn phí 15p cho shipper/phụ huynh
        public decimal LostTicketPenalty { get; set; } = 30000; // Tiền phạt mất vé
        public decimal StandardMonthlyFee { get; set; } = 80000; // Giá chuẩn xe máy
        public decimal OverQuotaMultiplier { get; set; } = 1.5m; // Xe thứ 3 +50%
        public decimal CardReplacementFee { get; set; } = 20000; // Phí cấp lại thẻ
    }

    public class IncidentReport
    {
        public int IncidentID { get; set; }
        public int SessionID { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string FinderName { get; set; } = string.Empty;
        public string IdentityCard { get; set; } = string.Empty; // CCCD / MSSV
        public string Phone { get; set; } = string.Empty;
        public string? FaceImageBase64 { get; set; }
        public decimal ParkingFee { get; set; } = 0;
        public decimal PenaltyAmount { get; set; } = 30000;
        public decimal TotalPaid { get; set; } = 30000;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByStaff { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    public class ShiftHandover
    {
        public int ShiftID { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public int TotalVehiclesIn { get; set; } = 0;
        public int TotalVehiclesOut { get; set; } = 0;
        public decimal TotalCashCollected { get; set; } = 0;
        public string NextStaffName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime HandoverTime { get; set; } = DateTime.Now;
    }
}
