using Animals.Share;
using System.Collections.ObjectModel;

namespace Animals.Client.Models
{
    public class AnimalItem
    {
        public int IdSinhVat => _sinhVat.IdSinhVat;
        public string TenKh => _sinhVat.TenKh;
        public string TenThuong => _sinhVat.TenThuong;
        public string TenTiengAnh => _sinhVat.TenTiengAnh;
        public int ThuocChi => _sinhVat.ThuocChi != null ? _sinhVat.ThuocChi.Value : 0;
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
        public ObservableCollection<Location> Locations => _locations;
        public string ShortName => _shortName;

        private readonly ObservableCollection<Location> _locations;
        private readonly string _shortName;
        private readonly SinhVat _sinhVat;
        private readonly Hinh _hinh;

        public AnimalItem() { }

        public AnimalItem(SinhVat sinhVat, Hinh Hinh, ObservableCollection<Location> location)
        {
            _sinhVat = sinhVat;
            _hinh = Hinh;
            _locations = location;
            _shortName = TenKh[0].ToString().ToUpper(); ;
        }

        public bool IsContainsText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }
            text = text.Trim();
            return TenKh.ToLower().Contains(text.ToLower()) || TenThuong.Contains(text.ToLower());
        }
    }
}
