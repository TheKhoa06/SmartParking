using System;
using System.Drawing;
using System.Windows.Forms;

namespace SmartParking.UI.Common
{
    public static class UITheme
    {
        // =========================================================================
        // 1. PALETTE MÀU SẮC CAO CẤP, HÀI HÒA & NỊNH MẮT (NORDIC SLATE & TECH BLUE)
        // Không dùng màu neon gắt, phối màu doanh nghiệp cao cấp tạo cảm giác thư thái
        // =========================================================================
        
        // 5 Màu trạng thái ô đỗ xe (Parking Slots) - Tone màu Pastel/Modern tinh tế
        public static readonly Color ColorEmpty = ColorTranslator.FromHtml("#059669");        // Xanh ngọc lục bảo dịu mắt
        public static readonly Color ColorOccupied = ColorTranslator.FromHtml("#E11D48");     // Đỏ san hô trầm (không chói)
        public static readonly Color ColorReserved = ColorTranslator.FromHtml("#D97706");     // Vàng hổ phách ấm áp
        public static readonly Color ColorCharging = ColorTranslator.FromHtml("#0284C7");     // Xanh lam thanh mát ⚡
        public static readonly Color ColorMaintenance = ColorTranslator.FromHtml("#64748B");  // Xám đá Slate nhã nhặn

        // Nền ứng dụng & Card
        public static readonly Color BgCanvas = ColorTranslator.FromHtml("#F1F5F9");          // Slate-100: Mềm dịu, thư giãn mắt
        public static readonly Color CardBg = Color.White;
        public static readonly Color CardBorder = ColorTranslator.FromHtml("#CBD5E1");      // Slate-300: Viền nét thanh lịch
        public static readonly Color CardHover = ColorTranslator.FromHtml("#F8FAFC");

        // Sidebar Deep Navy Slate (Sang trọng, ấm, chuẩn phần mềm quản lý hiện đại)
        public static readonly Color SidebarDark = ColorTranslator.FromHtml("#1E293B");       // Slate-800
        public static readonly Color SidebarBrand = ColorTranslator.FromHtml("#0F172A");      // Slate-900
        public static readonly Color SidebarActive = ColorTranslator.FromHtml("#334155");     // Slate-700
        public static readonly Color SidebarHover = ColorTranslator.FromHtml("#27354A");      // Slate-750
        public static readonly Color SidebarBorder = ColorTranslator.FromHtml("#334155");
        public static readonly Color SidebarText = ColorTranslator.FromHtml("#E2E8F0");        // Slate-200
        public static readonly Color SidebarMuted = ColorTranslator.FromHtml("#94A3B8");       // Slate-400

        // Màu thương hiệu chính (Modern Indigo Sapphire)
        public static readonly Color Primary = ColorTranslator.FromHtml("#2563EB");           // Blue-600
        public static readonly Color PrimaryHover = ColorTranslator.FromHtml("#1D4ED8");      // Blue-700
        public static readonly Color PrimaryDark = ColorTranslator.FromHtml("#1E3A8A");       // Blue-900
        public static readonly Color PrimaryLight = ColorTranslator.FromHtml("#EFF6FF");      // Blue-50 Soft tint

        // Màu trạng thái chức năng
        public static readonly Color Success = ColorTranslator.FromHtml("#059669");          // Emerald-600
        public static readonly Color SuccessLight = ColorTranslator.FromHtml("#ECFDF5");     // Emerald-50
        public static readonly Color SuccessText = ColorTranslator.FromHtml("#065F46");      // Emerald-800

        public static readonly Color Danger = ColorTranslator.FromHtml("#DC2626");           // Red-600
        public static readonly Color DangerLight = ColorTranslator.FromHtml("#FEF2F2");      // Red-50
        public static readonly Color DangerText = ColorTranslator.FromHtml("#991B1B");       // Red-800

        public static readonly Color Warning = ColorTranslator.FromHtml("#D97706");          // Amber-600
        public static readonly Color WarningLight = ColorTranslator.FromHtml("#FFFBEB");     // Amber-50
        public static readonly Color WarningText = ColorTranslator.FromHtml("#92400E");      // Amber-800

        public static readonly Color Info = ColorTranslator.FromHtml("#0284C7");             // Sky-600
        public static readonly Color InfoLight = ColorTranslator.FromHtml("#F0F9FF");        // Sky-50
        public static readonly Color InfoText = ColorTranslator.FromHtml("#075985");         // Sky-800

        // Màu chữ chuẩn hiển thị
        public static readonly Color TextDark = ColorTranslator.FromHtml("#0F172A");         // Slate-900 (Đậm rõ, không nhòe)
        public static readonly Color TextMuted = ColorTranslator.FromHtml("#64748B");        // Slate-500
        public static readonly Color TextLight = ColorTranslator.FromHtml("#94A3B8");        // Slate-400

        // Màu bảng LED ma trận quang báo mô phỏng thực tế
        public static readonly Color LedBg = ColorTranslator.FromHtml("#0F172A");            // Nền đen than chuyên nghiệp
        public static readonly Color LedTextSuccess = ColorTranslator.FromHtml("#34D399");   // Xanh ngọc phát quang dịu
        public static readonly Color LedTextWarning = ColorTranslator.FromHtml("#FBBF24");   // Hổ phách quang báo
        public static readonly Color LedTextDanger = ColorTranslator.FromHtml("#F87171");    // Đỏ còi báo động

        // =========================================================================
        // 2. TYPOGRAPHY HỆ THỐNG (CHUẨN SEGOE UI SẮC NÉT, RÕ RÀNG)
        // =========================================================================
        public static readonly Font HeaderFont = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font SubHeaderFont = new Font("Segoe UI", 11.5f, FontStyle.Bold);
        public static readonly Font TitleFont = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 9.25f, FontStyle.Regular);
        public static readonly Font BoldFont = new Font("Segoe UI", 9.25f, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.25f, FontStyle.Regular);
        public static readonly Font SmallBoldFont = new Font("Segoe UI", 8.25f, FontStyle.Bold);
        public static readonly Font BigDisplayFont = new Font("Segoe UI", 24f, FontStyle.Bold);
        public static readonly Font MonoFont = new Font("Consolas", 10.5f, FontStyle.Bold);

        // =========================================================================
        // 3. HELPER TẠO NÚT BẤM CHUẨN KÉO THẢ WINFORMS
        // =========================================================================
        public static Button CreateButton(string text, Color backColor, Color foreColor, int width = 120, int height = 34)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = backColor,
                ForeColor = foreColor,
                Size = new Size(width, height),
                Font = BoldFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }
    }
}
