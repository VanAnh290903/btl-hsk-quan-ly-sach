using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class HoaDonChiTiet
    {
        public string sMaHD { set; get; }
        public string sMaSach { set; get; }
        public int iSoLuong { set; get; }
        public float fThanhTien { set; get; }
        public float fDonGia { set; get; }
       
        public HoaDonChiTiet() {}

        public HoaDonChiTiet(string sMaHD, string sMaSach, int iSoLuong, float fThanhTien, float fDonGia)
        {
            this.sMaHD = sMaHD;
            this.sMaSach = sMaSach;
            this.iSoLuong = iSoLuong;
            this.fThanhTien = fThanhTien;
            this.fDonGia = fDonGia;
            
        }
    }
}
