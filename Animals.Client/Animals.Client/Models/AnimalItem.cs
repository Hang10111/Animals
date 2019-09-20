using Animals.Share;

namespace Animals.Client.Models
{
    public class AnimalItem
    {
        public int IdSinhVat => _sinhVat.IdSinhVat;
        public string TenKh => _sinhVat.TenKh;
        public string TenThuong => _sinhVat.TenThuong;
        public string TenTiengAnh => _sinhVat.TenTiengAnh;
        public int ThuocChi => _sinhVat.ThuocChi !=null ? _sinhVat.ThuocChi.Value :0;
        public string PhanBo => _sinhVat.PhanBo;
        public string DdHinhThai => _sinhVat.DdHinhThai;
        public string DdSinhHoc => _sinhVat.DdSinhHoc;
        public string TtSinhSan => _sinhVat.TtSinhSan;
        public string MtSong => _sinhVat.MtSong;
        public string DoNguyHiem => _sinhVat.DoNguyHiem;
        public string GtSuDung => _sinhVat.GtSuDung;
        public string TinhTrangMau => _sinhVat.TinhTrangMau;
        public string NoiTruMau => _sinhVat.NoiTruMau;
        public short LaDv => _sinhVat.LaDv != null ? _sinhVat.LaDv.Value : (short)0;
        public string TtBaoTon => _sinhVat.TtBaoTon;
        public string ImageURL => _hinh.DuongDan;
        private readonly SinhVat _sinhVat;
        private readonly Hinh _hinh;
        public AnimalItem() { }
        public AnimalItem(SinhVat sinhVat, Hinh Hinh)
        {
            _sinhVat = sinhVat;
            _hinh = Hinh;
            //FIXME: hardcode ImageURL
        //    Hinh.DuongDan = "http://192.168.1.200:10000/hinh-tin-tuc/test.jpg";
        }
    }
}
