using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class TaiKhoanDangNhap
    {
        public string sTaiKhoan { get; set; }
        public string sMatKhau { get; set; }
        public string sQuyen { get; set; }
        public int iTrangThai { get; set; }
        public string FK_sMaNV { get; set; }
        public string sTenNV { get; set; }

        public TaiKhoanDangNhap() { }

        public TaiKhoanDangNhap(string sTaiKhoan, string sMatKhau, string sQuyen, int iTrangThai, string FK_sMaNV)
        {
            this.sTaiKhoan = sTaiKhoan;
            this.sMatKhau = sMatKhau;
            this.sQuyen = sQuyen;
            this.iTrangThai = iTrangThai;
            this.FK_sMaNV = FK_sMaNV;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
