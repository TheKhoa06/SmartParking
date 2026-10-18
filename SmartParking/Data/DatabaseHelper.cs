using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SmartParking.Data
{
    public static class DatabaseHelper
    {
        private static string? _resolvedConnectionString = null;

        public static string[] CandidateInstances => new[]
        {
            ".",
            @".\SQLEXPRESS",
            "(local)",
            "localhost",
            "127.0.0.1",
            Environment.MachineName,
            $@"{Environment.MachineName}\SQLEXPRESS",
            @"(localdb)\MSSQLLocalDB",
            @"(localdb)\v11.0",
            @"(localdb)\ProjectsV13"
        };

        public static string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_resolvedConnectionString))
                    return _resolvedConnectionString;

                // 1. Kiểm tra cấu hình trong App.config với timeout ngắn (2 giây)
                var setting = ConfigurationManager.ConnectionStrings["SmartParkingDB"];
                string configConn = setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString)
                    ? setting.ConnectionString
                    : @"Data Source=.;Initial Catalog=SmartParkingDB;Integrated Security=True;TrustServerCertificate=True;";

                var builder = new SqlConnectionStringBuilder(configConn) { ConnectTimeout = 2 };
                if (TryConnect(builder.ConnectionString))
                {
                    _resolvedConnectionString = configConn;
                    return _resolvedConnectionString;
                }

                // 2. Tự động dò tìm qua tất cả các instance SQL Server phổ biến trên máy tính
                string? workingInstance = FindWorkingInstance();
                if (!string.IsNullOrEmpty(workingInstance))
                {
                    _resolvedConnectionString = $@"Data Source={workingInstance};Initial Catalog=SmartParkingDB;Integrated Security=True;TrustServerCertificate=True;";
                    SaveConnectionString(_resolvedConnectionString);
                    return _resolvedConnectionString;
                }

                _resolvedConnectionString = configConn;
                return _resolvedConnectionString;
            }
        }

        public static string? FindWorkingInstance()
        {
            foreach (var src in CandidateInstances)
            {
                // Thử kết nối trực tiếp đến SmartParkingDB
                string candidateConn = $@"Data Source={src};Initial Catalog=SmartParkingDB;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
                if (TryConnect(candidateConn))
                {
                    return src;
                }

                // Thử kết nối đến master nếu SmartParkingDB chưa được tạo
                string masterCandidate = $@"Data Source={src};Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;Connect Timeout=2;";
                if (TryConnect(masterCandidate))
                {
                    return src;
                }
            }
            return null;
        }

        public static bool TryConnect(string connString)
        {
            try
            {
                using var conn = new SqlConnection(connString);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SaveConnectionString(string newConnStr)
        {
            _resolvedConnectionString = newConnStr;
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var setting = config.ConnectionStrings.ConnectionStrings["SmartParkingDB"];
                if (setting != null)
                {
                    setting.ConnectionString = newConnStr;
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("SmartParkingDB", newConnStr, "System.Data.SqlClient"));
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch
            {
                // Bỏ qua nếu file config bị khóa quyền ghi (Read-only)
            }
        }

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static DataTable ExecuteDataTable(this SqlCommand cmd)
        {
            var dt = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static void InitializeDatabase(bool showConfigIfFailed = true)
        {
            try
            {
                EnsureDatabaseCreated();

                using (var conn = GetConnection())
                {
                    CreateTables(conn);
                    SeedInitialData(conn);
                }
            }
            catch (Exception ex)
            {
                if (showConfigIfFailed)
                {
                    var cfg = new SmartParking.UI.Forms.frmDbConfig();
                    if (cfg.ShowDialog() == DialogResult.OK)
                    {
                        return; // Đã cấu hình và khởi tạo thành công trong hộp thoại
                    }
                }

                MessageBox.Show(
                    "KHÔNG THỂ KẾT NỐI ĐẾN MICROSOFT SQL SERVER!\n\n" +
                    $"Chi tiết lỗi: {ex.Message}\n\n" +
                    "HƯỚNG DẪN XỬ LÝ:\n" +
                    "1. Bấm vào '⚙️ Cấu hình CSDL' ở màn hình Đăng Nhập để chọn lại Server Name/Xác thực.\n" +
                    "2. Kiểm tra Dịch vụ 'SQL Server' đã được BẬT (Running) trong Services (services.msc).\n" +
                    "3. Có thể mở SQL Server Management Studio (SSMS) và chạy file script 'Data\\SmartParking_SQLServer.sql'.",
                    "Lỗi Kết Nối SQL Server - SmartParking",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private static void EnsureDatabaseCreated()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(ConnectionString);
                string targetDb = builder.InitialCatalog;
                builder.InitialCatalog = "master";

                using (var masterConn = new SqlConnection(builder.ConnectionString))
                {
                    masterConn.Open();
                    using (var cmd = masterConn.CreateCommand())
                    {
                        cmd.CommandText = $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '{targetDb}') CREATE DATABASE [{targetDb}];";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Fall through if master cannot be queried
            }
        }

        private static void CreateTables(SqlConnection conn)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    IF OBJECT_ID('Users', 'U') IS NULL
                    CREATE TABLE Users (
                        UserID INT IDENTITY(1,1) PRIMARY KEY,
                        Username NVARCHAR(50) UNIQUE NOT NULL,
                        Password NVARCHAR(100) NOT NULL,
                        FullName NVARCHAR(100) NOT NULL,
                        Role NVARCHAR(20) NOT NULL DEFAULT 'Staff',
                        Phone NVARCHAR(20),
                        IsActive BIT DEFAULT 1
                    );

                    IF OBJECT_ID('Rooms', 'U') IS NULL
                    CREATE TABLE Rooms (
                        RoomID INT IDENTITY(1,1) PRIMARY KEY,
                        RoomNumber NVARCHAR(50) UNIQUE NOT NULL,
                        BuildingBlock NVARCHAR(100) NOT NULL,
                        MaxVehicleQuota INT DEFAULT 3,
                        Notes NVARCHAR(255)
                    );

                    IF OBJECT_ID('Residents', 'U') IS NULL
                    CREATE TABLE Residents (
                        ResidentID INT IDENTITY(1,1) PRIMARY KEY,
                        FullName NVARCHAR(100) NOT NULL,
                        StudentID_CCCD NVARCHAR(50) NOT NULL,
                        Phone NVARCHAR(20) NOT NULL,
                        Email NVARCHAR(100),
                        RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID)
                    );

                    IF OBJECT_ID('Vehicles', 'U') IS NULL
                    CREATE TABLE Vehicles (
                        VehicleID INT IDENTITY(1,1) PRIMARY KEY,
                        PlateNumber NVARCHAR(50) UNIQUE NOT NULL,
                        VehicleType NVARCHAR(50) NOT NULL,
                        ResidentID INT FOREIGN KEY REFERENCES Residents(ResidentID),
                        BrandModel NVARCHAR(100)
                    );

                    IF OBJECT_ID('MonthlyCards', 'U') IS NULL
                    CREATE TABLE MonthlyCards (
                        CardID INT IDENTITY(1,1) PRIMARY KEY,
                        CardCode NVARCHAR(100) UNIQUE NOT NULL,
                        VehicleID INT FOREIGN KEY REFERENCES Vehicles(VehicleID),
                        VehicleOrderInRoom INT DEFAULT 1,
                        IssueDate DATETIME NOT NULL DEFAULT GETDATE(),
                        ExpireDate DATETIME NOT NULL,
                        PricingPlan NVARCHAR(50) DEFAULT N'1 tháng',
                        MonthlyFee DECIMAL(18,2) DEFAULT 80000,
                        TotalPaid DECIMAL(18,2) DEFAULT 80000,
                        Status NVARCHAR(50) DEFAULT N'Hoạt động',
                        AssignedSlotID INT
                    );

                    IF OBJECT_ID('ParkingSlots', 'U') IS NULL
                    CREATE TABLE ParkingSlots (
                        SlotID INT IDENTITY(1,1) PRIMARY KEY,
                        SlotCode NVARCHAR(20) UNIQUE NOT NULL,
                        Zone NVARCHAR(20) NOT NULL,
                        SlotType NVARCHAR(50) NOT NULL,
                        Status INT DEFAULT 0,
                        AssignedRoomID INT,
                        CurrentPlate NVARCHAR(50),
                        OccupiedSince DATETIME
                    );

                    IF OBJECT_ID('ParkingSessions', 'U') IS NULL
                    CREATE TABLE ParkingSessions (
                        SessionID INT IDENTITY(1,1) PRIMARY KEY,
                        CardCode NVARCHAR(100),
                        PlateNumber NVARCHAR(50) NOT NULL,
                        VehicleType NVARCHAR(50) NOT NULL,
                        SlotID INT FOREIGN KEY REFERENCES ParkingSlots(SlotID),
                        CheckInTime DATETIME NOT NULL DEFAULT GETDATE(),
                        CheckInImageBase64 NVARCHAR(MAX),
                        CheckOutTime DATETIME,
                        CheckOutImageBase64 NVARCHAR(MAX),
                        IsCharging BIT DEFAULT 0,
                        TotalAmount DECIMAL(18,2) DEFAULT 0,
                        StaffInID INT,
                        StaffOutID INT,
                        Status INT DEFAULT 0,
                        Notes NVARCHAR(255)
                    );

                    IF OBJECT_ID('PricingRules', 'U') IS NULL
                    CREATE TABLE PricingRules (
                        RuleID INT PRIMARY KEY,
                        BicycleDay DECIMAL(18,2) DEFAULT 1000,
                        BicycleNight DECIMAL(18,2) DEFAULT 2000,
                        BicycleOvernight DECIMAL(18,2) DEFAULT 3000,
                        MotorDay DECIMAL(18,2) DEFAULT 3000,
                        MotorNight DECIMAL(18,2) DEFAULT 5000,
                        MotorOvernight DECIMAL(18,2) DEFAULT 10000,
                        CarFirst2Hours DECIMAL(18,2) DEFAULT 20000,
                        CarNextHour DECIMAL(18,2) DEFAULT 10000,
                        CarOvernight DECIMAL(18,2) DEFAULT 50000,
                        ElectricSurcharge DECIMAL(18,2) DEFAULT 5000,
                        FreeGraceMinutes INT DEFAULT 15,
                        LostTicketPenalty DECIMAL(18,2) DEFAULT 30000,
                        StandardMonthlyFee DECIMAL(18,2) DEFAULT 80000,
                        OverQuotaMultiplier DECIMAL(4,2) DEFAULT 1.5,
                        CardReplacementFee DECIMAL(18,2) DEFAULT 20000
                    );

                    IF OBJECT_ID('IncidentReports', 'U') IS NULL
                    CREATE TABLE IncidentReports (
                        IncidentID INT IDENTITY(1,1) PRIMARY KEY,
                        SessionID INT FOREIGN KEY REFERENCES ParkingSessions(SessionID),
                        PlateNumber NVARCHAR(50) NOT NULL,
                        FinderName NVARCHAR(100) NOT NULL,
                        IdentityCard NVARCHAR(50) NOT NULL,
                        Phone NVARCHAR(20) NOT NULL,
                        FaceImageBase64 NVARCHAR(MAX),
                        ParkingFee DECIMAL(18,2) DEFAULT 0,
                        PenaltyAmount DECIMAL(18,2) DEFAULT 30000,
                        TotalPaid DECIMAL(18,2) DEFAULT 30000,
                        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
                        CreatedByStaff NVARCHAR(100) NOT NULL,
                        Notes NVARCHAR(255)
                    );

                    IF OBJECT_ID('ShiftHandovers', 'U') IS NULL
                    CREATE TABLE ShiftHandovers (
                        ShiftID INT IDENTITY(1,1) PRIMARY KEY,
                        StaffID INT,
                        StaffName NVARCHAR(100) NOT NULL,
                        StartTime DATETIME NOT NULL,
                        EndTime DATETIME NOT NULL,
                        TotalVehiclesIn INT DEFAULT 0,
                        TotalVehiclesOut INT DEFAULT 0,
                        TotalCashCollected DECIMAL(18,2) DEFAULT 0,
                        NextStaffName NVARCHAR(100),
                        Notes NVARCHAR(255),
                        HandoverTime DATETIME NOT NULL DEFAULT GETDATE()
                    );
                ";
                cmd.ExecuteNonQuery();
            }
        }

        private static void SeedInitialData(SqlConnection conn)
        {
            using (var checkCmd = conn.CreateCommand())
            {
                checkCmd.CommandText = "SELECT COUNT(*) FROM Users;";
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar() ?? 0);
                if (userCount > 0) return; // Already seeded
            }

            using (var trans = conn.BeginTransaction())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;

                    // 1. Users
                    cmd.CommandText = @"
                        INSERT INTO Users (Username, Password, FullName, Role, Phone, IsActive) VALUES
                        ('admin', '123456', N'Huân & Hưng (Ban Quản Lý)', 'Admin', '0901234567', 1),
                        ('khoa', '123456', N'Khoa (Bảo vệ Ca Sáng)', 'Staff', '0912345678', 1),
                        ('vinh', '123456', N'Vinh (Bảo vệ Ca Tối)', 'Staff', '0923456789', 1);
                    ";
                    cmd.ExecuteNonQuery();

                    // 2. PricingRules
                    cmd.CommandText = @"
                        INSERT INTO PricingRules (RuleID, BicycleDay, BicycleNight, BicycleOvernight, MotorDay, MotorNight, MotorOvernight, CarFirst2Hours, CarNextHour, CarOvernight, ElectricSurcharge, FreeGraceMinutes, LostTicketPenalty, StandardMonthlyFee, OverQuotaMultiplier, CardReplacementFee)
                        VALUES (1, 1000, 2000, 3000, 3000, 5000, 10000, 20000, 10000, 50000, 5000, 15, 30000, 80000, 1.5, 20000);
                    ";
                    cmd.ExecuteNonQuery();

                    // 3. Rooms
                    cmd.CommandText = @"
                        INSERT INTO Rooms (RoomNumber, BuildingBlock, MaxVehicleQuota, Notes) VALUES
                        ('KTX-B301', N'Ký túc xá B', 3, N'Phòng 6 sinh viên nam'),
                        ('KTX-B302', N'Ký túc xá B', 3, N'Phòng 4 sinh viên CNTT'),
                        ('KTX-B303', N'Ký túc xá B', 3, N'Phòng 4 sinh viên'),
                        ('CC-A101', N'Chung cư Tháp A', 4, N'Hộ gia đình'),
                        ('CC-A1208', N'Chung cư Tháp A', 4, N'Căn hộ 3 phòng ngủ'),
                        ('CC-B502', N'Chung cư Tháp B', 3, N'Căn hộ 2 phòng ngủ');
                    ";
                    cmd.ExecuteNonQuery();

                    // 4. Residents
                    cmd.CommandText = @"
                        INSERT INTO Residents (FullName, StudentID_CCCD, Phone, Email, RoomID) VALUES
                        (N'Nguyễn Văn Tuấn', 'SV202401', '0988111222', 'tuan.nv@student.edu.vn', 2),
                        (N'Trần Thị Mai', 'SV202402', '0988222333', 'mai.tt@student.edu.vn', 2),
                        (N'Lê Hoàng Long', 'SV202403', '0988333444', 'long.lh@student.edu.vn', 2),
                        (N'Phạm Quốc Hùng', '001201004567', '0977888999', 'hung.pq@gmail.com', 5),
                        (N'Vũ Minh Đức', '001202005678', '0966555444', 'duc.vm@gmail.com', 4);
                    ";
                    cmd.ExecuteNonQuery();

                    // 5. Vehicles
                    cmd.CommandText = @"
                        INSERT INTO Vehicles (PlateNumber, VehicleType, ResidentID, BrandModel) VALUES
                        ('29B1-555.66', N'Xe máy xăng', 1, 'Honda Wave Alpha'),
                        ('29B1-888.99', N'Xe máy xăng', 2, 'Honda Vision'),
                        ('29E1-777.22', N'Xe máy điện', 3, 'VinFast Feliz S'),
                        ('30H-999.88', N'Ô tô', 4, 'Mazda CX-5'),
                        ('30E-123.45', N'Ô tô', 5, 'Toyota Vios');
                    ";
                    cmd.ExecuteNonQuery();

                    // 6. MonthlyCards
                    DateTime now = DateTime.Now;
                    cmd.CommandText = $@"
                        INSERT INTO MonthlyCards (CardCode, VehicleID, VehicleOrderInRoom, IssueDate, ExpireDate, PricingPlan, MonthlyFee, TotalPaid, Status, AssignedSlotID) VALUES
                        ('CARD-B302-01', 1, 1, '{now.AddMonths(-1):yyyy-MM-dd HH:mm:ss}', '{now.AddDays(20):yyyy-MM-dd HH:mm:ss}', N'1 tháng', 80000, 80000, N'Hoạt động', NULL),
                        ('CARD-B302-02', 2, 2, '{now.AddMonths(-2):yyyy-MM-dd HH:mm:ss}', '{now.AddDays(3):yyyy-MM-dd HH:mm:ss}', N'3 tháng', 80000, 228000, N'Sắp hết hạn', NULL),
                        ('CARD-B302-03', 3, 3, '{now.AddMonths(-5):yyyy-MM-dd HH:mm:ss}', '{now.AddDays(-2):yyyy-MM-dd HH:mm:ss}', N'Học kỳ 5 tháng', 120000, 540000, N'Hết hạn', NULL),
                        ('CARD-A1208-01', 4, 1, '{now.AddMonths(-3):yyyy-MM-dd HH:mm:ss}', '{now.AddMonths(9):yyyy-MM-dd HH:mm:ss}', N'12 tháng', 1200000, 11520000, N'Hoạt động', 37);
                    ";
                    cmd.ExecuteNonQuery();

                    // 7. ParkingSlots
                    // Zone A
                    for (int i = 1; i <= 20; i++)
                    {
                        string code = $"A-{i:D2}";
                        int status = (i == 1 || i == 3 || i == 7) ? 1 : 0;
                        string plate = (i == 1) ? "29B1-555.66" : (i == 3) ? "29X1-654.32" : (i == 7) ? "34B2-111.44" : null;
                        string occTime = status == 1 ? now.AddHours(-i * 2).ToString("yyyy-MM-dd HH:mm:ss") : null;
                        cmd.CommandText = $@"
                            INSERT INTO ParkingSlots (SlotCode, Zone, SlotType, Status, AssignedRoomID, CurrentPlate, OccupiedSince)
                            VALUES ('{code}', 'A', N'Xe máy', {status}, NULL, {(plate == null ? "NULL" : $"'{plate}'")}, {(occTime == null ? "NULL" : $"'{occTime}'")});
                        ";
                        cmd.ExecuteNonQuery();
                    }

                    // Zone B
                    for (int i = 1; i <= 15; i++)
                    {
                        string code = $"B-{i:D2}";
                        string slotType = i <= 6 ? "Trạm sạc điện" : "Xe đạp";
                        int status = 0;
                        string plate = null;
                        if (i == 1) { status = 3; plate = "29MD-456.78 (Đang sạc ⚡)"; }
                        else if (i == 5) { status = 4; }
                        else if (i == 8) { status = 1; plate = "Xe đạp Asama"; }

                        cmd.CommandText = $@"
                            INSERT INTO ParkingSlots (SlotCode, Zone, SlotType, Status, AssignedRoomID, CurrentPlate, OccupiedSince)
                            VALUES ('{code}', 'B', N'{slotType}', {status}, NULL, {(plate == null ? "NULL" : $"N'{plate}'")}, {(status != 0 && status != 4 ? $"'{now.AddHours(-3):yyyy-MM-dd HH:mm:ss}'" : "NULL")});
                        ";
                        cmd.ExecuteNonQuery();
                    }

                    // Zone B1
                    for (int i = 1; i <= 10; i++)
                    {
                        string code = $"B1-{i:D2}";
                        int status = 0;
                        int? assignedRoom = null;
                        string plate = null;
                        if (i == 2) { status = 2; assignedRoom = 5; }
                        else if (i == 5) { status = 1; plate = "30E-123.45"; }

                        cmd.CommandText = $@"
                            INSERT INTO ParkingSlots (SlotCode, Zone, SlotType, Status, AssignedRoomID, CurrentPlate, OccupiedSince)
                            VALUES ('{code}', 'B1', N'Ô tô', {status}, {(assignedRoom == null ? "NULL" : assignedRoom.ToString())}, {(plate == null ? "NULL" : $"'{plate}'")}, {(status == 1 ? $"'{now.AddHours(-5):yyyy-MM-dd HH:mm:ss}'" : "NULL")});
                        ";
                        cmd.ExecuteNonQuery();
                    }

                    // 8. ParkingSessions
                    cmd.CommandText = $@"
                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, Status, StaffInID, Notes)
                        VALUES ('CARD-B302-01', '29B1-555.66', N'Xe máy xăng', 1, '{now.AddHours(-3):yyyy-MM-dd HH:mm:ss}', 0, 2, N'Sinh viên vào KTX');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, Status, StaffInID, Notes)
                        VALUES (NULL, '29X1-654.32', N'Xe máy xăng', 3, '{now.AddHours(-2):yyyy-MM-dd HH:mm:ss}', 0, 2, N'Khách vãng lai');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, IsCharging, Status, StaffInID, Notes)
                        VALUES (NULL, '29MD-456.78', N'Xe máy điện', 21, '{now.AddHours(-1):yyyy-MM-dd HH:mm:ss}', 1, 0, 2, N'Khách cắm sạc điện');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, Status, StaffInID, Notes)
                        VALUES (NULL, '34B2-111.44', N'Xe máy xăng', 7, '{now.AddHours(-85):yyyy-MM-dd HH:mm:ss}', 0, 2, N'Xe vé lượt lưu bãi > 3 ngày');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, Status, StaffInID, Notes)
                        VALUES (NULL, '18H1-999.00', N'Xe máy xăng', 4, '{now.AddDays(-9):yyyy-MM-dd HH:mm:ss}', 0, 2, N'Xe vô chủ lưu bãi > 7 ngày');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, CheckOutTime, TotalAmount, Status, StaffInID, StaffOutID, Notes)
                        VALUES (NULL, '29C1-112.23', N'Xe máy xăng', 5, '{now.AddMinutes(-40):yyyy-MM-dd HH:mm:ss}', '{now.AddMinutes(-30):yyyy-MM-dd HH:mm:ss}', 0, 1, 2, 2, N'Shipper ShopeeFood 10 phút miễn phí');

                        INSERT INTO ParkingSessions (CardCode, PlateNumber, VehicleType, SlotID, CheckInTime, CheckOutTime, TotalAmount, Status, StaffInID, StaffOutID, Notes)
                        VALUES (NULL, '30F4-445.56', N'Xe máy xăng', 6, '{now.AddHours(-5):yyyy-MM-dd HH:mm:ss}', '{now.AddHours(-1):yyyy-MM-dd HH:mm:ss}', 3000, 1, 2, 2, N'Khách gửi ngày 3.000đ');
                    ";
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
            }
        }
    }
}
