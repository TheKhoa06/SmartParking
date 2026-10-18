using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SmartParking.Data
{
    /// <summary>
    /// LỚP XỬ LÝ CƠ SỞ DỮ LIỆU CHUẨN GIÁO TRÌNH LẬP TRÌNH TRỰC QUAN (UTC)
    /// Đóng gói các thao tác ADO.NET: SqlConnection, SqlCommand, SqlDataAdapter, DataTable
    /// </summary>
    public class ProcessDatabase
    {
        private string strConnect;
        private SqlConnection? con = null;

        public ProcessDatabase()
        {
            var setting = ConfigurationManager.ConnectionStrings["SmartParkingDB"];
            if (setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString))
            {
                strConnect = setting.ConnectionString;
            }
            else
            {
                strConnect = @"Data Source=.\SQLEXPRESS;Initial Catalog=SmartParkingDB;Integrated Security=True;TrustServerCertificate=True;";
            }
        }

        public ProcessDatabase(string connectionString)
        {
            strConnect = connectionString;
        }

        // 1. Mở kết nối CSDL (Open Connection)
        public void KetNoi()
        {
            if (con == null)
                con = new SqlConnection(strConnect);

            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        // 2. Đóng kết nối CSDL (Close Connection)
        public void DongKetNoi()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }

        // 3. Đọc dữ liệu ra bảng DataTable (Dùng SqlDataAdapter & SqlCommand)
        public DataTable DocBang(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                DongKetNoi();
            }
            return dt;
        }

        // 4. Đọc dữ liệu có tham số (Tránh tấn công SQL Injection)
        public DataTable DocBang(string sql, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            finally
            {
                DongKetNoi();
            }
            return dt;
        }

        // 5. Cập nhật dữ liệu (Thêm, Sửa, Xóa - ExecuteNonQuery)
        public int CapNhatDuLieu(string sql)
        {
            int rowsAffected = 0;
            try
            {
                KetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
            return rowsAffected;
        }

        // 6. Cập nhật dữ liệu có tham số
        public int CapNhatDuLieu(string sql, SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            try
            {
                KetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
            return rowsAffected;
        }

        // 7. Lấy giá trị đơn lẻ (ExecuteScalar)
        public object? LayGiaTri(string sql, SqlParameter[]? parameters = null)
        {
            object? result = null;
            try
            {
                KetNoi();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    result = cmd.ExecuteScalar();
                }
            }
            finally
            {
                DongKetNoi();
            }
            return result;
        }

        // 8. Lấy chuỗi kết nối hiện hành
        public string GetConnectionString()
        {
            return strConnect;
        }
    }
}
