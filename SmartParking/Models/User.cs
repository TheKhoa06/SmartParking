namespace SmartParking.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = "Staff"; // "Admin" or "Staff"
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
