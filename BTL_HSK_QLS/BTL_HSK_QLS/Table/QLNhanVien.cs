using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using BTL_HSK_QLS.DAO;
using BTL_HSK_QLS.Entities;
using BTL_HSK_QLS.Crystal_Report;

namespace BTL_HSK_QLS.Table
{
    public partial class QLNhanVien : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;
        QLDTNhanVien qldtNhanVien = new QLDTNhanVien();

        public QLNhanVien()
        {
            InitializeComponent();
        }
        public void HienDSNhanVien()
        {
            DataTable t = qldtNhanVien.layDSNhanVien(constr, "select * from v_DSNV ", "v_DSNV");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
            {
                t.Rows[i]["STT"] = i + 1;
            }
            dtgrwNhanVien.DataSource = t;
            dtgrwNhanVien.Columns["STT"].DisplayIndex = 0;
            dtgrwNhanVien.Columns["STT"].Width = 3;

        }
        private void loadDataNV(DataTable dsTimkiem)
        {
            dtgrwNhanVien.DataSource = dsTimkiem;
        }
        private void ViewNhanVien()
        {
            dtgrwNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dtgrwNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dtgrwNhanVien.Columns[2].HeaderText = "Giới tính";
            dtgrwNhanVien.Columns[3].HeaderText = "Tuổi";
            dtgrwNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dtgrwNhanVien.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            //ẩn input
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtTuoiNV.Enabled = false;
            txtSDTNV.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            //ẩn btn
            btnSua.Enabled = false;
            btnTaiLai.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
            HienDSNhanVien();
            ViewNhanVien();
        }


        

        //private void btnNhap_Click(object sender, EventArgs e)
        //{
        //    txtMaNV.Enabled = true;
        //    txtTenNV.Enabled = true;
        //    txtTuoiNV.Enabled = true;
        //    txtSDTNV.Enabled = true;
        //    rdbNam.Enabled = true;
        //    rdbNu.Enabled = true;
        //    //hien btn
        //    btnSua.Enabled = true;
        //    btnTaiLai.Enabled = true;
        //    btnThem.Enabled = true;
        //    btnTimKiem.Enabled = true;
        //    btnXoa.Enabled = true;

        //}
       
        //private void txtMaNV_Validating(object sender, CancelEventArgs e)
        //{
        //    if (txtMaNV.Text == "")
        //    {
        //        errorProvider1.SetError(txtMaNV, "Không được để trống");
        //    }
        //    else errorProvider1.SetError(txtMaNV, "");
        //}
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        // nhập
        private void btnNhap_Click_1(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtTuoiNV.Enabled = true;
            txtSDTNV.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            //hien btn
            btnSua.Enabled = true;
            btnTaiLai.Enabled = true;
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = true;
        }
        // chọn dữ liệu 
        private void dtgrwNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        // Thêm 
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtTenNV.Text;
            DateTime tNV = txtTuoiNV.Value;
            string SDTNV = txtSDTNV.Text;
            errorloiQLNV.SetError(txtMaNV, "");
            
            
            if (maNV != "" && tenNV != "" && txtTuoiNV.Value != null && SDTNV != "")
            {
                
                if (qldtNhanVien.Check_MNV(constr, maNV))
                {
                    if (rdbNam.Checked == false && rdbNu.Checked == false)
                    {
                        MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtSDTNV.Text.Length == 10)
                        {
                            if (qldtNhanVien.Check_SDT(constr, SDTNV))
                            {
                                string GioiTinh = (rdbNam.Checked == true ? "Nam" : "Nữ"); 
                                NhanVien nhanVien = new NhanVien(maNV, tenNV, GioiTinh,SDTNV,tNV);
                                qldtNhanVien.Them_NV(constr, nhanVien);

                                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                HienDSNhanVien();
                                ViewNhanVien();
                                return;
                                //add vào tài khoản
                                // xử lý nút tải lại
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại mỗi nhân viên không được trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                        }
                        MessageBox.Show("Số điện thoại chỉ có 10 hoặc 11 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    //MessageBox.Show("Mã sinh viên không được trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorloiQLNV.SetError(txtMaNV, "Không trùng");
                    return;
                }

            }
            else
                MessageBox.Show("Vui lòng nhập dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        // tải lại

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtTuoiNV.Text = "";
            txtSDTNV.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtTuoiNV.Enabled = false;
            txtSDTNV.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            //ẩn btn
            btnSua.Enabled = false;
            btnTaiLai.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
            HienDSNhanVien();
            ViewNhanVien();
        }
        //        //bắt sự kiện khi click vào 1 cột dữ liệu, lấy ra hàng dữ liệu cần thiết và đưa lên from nhập

        private void dtgrwNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgrwNhanVien.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
            txtTenNV.Text = dtgrwNhanVien.CurrentRow.Cells["Tên nhân viên"].Value.ToString();
            txtTuoiNV.Text = dtgrwNhanVien.CurrentRow.Cells["Tuổi"].Value.ToString();
            txtSDTNV.Text = dtgrwNhanVien.CurrentRow.Cells["Số điện thoại"].Value.ToString();
            if (dtgrwNhanVien.CurrentRow.Cells["Giới tính"].Value.ToString() == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isVaildNhanVien())
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.smanv = txtMaNV.Text.Trim();
                nhanVien.stennv = txtTenNV.Text.Trim();
                nhanVien.ituoi = txtTuoiNV.Value;
                nhanVien.ssdt = txtSDTNV.Text.Trim();
                if(rdbNam.Checked==true)
                {
                    nhanVien.sgioitinh = "Nam";
                }    
                else
                {
                    nhanVien.sgioitinh = "Nữ";
                }
                string GioiTinh = (rdbNam.Checked == true ? "Nam" : "Nữ");
                bool res = qldtNhanVien.updateNhanVien(nhanVien);
                if (res)
                {
                    HienDSNhanVien();
                    ViewNhanVien();
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi cập nhật nhân viên, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool isVaildNhanVien()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã Nhân Viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Tên Nhân Viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDTNV.Text))
            {
                MessageBox.Show("Số điện thoại Nhân Viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTuoiNV.Text))
            {
                MessageBox.Show("Ngày sinh Nhân Viên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Chọn giới tính cho nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có có chắc muốn xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.smanv = txtMaNV.Text.Trim();

                bool res = qldtNhanVien.deleteNhanVien(nhanVien);
                if (res)
                {
                    //load lại danh sách khách hàng 
                    HienDSNhanVien();
                    ViewNhanVien();
                    MessageBox.Show("Xóa nhân viên thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi xóa nhân viên, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //try
            //{
                NhanVien nhanVien = new NhanVien();
                nhanVien.smanv = txtMaNV.Text.Trim();
                nhanVien.stennv = txtMaNV.Text.Trim();
                nhanVien.ituoi = txtTuoiNV.Value;
                nhanVien.ssdt = txtSDTNV.Text.Trim();
                string GioiTinh = (rdbNam.Checked == true ? "Nam" : "Nữ");

                DataTable dt = qldtNhanVien.searchNhanVien(nhanVien);

                // Bind the filtered DataTable to the DataGridView.
                dtgrwNhanVien.DataSource = dt;
            ViewNhanVien();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void rdbNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
            crystalReportViewer.loadCrystalReportNhanVien();
            crystalReportViewer.ShowDialog();
        }
    }
}
