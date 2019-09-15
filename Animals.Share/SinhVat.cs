using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class SinhVat
    {
        public SinhVat() { }

        public int IdSinhVat { get; set; }
        public string TenKh { get; set; }
        public string TenThuong { get; set; }
        public string TenTiengAnh { get; set; }
        public int? ThuocChi { get; set; }
        public string PhanBo { get; set; }
        public string DdHinhThai { get; set; }
        public string DdSinhHoc { get; set; }
        public string TtSinhSan { get; set; }
        public string MtSong { get; set; }
        public string DoNguyHiem { get; set; }
        public string GtSuDung { get; set; }
        public string TinhTrangMau { get; set; }
        public string NoiTruMau { get; set; }
        public short? LaDv { get; set; }
        public string TtBaoTon { get; set; }
        public int? ToaDo { get; set; }
        public TinTuc IdSinhVatNavigation { get; set; }
        public PhanLoai ThuocChiNavigation { get; set; }
        public TtBaoTonIucn TtBaoTonNavigation { get; set; }
    }
}
