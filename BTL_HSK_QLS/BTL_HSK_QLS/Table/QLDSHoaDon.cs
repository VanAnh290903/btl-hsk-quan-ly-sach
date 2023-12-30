using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_QLS.DAO;
using BTL_HSK_QLS.Entities;
using System.Configuration;
using BTL_HSK_QLS.Crystal_Report;

namespace BTL_HSK_QLS.Table
{
    public partial class QLDSHoaDon : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        public QLDSHoaDon()
        {
            InitializeComponent();
        }

        private void QLDSHoaDon_Load(object sender, EventArgs e)
        {
            load_allHoaDon();
            btnInHD.Enabled = false;
            btnTimKiemHD.Enabled = false;
            if(Properties.Settings.Default.Quyen=="admin")
            {
                btnSuaHD.Enabled = false;
                rbdChuaThanhToan.Enabled = false;
                rdbThanhToan.Enabled = false;
                btnAddHD.Visible = false;
                btnTimKiemHD.Enabled = false;
                btnXoaHD.Enabled = false;
            }
            else
            {
                btnSuaHD.Visible = false;
                rbdChuaThanhToan.Enabled = false;
                rdbThanhToan.Enabled = false;
                btnXoaHD.Enabled = false;

            }
        }

        private void dgvDSHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load_allHoaDon()
        {
            DataTable t = hoaDonDAO.getAllDSHoaDon();
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            dgvDSHoaDon.DataSource = t;
            dgvDSHoaDon.Columns["STT"].DisplayIndex = 0;
        }

