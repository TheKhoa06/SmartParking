using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SmartParking.Models;
using SmartParking.UI.Common;
using SmartParking.UI.UserControls;

namespace SmartParking.UI.Forms
{
    public partial class frmMain : Form
    {
        private User currentUser;

        // UserControls instances (Kiến trúc Module 3 lớp)
        private ucParkingMap ucMap = null!;
        private ucGateControl ucGate = null!;
        private ucResidentMonthly ucResident = null!;
        private ucDashboard ucDash = null!;
        private ucAbandonedVehicles ucAbandoned = null!;
        private ucHistory ucHist = null!;
        private ucPricingConfig? ucPrice = null;
        private ucStaffManager? ucStaff = null;

        private Button? activeNavButton = null;
        private readonly List<Button> navButtons = new();

        public frmMain() : this(new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên (Admin)", Role = "Admin", IsActive = true })
        {
        }

        public frmMain(User user)
        {
            currentUser = user ?? new User { UserID = 1, Username = "admin", FullName = "Quản Trị Viên", Role = "Admin", IsActive = true };
            InitializeComponent();

            // Áp dụng Modern Menu Renderer (Chương 5 Giáo trình LTTQ)
            mnuMain.Renderer = new ModernMenuRenderer();
            toolMain.Renderer = new ModernMenuRenderer();
            statusMain.Renderer = new ModernMenuRenderer();

            // Cập nhật thông tin người dùng lên tiêu đề và thanh trạng thái
            Text = $"Hệ Thống Quản Lý Bãi Xe Thông Minh KTX & Chung Cư (SmartParking Pro) - [{currentUser.FullName} | {currentUser.Role}]";
            statusLblUser.Text = $"👤 Nhân viên: {currentUser.FullName} ({currentUser.Role})";
            lblUName.Text = currentUser.FullName;
            lblURole.Text = $"● {currentUser.Role} (Trực tuyến)";
            lblAvatar.Text = currentUser.Role == "Admin" ? "👑" : "🛡️";

            // Phân quyền hiển thị Menu & Navigation
            bool isAdmin = currentUser.Role == "Admin";
            mnuPricing.Enabled = isAdmin;
            mnuStaff.Enabled = isAdmin;
            lblSecAdmin.Visible = isAdmin;
            btnNavPrice.Visible = isAdmin;
            btnNavStaff.Visible = isAdmin;

            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            InitializeUserControls();

            // Mở màn hình mặc định: Sơ đồ bãi xe
            ShowView(ucMap, btnNavMap, "SƠ ĐỒ BÃI XE THỜI GIAN THỰC", "Giám sát trực quan trạng thái 5 màu - Tìm xe chớp nháy & Điều phối vị trí đỗ");
        }

        private void SetupEvents()
        {
            // Register nav buttons for hover styling
            navButtons.Add(btnNavMap);
            navButtons.Add(btnNavGate);
            navButtons.Add(btnNavResident);
            navButtons.Add(btnNavDash);
            navButtons.Add(btnNavAbandoned);
            navButtons.Add(btnNavHist);
            navButtons.Add(btnNavPrice);
            navButtons.Add(btnNavStaff);

            foreach (var btn in navButtons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != activeNavButton)
                        btn.BackColor = UITheme.SidebarHover;
                };
                btn.MouseLeave += (s, e) =>
                {
                    if (btn != activeNavButton)
                        btn.BackColor = UITheme.SidebarDark;
                };
            }

