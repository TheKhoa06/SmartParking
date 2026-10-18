using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using SmartParking.Models;

namespace SmartParking.UI.Common
{
    // =========================================================================
    // 1. NÚT BẤM HIỆN ĐẠI (MODERN BUTTON) - HIỆU ỨNG CHUYỂN SẮC & BO GÓC
    // =========================================================================
    public class ModernButton : Button
    {
        public int BorderRadius { get; set; } = 8;
        public Color NormalColor { get; set; } = UITheme.Primary;
        public Color HoverColor { get; set; } = UITheme.PrimaryHover;
        public Color PressedColor { get; set; } = UITheme.PrimaryDark;
        public Color BorderColor { get; set; } = Color.Transparent;
        public int BorderSize { get; set; } = 0;

        private bool isHovered = false;
        private bool isPressed = false;

        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = NormalColor;
            ForeColor = Color.White;
            Font = UITheme.BoldFont;
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Size = new Size(130, 38);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            isPressed = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color fill = !Enabled ? Color.FromArgb(203, 213, 225) :
                         isPressed ? PressedColor :
                         isHovered ? HoverColor : NormalColor;

            using (var path = GraphicsExtensions.CreateRoundedRectanglePath(rect, BorderRadius))
            {
                using (var brush = new SolidBrush(fill))
                {
                    g.FillPath(brush, path);
                }

                if (BorderSize > 0 && BorderColor != Color.Transparent)
                {
                    using var pen = new Pen(BorderColor, BorderSize);
                    g.DrawPath(pen, path);
                }
            }

