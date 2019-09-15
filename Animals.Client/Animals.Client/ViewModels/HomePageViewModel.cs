using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Animals.Share;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Commands;
using Animals.Client.Services;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Animals.Client.Models;

namespace Animals.Client.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        ZXingScannerPage scanPage;
        private ObservableCollection<AnimalItem> _dataSource;
        public ICommand CmdScan { get; }
        public ICommand SearchCommand { get; private set; }
        public ICommand ShowDetail { get; set; }

        public ObservableCollection<AnimalItem> DataSource { get => _dataSource; set => SetProperty(ref _dataSource, value); }
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "HomePage";
            DataSource = new ObservableCollection<AnimalItem>();
            CmdScan = new DelegateCommand(Scan);
            SearchCommand = new DelegateCommand<string>(Search);
            ShowDetail = new DelegateCommand<AnimalItem>(OnShowDetail);
        }

        private async void Search(string obj)
        {
            DataSource = new ObservableCollection<AnimalItem>((await LoadHomeListViewData()).Where(item => item.TenThuong.ToLower().Contains(obj)));
        }

        //Chuyển sang DetailPage
        public void OnShowDetail(AnimalItem obj)
        {
            var par = new Prism.Navigation.NavigationParameters();
            par.Add("sinhvat", obj);
            NavigationService.NavigateAsync("DetailPage", par);
        }
        
        //lấy dữ liệu cho listview
        private async Task<ObservableCollection<AnimalItem>> LoadHomeListViewData()
        {
            var url = Configuration.ID_HOST + "/api/detail";
            BodyResponseFormatBase<List<Tuple<SinhVat, Hinh>>> Response;
            Response = await HttpService.GetAsync<List<Tuple<SinhVat, Hinh>>>(url);
            var result = new ObservableCollection<AnimalItem>(Response.Result.Select(e => new AnimalItem(e.Item1,e.Item2)));
            return result;
        }       
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            DataSource = await LoadHomeListViewData();
        }
        private void Scan()
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    //  DisplayAlert("Scanned Barcode", result.Text, "OK");
                    // myCode.Text = result.Text;
                });
            };
        }
    }
}