            // Click events for Navigation Buttons
            btnNavMap.Click += (s, e) => ShowView(ucMap, btnNavMap, "SƠ ĐỒ BÃI XE THỜI GIAN THỰC", "Trực quan hóa 5 màu - Tìm xe chớp nháy & Điều phối ô đỗ");
            btnNavGate.Click += (s, e) => ShowView(ucGate, btnNavGate, "KIỂM SOÁT CỔNG VÀO / RA", "Mô phỏng camera nhận diện biển số, chống Anti-Passback & Miễn phí shipper 15p");
            btnNavResident.Click += (s, e) => ShowView(ucResident, btnNavResident, "QUẢN LÝ CƯ DÂN & VÉ THÁNG", "Định mức xe theo phòng KTX, tính lũy tiến xe thứ 3 (+50%) & Gửi email nhắc hạn");
            btnNavDash.Click += (s, e) => ShowView(ucDash, btnNavDash, "DASHBOARD PHÂN TÍCH & DOANH THU", "Chỉ số KPI thời gian thực, biểu đồ cơ cấu doanh thu & Mật độ giờ cao điểm");
            btnNavAbandoned.Click += (s, e) => ShowView(ucAbandoned, btnNavAbandoned, "CẢNH BÁO XE BỎ QUÊN / VÔ CHỦ", "Phát hiện xe lưu bãi quá 72h (cam) và quá 7 ngày (đỏ) - Định vị vị trí ô");
            btnNavHist.Click += (s, e) => ShowView(ucHist, btnNavHist, "TRA CỨU LỊCH SỬ & XUẤT BÁO CÁO", "Bộ lọc đa tiêu chí và xuất báo cáo Excel 3-sheet ClosedXML chuẩn kế toán");
            btnNavPrice.Click += (s, e) => OpenPricingModule();
            btnNavStaff.Click += (s, e) => OpenStaffModule();

            // MenuStrip Clicks
            mnuHandover.Click += (s, e) => OpenHandoverDialog();
            mnuPricing.Click += (s, e) => OpenPricingModule();
            mnuStaff.Click += (s, e) => OpenStaffModule();
            mnuLogout.Click += (s, e) => Logout();
            mnuExit.Click += (s, e) => Application.Exit();

            mnuMapItem.Click += (s, e) => btnNavMap.PerformClick();
            mnuGateItem.Click += (s, e) => btnNavGate.PerformClick();
            mnuResidentItem.Click += (s, e) => btnNavResident.PerformClick();
            mnuDashItem.Click += (s, e) => btnNavDash.PerformClick();
            mnuAbanItem.Click += (s, e) => btnNavAbandoned.PerformClick();
            mnuHistItem.Click += (s, e) => btnNavHist.PerformClick();
            mnuAbout.Click += (s, e) => ShowAboutDialog();
            mnuGuide.Click += (s, e) => ShowGuideDialog();

            // ToolStrip Clicks
            toolBtnMap.Click += (s, e) => btnNavMap.PerformClick();
            toolBtnGate.Click += (s, e) => btnNavGate.PerformClick();
            toolBtnResident.Click += (s, e) => btnNavResident.PerformClick();
            toolBtnDash.Click += (s, e) => btnNavDash.PerformClick();
            toolBtnAban.Click += (s, e) => btnNavAbandoned.PerformClick();
            toolBtnHist.Click += (s, e) => btnNavHist.PerformClick();
            toolBtnHandover.Click += (s, e) => OpenHandoverDialog();
            toolBtnReload.Click += (s, e) => ucMap.LoadSlotsFromDatabase();

            // Header buttons
            btnHandover.Click += (s, e) => OpenHandoverDialog();
            btnLogout.Click += (s, e) => Logout();

            // Tooltips
            toolTip.SetToolTip(btnHandover, "Bàn giao ca trực bảo vệ và chốt doanh thu tiền mặt (Ctrl+H)");

            // Real-time Clock Timer
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) =>
            {
                string nowText = DateTime.Now.ToString("HH:mm:ss  dd/MM/yyyy");
                lblClock.Text = nowText;
                statusLblTime.Text = nowText;
            };
            clockTimer.Start();

            // Header bottom border painting
            pnlHeader.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(new Pen(UITheme.CardBorder, 1), 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };

