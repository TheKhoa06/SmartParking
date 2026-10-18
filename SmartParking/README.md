# HỆ THỐNG QUẢN LÝ NHÀ GỬI XE THÔNG MINH KÝ TÚC XÁ & CHUNG CƯ (SMARTPARKING)
> **Đồ án môn học:** Lập Trình Trực Quan (C# Windows Forms nâng cao)  
> **Nền tảng:** .NET 8 / .NET 10 WinForms, SQLite (Nhúng sẵn) & SQL Server 2019/2022  
> **Nhóm thực hiện:** Huân (Lead), Khoa, Hưng, Vinh  
> **Thư mục dự án:** `C:\Hoc_ky_5\LapTrinhTrucQuan\SmartParking`

---

## 1. HƯỚNG DẪN CHẠY PHẦN MỀM (HOW TO RUN)

### Cách 1: Chạy trực tiếp từ dòng lệnh (Khuyên dùng)
1. Mở PowerShell hoặc Command Prompt tại thư mục dự án:
   ```powershell
   cd C:\Hoc_ky_5\LapTrinhTrucQuan\SmartParking
   dotnet run
   ```
2. Hoặc nhấp đúp vào file `run.bat` trong thư mục.

### Cách 2: Mở bằng Visual Studio 2022
1. Mở Visual Studio $\rightarrow$ Chọn **Open a project or solution**.
2. Trỏ đến file `C:\Hoc_ky_5\LapTrinhTrucQuan\SmartParking\SmartParking.csproj`.
3. Nhấn **F5** (hoặc nút **Start**) để chạy ứng dụng.

---

## 2. TÀI KHOẢN ĐĂNG NHẬP MẶC ĐỊNH (DEMO TÀI KHOẢN)

Trên màn hình đăng nhập (`frmLogin`) có sẵn 3 nút đăng nhập nhanh phục vụ demo đồ án trước hội đồng:
| Tài khoản | Mật khẩu | Tên người dùng | Vai trò | Phân quyền truy cập |
| :--- | :---: | :--- | :---: | :--- |
| `admin` | `123456` | **Huân & Hưng (Ban Quản Lý)** | `Admin` | Toàn quyền tất cả các màn hình (Bao gồm Cấu hình Bảng giá động & Quản lý nhân viên). |
| `khoa` | `123456` | **Khoa (Bảo vệ Ca Sáng)** | `Staff` | Màn hình Kiểm soát cổng, Sơ đồ bãi xe, Lịch sử, Bàn giao ca trực. |
| `vinh` | `123456` | **Vinh (Bảo vệ Ca Tối)** | `Staff` | Màn hình Làn vào/ra, Xử lý mất vé, Dashboard, Cảnh báo xe bỏ quên. |

---

## 3. PHÂN CÔNG MODULE VÀ FILE NGUỒN CỦA 4 THÀNH VIÊN

### 1. HUÂN (Team Lead) – Kiến trúc Lõi, Giao ca & Sơ đồ Bãi xe Trực quan
* **Màn hình phụ trách:**
  * `UI/Forms/frmLogin.cs`: Xác thực đăng nhập & nút chuyển nhanh vai trò.
  * `UI/Forms/frmMain.cs`: Khung giao diện chính (Shell Layout), Sidebar Navigation, đồng hồ số thời gian thực và điều hướng liên màn hình.
  * `UI/UserControls/ucParkingMap.cs`: Sơ đồ bãi xe động (`FlowLayoutPanel`) 3 khu vực (Khu A: Xe máy, Khu B: Xe đạp & Trạm sạc ⚡, Hầm B1: Ô tô).
    * **5 màu trạng thái:** 🟢 Trống (#2ECC71), 🔴 Có xe (#E74C3C), 🟡 Cố định vắng chủ (#F39C12), 🔵 Đang sạc điện (#3498DB), ⚪ Bảo trì (#95A5A6).
    * **Tính năng "Tìm xe của tôi ở đâu?":** Nhập biển số / MSSV $\rightarrow$ Tự động cuộn tới ô và nhấp nháy viền trong 5 giây.
    * **ContextMenu Chuột phải:** Xem chi tiết, Di chuyển xe sang ô khác, Báo bảo trì ô.
  * `UI/Forms/frmShiftHandover.cs`: Bàn giao ca trực bảo vệ, chốt số lượt vào/ra và tiền mặt thực thu.
  * `UI/UserControls/ucStaffManager.cs`: Quản lý nhân viên trực chốt & phân quyền Admin/Staff.

### 2. KHOA – Trạm Kiểm soát Làn Vào/Ra, Webcam, Quét QR & Tính tiền
* **Màn hình phụ trách:**
  * `UI/UserControls/ucGateControl.cs`: Màn hình chia đôi Làn Vào (Trái) & Làn Ra (Phải).
    * **Webcam & Live Capture:** Tích hợp bộ giả lập và xử lý luồng camera an ninh bảo mật kèm Watermark và nhận diện khuôn mặt.
    * **Nghiệp vụ Anti-Passback:** Kiểm tra thẻ tháng đang có xe trong bãi $\rightarrow$ Chặn ngay lập tức, hú còi cảnh báo và đổi bảng LED sang Đỏ!
    * **Chính sách Miễn phí 15 phút đầu cho Shipper:** Xe ra dưới 15 phút tự động tính 0 VNĐ, bảng LED hiển thị thông báo riêng.
    * **Thuật toán tính tiền vé lượt theo khung giờ:** Ngày (3.000đ), Tối (5.000đ), Qua đêm (10.000đ/đêm), Phụ phí sạc điện (+5.000đ).
    * **Tự động gợi ý ô đỗ trống:** Khi xe vào, hệ thống tự động điền ô trống phù hợp và đồng bộ đổi màu ngay lập tức sang sơ đồ của Huân.
  * `UI/Forms/frmPlateWarning.cs`: Cảnh báo không khớp biển số giữa thẻ tháng và xe thực tế.
  * `UI/Forms/frmQuickReceipt.cs`: Phiếu thanh toán kèm mã QR tra cứu điện tử khi xe ra.

### 3. HƯNG – Quản lý Cư dân/Sinh viên, Vé tháng theo Định mức Phòng & Tự động hóa
* **Màn hình phụ trách:**
  * `UI/UserControls/ucResidentMonthly.cs`: Quản lý Căn hộ, Phòng KTX, Cư dân và Thẻ tháng.
    * **Định mức số lượng xe theo phòng (Lũy tiến):** Xe 1 & 2 hưởng giá chuẩn ưu đãi (80.000đ); Xe thứ 3 tự động phụ thu +50% (120.000đ); Xe thứ 4 cảnh báo vượt trần tối đa.
    * **Đăng ký theo Gói Học kỳ:** 1 tháng (0%), 3 tháng (-5%), Học kỳ 5 tháng (-10%), Cả năm (-20%).
    * **Gán ô cố định Hầm B1 cho Ô tô:** Khi căn hộ thuê ô tô cố định, ô đỗ trên sơ đồ của Huân lập tức đổi sang màu Vàng cam (#F39C12).
    * **Tô màu DataGridView theo hạn thẻ (RowPrePaint):** Trắng (Bình thường), Vàng (Sắp hết hạn 1-5 ngày), Đỏ (Hết hạn), Xám (Khóa).
    * **Gửi Email nhắc nợ hàng loạt chạy ngầm (async/await Task + ProgressBar).**
    * **Cấp lại thẻ khi mất / Đổi xe mới:** Sinh mã QR mới, hủy mã cũ và cộng 20.000đ phí.
  * `UI/Forms/frmPrintTicket.cs`: Mẫu thẻ thành viên nhựa in mã QR tự động bằng thư viện `ZXing.Net`.
  * `UI/UserControls/ucPricingConfig.cs`: Cấu hình bảng giá và tham số động toàn hệ thống (Admin only).

### 4. VINH – Xử lý Sự cố Mất vé, Cảnh báo Xe bỏ quên, Đối soát & Dashboard
* **Màn hình phụ trách:**
  * `UI/UserControls/ucDashboard.cs`: Dashboard KPI và trực quan hóa số liệu:
    * 4 thẻ KPI: Tổng xe trong bãi, Doanh thu hôm nay, Vé tháng sắp hết hạn, Cảnh báo xe bỏ quên.
    * Biểu đồ Cột chồng (Stacked Chart) cơ cấu doanh thu theo 3 nguồn.
    * Biểu đồ Đường (Spline Chart) mật độ lưu lượng xe theo 24 giờ trong ngày (Làm rõ đỉnh 7h sáng & 17h chiều).
  * `UI/Forms/frmLostTicket.cs`: Quy trình xử lý mất vé xe: Tìm kiếm xe thông minh, phóng to ảnh chụp lúc vào để đối soát người/xe, chụp ảnh khuôn mặt người nhận kèm CCCD, tính tiền gửi + tiền phạt mất vé (30.000đ) và giải phóng ô đỗ.
  * `UI/UserControls/ucAbandonedVehicles.cs`: Quét các xe vé lượt nằm trong bầm quá 72 giờ (Tô màu Cam) và quá 7 ngày (Tô màu Đỏ đậm). Hỗ trợ nút định vị nhảy sang sơ đồ Huân để nhấp nháy kiểm tra an ninh.
  * `UI/UserControls/ucHistory.cs`: Lịch sử vào/ra, đối soát ảnh chụp 2 camera cạnh nhau và nút **Xuất Báo Cáo Kế Toán Excel 3-Sheet (ClosedXML)**.

---

## 4. MA TRẬN LIÊN THÔNG DỮ LIỆU THỜI GIAN THỰC (CROSS-MODULE BUS)

Hệ thống sử dụng lớp `SmartParking.Services.EventAggregator` đóng vai trò là Event Bus trung tâm:
1. **Khoa cho xe vào cổng** $\rightarrow$ Ô đỗ trên Sơ đồ của Huân đổi ngay sang màu 🔴 Đỏ (hoặc 🔵 Xanh dương có tia sét ⚡), thanh phần trăm lấp đầy tăng lên tức thì.
2. **Khoa cho xe ra cổng** $\rightarrow$ Ô đỗ của Huân tự động giải phóng về màu 🟢 Xanh lá (hoặc 🟡 Vàng cam nếu là ô cố định của cư dân đi làm).
3. **Hưng đổi bảng giá ở ucPricingConfig** $\rightarrow$ Ngay lượt xe ra tiếp theo của Khoa tự động tính theo biểu giá mới mà không cần tắt/mở lại phần mềm.
4. **Khoa bấm "Mất Vé"** $\rightarrow$ Gọi form lập biên bản của Vinh; sau khi Vinh thu tiền phạt và ký biên bản xong, ô đỗ của Huân tự động chuyển về Xanh lá và Dashboard của Vinh tự nhảy số.

---

## 5. TÀI LIỆU CƠ SỞ DỮ LIỆU (DATABASE FILES)
1. **SQLite (Tự động khởi tạo & Nhúng sẵn):** File `smartparking.db` sinh tự động cùng thư mục chạy ứng dụng với đầy đủ dữ liệu mẫu phong phú.
2. **Microsoft SQL Server Script:** File `Data/SmartParking_SQLServer.sql` chứa toàn bộ câu lệnh `CREATE TABLE`, khóa ngoại, chỉ mục (Index) và chú thích đầy đủ để nhóm nộp cho giảng viên nếu bộ môn yêu cầu SQL Server.
