using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class TinTuc
    {
        public TinTuc()
        {
            Hinh = new HashSet<Hinh>();
        }

        public int Idtin { get; set; }
        public int? Idtv { get; set; }
        public string TieuDe { get; set; }
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        public int? IdChuDe { get; set; }
        public string LoaiTin { get; set; }
        public short? DuyetTin { get; set; }

        public ChuDe IdChuDeNavigation { get; set; }
        public ThanhVien IdtvNavigation { get; set; }
        public SinhVat SinhVat { get; set; }
        public Video Video { get; set; }
        public ICollection<Hinh> Hinh { get; set; }
    }
}
