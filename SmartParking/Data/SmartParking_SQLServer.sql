-- =========================================================================================
-- ĐỒ ÁN MÔN HỌC: LẬP TRÌNH TRỰC QUAN (C# WINFORMS)
-- ĐỀ TÀI: HỆ THỐNG QUẢN LÝ NHÀ GỬI XE THÔNG MINH CHUNG CƯ & KÝ TÚC XÁ SINH VIÊN (SMARTPARKING)
-- TÁC GIẢ: NHÓM HUÂN - KHOA - HƯNG - VINH
-- CƠ SỞ DỮ LIỆU: MICROSOFT SQL SERVER 2019 / 2022
-- =========================================================================================

CREATE DATABASE SmartParkingDB;
GO
USE SmartParkingDB;
GO

-- 1. BẢNG NGƯỜI DÙNG & TÀI KHOẢN (HUÂN QUẢN LÝ)
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL DEFAULT 'Staff', -- 'Admin', 'Staff'
    Phone NVARCHAR(20),
    IsActive BIT DEFAULT 1
);

-- 2. BẢNG PHÒNG KTX / CĂN HỘ CHUNG CƯ (HƯNG QUẢN LÝ)
CREATE TABLE Rooms (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(50) UNIQUE NOT NULL, -- VD: KTX-B302, CC-A1208
    BuildingBlock NVARCHAR(100) NOT NULL,
    MaxVehicleQuota INT DEFAULT 3, -- Định mức tối đa trước khi chặn cứng
    Notes NVARCHAR(255)
);

-- 3. BẢNG CƯ DÂN / SINH VIÊN (HƯNG QUẢN LÝ)
CREATE TABLE Residents (
    ResidentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    StudentID_CCCD NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100),
    RoomID INT FOREIGN KEY REFERENCES Rooms(RoomID)
);

-- 4. BẢNG PHƯƠNG TIỆN (HƯNG QUẢN LÝ)
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    PlateNumber NVARCHAR(50) UNIQUE NOT NULL,
    VehicleType NVARCHAR(50) NOT NULL, -- 'Xe đạp', 'Xe máy xăng', 'Xe máy điện', 'Ô tô'
    ResidentID INT FOREIGN KEY REFERENCES Residents(ResidentID),
    BrandModel NVARCHAR(100)
);

-- 5. BẢNG THẺ THÁNG / HỌC KỲ (HƯNG QUẢN LÝ)
CREATE TABLE MonthlyCards (
    CardID INT IDENTITY(1,1) PRIMARY KEY,
    CardCode NVARCHAR(100) UNIQUE NOT NULL, -- Mã QR
    VehicleID INT FOREIGN KEY REFERENCES Vehicles(VehicleID),
    VehicleOrderInRoom INT DEFAULT 1, -- Thứ tự xe trong phòng (1, 2 = giá chuẩn, 3 = +50%)
    IssueDate DATETIME NOT NULL DEFAULT GETDATE(),
    ExpireDate DATETIME NOT NULL,
    PricingPlan NVARCHAR(50) DEFAULT N'1 tháng', -- '1 tháng', '3 tháng', 'Học kỳ 5 tháng', '12 tháng'
    MonthlyFee DECIMAL(18,2) DEFAULT 80000,
    TotalPaid DECIMAL(18,2) DEFAULT 80000,
    Status NVARCHAR(50) DEFAULT N'Hoạt động', -- 'Hoạt động', 'Sắp hết hạn', 'Hết hạn', 'Bị khóa'
    AssignedSlotID INT
);

-- 6. BẢNG Ô ĐỖ XE (HUÂN & KHOA QUẢN LÝ)
CREATE TABLE ParkingSlots (
    SlotID INT IDENTITY(1,1) PRIMARY KEY,
    SlotCode NVARCHAR(20) UNIQUE NOT NULL, -- A-01, B-01, B1-01
    Zone NVARCHAR(20) NOT NULL, -- 'A', 'B', 'B1'
    SlotType NVARCHAR(50) NOT NULL, -- 'Xe máy', 'Trạm sạc điện', 'Ô tô'
    Status INT DEFAULT 0, -- 0: Trống, 1: Có xe, 2: Cố định vắng, 3: Đang sạc, 4: Bảo trì
    AssignedRoomID INT,
    CurrentPlate NVARCHAR(50),
    OccupiedSince DATETIME
);

-- 7. BẢNG LƯỢT XE RA VÀO (KHOA QUẢN LÝ)
CREATE TABLE ParkingSessions (
    SessionID INT IDENTITY(1,1) PRIMARY KEY,
    CardCode NVARCHAR(100), -- NULL nếu là vé lượt
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
    Status INT DEFAULT 0, -- 0: Đang trong bãi, 1: Đã ra, 2: Mất vé đã lập biên bản
    Notes NVARCHAR(255)
);

-- 8. BẢNG CẤU HÌNH GIÁ & QUY TẮC (HƯNG QUẢN LÝ)
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
    FreeGraceMinutes INT DEFAULT 15, -- Miễn phí 15p cho shipper/phụ huynh
    LostTicketPenalty DECIMAL(18,2) DEFAULT 30000,
    StandardMonthlyFee DECIMAL(18,2) DEFAULT 80000,
    OverQuotaMultiplier DECIMAL(4,2) DEFAULT 1.5,
    CardReplacementFee DECIMAL(18,2) DEFAULT 20000
);

-- 9. BẢNG BIÊN BẢN SỰ CỐ MẤT VÉ (VINH QUẢN LÝ)
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

-- 10. BẢNG BÀN GIAO CA BẢO VỆ (HUÂN QUẢN LÝ)
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
GO
