using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;

namespace KpnXam101.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage
    {
		public MainPage()
		{
			InitializeComponent();

		    Picker.ItemsSource = new List<string>
		    {
		        "Plus",
		        "Min",
            };
		}

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(Getal1.Text, out int getal1))
            {
                await DisplayAlert("Niet geldig", "Voer een geldig getal in", "OK");
                return;
            }

            if (!int.TryParse(Getal2.Text, out int getal2))
            {
                await DisplayAlert("Niet geldig", "Voer een geldig getal in", "OK");
                return;
            }

            string actie = (string) Picker.SelectedItem ?? string.Empty;
            if (string.IsNullOrEmpty(actie))
            {
                await DisplayAlert("Niet geldig", "Voer een geldig actie in", "OK");
                return;
            }

            int totaal;
            if (actie.Equals("plus", StringComparison.InvariantCultureIgnoreCase))
            {
                totaal = getal1 + getal2;
            }
            else
            {
                totaal = getal1 - getal2;
            }

            await DisplayAlert("Uitkomst", $"{totaal}", "OK");
        }
    }
}
