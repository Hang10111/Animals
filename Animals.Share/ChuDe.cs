using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class ChuDe
    {
        public ChuDe()
        {
            InverseIdChaNavigation = new HashSet<ChuDe>();
            TinTuc = new HashSet<TinTuc>();
        }

        public int IdChuDe { get; set; }
        public string TenChuDe { get; set; }
        public int? IdCha { get; set; }
        public short Duyet { get; set; }

        public ChuDe IdChaNavigation { get; set; }
        public ICollection<ChuDe> InverseIdChaNavigation { get; set; }
        public ICollection<TinTuc> TinTuc { get; set; }
    }
}
