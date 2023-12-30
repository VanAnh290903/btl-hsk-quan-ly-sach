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
    class HoaDonDAO
    {
        private SqlConnection connection;

        public HoaDonDAO()
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
        // phương thức lấy all Hóa đơn 
        public DataTable getAllHoaDon()
        {
            openConnection();
            DataTable dtHoaDon = new DataTable();
            string query = "SELECT * FROM vv_getKhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dtHoaDon);
            closeConnection();
            return dtHoaDon;
        }
        // phương thức lấy all Hóa đơn chi tiết
        public DataTable getAllHoaDonChiTiet()
        {
            openConnection();
            DataTable dtHoaDonCT = new DataTable();
            string query = "SELECT * FROM vv_getKhachHang";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dtHoaDonCT);
            closeConnection();
            return dtHoaDonCT;
        }
        // Phương thức lấy danh sách hóa đơn 
        public DataTable getAllDSHoaDon()
        {
            openConnection();
            DataTable dataHoaDon = new DataTable();
            string query = "SELECT * FROM v_DSHoaDon";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataHoaDon);
            closeConnection();
            return dataHoaDon;
        }
        public List<Sach> getSach()
        {
            List<Sach> sachs = new List<Sach>();
            openConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM tblSach where isoluongtrongkho > 0", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            closeConnection();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Sach sach = new Sach();
                sach.sMaSach = row["smasach"].ToString();
                sach.sTenSach = row["stensach"].ToString();
                sach.sTenTacGia = row["stentacgia"].ToString();
                sach.sNXB = row["sNXB"].ToString();
                sach.sMaLoaiSach = row["smaloaisach"].ToString();
                sach.iSoLuongTrongKho = int.Parse(row["isoluongtrongkho"].ToString());
                sachs.Add(sach);
            }

            return sachs;
        }
        public List<KhachHang> getKhachHang()
        {
            List<KhachHang> khachHangs = new List<KhachHang>();
            openConnection();
            SqlCommand command = new SqlCommand("SELECT * FROM tblkhachhang", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            closeConnection();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.sMaKH = row["smakh"].ToString();
                khachHang.sTenKH = row["stenkh"].ToString();
                khachHang.sSdt = row["ssdt"].ToString();
                khachHangs.Add(khachHang);
            }

            return khachHangs;
        }
        public bool insertHoaDon(HoaDon hoaDon)
        {
            try
            {
                openConnection();


                SqlCommand cmd = new SqlCommand("sp_InsertHoaDon", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sMaHD", hoaDon.sMaHD);
                cmd.Parameters.AddWithValue("@sMaNV", hoaDon.sMaNV);
                cmd.Parameters.AddWithValue("@sMaKH", hoaDon.sMaKH);
                cmd.Parameters.AddWithValue("@dNgayLap", hoaDon.dNgayLap);
                cmd.Parameters.AddWithValue("@iTongTien", hoaDon.iTongTien);
                cmd.Parameters.AddWithValue("@iTrangThai", hoaDon.iTrangThai);
                int result = cmd.ExecuteNonQuery();
                closeConnection();
                return result > 0;
            }
            catch (Exception ex) { return false; }

            
        }
        public bool InsertListHoaDonChiTiet(List<HoaDonChiTiet> listHoaDonChiTiet)
        {
            string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO tblCTHD  VALUES (@sMaHD, @sMaSach, @iSoLuong, @fThanhTien, @fDonGia)", conn, tran);
                    foreach (var hoadonchitiet in listHoaDonChiTiet)
                    {
                        cmdInsert.Parameters.Clear();
                        cmdInsert.Parameters.AddWithValue("@sMaHD", hoadonchitiet.sMaHD);
                        cmdInsert.Parameters.AddWithValue("@sMaSach", hoadonchitiet.sMaSach);
                        cmdInsert.Parameters.AddWithValue("@iSoLuong", hoadonchitiet.iSoLuong);
                        cmdInsert.Parameters.AddWithValue("@fThanhTien", hoadonchitiet.fThanhTien);
                        cmdInsert.Parameters.AddWithValue("@fDonGia", hoadonchitiet.fDonGia);

                        cmdInsert.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
        // sửa trạng thái của hóa đơn 
        public bool updateHoaDon(HoaDon hoaDon)
        {
            openConnection();
           
                SqlCommand cmd = new SqlCommand("sp_UpdateHoaDon", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sMaHD", hoaDon.sMaHD);
                cmd.Parameters.AddWithValue("@iTrangThai", hoaDon.iTrangThai);
                //cmd.Parameters.AddWithValue("@sSdt", khachHang.sSdt);
                int result = cmd.ExecuteNonQuery();
                closeConnection();
                return result > 0;
           
        }
        //Xóa hdct
        public bool deleteHoaDonCT(HoaDonChiTiet hoaDonChiTiet)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_DeleteHoaDonCT", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaHD", hoaDonChiTiet.sMaHD);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        // xóa hd

        public bool deleteHoaDon(HoaDon hoaDon)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand("sp_DeleteHoaDon", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sMaHD", hoaDon.sMaHD);

            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        //Xem hóa đơn chi tiết theo mã hóa đơn truyền vào 
        //public void getAllDSHoaDonCT(HoaDon hoaDonChiTiet)
        //{
        //    openConnection();
        //    SqlCommand cmd = new SqlCommand("sp_vDSHoaDonCT", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@sMaHD", hoaDonChiTiet.sMaHD);

        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
            
        //}
        //void check trạng thái hóa đơn

        // tìm kiếm hóa đơn theo trạng thái 
        public DataTable searchHoaDon(HoaDon hoaDon)
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Mở kết nối
                connection.Open();

                // Tạo command để thực hiện câu truy vấn
                SqlCommand command = new SqlCommand("sp_SearchHoaDon", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Thêm tham số
                command.Parameters.AddWithValue("@iTrangThai", hoaDon.iTrangThai);
                //command.Parameters.AddWithValue("@sTenKH", khachHang.sTenKH);
                //command.Parameters.AddWithValue("@sSdt", khachHang.sSdt);

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
        // sửa sl sách
        public bool updateSoLuongSach(string maSach, int soluongsachmua)
        {
            openConnection();

            SqlCommand cmd = new SqlCommand("sp_UpdateSoLuongSach", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maSach", maSach);
            cmd.Parameters.AddWithValue("@soluongsach", soluongsachmua);
            int result = cmd.ExecuteNonQuery();
            closeConnection();
            return result > 0;
        }
        // Lấy danh sách hóa đơn chi tiết
        public DataTable getDSHoaDonChiTiet(string maHoaDon)
        {
            openConnection();
            DataTable dataHoaDonCT = new DataTable();
            string query = "SELECT * FROM v_getHoaDonChiTiet where smahd = '"+maHoaDon+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataHoaDonCT);
            closeConnection();
            return dataHoaDonCT;
        }
        public bool checkTrangThaiHD(string maHoaDon)
        {
            bool trangThai = false;

            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand("SELECT iTrangThai FROM tblHD WHERE smahd = @maHoaDon", connection);
                cmd.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int iTrangThai))
                {
                    trangThai = iTrangThai > 0;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
            }
            finally
            {
                closeConnection();
            }

            return trangThai;
        }
    }
}
