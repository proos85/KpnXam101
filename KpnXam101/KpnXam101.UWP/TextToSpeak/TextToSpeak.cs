using System;
using Windows.UI.Xaml.Controls;
using KpnXam101.TextToSpeak;
using KpnXam101.UWP.TextToSpeak;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeak))]
namespace KpnXam101.UWP.TextToSpeak
{
    public class TextToSpeak: ITextToSpeak
    {
        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}