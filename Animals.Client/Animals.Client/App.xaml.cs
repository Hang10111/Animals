using Animals.Client.Views;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Animals.Client
{
    public partial class App : PrismApplication
    {
        public App() : base(null) { }
        protected async override void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("Navigation/Home");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<HomePage>("Home");
            containerRegistry.RegisterForNavigation<DetailPage>("Detail");
            containerRegistry.RegisterForNavigation<ScannerPage>("Scanner");
        }
    }
}
