using Animals.Client.Customs;
using Animals.Client.Models;
using Animals.Client.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Animals.Client.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public bool IsVisibleRefresh => DataSource.Count <= 0 && string.IsNullOrEmpty(SearchText);
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value, () => { RaisePropertyChanged(nameof(DataSource)); RaisePropertyChanged(nameof(IsVisibleRefresh)); });
        }
        public CustomObservableCollection<IGrouping<string, AnimalItem>> DataSource
        {
            get
            {
                CustomObservableCollection<IGrouping<string, AnimalItem>> result = new CustomObservableCollection<IGrouping<string, AnimalItem>>();
                var animalItems = AnimalItemModels?.Where(item =>
                item.IsContainsText(SearchText))
                .OrderBy(item => item.ShortName)
                .ThenBy(item => item.TenTiengAnh)
                .GroupBy(item => item.ShortName);
                result.Replace(animalItems);
                return result;
            }
        }

        public ICommand ScanQRCommand { get; private set; }
        public ICommand ShowDetailCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        
        protected IEnumerable<AnimalItem> AnimalItemModels
        {
            set => SetProperty(ref _animalItemModels, value, () => { RaisePropertyChanged(nameof(DataSource)); RaisePropertyChanged(nameof(IsVisibleRefresh)); });
            get => _animalItemModels;
        }

        private string _searchText;
        private IEnumerable<AnimalItem> _animalItemModels;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "HomePage";
            InitializeCommand();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (AnimalItemModels == null)
            {
                RefreshCommand.Execute(null);
            }
            IsBusy = false;
        }

        private void InitializeCommand()
        {
            ScanQRCommand = new DelegateCommand(HandleScanQRCommand);
            RefreshCommand = new DelegateCommand(HandleRefreshCommand);
            ShowDetailCommand = new DelegateCommand<AnimalItem>(HandleShowDetailCommand);
        }

        private async void HandleRefreshCommand()
        {
            IsBusy = true;
            AnimalItemModels = await LoadHomeListViewData();
            IsBusy = false;
        }


        private void HandleShowDetailCommand(AnimalItem obj)
        {
            var parameters = new NavigationParameters();
            parameters.Add("sinhvat", obj);
            NavigationService.NavigateAsync("Detail", parameters);
        }

        private async Task<IEnumerable<AnimalItem>> LoadHomeListViewData()
        {
            return await AnimalService.GetAnimals();
        }
        
        private void HandleScanQRCommand()
        {
            NavigationService.NavigateAsync("Scanner");
        }
    }
}
