using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BTL_HSK_QLS.Entities;

namespace BTL_HSK_QLS.DAO
{
    class QLDTNhanVien
    {
        //Hàm dùng chung
        string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
        private SqlConnection connection;
        public QLDTNhanVien()
        {
            string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;

            connection = new SqlConnection(constr);
        }
        // Phương thức mwor kết nối
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
        //
        public DataTable layDSNhanVien(string constr, string sqlcmd, string datatb)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable(datatb);
                        ad.Fill(tb);
                        return tb;
                    }
                }
            }
        }
        // phương thức thêm nhân viên
        public bool Them_NV(string constr, NhanVien nhanVien)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Insert_NV";
                    cmd.Parameters.AddWithValue("@sMaNV", nhanVien.smanv);
                    cmd.Parameters.AddWithValue("@sTenNV", nhanVien.stennv);
                    cmd.Parameters.AddWithValue("@sGioiTinh", nhanVien.sgioitinh);
                    cmd.Parameters.AddWithValue("@iTuoi", nhanVien.ituoi);
                    cmd.Parameters.AddWithValue("@sSDT", nhanVien.ssdt);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }


        }
        //Phương thức update nhân viên
        public bool updateNhanVien(NhanVien nhanVien)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_UpdateNhanVien", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaNV", nhanVien.smanv);
            cmd.Parameters.AddWithValue("@sTenNV", nhanVien.stennv);
            cmd.Parameters.AddWithValue("@sGioiTinh", nhanVien.sgioitinh);
            cmd.Parameters.AddWithValue("@dTuoi", nhanVien.ituoi);
            cmd.Parameters.AddWithValue("@sSDT", nhanVien.ssdt);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức delete khách hàng
        public bool deleteNhanVien(NhanVien nhanVien)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("Sp_DeleteNhanVien", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaNV", nhanVien.smanv);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức tìm kiếm 
        public DataTable searchNhanVien(NhanVien nhanVien)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Mở kết nối
                connection.Open();

                // Tạo command để thực hiện câu truy vấn
                SqlCommand command = new SqlCommand("sp_SearchNhanVien", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Thêm tham số
                command.Parameters.AddWithValue("@sMaNV", nhanVien.smanv);
                command.Parameters.AddWithValue("@sTenNV", nhanVien.stennv);
                command.Parameters.AddWithValue("@sGioiTinh", nhanVien.sgioitinh);
                command.Parameters.AddWithValue("@dTuoi", nhanVien.ituoi);
                command.Parameters.AddWithValue("@sSDT", nhanVien.ssdt);

                // Sử dụng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                MessageBox.Show(adapter.ToString());
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                throw ex;
            }
            finally
            {
                // Đảm bảo luôn đóng kết nối sau khi sử dụng
                connection.Close();
            }

            return dataTable;
        }
        //check trùng mã nhân viên
        public bool Check_MNV(string constr, string MaSV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select*from tblnhanvien", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["smanv"].Equals(MaSV))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        //check trùng sđt
        public bool Check_SDT(string constr, string MaSV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select*from tblnhanvien", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["ssdt"].Equals(MaSV))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
    }
}
