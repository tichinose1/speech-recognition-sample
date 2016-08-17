using Microsoft.Speech.Recognition;
using System;
using System.Diagnostics;
using System.Linq;

namespace SpeechRecognitionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Recognize();

            Console.ReadLine();
        }

        static void Recognize()
        {
            var recognizer = GetRecognizer();

            var engine = new SpeechRecognitionEngine(recognizer);
            engine.SetInputToDefaultAudioDevice();
            engine.SpeechDetected += SpeechRecognitionEngine_SpeechDetected;
            engine.SpeechHypothesized += SpeechRecognitionEngine_SpeechHypothesized;
            engine.SpeechRecognized += SpeechRecognitionEngine_SpeechRecognized;
            engine.SpeechRecognitionRejected += SpeechRecognitionEngine_SpeechRecognitionRejected;
            engine.RecognizeCompleted += SpeechRecognistionEngine_RecognizeCompleted;

            var grammar = new Grammar(new GrammarBuilder(new Choices(new[]
            {
                "生活満足度",
                "せいかつまんぞくど",
                "あおいろ"
            })));
            engine.LoadGrammarAsync(grammar);

            engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        static void SpeechRecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Debug.WriteLine("SpeechRecognitionRejected");
        }

        static void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Debug.WriteLine("SpeechRecognized");
            foreach (var alternate in e.Result.Alternates)
            {
                foreach (var unit in alternate.ReplacementWordUnits)
                {
                    Debug.WriteLine("Alternates.ReplacementWordUnits.Text: {0}", unit.Text);
                }
                foreach (var word in alternate.Words)
                {
                    Debug.WriteLine("Alternates.Words.LexicalForm: {0}", word.LexicalForm);
                    Debug.WriteLine("Alternates.Words.Pronunciation: {0}", word.Pronunciation);
                    Debug.WriteLine("Alternates.Words.Text: {0}", word.Text);
                }
            }
            foreach (var item in e.Result.ReplacementWordUnits)
            {
                Debug.WriteLine("ReplacementWordUnits.Text: {0}", item.Text);
            }
            foreach (var item in e.Result.Words)
            {
                Debug.WriteLine("Words.LexicalForm: {0}", item.LexicalForm);
                Debug.WriteLine("Words.Pronunciation: {0}", item.Pronunciation);
                Debug.WriteLine("Words.Text: {0}", item.Text);
            }
            Debug.WriteLine("Text: {0}", e.Result.Text);
        }

        static void SpeechRecognitionEngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Debug.WriteLine("SpeechHypothesized");
        }

        static void SpeechRecognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Debug.WriteLine("SpeechDetected");
        }

        static void SpeechRecognistionEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Debug.WriteLine("RecognizeCompleted");
        }

        static RecognizerInfo GetRecognizer()
        {
            return SpeechRecognitionEngine.InstalledRecognizers().First(r => r.Culture.Name == "ja-JP");
        }
    }
}
