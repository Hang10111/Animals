using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class PhanLoai
    {
        public PhanLoai()
        {
            InverseIdChaNavigation = new HashSet<PhanLoai>();
            SinhVat = new HashSet<SinhVat>();
        }

        public int IdPhanLoai { get; set; }
        public string TenPhanLoai { get; set; }
        public int? IdCha { get; set; }

        public PhanLoai IdChaNavigation { get; set; }
        public ICollection<PhanLoai> InverseIdChaNavigation { get; set; }
        public ICollection<SinhVat> SinhVat { get; set; }
    }
}
