﻿using AVFoundation;
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
                Rate = AVSpeechUtterance.MaximumSpeechRate,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-AU"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}