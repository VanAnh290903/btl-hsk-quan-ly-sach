using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class NhanVien
    {
        public string smanv { get; set; }
        public string stennv { get; set; }
        public string sgioitinh { get; set; }
        public string ssdt { get; set; }
        public DateTime ituoi { get; set; }
        public NhanVien() { }

        public NhanVien(string smanv, string stennv, string sgioitinh, string ssdt, DateTime ituoi)
        {
            this.smanv = smanv;
            this.stennv = stennv;
            this.sgioitinh = sgioitinh;
            this.ssdt = ssdt;
            this.ituoi = ituoi;
        }
    }
}