            var textRect = ClientRectangle;
            Color textClr = !Enabled ? Color.FromArgb(100, 116, 139) : ForeColor;
            TextRenderer.DrawText(g, Text, Font, textRect, textClr, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    // =========================================================================
    // 2. KHUNG CARD CHỨA NỘI DUNG (MODERN CARD) - VIỀN SIÊU MẢNH & BO GÓC
    // =========================================================================
    public class ModernCard : Panel
    {
        public int Radius { get; set; } = 10;
        public Color BorderColor { get; set; } = UITheme.CardBorder;
        public int BorderThickness { get; set; } = 1;

        public ModernCard()
        {
            BackColor = Color.White;
            Padding = new Padding(14);
            Margin = new Padding(6);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = GraphicsExtensions.CreateRoundedRectanglePath(rect, Radius);

            if (BorderThickness > 0)
            {
                using var pen = new Pen(BorderColor, BorderThickness);
                g.DrawPath(pen, path);
            }
        }
    }

    // =========================================================================
    // 3. THẺ Ô ĐỖ XE TRỰC QUAN 5 MÀU (SLOT CONTROL) - HIỆU ỨNG TÌM KIẾM CHỚP NHÁY
    // =========================================================================
    public class SlotControl : UserControl
    {
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public ParkingSlot SlotData { get; private set; }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool IsBlinking { get; set; } = false;
        private bool _blinkState = false;
        private bool _isHovered = false;

        public SlotControl() : this(new ParkingSlot { SlotCode = "A-01", Zone = "B2", SlotType = "Xe máy", Status = 0 })
        {
        }

        public SlotControl(ParkingSlot slot)
        {
            SlotData = slot ?? new ParkingSlot { SlotCode = "A-01", Zone = "B2", SlotType = "Xe máy", Status = 0 };
            Size = new Size(122, 90);
            Margin = new Padding(6);
            DoubleBuffered = true;
            Cursor = Cursors.Hand;
        }

        public void UpdateData(ParkingSlot slot)
        {
            SlotData = slot;
            Invalidate();
        }

        public void ToggleBlink()
        {
            _blinkState = !_blinkState;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Xác định màu trạng thái
            Color mainColor = SlotData.Status switch
            {
                0 => UITheme.ColorEmpty,         // 🟢 Trống
                1 => UITheme.ColorOccupied,      // 🔴 Có xe
                2 => UITheme.ColorReserved,      // 🟡 Cố định vắng
                3 => UITheme.ColorCharging,      // 🔵 Đang cắm sạc
                4 => UITheme.ColorMaintenance,   // ⚪ Bảo trì
                _ => UITheme.ColorEmpty
            };

            var rect = new Rectangle(2, 2, Width - 5, Height - 5);

            // Nền thẻ: Gradient nhẹ từ màu gốc xuống tone hơi đậm tạo chiều sâu
            using (var brush = new LinearGradientBrush(rect, mainColor, Color.FromArgb(Math.Max(0, mainColor.R - 25), Math.Max(0, mainColor.G - 25), Math.Max(0, mainColor.B - 25)), 90f))
            {
                g.FillRoundedRectangle(brush, rect, 10);
            }

            // Dải tiêu đề trên
            using (var topStrip = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                g.FillRoundedRectangle(topStrip, new Rectangle(2, 2, Width - 5, 26), 8);
            }

            // Mã ô đỗ (Slot Code)
            using (var fontCode = new Font("Segoe UI", 9.5f, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, SlotData.SlotCode, fontCode, new Rectangle(8, 4, Width - 60, 22), Color.White, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

            // Tag nhãn phương tiện
            string tag = SlotData.Status switch
            {
                3 => "⚡ SẠC",
                2 => "CỐ ĐỊNH",
                4 => "BẢO TRÌ",
                _ => SlotData.Zone == "B1" ? "🚗 Ô TÔ" : "🛵 XE MÁY"
            };

            using (var fontTag = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, tag, fontTag, new Rectangle(Width - 85, 4, 78, 22), Color.White, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }

            // Hiển thị biển số xe hoặc trạng thái
            string displayInfo;
            if (SlotData.Status == 0) displayInfo = "TRỐNG";
            else if (SlotData.Status == 2) displayInfo = "VẮNG CHỦ";
            else if (SlotData.Status == 4) displayInfo = "BẢO TRÌ";
            else displayInfo = !string.IsNullOrWhiteSpace(SlotData.CurrentPlate) ? SlotData.CurrentPlate : "ĐÃ ĐỖ";

            // Hộp con nhộng (Capsule) chứa biển số
            var plateRect = new Rectangle(8, Height - 36, Width - 16, 26);
            using (var plateBg = new SolidBrush(Color.FromArgb(235, 15, 23, 42))) // Slate-900 sang trọng
            {
                g.FillRoundedRectangle(plateBg, plateRect, 6);
            }

            using (var fontPlate = new Font("Consolas", 9f, FontStyle.Bold))
            {
                TextRenderer.DrawText(g, displayInfo, fontPlate, plateRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            // Viền và hiệu ứng chớp nháy (Blink Effect khi tìm xe)
            if (IsBlinking)
            {
                Color blinkBorder = _blinkState ? Color.Yellow : Color.White;
                using var blinkPen = new Pen(blinkBorder, 3.5f);
                g.DrawRoundedRectangle(blinkPen, rect, 10);
            }
            else if (_isHovered)
            {
                using var hoverPen = new Pen(Color.White, 2.5f);
                g.DrawRoundedRectangle(hoverPen, rect, 10);
            }
            else
            {
                using var borderPen = new Pen(Color.FromArgb(60, 0, 0, 0), 1f);
                g.DrawRoundedRectangle(borderPen, rect, 10);
            }
        }
    }

    // =========================================================================
    // 4. TIỆN ÍCH ĐỒ HỌA GDI+ (GRAPHICS EXTENSIONS)
    // =========================================================================
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using var path = CreateRoundedRectanglePath(rect, radius);
            g.FillPath(brush, path);
        }

        public static void FillRoundedRectangle(this Graphics g, Brush brush, int x, int y, int width, int height, int radius)
        {
            using var path = CreateRoundedRectanglePath(new Rectangle(x, y, width, height), radius);
            g.FillPath(brush, path);
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using var path = CreateRoundedRectanglePath(rect, radius);
            g.DrawPath(pen, path);
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, int x, int y, int width, int height, int radius)
        {
            using var path = CreateRoundedRectanglePath(new Rectangle(x, y, width, height), radius);
            g.DrawPath(pen, path);
        }

        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    // =========================================================================
    // 5. BĂNG THÔNG BÁO LED (LED STATUS BANNER)
    // =========================================================================
    public class LedStatusBanner : Panel
    {
        private Label lblMessage;

        public LedStatusBanner()
        {
            Height = 52;
            BackColor = UITheme.ColorEmpty;
            Padding = new Padding(12);
            DoubleBuffered = true;

            lblMessage = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "🟢 CỔNG SẴN SÀNG - MỜI XE VÀO / RA"
            };
            Controls.Add(lblMessage);
        }

        public void SetStatus(string message, Color bgColor, Color textColor)
        {
            lblMessage.Text = message;
            BackColor = bgColor;
            lblMessage.ForeColor = textColor;
            lblMessage.Font = new Font("Segoe UI", message.Length > 45 ? 10.5f : 12f, FontStyle.Bold);
        }
    }

    // =========================================================================
    // 6. THANH TIẾN ĐỘ THỜI GIAN THỰC (COLOR PROGRESS BAR)
    // =========================================================================
    public class ColorProgressBar : ProgressBar
    {
        public ColorProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Height = 24;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = ClientRectangle;
            using (var trackBrush = new SolidBrush(Color.FromArgb(226, 232, 240)))
            {
                g.FillRoundedRectangle(trackBrush, rect, 6);
            }

            float percent = Maximum > 0 ? (float)Value / Maximum : 0;
            int fillWidth = (int)(rect.Width * percent);

            Color fillColor = percent < 0.70f ? UITheme.ColorEmpty :
                              percent <= 0.90f ? UITheme.ColorReserved : UITheme.ColorOccupied;

            if (fillWidth > 6)
            {
                using var fillBrush = new SolidBrush(fillColor);
                g.FillRoundedRectangle(fillBrush, new Rectangle(0, 0, fillWidth, rect.Height), 6);
            }

            string text = $"{Value}/{Maximum} xe ({(percent * 100):F0}%)";
            using var font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            var size = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.Black, (rect.Width - size.Width) / 2, (rect.Height - size.Height) / 2);
        }
    }

    // =========================================================================
    // 7. THẺ THỐNG KÊ CHỈ SỐ KPI (KPI CARD)
    // =========================================================================
    public class KpiCard : Panel
    {
        private Label lblTitle;
        private Label lblValue;
        private Label lblSubtext;
        private Color _accentColor;

        public KpiCard() : this("CHỈ SỐ KPI", "0", "Đang cập nhật dữ liệu", UITheme.Primary)
        {
        }

        public KpiCard(string title, string initialValue, string subtext, Color accentColor)
        {
            _accentColor = accentColor;
            Size = new Size(245, 105);
            BackColor = Color.White;
            Margin = new Padding(8);
            Padding = new Padding(14, 12, 14, 12);
            DoubleBuffered = true;

            lblTitle = new Label
            {
                Text = title.ToUpper(),
                Font = new Font("Segoe UI", 8.25f, FontStyle.Bold),
                ForeColor = UITheme.TextMuted,
                Dock = DockStyle.Top,
                Height = 18
            };

            lblValue = new Label
            {
                Text = initialValue,
                Font = new Font("Segoe UI", 16.5f, FontStyle.Bold),
                ForeColor = UITheme.TextDark,
                Dock = DockStyle.Top,
                Height = 34
            };

            lblSubtext = new Label
            {
                Text = subtext,
                Font = new Font("Segoe UI", 8.25f, FontStyle.Regular),
                ForeColor = UITheme.TextMuted,
                Dock = DockStyle.Bottom,
                Height = 20
            };

            Controls.Add(lblSubtext);
            Controls.Add(lblValue);
            Controls.Add(lblTitle);

            Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var r = new Rectangle(0, 0, Width - 1, Height - 1);
                using (var pen = new Pen(UITheme.CardBorder, 1))
                {
                    g.DrawRoundedRectangle(pen, r, 10);
                }

                // Dải nhấn màu sắc bên trái
                using (var brush = new SolidBrush(_accentColor))
                {
                    g.FillRoundedRectangle(brush, new Rectangle(0, 0, 5, Height - 1), 2);
                }
            };
        }

        public void Configure(string title, string initialValue, string subtext, Color accentColor)
        {
            lblTitle.Text = title.ToUpper();
            lblValue.Text = initialValue;
            lblSubtext.Text = subtext;
            _accentColor = accentColor;
            Invalidate();
        }

        public void UpdateValue(string value, string? subtext = null)
        {
            lblValue.Text = value;
            if (subtext != null) lblSubtext.Text = subtext;
        }
    }

