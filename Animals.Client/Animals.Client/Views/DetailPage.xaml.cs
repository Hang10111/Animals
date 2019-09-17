using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mapsui.Layers;
using BruTile.Predefined;
using Mapsui.Widgets.ScaleBar;

namespace Animals.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            mapView.Map.Layers.Add(new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap)) { Name = "OpenStreetMap" });
            mapView.Map.Widgets.Add(new ScaleBarWidget(mapView.Map));
        }
    }
}