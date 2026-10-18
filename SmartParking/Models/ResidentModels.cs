namespace SmartParking.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = string.Empty; // e.g. "KTX-B302" or "CC-A1208"
        public string BuildingBlock { get; set; } = string.Empty; // "KTX Khu B", "Chung cư Tòa A"
        public int MaxVehicleQuota { get; set; } = 3; // Maximum vehicles allowed before hard block
        public string Notes { get; set; } = string.Empty;
    }

    public class Resident
    {
        public int ResidentID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string StudentID_CCCD { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
    }

    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = "Xe máy xăng"; // "Xe đạp", "Xe máy xăng", "Xe máy điện", "Ô tô"
        public int ResidentID { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public string BrandModel { get; set; } = string.Empty;
    }
}
