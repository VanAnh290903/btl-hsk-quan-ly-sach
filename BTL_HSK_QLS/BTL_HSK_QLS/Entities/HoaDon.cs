using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class HoaDon
    {
        public string sMaHD { set; get; }
        public string sMaNV { set; get; }
        public string sMaKH { set; get; }
        public DateTime dNgayLap { set; get; }
        public int iTongTien { set; get; }
        public int iTrangThai { set; get; }

        public HoaDon() { }

        public HoaDon(string sMaHD, string sMaNV, string sMaKH, DateTime dNgayLap, int iTongTien, int iTrangThai)
        {
            this.sMaHD = sMaHD;
            this.sMaNV = sMaNV;
            this.sMaKH = sMaKH;
            this.dNgayLap = dNgayLap;
            this.iTongTien = iTongTien;
            this.iTrangThai = iTrangThai;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
