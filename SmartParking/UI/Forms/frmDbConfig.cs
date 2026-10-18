using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.UI.Common;

namespace SmartParking.UI.Forms
{
    public partial class frmDbConfig : Form
    {
        public frmDbConfig()
        {
            InitializeComponent();
            SetupEvents();
            LoadCurrentSettings();
        }

        private void SetupEvents()
        {
            rbWindowsAuth.CheckedChanged += (s, e) =>
            {
                pnlSqlAuth.Enabled = rbSqlAuth.Checked;
                rbWindowsAuth.Font = new Font("Segoe UI", 9f, rbWindowsAuth.Checked ? FontStyle.Bold : FontStyle.Regular);
                rbWindowsAuth.ForeColor = rbWindowsAuth.Checked ? UITheme.Primary : UITheme.TextDark;
                rbSqlAuth.Font = new Font("Segoe UI", 9f, rbSqlAuth.Checked ? FontStyle.Bold : FontStyle.Regular);
                rbSqlAuth.ForeColor = rbSqlAuth.Checked ? UITheme.Primary : UITheme.TextDark;
            };

            rbSqlAuth.CheckedChanged += (s, e) =>
            {
                pnlSqlAuth.Enabled = rbSqlAuth.Checked;
            };

            btnAutoDetect.Click += (s, e) => RunAutoDetect();
            btnTest.Click += (s, e) => TestCurrentConnection();
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => Close();
        }

        private void LoadCurrentSettings()
        {
            cboServer.Items.Clear();
            string machineName = Environment.MachineName;

            cboServer.Items.Add(".");
            cboServer.Items.Add(@".\SQLEXPRESS");
            cboServer.Items.Add("(local)");
            cboServer.Items.Add("localhost");
            cboServer.Items.Add(machineName);
            cboServer.Items.Add($@"{machineName}\SQLEXPRESS");
            cboServer.Items.Add(@"(localdb)\MSSQLLocalDB");

            try
            {
                var builder = new SqlConnectionStringBuilder(DatabaseHelper.ConnectionString);
                cboServer.Text = builder.DataSource;
                txtDatabase.Text = string.IsNullOrWhiteSpace(builder.InitialCatalog) ? "SmartParkingDB" : builder.InitialCatalog;

                if (builder.IntegratedSecurity)
                {
                    rbWindowsAuth.Checked = true;
                }
                else
                {
                    rbSqlAuth.Checked = true;
                    txtUser.Text = builder.UserID;
                    txtPassword.Text = builder.Password;
                }
            }
            catch
            {
                cboServer.SelectedIndex = 0;
            }
        }

        private string BuildConnectionString(bool toMaster = false)
        {
            string srv = cboServer.Text.Trim();
            if (string.IsNullOrWhiteSpace(srv)) srv = ".";
            string db = toMaster ? "master" : txtDatabase.Text.Trim();
            if (string.IsNullOrWhiteSpace(db)) db = "SmartParkingDB";

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = srv,
                InitialCatalog = db,
                TrustServerCertificate = true,
                ConnectTimeout = 4
            };

            if (rbWindowsAuth.Checked)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtUser.Text.Trim();
                builder.Password = txtPassword.Text;
            }

            return builder.ConnectionString;
        }

        private bool TestCurrentConnection()
        {
            lblStatus.Text = "⏳ Đang kiểm tra kết nối...";
            lblStatus.ForeColor = Color.FromArgb(71, 85, 105);
            lblStatus.BackColor = Color.FromArgb(241, 245, 249);
            Application.DoEvents();

            string connStr = BuildConnectionString(false);

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                }
                lblStatus.Text = $"🟢 KẾT NỐI THÀNH CÔNG! Đã kết nối đến '{cboServer.Text.Trim()}' (DB: {txtDatabase.Text.Trim()}).";
                lblStatus.ForeColor = UITheme.SuccessText;
                lblStatus.BackColor = UITheme.SuccessLight;
                return true;
            }
            catch (Exception ex)
            {
                // Thử kết nối đến master nếu DB chưa tạo
                string masterStr = BuildConnectionString(true);
                try
                {
                    using (var mConn = new SqlConnection(masterStr))
                    {
                        mConn.Open();
                    }
                    lblStatus.Text = $"🟡 KẾT NỐI MÁY CHỦ THÀNH CÔNG! (DB '{txtDatabase.Text.Trim()}' sẽ được tự động tạo khi bấm Lưu).";
                    lblStatus.ForeColor = UITheme.WarningText;
                    lblStatus.BackColor = UITheme.WarningLight;
                    return true;
                }
                catch
                {
                    lblStatus.Text = $"🔴 THẤT BẠI: {ex.Message}";
                    lblStatus.ForeColor = UITheme.DangerText;
                    lblStatus.BackColor = UITheme.DangerLight;
                    return false;
                }
            }
        }

        private void RunAutoDetect()
        {
            lblStatus.Text = "⏳ Đang quét các instance SQL Server trên máy...";
            lblStatus.ForeColor = UITheme.Primary;
            Application.DoEvents();

            string workingInstance = DatabaseHelper.FindWorkingInstance();
            if (!string.IsNullOrEmpty(workingInstance))
            {
                cboServer.Text = workingInstance;
                rbWindowsAuth.Checked = true;
                lblStatus.Text = $"🟢 ĐÃ TÌM THẤY SQL SERVER HOẠT ĐỘNG: '{workingInstance}'!";
                lblStatus.ForeColor = UITheme.SuccessText;
                lblStatus.BackColor = UITheme.SuccessLight;
            }
            else
            {
                lblStatus.Text = "🔴 Không tìm thấy instance SQL Server nào khả dụng. Vui lòng kiểm tra Services hoặc nhập thủ công.";
                lblStatus.ForeColor = UITheme.DangerText;
                lblStatus.BackColor = UITheme.DangerLight;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!TestCurrentConnection())
            {
                if (MessageBox.Show("Kết nối hiện tại chưa thành công! Bạn có chắc chắn muốn lưu cấu hình này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
            }

            string finalConnStr = BuildConnectionString(false);
            DatabaseHelper.SaveConnectionString(finalConnStr);

            try
            {
                DatabaseHelper.InitializeDatabase();
                MessageBox.Show("ĐÃ LƯU CẤU HÌNH & KHỞI TẠO CƠ SỞ DỮ LIỆU THÀNH CÔNG!\n\nPhần mềm đã sẵn sàng hoạt động.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo CSDL: {ex.Message}", "Lỗi Khởi Tạo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
