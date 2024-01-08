using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using P06Shop.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.SpeechService
{
    public class SpeechService : ISpeechService
    {
        private readonly SpeechSettings _speechSettings;

        public SpeechService(SpeechSettings speechSettings)
        {
            _speechSettings = speechSettings;
        }
        // Microsoft.CognitiveServices.Speech
        public async Task<SpeechRecognitionResult> RecognizeAsync()
        {
            var conf = SpeechConfig.FromSubscription(_speechSettings.SpeechApiKey, _speechSettings.SpeechRegion);
            conf.SpeechRecognitionLanguage = _speechSettings.SpeechRecognitionLanguage;
            return await RecognizeFromMic(conf);
        }

        private async Task<SpeechRecognitionResult> RecognizeFromMic(SpeechConfig speechConfig)
        {
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            return result;
        }
    }
}
