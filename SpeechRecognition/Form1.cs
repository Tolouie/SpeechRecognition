using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;
using System.Web;
using System.Net;
using Google.Cloud.Translate.V3;

namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        SpeechRecognitionEngine startListening = new SpeechRecognitionEngine();

        Random rnd = new Random();

        int RecTimeOut = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice(); //Sets the default headphones and microphones. Internal mics don't pick up audio well
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines("DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startListening.SetInputToDefaultAudioDevice();
            startListening.LoadGrammarAsync(new Grammar(new Choices(File.ReadAllLines("DefaultCommands.txt"))));
            startListening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startListening_SpeechRecognized);
        }
        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;
            if (speech == "Launch google")
            {
                Process.Start("chrome.exe");
            }
            if(speech == "Open up youtube")
            {
                Process.Start("chrome.exe", @"http://www.youtube.com/");
            }

            if (speech == "Hello")
            {
                _synthesizer.SpeakAsync("Hello, I am here");
            }
            if (speech == "Testing")
            {
                _synthesizer.SpeakAsync("Speech recognizer working");
            }
            if(speech == "What time is it")
            {
                _synthesizer.SpeakAsync(DateTime.Now.ToString("h mm tt"));
            }
            if (speech == "Stop talking")
            {
                _synthesizer.SpeakAsyncCancelAll();
                ranNum = rnd.Next(1, 2);
                if(ranNum == 1)
                {
                    _synthesizer.SpeakAsync("Yes sir");
                }
                if(ranNum == 2)
                {
                    _synthesizer.SpeakAsync("I will be quiet");
                }
            }
            if(speech == "Stop listening")
            {
                _synthesizer.SpeakAsync("If you need me just ask");
                _recognizer.RecognizeAsyncCancel();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
            }
            if (speech == "Show Commands")
            {
                string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));

                listBoxCommand.Items.Clear();
                listBoxCommand.SelectionMode = SelectionMode.None;
                listBoxCommand.Visible = true;
                foreach(string command in commands)
                {
                    listBoxCommand.Items.Add(command);
                }
            }

            if(speech == "Hide Commands")
            {
                listBoxCommand.Visible = false;
            }

        }
        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }
        private void startListening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Wake up")
            {
                startListening.RecognizeAsyncCancel();
                _synthesizer.SpeakAsync("Yes, I'm here");

            }
        }
        private void tmrSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                tmrSpeaking.Stop();
                startListening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetSupportedLanguagesRequest request = new GetSupportedLanguagesRequest();

            request.Parent = "projects/translatespeech-371415";
            //synthesizer.SetOutputToDefaultAudioDevice();
            _synthesizer.Speak("");
            //TC: TESTING
            var client = TranslationServiceClient.Create();
            var response = client.GetSupportedLanguagesAsync(request);
            Console.WriteLine(response);
        }
    }
}
