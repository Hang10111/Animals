using Animals.Share;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        public static object VietNamChar { get; private set; }

        private readonly ObservableCollection<Location> _locations;
        private readonly string _shortName;
        private readonly Species _sinhVat;
        private readonly ObservableCollection<Images> _hinh;

        public AnimalItem() { }

        public AnimalItem(Species sinhVat, ObservableCollection<Images> hinhs, ObservableCollection<Location> location)
        {
            _sinhVat = sinhVat ?? new Species();
            //var newhinh = _hinh.Select(x => x.Replace("\r\n", "")).ToList();
            _locations = location;
            _shortName = !string.IsNullOrEmpty(TenKh) ? TenKh[0].ToString().ToLower() : string.Empty;
            AvatarUrl = _hinh.FirstOrDefault()?.ImgPath;
        }
        public bool IsContainsText(string text)
        {

            var result = false;
            if (string.IsNullOrWhiteSpace(text))
            {
                result = true;
            }
            else
            {
                if (text.ToLower().Contains(TenKh?.ToLower() ?? string.Empty) && text.ToLower().Contains(TenThuong?.ToLower() ?? string.Empty))
                {
                    result = true;
                }
                else if (!text.ToLower().Contains(TenKh?.ToLower() ?? string.Empty) && !text.ToLower().Contains(TenThuong?.ToLower() ?? string.Empty))
                {
                    text = text.Trim();
                    result = TenKh.ToLower().Contains(text.ToLower()) || TenThuong.ToLower().Contains(text.ToLower());
                }
                else if (!text.ToLower().Contains(TenKh?.ToLower() ?? string.Empty) && text.ToLower().Contains(TenThuong?.ToLower() ?? string.Empty))
                {
                    text = text.Trim();
                    result = TenKh.ToLower().Contains(text.ToLower());
                }
                else if (text.ToLower().Contains(TenKh?.ToLower() ?? string.Empty) && !text.ToLower().Contains(TenThuong?.ToLower() ?? string.Empty))
                {
                    text = text.Trim();
                    result = TenThuong.ToLower().Contains(text.ToLower());
                }

            }
            return result;
        }
    }
    
}
