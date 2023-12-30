using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class KhachHang
    {
        public string sMaKH { set; get; }
        public string sTenKH { set; get; }
        public string sSdt { set; get; }

        public KhachHang() { }

        public KhachHang(string sMaKH, string sTenKH, string sSdt)
        {
            this.sMaKH = sMaKH;
            this.sTenKH = sTenKH;
            this.sSdt = sSdt;
        }
    }
}
