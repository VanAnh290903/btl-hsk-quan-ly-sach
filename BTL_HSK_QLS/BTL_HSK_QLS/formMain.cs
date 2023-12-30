using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_HSK_QLS.Table;

namespace BTL_HSK_QLS
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            
        }

        private void QLNhanVien_Click(object sender, EventArgs e)
        {
            
            QLNhanVien formQLNhanVien = new QLNhanVien();
            formQLNhanVien.MdiParent = this;
            formQLNhanVien.Dock = DockStyle.Fill;
            formQLNhanVien.Show();
            
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Properties.Settings.Default.Reset();

                this.Hide();
                DangNhap formDangNhap = new DangNhap();
               
                formDangNhap.ShowDialog();
                this.Close();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang formQLKhachHang = new QLKhachHang();
            formQLKhachHang.MdiParent = this;
            formQLKhachHang.Dock = DockStyle.Fill;
            formQLKhachHang.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTaiKhoan formQLTaiKhoan = new QLTaiKhoan();
            formQLTaiKhoan.MdiParent = this;
            formQLTaiKhoan.Dock = DockStyle.Fill;
            formQLTaiKhoan.Show();
        }

        private void thêmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadHoaDon();
        }
        public void loadHoaDon()
        {
            QLHoaDonChiTiet qLHoaDonChiTiet = new QLHoaDonChiTiet();
            qLHoaDonChiTiet.MdiParent = this;
            qLHoaDonChiTiet.Dock = DockStyle.Fill;
            qLHoaDonChiTiet.Show();
        }

        private void xemDanhSáchHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLDSHoaDon qLDSHoaDon = new QLDSHoaDon();
            qLDSHoaDon.MdiParent = this;
            qLDSHoaDon.Dock = DockStyle.Fill;
            qLDSHoaDon.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLDSHoaDon qLDSHoaDon = new QLDSHoaDon();
            qLDSHoaDon.MdiParent = this;
            qLDSHoaDon.Dock = DockStyle.Fill;
            qLDSHoaDon.Show();
        }
        public void loadHDCTinadmin(string maHoaDon)
        {
            XemHoaDonChiTiet xemHoaDonChiTiet = new XemHoaDonChiTiet(maHoaDon);
            xemHoaDonChiTiet.MdiParent = this;
            xemHoaDonChiTiet.Dock = DockStyle.Fill;
            xemHoaDonChiTiet.Show();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_ControlRemoved(object sender, ControlEventArgs e)
        {

        }
    }
}
