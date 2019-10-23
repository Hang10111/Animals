using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

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
        bool _isProcessing = false;

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get => _isAnalyzing;
            set => SetProperty(ref _isAnalyzing, value);
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }

        private ZXing.Result _result;
        public ZXing.Result Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }


        //private readonly INavigationService _navigationService;
        //private readonly IPageDialogService _pageDialogue;
        private readonly IDeviceService _deviceService;


        private bool _isTurnOnFlash;

        public ScannerPageViewModel(INavigationService navigationService, IDeviceService deviceService) : base(navigationService)
        {
            //_navigationService = navigationService;
            //_pageDialogue = pageDialogService;
            _deviceService = deviceService;
            Title = "Scan";
            TurnOnFlashCommand = new DelegateCommand(HandleTurnOnFlashCommand);
            OnBarcodeScannedCommand = new DelegateCommand(OnBarcodeScanned, canExecute);
            _isScanning = true;
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
            if (!_isProcessing)
            {
                _deviceService.BeginInvokeOnMainThread(async () =>
                {
                    _isProcessing = true;
                    _isAnalyzing = false;
                    RaisePropertyChanged("IsAnalyzing");
                    string message = Result.Text;
                    Debug.WriteLine(message);
                    var animalItems = await Services.AnimalService.GetAnimals();
                    var animal = animalItems.FirstOrDefault(item => item.IdSinhVat.ToString() == message);
                    var parameters = new NavigationParameters();
                    parameters.Add("sinhvat", animal);
                    await NavigationService.NavigateAsync("Detail", parameters); 
                    _isProcessing = false;
                    _isAnalyzing = true;
                    RaisePropertyChanged("IsAnalyzing");
                });
            }
        }
    }
}
