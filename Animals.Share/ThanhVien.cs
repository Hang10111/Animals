using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class ThanhVien
    {
        public ThanhVien()
        {
            TinTuc = new HashSet<TinTuc>();
        }

        public int Idtv { get; set; }
        public string TenDn { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public int? Sdt { get; set; }

        public ICollection<TinTuc> TinTuc { get; set; }
    }
}
