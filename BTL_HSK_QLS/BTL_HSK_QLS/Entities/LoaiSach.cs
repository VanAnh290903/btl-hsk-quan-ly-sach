using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK_QLS.Entities
{
    class LoaiSach
    {
        public string smaloaisach { get; set; }
        public string stenloaisach { get; set; }
        public LoaiSach() { }

        public LoaiSach(string smaloaisach, string stenloaisach)
        {
            this.smaloaisach = smaloaisach;
            this.stenloaisach = stenloaisach;
        }
    }
}