    // =========================================================================
    // 8. ĐỊNH DẠNG DATAGRIDVIEW CHUẨN MÔN LTTQ & HIỆN ĐẠI
    // =========================================================================
    public static class ModernGridHelper
    {
        public static void ApplyModernStyle(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(241, 245, 249);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tiêu đề cột
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 42;

            // Dòng dữ liệu
            dgv.RowTemplate.Height = 38;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138);
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);

            // Dòng xen kẽ (Zebra stripes)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138);
        }
    }

    // =========================================================================
    // 9. BỘ VẼ MENU & TOOLSTRIP HIỆN ĐẠI (MODERN FLAT MENU RENDERER)
    // =========================================================================
    public class ModernColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground => Color.White;
        public override Color ImageMarginGradientBegin => Color.White;
        public override Color ImageMarginGradientMiddle => Color.White;
        public override Color ImageMarginGradientEnd => Color.White;
        public override Color MenuBorder => Color.FromArgb(226, 232, 240);
        public override Color MenuItemBorder => Color.FromArgb(191, 219, 254);
        public override Color MenuItemSelected => Color.FromArgb(239, 246, 255);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(239, 246, 255);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(239, 246, 255);
        public override Color MenuStripGradientBegin => Color.White;
        public override Color MenuStripGradientEnd => Color.White;
        public override Color ToolStripGradientBegin => Color.FromArgb(248, 250, 252);
        public override Color ToolStripGradientMiddle => Color.FromArgb(248, 250, 252);
        public override Color ToolStripGradientEnd => Color.FromArgb(248, 250, 252);
        public override Color ToolStripBorder => Color.FromArgb(226, 232, 240);
        public override Color SeparatorDark => Color.FromArgb(226, 232, 240);
        public override Color SeparatorLight => Color.White;
        public override Color GripDark => Color.Transparent;
        public override Color GripLight => Color.Transparent;
        public override Color ButtonSelectedHighlight => Color.FromArgb(241, 245, 249);
        public override Color ButtonSelectedGradientBegin => Color.FromArgb(241, 245, 249);
        public override Color ButtonSelectedGradientMiddle => Color.FromArgb(241, 245, 249);
        public override Color ButtonSelectedGradientEnd => Color.FromArgb(241, 245, 249);
        public override Color ButtonSelectedBorder => Color.FromArgb(203, 213, 225);
        public override Color ButtonPressedHighlight => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientBegin => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientMiddle => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedGradientEnd => Color.FromArgb(219, 234, 254);
        public override Color ButtonPressedBorder => Color.FromArgb(147, 197, 253);
        public override Color StatusStripGradientBegin => Color.White;
        public override Color StatusStripGradientEnd => Color.White;
    }

    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernColorTable())
        {
            RoundedEdges = false;
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is StatusStrip)
            {
                using var p = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(p, 0, 0, e.ToolStrip.Width, 0);
            }
            else
            {
                using var p = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(p, 0, e.ToolStrip.Height - 1, e.ToolStrip.Width, e.ToolStrip.Height - 1);
            }
        }
    }
}
