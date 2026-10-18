using System;
using System.Windows.Forms;
using SmartParking.Data;
using SmartParking.UI.Forms;

namespace SmartParking
{
    static class Program
    {
        /// <summary>
        /// Điểm bắt đầu chính của ứng dụng C# Windows Forms (.NET Framework 4.8).
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(int dpiFlag);

        [System.Runtime.InteropServices.DllImport("SHCore.dll")]
        private static extern bool SetProcessDpiAwareness(int awareness);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetProcessDpiAwarenessContext(-4); // DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2
                }
            }
            catch
            {
                try { SetProcessDpiAwareness(2); } // Process_Per_Monitor_DPI_Aware
                catch { try { SetProcessDPIAware(); } catch { } }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Tự động kiểm tra và khởi tạo Database trên Microsoft SQL Server
            try
            {
                DatabaseHelper.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 2. Chạy Form Đăng Nhập
            Application.Run(new frmLogin());
        }
    }
}