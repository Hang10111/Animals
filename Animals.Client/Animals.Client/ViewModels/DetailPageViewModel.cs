using Animals.Client.Models;
using Prism.Navigation;

namespace Animals.Client.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        public string TenKh { get => _tenKh; set => SetProperty(ref _tenKh, value); }
        public string TenThuong { get => _tenThuong; set => SetProperty(ref _tenThuong, value); }
        public string TenTiengAnh { get => _tenTiengAnh; set => SetProperty(ref _tenTiengAnh, value); }
        public int ThuocChi { get => _thuocChi; set => SetProperty(ref _thuocChi, value); }
        public string PhanBo { get => _phanBo; set => SetProperty(ref _phanBo, value); }
        public string DdHinhThai { get => _ddHinhThai; set => SetProperty(ref _ddHinhThai, value); }
        public string DdSinhHoc { get => _ddSinhHoc; set => SetProperty(ref _ddSinhHoc, value); }
        public string TtSinhSan { get => _ttSinhSan; set => SetProperty(ref _ttSinhSan, value); }
        public string MtSong { get => _mtSong; set => SetProperty(ref _mtSong, value); }
        public string DoNguyHiem { get => _doNguyHiem; set => SetProperty(ref _doNguyHiem, value); }
        public string GtSuDung { get => _gtSuDung; set => SetProperty(ref _gtSuDung, value); }
        public string TinhTrangMau { get => _tinhTrangMau; set => SetProperty(ref _tinhTrangMau, value); }
        public string NoiTruMau { get => _noiTruMau; set => SetProperty(ref _noiTruMau, value); }
        public string ImageURL { get => _imageURL; set => SetProperty(ref _imageURL, value); }

        private AnimalItem _animalItem;
        private string _tenKh = string.Empty;
        private string _tenThuong = string.Empty;
        private string _tenTiengAnh = string.Empty;
        private string _imageURL = string.Empty;
        private int _thuocChi;
        private string _phanBo = string.Empty;
        private string _ddHinhThai = string.Empty;
        private string _ddSinhHoc = string.Empty;
        private string _ttSinhSan = string.Empty;
        private string _mtSong = string.Empty;
        private string _doNguyHiem = string.Empty;
        private string _gtSuDung = string.Empty;
        private string _tinhTrangMau = string.Empty;
        private string _noiTruMau = string.Empty;

        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Detail";
            _animalItem = new AnimalItem();
            InitializeCommand();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("sinhvat"))
            {
                _animalItem = (AnimalItem)parameters["sinhvat"];
                OnEntityChanged();
            }
        }

        private void InitializeCommand()
        {
        }

        private void HandleShowDetailCommand()
        {
            //Show detail later
        }

        private void OnEntityChanged()
        {
            TenKh = _animalItem.TenKh;
            TenThuong = _animalItem.TenThuong;
            TenTiengAnh = _animalItem.TenTiengAnh;
            ThuocChi = _animalItem.ThuocChi;
            PhanBo = _animalItem.PhanBo;
            DdHinhThai = _animalItem.DdHinhThai;
            DdSinhHoc = _animalItem.DdSinhHoc;
            TtSinhSan = _animalItem.TtSinhSan;
            MtSong = _animalItem.MtSong;
            DoNguyHiem = _animalItem.DoNguyHiem;
            GtSuDung = _animalItem.GtSuDung;
            TinhTrangMau = _animalItem.TinhTrangMau;
            NoiTruMau = _animalItem.NoiTruMau;
            ImageURL = _animalItem.ImageURL;
        }
    }
}