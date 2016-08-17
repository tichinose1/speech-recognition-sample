using Microsoft.Speech.Recognition;
using SpeechRecognitionConsole.Properties;
using System;
using System.Diagnostics;
using System.Globalization;

namespace SpeechRecognitionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();

            Console.ReadLine();
        }

        static void Execute()
        {
            var engine = new SpeechRecognitionEngine(new CultureInfo(Settings.Default.Culture));
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
                "冷蔵庫"
            })));
            engine.LoadGrammarAsync(grammar);

            engine.RecognizeAsync(RecognizeMode.Multiple);
        }

        static void SpeechRecognitionEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Debug.Print("SpeechRecognitionRejected");
        }

        static void SpeechRecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Debug.Print("SpeechRecognized");

            foreach (var a in e.Result.Alternates)
            {
                foreach (var u in a.ReplacementWordUnits)
                    Debug.Print("e.Result.Alternates.ReplacementWordUnits.Text: {0}", u.Text);

                foreach (var w in a.Words)
                {
                    Debug.Print("e.Result.Alternates.Words.LexicalForm: {0}", w.LexicalForm);
                    Debug.Print("e.Result.Alternates.Words.Pronunciation: {0}", w.Pronunciation);
                    Debug.Print("e.Result.Alternates.Words.Text: {0}", w.Text);
                }
            }

            foreach (var u in e.Result.ReplacementWordUnits)
                Debug.Print("e.Result.ReplacementWordUnits.Text: {0}", u.Text);

            foreach (var w in e.Result.Words)
            {
                Debug.Print("e.Result.Words.LexicalForm: {0}", w.LexicalForm);
                Debug.Print("e.Result.Words.Pronunciation: {0}", w.Pronunciation);
                Debug.Print("e.Result.Words.Text: {0}", w.Text);
            }

            Debug.Print("e.Result.Text: {0}", e.Result.Text);
            Debug.Print("e.Result.Confidence: {0}", e.Result.Confidence);
        }

        static void SpeechRecognitionEngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            Debug.Print("SpeechHypothesized");
        }

        static void SpeechRecognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Debug.Print("SpeechDetected");
        }

        static void SpeechRecognistionEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Debug.Print("RecognizeCompleted");
        }
    }
}
