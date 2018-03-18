using AVFoundation;
using KpnXam101.iOS.TextToSpeak;
using KpnXam101.TextToSpeak;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeak))]
namespace KpnXam101.iOS.TextToSpeak
{
    public class TextToSpeak: ITextToSpeak
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}