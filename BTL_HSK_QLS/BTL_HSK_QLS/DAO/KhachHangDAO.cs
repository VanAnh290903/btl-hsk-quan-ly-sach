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
    class KhachHangDAO
    {
        private SqlConnection connection;

        public KhachHangDAO()
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

        //Phương thức insert khách hàng
        public bool insertKhachHang(KhachHang khachHang)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("Sp_InsertKhachHang", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaKH", khachHang.sMaKH);
            cmd.Parameters.AddWithValue("@sTenKH", khachHang.sTenKH);
            cmd.Parameters.AddWithValue("@sSdt", khachHang.sSdt);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức update khách hàng
        public bool updateKhachHang(KhachHang khachHang)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_UpdateKhachHang", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaKH", khachHang.sMaKH);
            cmd.Parameters.AddWithValue("@sTenKH", khachHang.sTenKH);
            cmd.Parameters.AddWithValue("@sSdt", khachHang.sSdt);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức delete khách hàng
        public bool deleteKhachHang(KhachHang khachHang)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("Sp_DeleteKhachHang", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaKH", khachHang.sMaKH);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Phương thức lấy all khách hàng
        public DataTable getAllKhachHang()
        {
            openConnection();
            DataTable dtTaiKhoan = new DataTable();
            string query = "SELECT * FROM vv_getKhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dtTaiKhoan);
            closeConnection();
            return dtTaiKhoan;
        }
        //Phương thức tìm kiếm 
        public DataTable searchKhachHang(KhachHang khachHang)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Mở kết nối
                connection.Open();

                // Tạo command để thực hiện câu truy vấn
                SqlCommand command = new SqlCommand("sp_SearchKhachHang", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Thêm tham số
                command.Parameters.AddWithValue("@sMaKH", khachHang.sMaKH);
                command.Parameters.AddWithValue("@sTenKH", khachHang.sTenKH);
                command.Parameters.AddWithValue("@sSdt", khachHang.sSdt);

                // Sử dụng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
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
        // check trùng mac khsch nhàng 
        public bool Check_MKH(string constr, string MaKH)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select*from tblkhachhang", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["smakh"].Equals(MaKH))
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
