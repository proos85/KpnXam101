using Xamarin.Forms.Xaml;

namespace KpnXam101.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage
    {
		public MainPage()
		{
			InitializeComponent();

		    XamarinMonkey.Source = "https://i.redditmedia.com/92TL_kmRrwXC1eenJG0ocjMrYcNM64_1KtwtW6zo-u8.png?w=320&s=02380754ddf1ea89db0abee08a47f4bd";
		}
	}
}
