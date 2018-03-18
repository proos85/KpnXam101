using KpnXam101.ViewModel;
using Xamarin.Forms.Xaml;

namespace KpnXam101.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage
    {
		public MainPage()
		{
			InitializeComponent();
		    BindingContext = new CalculatorViewModel();
		}

    }
}