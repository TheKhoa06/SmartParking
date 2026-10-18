using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.UI.Common;

namespace SmartParking.UI.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            SetupEvents();
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
        }

        private void SetupEvents()
        {
            btnLogin.Click += BtnLogin_Click;
            btnQuickAdmin.Click += (s, e) => { txtUsername.Text = "admin"; txtPassword.Text = "123456"; btnLogin.PerformClick(); };
            btnQuickKhoa.Click += (s, e) => { txtUsername.Text = "khoa"; txtPassword.Text = "123456"; btnLogin.PerformClick(); };
            btnQuickVinh.Click += (s, e) => { txtUsername.Text = "vinh"; txtPassword.Text = "123456"; btnLogin.PerformClick(); };

            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            lnkDbConfig.Click += (s, e) =>
            {
                var cfg = new frmDbConfig();
                cfg.ShowDialog();
            };

            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) BtnLogin_Click(s, e);
            };

            toolTip.SetToolTip(lnkDbConfig, "Cấu hình lại máy chủ SQL Server (Instance, Xác thực Windows/sa)");

            toolTip.SetToolTip(btnLogin, "Đăng nhập vào hệ thống SmartParking");
            toolTip.SetToolTip(btnQuickAdmin, "Tài khoản Quản trị viên: Có toàn quyền xem sơ đồ, cấu hình bảng giá, quản lý nhân viên");
            toolTip.SetToolTip(btnQuickKhoa, "Tài khoản Nhân viên trực cổng vào/ra, quét biển số");
            toolTip.SetToolTip(btnQuickVinh, "Tài khoản Nhân viên: Xử lý mất vé, xe quá hạn, xem báo cáo");

            pnlHero.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using var brush = new LinearGradientBrush(
                    pnlHero.ClientRectangle,
                    Color.FromArgb(15, 23, 42),
                    Color.FromArgb(30, 41, 59),
                    LinearGradientMode.Vertical);
                g.FillRectangle(brush, pnlHero.ClientRectangle);

                using var circleBrush = new SolidBrush(Color.FromArgb(18, 37, 99, 235));
                g.FillEllipse(circleBrush, -50, -50, 260, 260);
            };

            pnlDivider.Paint += (s, e) =>
            {
                int lineY = pnlDivider.Height / 2;
                int gapLeft = Math.Max(0, lblQuickDemo.Left - 10);
                int gapRight = Math.Min(pnlDivider.Width, lblQuickDemo.Right + 10);
                using var pen = new Pen(UITheme.CardBorder, 1);
                if (gapLeft > 0) e.Graphics.DrawLine(pen, 0, lineY, gapLeft, lineY);
                if (gapRight < pnlDivider.Width) e.Graphics.DrawLine(pen, gapRight, lineY, pnlDivider.Width, lineY);
            };

            pnlBadge.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var p = new Pen(Color.FromArgb(70, 255, 255, 255), 1);
                e.Graphics.DrawRoundedRectangle(p, new Rectangle(0, 0, pnlBadge.Width - 1, pnlBadge.Height - 1), 8);
            };
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            errorProvider.Clear();

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(user))
            {
                errorProvider.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                errorProvider.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                txtPassword.Focus();
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT UserID, Username, Password, FullName, Role, Phone, IsActive FROM Users WHERE Username = @U AND Password = @P;";
                cmd.Parameters.AddWithValue("@U", user);
                cmd.Parameters.AddWithValue("@P", pass);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bool isActive = Convert.ToInt32(reader["IsActive"]) == 1;
                    if (!isActive)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị khóa! Vui lòng liên hệ Quản trị viên.", "Khóa tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var loggedUser = new User
                    {
                        UserID = reader.GetInt32(0),
                        Username = reader["Username"].ToString()!,
                        FullName = reader["FullName"].ToString()!,
                        Role = reader["Role"].ToString()!,
                        Phone = reader["Phone"]?.ToString() ?? "",
                        IsActive = true
                    };

                    Hide();
                    var mainForm = new frmMain(loggedUser);
                    mainForm.FormClosed += (s, args) => Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu! Vui lòng thử lại.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(
                    $"Lỗi kết nối CSDL khi đăng nhập:\n{ex.Message}\n\nBạn có muốn mở hộp thoại Cấu hình SQL Server để chọn lại máy chủ không?",
                    "Lỗi Kết Nối CSDL",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var cfg = new frmDbConfig();
                    cfg.ShowDialog();
                }
            }
        }
    }
}
