using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_QLS.Utilities;
using BTL_HSK_QLS.DAO;

namespace BTL_HSK_QLS.Table
{
    public partial class DoiMatKhau : Form
    {
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = Properties.Settings.Default.TaiKhoan;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (checkInpuut())
            {
                //if (taiKhoanDAO.checkPassword(txtMatKhauCu.Text.Trim(), Properties.Settings.Default.TaiKhoan))
                if (Properties.Settings.Default.MatKhau.Equals(txtMatKhauCu.Text))
                {
                    bool res = taiKhoanDAO.updatePassword(txtMatKhauMoi.Text.Trim(), Properties.Settings.Default.TaiKhoan);
                    if (res)
                    {
                        //load lại danh sách khách hàng 
                        Properties.Settings.Default.MatKhau = txtMatKhauMoi.Text.Trim();
                        loadDetail();
                        MessageBox.Show("Đổi mật khẩu thàng công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra khi thêm khách hàng, vui lòng thử lại hoặc liên hệ nhiên viên hỗ trợ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void loadDetail()
        {
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhanMK.Text = "";
        }

        private bool checkInpuut()
        {
            //kiểm tra phập đủ dữ liệu
            if (String.IsNullOrWhiteSpace(txtMatKhauCu.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu cũ không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txtMatKhauMoi.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu mới không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return false;
            }
            else if (!CheckValid.IsPasswordValid(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ!(Trên 8 ký tự và có cả chữ hoa và số, không có ký tự đặc biệt)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return false;
            }
            return true;
        }

        private void CamKyTuCach(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Không cho phép nhập ký tự cách
            }
        }
    }
}
