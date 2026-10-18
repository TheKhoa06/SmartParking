using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using SmartParking.UI.Common;

namespace SmartParking.Services
{
    public static class CameraService
    {
        public static string BitmapToBase64(Bitmap? bitmap)
        {
            if (bitmap == null) return string.Empty;
            using var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }

        public static Bitmap? Base64ToBitmap(string? base64)
        {
            if (string.IsNullOrWhiteSpace(base64)) return null;
            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                using var ms = new MemoryStream(bytes);
                return new Bitmap(ms);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Tạo khung hình giả lập camera giám sát an ninh với lớp phủ HUD nhận diện biển số AI công nghệ cao
        /// </summary>
        public static Bitmap CaptureCameraFrame(string plateNumber, string laneName, bool isFaceIncluded = false)
        {
            int width = 480;
            int height = 300;
            var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Nền camera bãi xe ngầm
            using (var brush = new LinearGradientBrush(new Rectangle(0, 0, width, height), Color.FromArgb(20, 25, 35), Color.FromArgb(10, 12, 18), 90f))
            {
                g.FillRectangle(brush, 0, 0, width, height);
            }

            // Đường chỉ dẫn làn xe (Làn đường phản quang)
            using (var lanePen = new Pen(Color.FromArgb(70, 245, 158, 11), 3) { DashStyle = DashStyle.Dash })
            {
                g.DrawLine(lanePen, 80, height, 180, 120);
                g.DrawLine(lanePen, width - 80, height, width - 180, 120);
            }

            // 2. Hình bóng phương tiện (Vehicle Body)
            using (var vehBrush = new SolidBrush(Color.FromArgb(50, 60, 75)))
            {
                g.FillRoundedRectangle(vehBrush, 130, 95, 220, 130, 16);
            }
            using (var roofBrush = new SolidBrush(Color.FromArgb(38, 46, 58)))
            {
                g.FillRoundedRectangle(roofBrush, 160, 70, 160, 50, 12);
            }

            // Đèn pha xe (Headlights)
            using (var headBrush = new SolidBrush(Color.FromArgb(200, 254, 243, 199)))
            {
                g.FillEllipse(headBrush, 145, 125, 32, 22);
                g.FillEllipse(headBrush, 303, 125, 32, 22);
            }

            // 3. Biển số xe thực tế
            var plateRect = new Rectangle(180, 160, 120, 42);
            using (var plateBg = new SolidBrush(Color.FromArgb(254, 252, 232))) // Nền vàng phản quang hoặc trắng
            {
                g.FillRoundedRectangle(plateBg, plateRect, 5);
            }
            g.DrawRoundedRectangle(new Pen(Color.FromArgb(15, 23, 42), 2), plateRect, 5);

            // Chữ số trên biển
            using (var plateFont = new Font("Consolas", 12f, FontStyle.Bold))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(string.IsNullOrWhiteSpace(plateNumber) ? "29X-???.??" : plateNumber, plateFont, Brushes.Black, plateRect, sf);
            }

            // 4. KHUNG HUD AI NHẬN DIỆN BIỂN SỐ PHÁT SÁNG (AI LPR BOUNDING BOX)
            var hudRect = new Rectangle(165, 145, 150, 72);
            using (var aiPen = new Pen(Color.FromArgb(52, 211, 153), 2)) // Emerald-400
            {
                // Vẽ 4 góc ngoặc [ ]
                int arm = 14;
                // Top-Left
                g.DrawLine(aiPen, hudRect.Left, hudRect.Top, hudRect.Left + arm, hudRect.Top);
                g.DrawLine(aiPen, hudRect.Left, hudRect.Top, hudRect.Left, hudRect.Top + arm);
                // Top-Right
                g.DrawLine(aiPen, hudRect.Right, hudRect.Top, hudRect.Right - arm, hudRect.Top);
                g.DrawLine(aiPen, hudRect.Right, hudRect.Top, hudRect.Right, hudRect.Top + arm);
                // Bottom-Left
                g.DrawLine(aiPen, hudRect.Left, hudRect.Bottom, hudRect.Left + arm, hudRect.Bottom);
                g.DrawLine(aiPen, hudRect.Left, hudRect.Bottom, hudRect.Left, hudRect.Bottom - arm);
                // Bottom-Right
                g.DrawLine(aiPen, hudRect.Right, hudRect.Bottom, hudRect.Right - arm, hudRect.Bottom);
                g.DrawLine(aiPen, hudRect.Right, hudRect.Bottom, hudRect.Right, hudRect.Bottom - arm);
            }

            // Nhãn AI
            using (var aiFont = new Font("Segoe UI", 7.5f, FontStyle.Bold))
            {
                using var badgeBg = new SolidBrush(Color.FromArgb(200, 16, 185, 129));
                g.FillRoundedRectangle(badgeBg, new Rectangle(hudRect.Left, hudRect.Top - 18, 125, 16), 3);
                g.DrawString("AI LPR: 99.8% CONF", aiFont, Brushes.White, hudRect.Left + 4, hudRect.Top - 17);
            }

            // 5. Khung chân dung nhận diện khuôn mặt (Nếu là màn hình mất vé)
            if (isFaceIncluded)
            {
                var faceRect = new Rectangle(215, 45, 52, 52);
                g.FillEllipse(Brushes.SandyBrown, faceRect);
                using var facePen = new Pen(Color.FromArgb(6, 182, 212), 2);
                g.DrawEllipse(facePen, faceRect);

                using var fTag = new Font("Segoe UI", 7f, FontStyle.Bold);
                using var faceBg = new SolidBrush(Color.FromArgb(180, 8, 145, 178));
                g.FillRoundedRectangle(faceBg, new Rectangle(205, 26, 72, 15), 3);
                g.DrawString("FACE ID 99%", fTag, Brushes.White, 208, 27);
            }

            // 6. Lớp phủ thông tin an ninh CCTV (HUD OSD)
            using (var bannerBrush = new SolidBrush(Color.FromArgb(180, 10, 15, 25)))
            {
                g.FillRectangle(bannerBrush, 0, 0, width, 28);
                g.FillRectangle(bannerBrush, 0, height - 24, width, 24);
            }

            using (var hudFont = new Font("Consolas", 8.5f, FontStyle.Bold))
            {
                // Góc trên trái
                g.DrawString($"● REC  CAM-01 [LIVE] - {laneName.ToUpper()}", hudFont, Brushes.LimeGreen, 8, 7);
                // Góc trên phải
                g.DrawString($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}", hudFont, Brushes.White, width - 175, 7);
                // Góc dưới
                g.DrawString("SMARTPARKING AI SECURITY v2.0 | 30 FPS | 1080p", hudFont, new SolidBrush(Color.FromArgb(148, 163, 184)), 8, height - 18);
            }

            return bmp;
        }
    }
}
