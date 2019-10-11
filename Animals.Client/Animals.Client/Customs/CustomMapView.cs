using Animals.Share;
using BruTile.Predefined;
using Mapsui.Layers;
using Mapsui.UI.Forms;
using Mapsui.Widgets.ScaleBar;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Animals.Client.Xamarin
{
    public class CustomMapView : MapView
    {
        public static readonly BindableProperty LocationsProperty =
            BindableProperty.Create("Locations",
                typeof(System.Collections.ObjectModel.ObservableCollection<Location>),
                typeof(CustomMapView),
                new System.Collections.ObjectModel.ObservableCollection<Location>());

        public System.Collections.ObjectModel.ObservableCollection<Location> Locations
        {
            get
            {
                return (System.Collections.ObjectModel.ObservableCollection<Location>)GetValue(LocationsProperty);
            }
            set
            {
                SetValue(LocationsProperty, value);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Locations")
            {
                Pins.Clear();
                foreach (var item in Locations)
                {
                    Pins.Add(new Pin(this)
                    {
                        Label = (Locations.IndexOf(item) + 1).ToString(),
                        Position = new Position(item.Latitude, item.Longitude),
                        Type = PinType.Pin,
                    });
                }
            }
        }

        public CustomMapView() : base()
        {
            Map.Layers.Add(new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap)) { Name = "OpenStreetMap" });
            Map.Widgets.Add(new ScaleBarWidget(Map));
        }
    }
}
