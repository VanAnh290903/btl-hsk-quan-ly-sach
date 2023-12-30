using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_QLS.Entities;
using BTL_HSK_QLS.DAO;
using BTL_HSK_QLS.Utilities;

namespace BTL_HSK_QLS.Table
{
    public partial class QLTaiKhoan : Form
    {
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public QLTaiKhoan()
        {
            InitializeComponent();
        }
        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            loadDetail(1);
            loadAddTaiKhoan();
            loadCbbNhanVien();
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            loadDetail(2);
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            loadDetail(1);
            loadAddTaiKhoan();
            loadCbbNhanVien();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isVaildTaiKhoan())
            {
                
                if (!taiKhoanDAO.checkTrungTaiKhoan(txtTaiKhoan.Text))
                {
                    TaiKhoanDangNhap taikhoan = new TaiKhoanDangNhap();
                    taikhoan.sTaiKhoan = txtTaiKhoan.Text.Trim();
                    taikhoan.sMatKhau = txtMatKhau.Text.Trim();
                    taikhoan.sQuyen = "nhanvien";
                    taikhoan.iTrangThai = (rabHoatDong.Checked == true ? 1 : 0);
                    taikhoan.FK_sMaNV = cbbNhanVien.SelectedValue?.ToString();

                    bool res = taiKhoanDAO.insertTaiKhoan(taikhoan);
                    if (res)
                    {
                        loadAddTaiKhoan();
                        loadDetail(1);
                        loadCbbNhanVien();
                        MessageBox.Show("Thêm Tài khoản thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra khi thêm tài khoản, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void dtgrvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaiKhoan.Text = dtgrvTaiKhoan.CurrentRow.Cells["Tài khoản"].Value.ToString();
            txtMatKhau.Text = "";
            rabHoatDong.Checked = (dtgrvTaiKhoan.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Hoạt động" ? true : false);
            rabKhoa.Checked = (dtgrvTaiKhoan.CurrentRow.Cells["Trạng thái"].Value.ToString() == "Khóa" ? true : false);

            NhanVien nhanVien = new NhanVien();
            nhanVien.smanv = dtgrvTaiKhoan.CurrentRow.Cells["smanv"].Value.ToString();
            nhanVien.stennv = dtgrvTaiKhoan.CurrentRow.Cells["Nhân viên"].Value.ToString();
            List<NhanVien> nhanViens = new List<NhanVien>();
            nhanViens.Add(nhanVien);
            cbbNhanVien.DataSource = nhanViens;
            loadDetail(3);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if(isVaildTaiKhoan(1))
            {
                TaiKhoanDangNhap taikhoan = new TaiKhoanDangNhap();
                taikhoan.sTaiKhoan = txtTaiKhoan.Text.Trim();
                taikhoan.sMatKhau = txtMatKhau.Text.Trim();
                taikhoan.iTrangThai = (rabHoatDong.Checked == true ? 1 : 0);
                taikhoan.FK_sMaNV = cbbNhanVien.SelectedValue?.ToString();

                bool res = taiKhoanDAO.updateTaiKhoan(taikhoan);
                if (res)
                {
                    loadAddTaiKhoan();
                    loadDetail(1);
                    loadCbbNhanVien();
                    MessageBox.Show("Sửa khách hàng thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi sửa tài khoản, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có có chắc muốn xóa tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TaiKhoanDangNhap taikhoan = new TaiKhoanDangNhap();
                taikhoan.FK_sMaNV = cbbNhanVien.SelectedValue?.ToString();

                bool res = taiKhoanDAO.deleteKhachHang(taikhoan);
                if (res)
                {
                    loadAddTaiKhoan();
                    loadDetail(1);
                    loadCbbNhanVien();
                    MessageBox.Show("Xóa tài khoản thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra khi xóa tài khoản, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanDangNhap taikhoan = new TaiKhoanDangNhap();
                taikhoan.sTaiKhoan = txtTaiKhoan.Text.Trim();
                taikhoan.iTrangThai = (rabHoatDong.Checked == true ? 1 : 0);

                DataTable dt = taiKhoanDAO.searchTaiKhoan(taikhoan);

                // Bind the filtered DataTable to the DataGridView.
                dt.Columns.Add("STT");
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["STT"] = i + 1;
                dtgrvTaiKhoan.DataSource = dt;
                dtgrvTaiKhoan.Columns["STT"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDetail(int mode)
        {
            if (mode == 1)
            {
                
                txtTaiKhoan.Enabled = false;
                txtMatKhau.Enabled = false;
                rabHoatDong.Enabled = false;
                rabKhoa.Enabled = false;
                cbbNhanVien.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = false;
                btnNhap.Enabled = true;
            } else if (mode == 2)
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
                rabHoatDong.Enabled = true;
                rabKhoa.Enabled = true;
                cbbNhanVien.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnTimKiem.Enabled = true;
                btnNhap.Enabled = false;
            } else if (mode == 3)
            {
                txtTaiKhoan.Enabled = true;
                txtMatKhau.Enabled = true;
                rabHoatDong.Enabled = true;
                rabKhoa.Enabled = true;
                cbbNhanVien.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = false;
                btnNhap.Enabled = false;
            }
            txtTaiKhoan.Text = txtMatKhau.Text = "";
            rabHoatDong.Checked = false;
            rabKhoa.Checked = false;
        }
        private void loadCbbNhanVien()
        {
            cbbNhanVien.DisplayMember = "stennv";
            cbbNhanVien.ValueMember = "smanv";

            List<NhanVien> nhanViens = taiKhoanDAO.getNhanVien();
            cbbNhanVien.DataSource = nhanViens;
        }
        private void loadAddTaiKhoan()
        {
            DataTable t = taiKhoanDAO.getAllTaiKhoanNhanVien();
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            dtgrvTaiKhoan.DataSource = t;
            dtgrvTaiKhoan.Columns["STT"].DisplayIndex = 0; 
            dtgrvTaiKhoan.Columns["smanv"].Visible = false; 
            foreach (DataGridViewColumn column in dtgrvTaiKhoan.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
        private bool isVaildTaiKhoan(int ngoaiLe = 0)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                return false;
            }
            if (ngoaiLe == 0)
            {
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                    return false;
                }
                if (!CheckValid.IsPasswordValid(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                    return false;
                }
            } 
            else
            {
                if (txtMatKhau.Text != "")
                {
                    if (!CheckValid.IsPasswordValid(txtMatKhau.Text))
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                        return false;
                    }
                }
            }
            
            if (rabHoatDong.Checked == false && rabKhoa.Checked == false)
            {
                MessageBox.Show("Trạng thái không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbbNhanVien.SelectedIndex == -1) 
            {
                MessageBox.Show("Không được bỏ trống nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            return true;
        }

       
    }
}