        private void btnAddHD_Click(object sender, EventArgs e)
        {
            ((QuyenNV)this.ParentForm).loadHoaDon();
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.Quyen == "admin")
            //{
            //    btnSuaHD.Enabled = true;
            //    rbdChuaThanhToan.Enabled = true;
            //    rdbThanhToan.Enabled = true;
            //}
            //MessageBox.Show(dgvDSHoaDon.CurrentRow.Cells["Trạng thái"].Value.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgvDSHoaDon.CurrentRow.Cells["Trạng thái"].Value.ToString()=="Chưa thanh toán")
            {
                if (rdbThanhToan.Checked == true)
                {
                    HoaDon hoaDon = new HoaDon();
                    hoaDon.sMaHD = txtMaHD.Text.Trim();
                    if (rbdChuaThanhToan.Checked == true)
                        hoaDon.iTrangThai = 0;
                    else if (rdbThanhToan.Checked == true)
                        hoaDon.iTrangThai = 1;
                    bool res = hoaDonDAO.updateHoaDon(hoaDon);
                    if (res)
                    {
                        //load lại danh sách khách hàng 
                        load_allHoaDon();
                        //clearPhanTu();
                        MessageBox.Show("Cập nhật hóa đơn thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra khi cập nhật khách hàng, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }    
                    
            }    
            



        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoaDon = new HoaDon();
                //hoaDon.sMaKH = txtMaKH.Text.Trim();
                //khachHang.sTenKH = txtTenKH.Text.Trim();
                //khachHang.sSdt = txtSDT.Text.Trim();
                if(rbdChuaThanhToan.Checked==true)
                {
                    hoaDon.iTrangThai = 0;
                }
                else if(rdbThanhToan.Checked==true)
                {
                    hoaDon.iTrangThai = 1;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập điều kiện tìm kiếm!", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    // thêm dấu đỏ báo lỗi
                }


                DataTable dt = hoaDonDAO.searchHoaDon(hoaDon);

                // Bind the filtered DataTable to the DataGridView.
                dgvDSHoaDon.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgvDSHoaDon.CurrentRow.Cells["Mã hóa đơn"].Value.ToString();
            if(dgvDSHoaDon.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Chưa thanh toán")
            {
                rbdChuaThanhToan.Checked = true;
            }
            else { rdbThanhToan.Checked = true; }
            if(Properties.Settings.Default.Quyen == "admin")
            {
                if (dgvDSHoaDon.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Chưa thanh toán")
                {
                    btnSuaHD.Enabled = true;
                    btnXoaHD.Enabled = true;
                    btnInHD.Enabled = false;

                }
                else
                {
                    btnSuaHD.Enabled = false;
                    btnXoaHD.Enabled = false;
                    btnInHD.Enabled = true;
                }
            }   
            else if(Properties.Settings.Default.Quyen == "nhanvien")
            {
                if (dgvDSHoaDon.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Chưa thanh toán")
                {
                    //btnSuaHD.Enabled = true;
                    btnXoaHD.Enabled = true;
                    btnInHD.Enabled = false;
                }
                else
                {
                    btnSuaHD.Enabled = false;
                    btnXoaHD.Enabled = false;
                    btnInHD.Enabled = true;
                }
            }    
            
                
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có có chắc muốn xóa hóa đơn này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HoaDon hoaDon = new HoaDon();
                HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
                hoaDonChiTiet.sMaHD = txtMaHD.Text.Trim();
                hoaDon.sMaHD = txtMaHD.Text.Trim();
                bool resHDCT = hoaDonDAO.deleteHoaDonCT(hoaDonChiTiet);
                bool res = hoaDonDAO.deleteHoaDon(hoaDon);
                if (resHDCT)
                {
                    if (res)
                    {
                        //load lại danh sách khách hàng 
                        load_allHoaDon();
                        //clearPhanTu();
                        MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra khi xóa hóa đơn, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //else
                //{
                //    MessageBox.Show("Đã có lỗi sảy ra khi xóa hóa đơn, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
               
            }
        }

        private void btnNhapDL_Click(object sender, EventArgs e)
        {
            btnTimKiemHD.Enabled = true;
            txtMaHD.Text = "";
            rdbThanhToan.Checked = false;
            rbdChuaThanhToan.Checked = false;
            if(Properties.Settings.Default.Quyen == "admin")
            {
                btnSuaHD.Enabled = false;
                rbdChuaThanhToan.Enabled = true;
                rdbThanhToan.Enabled = true;
                btnAddHD.Visible = false;
                btnTimKiemHD.Enabled = true;
                btnXoaHD.Enabled = false;
                txtMaHD.Enabled = true;
            } 
            else
            {
                btnSuaHD.Enabled = false;
                rbdChuaThanhToan.Enabled = true;
                rdbThanhToan.Enabled = true;
                btnAddHD.Visible = true;
                btnTimKiemHD.Enabled = true;
                btnXoaHD.Enabled = false;
                txtMaHD.Enabled = true;
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            load_allHoaDon();
            if (Properties.Settings.Default.Quyen == "admin")
            {
                btnSuaHD.Enabled = false;
                rbdChuaThanhToan.Enabled = false;
                rdbThanhToan.Enabled = false;
                btnAddHD.Visible = false;
                btnTimKiemHD.Enabled = false;
                btnXoaHD.Enabled = false;
            }
            else
            {
                btnSuaHD.Enabled = false;
                rbdChuaThanhToan.Enabled = false;
                rdbThanhToan.Enabled = false;
            }
        }

        private void btnXemHDCT_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Quyen == "nhanvien")
            {
                ((QuyenNV)this.ParentForm).loadDSHDCT(txtMaHD.Text);
                //HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
                //hoaDonChiTiet.sMaHD = txtMaHD.Text.Trim();
            }    
            else if(Properties.Settings.Default.Quyen == "admin")
            {
                //string maHoaDon = txtMaHD.Text.Trim();
                //XemHoaDonChiTiet xemHoaDonChiTiet = new XemHoaDonChiTiet();
                //xemHoaDonChiTiet.laymahd(maHoaDon);
                ((formMain)this.ParentForm).loadHDCTinadmin(txtMaHD.Text);
            

                //hoaDonChiTiet.sMaHD = txtMaHD.Text.Trim();
            }    
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
            crystalReportViewer.loadHoaDonChiTiet( txtMaHD.Text);
            crystalReportViewer.ShowDialog();
        }
    }
}
