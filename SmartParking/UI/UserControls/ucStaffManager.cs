using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SmartParking.Data;
using SmartParking.Models;
using SmartParking.UI.Common;

namespace SmartParking.UI.UserControls
{
    public partial class ucStaffManager : UserControl
    {
        private int selectedUserId = 0;

        public ucStaffManager()
        {
            InitializeComponent();
            SetupEvents();

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadStaffList();
        }

        private void SetupEvents()
        {
            ModernGridHelper.ApplyModernStyle(dgvStaff);
            dgvStaff.CellClick += DgvStaff_CellClick;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        private void LoadStaffList()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT UserID AS [ID], Username AS [Tên Đăng Nhập], FullName AS [Họ Và Tên], Role AS [Vai Trò], Phone AS [Số Điện Thoại], CASE WHEN IsActive = 1 THEN N'Hoạt động' ELSE N'Đã khóa' END AS [Trạng Thái] FROM Users;";
                dgvStaff.DataSource = cmd.ExecuteDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách nhân viên: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvStaff_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStaff.Rows[e.RowIndex];
            selectedUserId = Convert.ToInt32(row.Cells["ID"].Value);
            txtUsername.Text = row.Cells["Tên Đăng Nhập"].Value.ToString();
            txtFullName.Text = row.Cells["Họ Và Tên"].Value.ToString();
            txtPhone.Text = row.Cells["Số Điện Thoại"].Value?.ToString() ?? "";
            cboRole.SelectedItem = row.Cells["Vai Trò"].Value.ToString();
            chkActive.Checked = row.Cells["Trạng Thái"].Value.ToString() == "Hoạt động";
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Users (Username, Password, FullName, Role, Phone, IsActive)
                    VALUES (@User, @Pass, @Name, @Role, @Phone, @Active);
                ";
                cmd.Parameters.AddWithValue("@User", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@Pass", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem?.ToString() ?? "Staff");
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Active", chkActive.Checked ? 1 : 0);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm nhân viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (selectedUserId == 0) return;
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Users 
                    SET FullName = @Name, Role = @Role, Phone = @Phone, IsActive = @Active
                    " + (!string.IsNullOrWhiteSpace(txtPassword.Text) ? ", Password = @Pass " : "") + @"
                    WHERE UserID = @ID;
                ";
                cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Role", cboRole.SelectedItem?.ToString() ?? "Staff");
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Active", chkActive.Checked ? 1 : 0);
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@Pass", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@ID", selectedUserId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (selectedUserId == 0) return;
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Users SET IsActive = 0 WHERE UserID = @ID;";
                cmd.Parameters.AddWithValue("@ID", selectedUserId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã khóa tài khoản nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaffList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
