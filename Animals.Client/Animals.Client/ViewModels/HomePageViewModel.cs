using System.Windows.Input;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Commands;
using Animals.Client.Services;
using System.Linq;
using System.Threading.Tasks;
using Animals.Client.Models;
using Xamarin.Forms;

namespace Animals.Client.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<AnimalItem> DataSource { get => _dataSource; set => SetProperty(ref _dataSource, value, () => { RaisePropertyChanged(nameof(IsVisibleRefresh)); }); }
        public bool IsVisibleRefresh => DataSource.Count <= 0;

        public ICommand ScanQRCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand ShowDetailCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        
        private ObservableCollection<AnimalItem> _dataSource;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "HomePage";
            DataSource = new ObservableCollection<AnimalItem>();
            InitializeCommand();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            RefreshCommand.Execute(null);
        }

        private void InitializeCommand()
        {
            ScanQRCommand = new DelegateCommand(HandleScanQRCommand);
            RefreshCommand = new DelegateCommand(HandleRefreshCommand);
            SearchCommand = new DelegateCommand<string>(HandleSearchCommand);
            ShowDetailCommand = new DelegateCommand<AnimalItem>(HandleShowDetailCommand);
        }

        private void HandleRefreshCommand()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                IsBusy = true;
                DataSource = await LoadHomeListViewData();
                IsBusy = false;
            });
        }

        private async void HandleSearchCommand(string obj)
        {
            DataSource = new ObservableCollection<AnimalItem>((await LoadHomeListViewData()).Where(item => item.TenThuong.ToLower().Contains(obj)));
        }

        private void HandleShowDetailCommand(AnimalItem obj)
        {
            var parameters = new NavigationParameters();
            parameters.Add("sinhvat", obj);
            NavigationService.NavigateAsync("Detail", parameters);
        }

        private async Task<ObservableCollection<AnimalItem>> LoadHomeListViewData()
        {
            return new ObservableCollection<AnimalItem>(await AnimalService.GetAnimals());
        }
        
        private void HandleScanQRCommand()
        {
            NavigationService.NavigateAsync("Scanner");
        }
    }
}
