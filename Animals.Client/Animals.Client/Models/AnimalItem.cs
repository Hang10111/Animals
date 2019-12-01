using Animals.Share;
using System.Collections.ObjectModel;
using System.Linq;

namespace Animals.Client.Models
{
    public class AnimalItem
    {
        public int IdSinhVat => _sinhVat.SpeciesId;
        public string TenKh => _sinhVat.ScientificName;
        public string TenThuong => _sinhVat.VietName;
        public string TenTiengAnh => _sinhVat.EngName;
        public int ThuocChi => _sinhVat.Genus != null ? _sinhVat.Genus.Value : 0;
        public string PhanBo => _sinhVat.Distribution;
        public string DdHinhThai => _sinhVat.MorphoCharcs;
        public string DdSinhHoc => _sinhVat.BioCharcs;
        public string TtSinhSan => _sinhVat.Reproduction;
        public string MtSong => _sinhVat.Habitats;
        public string DoNguyHiem => _sinhVat.Danger;
        public string GtSuDung => _sinhVat.UseValue;
        public string TinhTrangMau => _sinhVat.StatusId;
        public string NoiTruMau => _sinhVat.SampleId;
        public short LaDv => _sinhVat.IsAnimal != null ? _sinhVat.IsAnimal.Value : (short)0;
        public string TtBaoTon => _sinhVat.Status.StatusName;
        public ObservableCollection<Images> ImageURL => _hinh;
        public ObservableCollection<Location> Locations => _locations;
        public string ShortName => _shortName;
        public string AvatarUrl { get; set; }

        private readonly ObservableCollection<Location> _locations;
        private readonly string _shortName;
        private readonly Species _sinhVat;
        private readonly ObservableCollection<Images> _hinh;

        public AnimalItem() { }

        public AnimalItem(Species sinhVat, ObservableCollection<Images> hinhs, ObservableCollection<Location> location)
        {
            _sinhVat = sinhVat;
            _hinh = hinhs;
            _locations = location;
            _shortName = TenKh[0].ToString().ToUpper();
            AvatarUrl = _hinh.FirstOrDefault()?.ImgPath;
        }

        public bool IsContainsText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }
            text = text.Trim();
            return TenKh.ToLower().Contains(text.ToLower()) || TenTiengAnh.Contains(text.ToLower()) || TenThuong.Contains(text.ToLower());
        }
    }
}
