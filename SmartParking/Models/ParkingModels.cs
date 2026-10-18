using System;

namespace SmartParking.Models
{
    public class MonthlyCard
    {
        public int CardID { get; set; }
        public string CardCode { get; set; } = string.Empty; // QR string: e.g. "CARD-B302-29B155566"
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = "Xe máy xăng";
        public string OwnerName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int RoomID { get; set; }
        public int VehicleOrderInRoom { get; set; } = 1; // 1, 2 = standard price, 3 = +50%, 4+ = blocked
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddMonths(1);
        public string PricingPlan { get; set; } = "1 tháng"; // "1 tháng", "3 tháng", "Học kỳ 5 tháng", "12 tháng"
        public decimal MonthlyFee { get; set; } = 80000;
        public decimal TotalPaid { get; set; } = 80000;
        public string Status { get; set; } = "Hoạt động"; // "Hoạt động", "Sắp hết hạn", "Hết hạn", "Bị khóa"
        public int? AssignedSlotID { get; set; } // Fixed slot for Resident Cars (e.g., B1-02)
    }

    public class ParkingSlot
    {
        public int SlotID { get; set; }
        public string SlotCode { get; set; } = string.Empty; // "A-01", "B-05", "B1-02"
        public string Zone { get; set; } = "A"; // "A" (Xe máy), "B" (Xe đạp & xe điện sạc), "B1" (Ô tô)
        public string SlotType { get; set; } = "Xe máy"; // "Xe máy", "Trạm sạc điện", "Ô tô"
        // 0: Trống (Green #2ECC71)
        // 1: Đang có xe (Red #E74C3C)
        // 2: Cố định vắng (Orange #F39C12)
        // 3: Đang sạc điện (Blue #3498DB)
        // 4: Bảo trì (Gray #95A5A6)
        public int Status { get; set; } = 0;
        public int? AssignedRoomID { get; set; }
        public string? CurrentPlate { get; set; }
        public DateTime? OccupiedSince { get; set; }
    }

    public class ParkingSession
    {
        public int SessionID { get; set; }
        public string? CardCode { get; set; } // Null if casual ticket
        public string PlateNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = "Xe máy xăng";
        public int SlotID { get; set; }
        public string SlotCode { get; set; } = string.Empty;
        public DateTime CheckInTime { get; set; } = DateTime.Now;
        public string? CheckInImageBase64 { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? CheckOutImageBase64 { get; set; }
        public bool IsCharging { get; set; } = false;
        public decimal TotalAmount { get; set; } = 0;
        public int StaffInID { get; set; }
        public int? StaffOutID { get; set; }
        // 0: Đang đỗ trong bãi
        // 1: Đã ra an toàn
        // 2: Mất vé đã lập biên bản
        public int Status { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
    }
}