            // Online Badge border painting
            pnlOnlineBadge.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var p = new Pen(Color.FromArgb(167, 243, 208), 1);
                e.Graphics.DrawRoundedRectangle(p, new Rectangle(0, 0, pnlOnlineBadge.Width - 1, pnlOnlineBadge.Height - 1), 6);
            };
        }

        private void InitializeUserControls()
        {
            ucMap = new ucParkingMap();
            ucGate = new ucGateControl(currentUser);
            ucResident = new ucResidentMonthly();

            ucDash = new ucDashboard(target =>
            {
                if (target == "ResidentMonthly")
                    ShowView(ucResident, btnNavResident, "QUẢN LÝ CƯ DÂN & VÉ THÁNG", "Định mức xe theo phòng KTX & Gói kỳ");
                else if (target == "AbandonedVehicles")
                    ShowView(ucAbandoned, btnNavAbandoned, "CẢNH BÁO XE BỎ QUÊN / VÔ CHỦ", "Phát hiện xe lưu bãi quá 72h & Quá 7 ngày");
            });

            ucAbandoned = new ucAbandonedVehicles(slotCode =>
            {
                ShowView(ucMap, btnNavMap, "SƠ ĐỒ BÃI XE THỜI GIAN THỰC", "Đang định vị ô xe được chọn");
            });

            ucHist = new ucHistory(currentUser);
        }

        private void ShowView(UserControl uc, Button navButton, string title, string subtitle)
        {
            if (activeNavButton != null)
            {
                activeNavButton.BackColor = UITheme.SidebarDark;
                activeNavButton.ForeColor = UITheme.SidebarText;
            }

            activeNavButton = navButton;
            activeNavButton.BackColor = UITheme.Primary;
            activeNavButton.ForeColor = Color.White;

            lblModuleTitle.Text = title;
            lblModuleSubtitle.Text = subtitle;
            statusLblState.Text = $"🟢 Đang hiển thị: {title}";

            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            pnlContent.ResumeLayout();
        }

        private void OpenPricingModule()
        {
            ucPrice ??= new ucPricingConfig();
            ShowView(ucPrice, btnNavPrice, "CẤU HÌNH BIỂU PHÍ & LUẬT TÍNH TIỀN", "Điều chỉnh linh hoạt giá ngày/đêm/qua đêm, phụ thu sạc điện & định mức phòng");
        }

        private void OpenStaffModule()
        {
            ucStaff ??= new ucStaffManager();
            ShowView(ucStaff, btnNavStaff, "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN", "Quản lý danh sách nhân viên bảo vệ ca trực, cấp lại mật khẩu & khóa tài khoản");
        }

        private void OpenHandoverDialog()
        {
            var frm = new frmShiftHandover(currentUser);
            frm.ShowDialog();
        }

        private void Logout()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                var login = new frmLogin();
                login.Show();
            }
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show(
                "🅿️ SMARTPARKING PRO - HỆ THỐNG QUẢN LÝ BÃI XE KTX & CHUNG CƯ\n\n" +
                "• Đề tài: Quản lý bãi giữ xe thông minh khu ký túc xá & căn hộ sinh viên\n" +
                "• Môn học: Lập Trình Trực Quan (C# Windows Forms Application)\n" +
                "• Nền tảng: Microsoft .NET Framework 4.8\n" +
                "• Cơ sở dữ liệu: Microsoft SQL Server 2019 / 2022 (ADO.NET thuần túy)\n" +
                "• Nhóm sinh viên thực hiện: Huân (Trưởng nhóm) - Khoa - Hưng - Vinh\n" +
                "• Bản quyền: © 2026 - Trường Đại Học Giao Thông Vận Tải (UTC)",
                "Thông tin phần mềm SmartParking Pro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ShowGuideDialog()
        {
            MessageBox.Show(
                "HƯỚNG DẪN SỬ DỤNG NHANH CÁC PHÍM TẮT & CHỨC NĂNG:\n\n" +
                "• F1: Mở Sơ đồ bãi xe trực quan 5 màu (Huân phụ trách)\n" +
                "• F2: Mở Cổng kiểm soát Vào / Ra camera (Khoa phụ trách)\n" +
                "• F3: Quản lý căn hộ, định mức xe & vé tháng (Hưng phụ trách)\n" +
                "• F4: Dashboard biểu đồ phân tích KPI doanh thu (Vinh phụ trách)\n" +
                "• F5: Cảnh báo xe bỏ quên lưu bãi >72h (Vinh phụ trách)\n" +
                "• F6: Tra cứu lịch sử & Xuất báo cáo Excel 3-sheet (Vinh phụ trách)\n" +
                "• Ctrl + H: Mở form Bàn giao ca trực & chốt tiền mặt\n" +
                "• Ctrl + L: Đăng xuất người dùng hiện tại",
                "Hướng dẫn sử dụng đồ án",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
