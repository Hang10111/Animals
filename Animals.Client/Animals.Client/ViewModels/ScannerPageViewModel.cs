using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace Animals.Client.ViewModels
{
    public class ScannerPageViewModel : ViewModelBase
    {
        public ICommand OnBarcodeScannedCommand { get; private set; }
        public ICommand TurnOnFlashCommand { get; private set; }

        public bool IsTurnOnFlash
        {
            get => _isTurnOnFlash;
            set => SetProperty(ref _isTurnOnFlash, value);
        }
        public bool IsAnalyzing
        {
            get => _isAnalyzing;
            set => SetProperty(ref _isAnalyzing, value);
        }
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }
        public ZXing.Result Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        private bool _isAnalyzing = true;
        private bool _isScanning = true;
        private ZXing.Result _result;
        private bool _isTurnOnFlash;

        public ScannerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Scan";
            TurnOnFlashCommand = new DelegateCommand(HandleTurnOnFlashCommand);
            OnBarcodeScannedCommand = new DelegateCommand(OnBarcodeScanned, canExecute);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsBusy = false;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(IsBusy))
            {
                ((DelegateCommand)OnBarcodeScannedCommand).RaiseCanExecuteChanged();
            }
        }

        private void HandleTurnOnFlashCommand()
        {
            IsTurnOnFlash = !IsTurnOnFlash;
        }

        private bool canExecute()
        {
            return IsNotBusy;
        }

        private async void OnBarcodeScanned()
        {
            IsBusy = true;
            IsAnalyzing = false;
            var animalItems = await Services.AnimalService.GetAnimals();
            var animal = animalItems.FirstOrDefault(item => item.IdSinhVat.ToString() == Result.Text);
            var parameters = new NavigationParameters();
            parameters.Add("sinhvat", animal);
            await NavigationService.NavigateAsync("Detail", parameters);
            IsBusy = false;
        }
    }
}
