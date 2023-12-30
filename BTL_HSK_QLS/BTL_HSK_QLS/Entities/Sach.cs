using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class Sach
    {
        public string sMaSach { set; get; }
        public string sTenSach { set; get; }
        public string sTenTacGia { set; get; }
        public string sNXB { set; get; }
        public string sMaLoaiSach { set; get; }
        public int iSoLuongTrongKho { set; get; }

        public Sach() { }

        public Sach(string sMaSach, string sTenSach, string sTenTacGia, string sNXB, string sMaLoaiSach, int iSoLuongTrongKho)
        {
            this.sMaSach = sMaSach;
            this.sTenSach = sTenSach;
            this.sTenTacGia = sTenTacGia;
            this.sNXB = sNXB;
            this.sMaLoaiSach = sMaLoaiSach;
            this.iSoLuongTrongKho = iSoLuongTrongKho;
        }
    }
}
