using Android.App;
using Android.Speech.Tts;
using KpnXam101.Droid.TextToSpeak;
using KpnXam101.TextToSpeak;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeak))]
namespace KpnXam101.Droid.TextToSpeak
{
    public class TextToSpeak: Java.Lang.Object, ITextToSpeak, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _toSpeak;

        public void Speak(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                var mainActivityInstance = (Activity)Forms.Context;

                _speaker = new TextToSpeech(mainActivityInstance, this);
            }
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}