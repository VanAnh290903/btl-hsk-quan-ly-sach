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
using BTL_HSK_QLS.Utilities;
using System.Configuration;

namespace BTL_HSK_QLS
{
    
    public partial class DangNhap : Form
    {
        private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void ckboxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckboxHienMK.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //check ....
            //check mật khẩu: không cách, trên >8 kí tự , có chữ hoa chữ thường số kí tự đb

            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            if (String.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Tài khoản không được rỗng, nhập thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaiKhoan.Focus();
                return;
            }


            if (CheckValid.IsPasswordValid(matKhau))
            {
                // oke
                TaiKhoanDangNhap tkDangNhap = taiKhoanDAO.kiemTraDangNhap(taiKhoan, matKhau);

                if (tkDangNhap.sTaiKhoan != null)
                {
                    Properties.Settings.Default.MaNV = tkDangNhap.FK_sMaNV;
                    Properties.Settings.Default.TaiKhoan = tkDangNhap.sTaiKhoan;
                    Properties.Settings.Default.MatKhau = tkDangNhap.sMatKhau;
                    Properties.Settings.Default.Quyen = tkDangNhap.sQuyen;
                    Properties.Settings.Default.TrangThai = tkDangNhap.iTrangThai;
                    Properties.Settings.Default.TenNV = tkDangNhap.sTenNV;
                    Properties.Settings.Default.Save();
                    this.Hide();

                    if (tkDangNhap.sQuyen == "admin")
                    {
                        MessageBox.Show("Quyền admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formMain formMain = new formMain();
                        formMain.Dock = DockStyle.Fill;
                        //formMain.FormBorderStyle = FormBorderStyle.None;
                        formMain.WindowState = FormWindowState.Maximized;
                        formMain.StartPosition = FormStartPosition.CenterScreen; // Căn giữa form trên màn hình
                        formMain.ClientSize = new Size(800, 600); // Thiết lập kích thước form
                        formMain.AutoScaleMode = AutoScaleMode.Font; // Tự động thay đổi kích thước các điều khiển trên form
                        formMain.ShowDialog();
                    } else if (tkDangNhap.sQuyen == "nhanvien")
                    {
                        MessageBox.Show("Quyền Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        QuyenNV formTrangchuNhanVien = new QuyenNV();
                        formTrangchuNhanVien.Dock = DockStyle.Fill;
                        formTrangchuNhanVien.WindowState = FormWindowState.Maximized;
                        formTrangchuNhanVien.StartPosition = FormStartPosition.CenterScreen; // Căn giữa form trên màn hình
                        formTrangchuNhanVien.ClientSize = new Size(800, 600); // Thiết lập kích thước form
                        formTrangchuNhanVien.AutoScaleMode = AutoScaleMode.Font; // Tự động thay đổi kích thước các điều khiển trên form
                        formTrangchuNhanVien.ShowDialog();
                    }
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu hoặc tài khoản không đúng, vui lòng nhập lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MaNV != "")
            {
                // login thẳng
                this.Hide();
                if (Properties.Settings.Default.Quyen == "admin")
                {
                    formMain formMain = new formMain();
                    formMain.Dock = DockStyle.Fill;
                    //formMain.FormBorderStyle = FormBorderStyle.None;
                    formMain.WindowState = FormWindowState.Maximized;
                    formMain.StartPosition = FormStartPosition.CenterScreen; // Căn giữa form trên màn hình
                    formMain.ClientSize = new Size(800, 600); // Thiết lập kích thước form
                    formMain.AutoScaleMode = AutoScaleMode.Font; // Tự động thay đổi kích thước các điều khiển trên form
                    formMain.ShowDialog();
                }
                else if (Properties.Settings.Default.Quyen == "nhanvien")
                {
                    QuyenNV formTrangchuNhanVien = new QuyenNV();
                    formTrangchuNhanVien.Dock = DockStyle.Fill;
                    formTrangchuNhanVien.WindowState = FormWindowState.Maximized;
                    formTrangchuNhanVien.StartPosition = FormStartPosition.CenterScreen; // Căn giữa form trên màn hình
                    formTrangchuNhanVien.ClientSize = new Size(800, 600); // Thiết lập kích thước form
                    formTrangchuNhanVien.AutoScaleMode = AutoScaleMode.Font; // Tự động thay đổi kích thước các điều khiển trên form
                    formTrangchuNhanVien.ShowDialog();
                }
                this.Close();
            }
        }
        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Không cho phép nhập ký tự cách
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Không cho phép nhập ký tự cách
            }
        }
    }
}
