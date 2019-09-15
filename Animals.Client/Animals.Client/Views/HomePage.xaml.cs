using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Animals.Client.Services;
using Newtonsoft.Json;
using Animals.Share;
using Animals.Client.ViewModels;

namespace Animals.Client.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        //ZXingScannerPage scanPage;

        //public object HomeListView { get; private set; }

        public HomePage ()
		{
			InitializeComponent ();
           // Scan.Clicked += Scan_Clicked;
           // GetSinhVatAsync();
            
        }


        /*private async void Scan_Clicked(object sender, EventArgs e)
{
   scanPage = new ZXingScannerPage();
   scanPage.OnScanResult += (result) => {
       scanPage.IsScanning = false;
       Device.BeginInvokeOnMainThread(() => {
           Navigation.PopModalAsync();
           DisplayAlert("Scanned Barcode", result.Text, "OK");
           //myCode.Text = result.Text;
       });
   };

   await Navigation.PushModalAsync(scanPage);
}
private async void GetSinhVatAsync()
{
   var url = Configuration.ID_HOST + "/api/home";
   BodyResponseFormatBase<SinhVat> Response;
   Response = await HttpService.GetAsync<SinhVat>(url);
   HomeListView.ItemsSource = Response;

}
private async void GetHinhAsync()
{
   var url = Configuration.ID_HOST + "/api/image";
   BodyResponseFormatBase<Hinh> Response;
   Response = await HttpService.GetAsync<Hinh>(url);
   HomeListView.ItemsSource = Response;

}

*/
    }
}