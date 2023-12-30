using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BTL_HSK_QLS.Entities;
namespace BTL_HSK_QLS.DAO
{
    class TaiKhoanDAO
    {
        private SqlConnection connection;

        public TaiKhoanDAO()
        {
            string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;

            connection = new SqlConnection(constr);
        }
        // Phương thức mở kết nối 
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        //Phương thức đóng kết nối
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        // Kiểm tra sđăng nhập 
        public TaiKhoanDangNhap kiemTraDangNhap(string sTaiKhoan, string sMatKhau)
        {
            openConnection();
            TaiKhoanDangNhap tkDangNhap = new TaiKhoanDangNhap();
            SqlCommand cmd = new SqlCommand("SP_KiemTraTaiKhoan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", sTaiKhoan);
            cmd.Parameters.AddWithValue("@matkhau", sMatKhau);

            SqlDataReader reader = cmd.ExecuteReader();// lấy một bản ghi
            while (reader.Read())
            {
                tkDangNhap.sTaiKhoan = reader["sTaiKhoan"].ToString();
                tkDangNhap.sMatKhau = reader["sMatKhau"].ToString();
                tkDangNhap.sQuyen = reader["sQuyen"].ToString();
                tkDangNhap.iTrangThai = (int)reader["iTrangThai"];
                tkDangNhap.FK_sMaNV = reader["FK_sMaNV"].ToString();
                tkDangNhap.sTenNV = reader["stennv"].ToString();
            }
            closeConnection();
            return tkDangNhap;
        }

        //Phương thức insert tài khoản
        public bool insertTaiKhoan(TaiKhoanDangNhap taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_InsertTaiKhoan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTaiKhoan", taikhoan.sTaiKhoan);
            cmd.Parameters.AddWithValue("@sMatKhau", taikhoan.sMatKhau);
            cmd.Parameters.AddWithValue("@sQuyen", taikhoan.sQuyen);
            cmd.Parameters.AddWithValue("@iTrangThai", taikhoan.iTrangThai);
            cmd.Parameters.AddWithValue("@FK_sMaNV", taikhoan.FK_sMaNV);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức update tài khoản
        public bool updateTaiKhoan(TaiKhoanDangNhap taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_UpdateTaiKhoan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTaiKhoan", taikhoan.sTaiKhoan);
            cmd.Parameters.AddWithValue("@sMatKhau", taikhoan.sMatKhau);
            cmd.Parameters.AddWithValue("@iTrangThai", taikhoan.iTrangThai);
            cmd.Parameters.AddWithValue("@FK_sMaNV", taikhoan.FK_sMaNV);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức delete tài khoản
        public bool deleteKhachHang(TaiKhoanDangNhap taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_DeleteTaiKhoan", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FK_sMaNV", taikhoan.FK_sMaNV);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức lấy nhân viên
        public List<NhanVien> getNhanVien()
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            openConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM v_DSNV left join tblDangNhap on FK_sMaNV = [Mã nhân viên] where FK_sMaNV is null", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            closeConnection();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.smanv = row["Mã nhân viên"].ToString();
                nhanVien.stennv = row["Tên nhân viên"].ToString();
                nhanViens.Add(nhanVien);
            }

            return nhanViens;
        }
        //Phương thức lấy all tài khoản nhân viên
        public DataTable getAllTaiKhoanNhanVien()
        {
            openConnection();
            DataTable dtTaiKhoan = new DataTable();
            string query = "SELECT * FROM v_DSTaiKhoan";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dtTaiKhoan);
            closeConnection();
            return dtTaiKhoan;
        }
        public bool checkTrungTaiKhoan(string taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("select * from tblDangNhap where sTaiKhoan = @sTaiKhoan", connection);
            cmd.Parameters.AddWithValue("@sTaiKhoan", taikhoan);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            return count > 0;
        }
        //Phương thức tìm kiếm 
        public DataTable searchTaiKhoan(TaiKhoanDangNhap taiKhoan)
        {
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_SearchTaiKhoan", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@sTaiKhoan", taiKhoan.sTaiKhoan);
                command.Parameters.AddWithValue("@iTrangThai", taiKhoan.iTrangThai);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
        //phương thức kiểm tra mật khẩu có trùng vs mật khẩu cũ hay không 
        public bool checkPassword(string txtPassword, string taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("select * from tblDangNhap where sMatKhau = @sMatKhau and sTaiKhoan = @sTaiKhoan", connection);
            cmd.Parameters.AddWithValue("@sMatKhau", txtPassword);
            cmd.Parameters.AddWithValue("@sTaiKhoan", taikhoan);

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            closeConnection();
            return count > 0;
        }
        //Phương thức đổi mật khẩu
        public bool updatePassword(string txtPassword, string taikhoan)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_UpdatePassWord", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sTaiKhoan", taikhoan);
            cmd.Parameters.AddWithValue("@sMatKhau", txtPassword);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
    }
}
