using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Text.Json;
using System.Speech.Synthesis;
using System.Threading;
using System.Text.Json.Serialization;

namespace Steam_TTS
{
    public class TTSService : IDisposable
    {

        public bool DontRepeatNick
        {
            set
            {
                _SpeakThreadMutex.WaitOne();

                var newSettings = Settings;
                newSettings.DontRepeatNick = value;
                Settings = newSettings;

                UpdateSpeech();

                _SpeakThreadMutex.ReleaseMutex();

            }
            get => Settings.DontRepeatNick;
        }

        public bool LoadWithWindows
        {
            set
            {
                var newSettings = Settings;
                newSettings.LoadWithWindows = value;
                Settings = newSettings;
            }
            get => Settings.LoadWithWindows;
        }

        public int Rate
        {
            set
            {
                _SpeakThreadMutex.WaitOne();

                var newSettings = Settings;
                newSettings.Rate = value;
                Settings = newSettings;

                UpdateSpeech();

                _SpeakThreadMutex.ReleaseMutex();

            }
            get => Settings.Rate;
        }

        public int Volume
        {
            set
            {
                _SpeakThreadMutex.WaitOne();

                var newSettings = Settings;
                newSettings.Volume = value;
                Settings = newSettings;

                UpdateSpeech();

                _SpeakThreadMutex.ReleaseMutex();

            }
            get => Settings.Volume;
        }

        bool _Mute = false;

        public bool Mute
        {
            get
            {
                _SpeakThreadMutex.WaitOne();

                var mute = _Mute;

                _SpeakThreadMutex.ReleaseMutex();

                return mute;
            }

            set
            {
                if (value)
                    _Speech.SpeakAsyncCancelAll();

                _SpeakThreadMutex.WaitOne();

                _Mute = value;

                _SpeakThreadMutex.ReleaseMutex();
            }
                
        }

        public struct SpeechSettings
        {
            [JsonPropertyName("volume")]
            public int Volume { get; set; }

            [JsonPropertyName("rate")]
            public int Rate { get; set; }

            [JsonPropertyName("dontRepeatNick")]
            public bool DontRepeatNick { get; set; }

            [JsonPropertyName("LoadWithWindows")]
            public bool LoadWithWindows { get; set; }

        }

        public SpeechSettings Settings { get; private set; } = new SpeechSettings
        {
            Volume = 100,
            Rate = 0,
            DontRepeatNick = false,
            LoadWithWindows = false
        };
        SpeechSynthesizer _Speech = new SpeechSynthesizer();
        Stack<string> _SpeakOrder = new Stack<string>();
        Thread _SpeakThread;
        Mutex _SpeakThreadMutex = new Mutex();
        bool _RunSpeakThread = true;

        public bool IsWorking => _RunSpeakThread;

        void SpeakThread()
        {
            while (_RunSpeakThread)
            {
                _SpeakThreadMutex.WaitOne();

                while (_SpeakOrder.Count > 0)
                {
                    var message = _SpeakOrder.Pop();

                    if (_Mute)
                        continue;

                    try
                    {
                        _Speech.Speak(message);
                    }
                    catch (OperationCanceledException){}
                }

                _SpeakThreadMutex.ReleaseMutex();

                Thread.Sleep(10);
            }
        }

        void UpdateSpeech()
        {
            _Speech.Volume = Settings.Volume; // 0 ... 100
            _Speech.Rate = Settings.Rate; // -10 ... 100
        }

        public bool LoadSettings()
        {
            if (File.Exists("settings.json"))
            {
                try
                {
                    Settings = JsonSerializer.Deserialize<SpeechSettings>(File.ReadAllText("settings.json"));

                    UpdateSpeech();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed load settings! {0}", ex.ToString());
                }
            }
                return false;
        }

        public void SaveSettings()
        {
            File.WriteAllText("settings.json", JsonSerializer.Serialize(Settings));
        }

        public void ForceDispose()
        {
            _RunSpeakThread = false;

            Dispose();
        }

        public void SkipMessage() => _Speech.SpeakAsyncCancelAll();

        public void Dispose() => _RunSpeakThread = false;

        public TTSService()
        {
            _Speech.SetOutputToDefaultAudioDevice();
            _Speech.SelectVoiceByHints(0, 0, 0, new CultureInfo("RU-ru", true));

            LoadSettings();

            _SpeakThread = new Thread(SpeakThread);
            _SpeakThread.Start();
        }

        public void Speak(string what)
        {
            _SpeakThreadMutex.WaitOne();
            _SpeakOrder.Push(what);
            _SpeakThreadMutex.ReleaseMutex();
        }
    }
}
