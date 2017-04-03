using Microsoft.CognitiveServices.SpeechRecognition;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechRecognitionWpf3
{
    public static class OxfordClient
    {
        public static Action<string> OnPartialResponseReceived;
        public static Action<string> OnResponseReceived;

        private static MicrophoneRecognitionClient client;

        public static void Initialize()
        {
            client = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                SpeechRecognitionMode.ShortPhrase,
                "ja-JP",
                "90208e524a694073908643976ff7efeb");

            client.OnResponseReceived += Client_OnResponseReceived;
            client.OnPartialResponseReceived += Client_OnPartialResponseReceived;
        }

        public static void Start()
        {
            client.StartMicAndRecognition();
        }

        private static void Client_OnPartialResponseReceived(object sender, PartialSpeechResponseEventArgs e)
        {
            OnPartialResponseReceived?.Invoke(e.PartialResult);
            Debug.WriteLine("OnPartialResponseReceived: " + e.PartialResult);
        }

        private static void Client_OnResponseReceived(object sender, SpeechResponseEventArgs e)
        {
            if (e.PhraseResponse.Results.Length == 0) return;

            // 不要？
            //client.EndMicAndRecognition();

            foreach (var item in e.PhraseResponse.Results)
            {
                Debug.WriteLine("OnResponseReceived: " + item.DisplayText);
            }

            OnResponseReceived?.Invoke(e.PhraseResponse.Results[0].DisplayText);
        }
    }
}
