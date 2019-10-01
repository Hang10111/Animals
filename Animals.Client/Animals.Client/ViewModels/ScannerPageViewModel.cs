using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Animals.Client.ViewModels
{
    public class ScannerPageViewModel : ViewModelBase
    {
        public DelegateCommand OnBarcodeScannedCommand { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogue;
        private readonly IDeviceService _deviceService;

        bool _isProcessing = false;

        private bool _isAnalyzing = true;
        public bool IsAnalyzing
        {
            get
            {
                return _isAnalyzing;
            }
            set
            {
                if (SetProperty(ref _isAnalyzing, value))
                {
                    //Do something
                }
            }
        }

        private bool _isScanning;
        public bool IsScanning
        {
            get
            {
                return _isScanning;
            }
            set
            {
                if (SetProperty(ref _isAnalyzing, value))
                {
                    //Do something
                }
            }
        }

        private ZXing.Result _result;
        public ZXing.Result Result
        {
            get
            {
                return _result;
            }
            set
            {
                if (SetProperty(ref _result, value))
                {
                    //Do something
                }
            }
        }
        public ScannerPageViewModel(INavigationService navigationService,
                                    IPageDialogService pageDialogService,
                                    IDeviceService deviceService) : base(navigationService)
        {
            Title = "Scan";

            _navigationService = navigationService;
            _pageDialogue = pageDialogService;
            _deviceService = deviceService;

            OnBarcodeScannedCommand = new DelegateCommand(OnBarcodeScanned);

            _isScanning = true;
        }

        private void OnBarcodeScanned()
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
                    await _pageDialogue.DisplayAlertAsync("Scan!", message, "Close");
                    _isProcessing = false;
                    _isAnalyzing = true;
                    RaisePropertyChanged("IsAnalyzing");
                });
            }
        }
    }
}
