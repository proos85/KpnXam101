using System.Windows.Input;
using KpnXam101.TextToSpeak;
using Xamarin.Forms;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedMember.Global
namespace KpnXam101.ViewModel
{
    public class CalculatorViewModel: BaseViewModel
    {
        private string _totaal = "0";
        public string Totaal
        {
            get => _totaal;
            set
            {
                if (_totaal != value)
                {
                    _totaal = value;
                    OnPropertyChanged(nameof(Totaal));
                }
            }
        }


        private string _plusBackgroundColor = "brown";
        public string PlusBackgroundColor
        {
            get => _plusBackgroundColor;
            set
            {
                if (_plusBackgroundColor != value)
                {
                    _plusBackgroundColor = value;
                    OnPropertyChanged(nameof(PlusBackgroundColor));
                }
            }
        }

        private string _minBackgroundColor = "brown";
        public string MinBackgroundColor
        {
            get => _minBackgroundColor;
            set
            {
                if (_minBackgroundColor != value)
                {
                    _minBackgroundColor = value;
                    OnPropertyChanged(nameof(MinBackgroundColor));
                }
            }
        }


        public int Getal1 { get; set; }
        public int Getal2 { get; set; }
        public bool HeeftGebruikerPlusOfMinGeselecteerd { get; set; }
        public bool HeeftGebruikerPlusGeselecteerd { get; set; }
        public bool HeeftGebruikerMinGeselecteerd { get; set; }

        public ICommand KnopAction { get; set; }
        public ICommand PlusMinAction { get; set; }
        public ICommand BerekenAction { get; set; }
        public ICommand WisAction { get; set; }

        public CalculatorViewModel()
        {
            KnopAction = new Command<string>(KnopActionHandler);
            PlusMinAction = new Command<string>(PlusMinActionHandler);
            BerekenAction = new Command(BerekenActionHandler);
            WisAction = new Command(WisActionHandler);
        }

        private void KnopActionHandler(string knop)
        {
            try
            {
                if (!HeeftGebruikerPlusOfMinGeselecteerd)
                {
                    string getal1String = Getal1 == 0 ? string.Empty : Getal1.ToString();
                    string newGetal1String = $"{getal1String}{knop}";

                    Getal1 = int.Parse(newGetal1String);
                    Totaal = newGetal1String;
                }
                else
                {
                    string getal1String = Getal1 == 0 ? string.Empty : Getal1.ToString();

                    string getal2String = Getal2 == 0 ? string.Empty : Getal2.ToString();
                    string newGetal2String = $"{getal2String}{knop}";

                    Getal2 = int.Parse(newGetal2String);
                    Totaal = $"{getal1String} {(HeeftGebruikerPlusGeselecteerd ? "+" : "-")} {newGetal2String}";
                }
            }
            catch
            {
                // Ignore
            }
        }

        private void PlusMinActionHandler(string knop)
        {
            HeeftGebruikerPlusOfMinGeselecteerd = true;
            HeeftGebruikerPlusGeselecteerd = knop.Equals("+");
            HeeftGebruikerMinGeselecteerd = knop.Equals("-");

            PlusBackgroundColor = HeeftGebruikerPlusGeselecteerd ? "Yellow" : "Brown";
            MinBackgroundColor = HeeftGebruikerMinGeselecteerd ? "Yellow" : "Brown";
        }

        private void BerekenActionHandler()
        {
            if (!HeeftGebruikerPlusOfMinGeselecteerd)
            {
                return;
            }

            try
            {
                int totaal;
                if (HeeftGebruikerPlusGeselecteerd)
                {
                    totaal = Getal1 + Getal2;
                }
                else
                {
                    totaal = Getal1 - Getal2;
                }

                Totaal = totaal.ToString();

                Getal1 = Getal2 = 0;
                HeeftGebruikerPlusOfMinGeselecteerd = HeeftGebruikerPlusGeselecteerd = HeeftGebruikerMinGeselecteerd = false;
                PlusBackgroundColor = MinBackgroundColor = "Brown";

                DependencyService.Get<ITextToSpeak>().Speak(Totaal);
            }
            catch
            {
                // Ignore
            }
        }

        private void WisActionHandler()
        {
            Getal1 = Getal2 = 0;
            HeeftGebruikerPlusOfMinGeselecteerd = HeeftGebruikerPlusGeselecteerd = HeeftGebruikerMinGeselecteerd = false;
            Totaal = "0";
            PlusBackgroundColor = MinBackgroundColor = "Brown";
        }
    }
}
