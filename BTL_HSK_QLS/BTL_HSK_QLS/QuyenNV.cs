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
    public partial class QuyenNV : Form
    {
        public QuyenNV()
        {
            InitializeComponent();
        }

        private void QuyenNV_Load(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang formQLKhachHang = new QLKhachHang();
            formQLKhachHang.MdiParent = this;
            formQLKhachHang.Dock = DockStyle.Fill;
            formQLKhachHang.Show();
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

        public void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
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
        public void loadDSHD()
        {
            QLDSHoaDon qLDSHoaDon = new QLDSHoaDon();
            qLDSHoaDon.MdiParent = this;
            qLDSHoaDon.Dock = DockStyle.Fill;
            qLDSHoaDon.Show();
        }
        public void loadDSHDCT(string maHoaDon)
        {
            XemHoaDonChiTiet xemHoaDonChiTiet = new XemHoaDonChiTiet(maHoaDon);
            xemHoaDonChiTiet.MdiParent = this;
            xemHoaDonChiTiet.Dock = DockStyle.Fill;
            xemHoaDonChiTiet.Show();
        }
        private void danhSáchHóaĐơnĐãTạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLDSHoaDon qLDSHoaDon = new QLDSHoaDon();
            qLDSHoaDon.MdiParent = this;
            qLDSHoaDon.Dock = DockStyle.Fill;
            qLDSHoaDon.Show(); 
        }

        private void khoSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSach qLSach = new QLSach();
            qLSach.MdiParent = this;
            qLSach.Dock = DockStyle.Fill;
            qLSach.Show();
        }

        private void loạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLoaiSach qLLoaiSach = new QLLoaiSach();
            qLLoaiSach.MdiParent = this;
            qLLoaiSach.Dock = DockStyle.Fill;
            qLLoaiSach.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau formDoiMatKhau = new DoiMatKhau();
            formDoiMatKhau.MdiParent = this;
            formDoiMatKhau.Dock = DockStyle.Fill;
            formDoiMatKhau.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
