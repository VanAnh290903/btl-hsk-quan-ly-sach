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

namespace BTL_HSK_QLS.Table
{
    public partial class QLKhachHang : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["db_QLS"].ConnectionString;

        private KhachHangDAO khachHangDAO = new KhachHangDAO();
        public QLKhachHang()
        {
            InitializeComponent();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            load_AllKhachHang();
            clearPhanTu();
        }
        //Lấy ra danh sách khách hàng
        private void load_AllKhachHang()
        {
            DataTable t = khachHangDAO.getAllKhachHang();
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            dtgrvKhachHang.DataSource = t;
            dtgrvKhachHang.Columns["STT"].DisplayIndex = 0;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            hienPhanTu();
            txtMaKH.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (isVaildKhachHang())
            {
                KhachHang khachHang = new KhachHang();
                if (khachHangDAO.Check_MKH(constr,khachHang.sMaKH))
                {
                    khachHang.sMaKH = txtMaKH.Text.Trim();
                    khachHang.sTenKH = txtTenKH.Text.Trim();
                    khachHang.sSdt = txtSDT.Text.Trim();

                    bool res = khachHangDAO.insertKhachHang(khachHang);
                    if (res)
                    {
                        //load lại danh sách khách hàng 
                        load_AllKhachHang();
                        clearPhanTu();
                        MessageBox.Show("Thêm khách hàng thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra khi thêm khách hàng, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else MessageBox.Show("Mã Khách hàng không được trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
        }
        //bắt sự kiện khi click vào 1 cột dữ liệu, lấy ra hàng dữ liệu cần thiết và đưa lên from nhập
        private void dtgrvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dtgrvKhachHang.CurrentRow.Cells["Mã khách hàng"].Value.ToString();
            txtTenKH.Text = dtgrvKhachHang.CurrentRow.Cells["Tên khách hàng"].Value.ToString();
            txtSDT.Text = dtgrvKhachHang.CurrentRow.Cells["Số điện thoại"].Value.ToString();

            txtMaKH.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isVaildKhachHang())
            {
                KhachHang khachHang = new KhachHang();
                khachHang.sMaKH = txtMaKH.Text.Trim();
                khachHang.sTenKH = txtTenKH.Text.Trim();
                khachHang.sSdt = txtSDT.Text.Trim();

                bool res = khachHangDAO.updateKhachHang(khachHang);
                if (res)
                {
                    //load lại danh sách khách hàng 
                    load_AllKhachHang();
                    clearPhanTu();
                    MessageBox.Show("Cập nhật khách hàng thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi cập nhật khách hàng, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có có chắc muốn xóa khách hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.sMaKH = txtMaKH.Text.Trim();

                bool res = khachHangDAO.deleteKhachHang(khachHang);
                if (res)
                {
                    //load lại danh sách khách hàng 
                    load_AllKhachHang();
                    clearPhanTu();
                    MessageBox.Show("Xóa khách hàng thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi xóa khách hàng, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang khachHang = new KhachHang();
                khachHang.sMaKH = txtMaKH.Text.Trim();
                khachHang.sTenKH = txtTenKH.Text.Trim();
                khachHang.sSdt = txtSDT.Text.Trim();

                DataTable dt = khachHangDAO.searchKhachHang(khachHang);

                // Bind the filtered DataTable to the DataGridView.
                dtgrvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            clearPhanTu();
            load_AllKhachHang();
        }
        private void hienPhanTu()
        {
            
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnTaiLai.Enabled = true;
            btnNhap.Enabled = true;
            txtMaKH.Text = txtTenKH.Text = txtSDT.Text = "";
        }
        private void clearPhanTu()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
            btnTaiLai.Enabled = false;
            btnNhap.Enabled = true;

        }
        //Check valid khách hàng
        private bool isVaildKhachHang()
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại khách hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Không cho phép nhập ký tự cách
            }
        }


        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTaiLai_Click_1(object sender, EventArgs e)
        {
            clearPhanTu();
            load_AllKhachHang();
        }
    }
}
