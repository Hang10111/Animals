using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class TtBaoTonIucn
    {
        public TtBaoTonIucn()
        {
            SinhVat = new HashSet<SinhVat>();
        }

        public string IdTinhTrang { get; set; }
        public string TenTinhTrang { get; set; }

        public ICollection<SinhVat> SinhVat { get; set; }
    }
}
