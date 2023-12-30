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
using System.Data.SqlClient;
using BTL_HSK_QLS.Crystal_Report;

namespace BTL_HSK_QLS.Table

{
    public partial class XemHoaDonChiTiet : Form
    {
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        private string maHoaDon;
        public XemHoaDonChiTiet(string maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }
        //private int checkTrangThai;
        //public XemHoaDonChiTiet(int checkTrangThai)
        //{
        //    InitializeComponent();
        //    this.checkTrangThai = checkTrangThai;
        //}

        private void XemHoaDonChiTiet_Load(object sender, EventArgs e)
        {
            lblMaHoaDon.Text = maHoaDon;
            loadDSHoaDonChiTiet();
            if(!hoaDonDAO.checkTrangThaiHD(maHoaDon))
            {
                btnInHD.Enabled = false;
            }
        }
        private void loadDSHoaDonChiTiet()
        {
            DataTable t = hoaDonDAO.getDSHoaDonChiTiet(maHoaDon);
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            dgvHoaDonChiTiet.DataSource = t;
            dgvHoaDonChiTiet.Columns["STT"].DisplayIndex = 0;
            dgvHoaDonChiTiet.Columns["smahd"].Visible = false;
            dgvHoaDonChiTiet.Columns["smasach"].Visible = false;
            foreach (DataGridViewColumn column in dgvHoaDonChiTiet.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
            crystalReportViewer.loadHoaDonChiTiet( maHoaDon);
            crystalReportViewer.ShowDialog();
        }

    }
}