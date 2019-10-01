using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Animals.Client.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Color : ResourceDictionary
    {
		public Color ()
		{
			InitializeComponent ();
		}
	}
}