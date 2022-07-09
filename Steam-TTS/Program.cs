using System;
using System.Text.RegularExpressions;
using System.Windows;
using Steamworks;

namespace Steam_TTS
{
    public static class Program
    {
        private static SteamId _lastSteamId;
        public static TTSService TtsService;
        static Regex LinkPattern = new Regex(@"(?:https?:\/\/)?(?:[\w\.]+)\.(?:[a-z]{2,6}\.?)(?:\/[\w\.]*)*\/?", RegexOptions.Compiled);
        static Regex SmilePattern = new Regex(":[A-Za-z0-9_]+:", RegexOptions.Compiled);

        static void OnSteamMessage(Friend friend, string content)
        {

            content = SmilePattern.Replace(content, "смайлик");
            content = LinkPattern.Replace(content, "ссылка");

            if (!TtsService.DontRepeatNick || _lastSteamId != friend.Id)
            {
                _lastSteamId = friend.Id;
                content = friend.Name + " сказал: " + content;
            }

            TtsService.Speak(content);
        }

        [STAThread]
        static void Main()
        {
            try
            {
                SteamClient.Init(480);
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "Для работы программы требуется запущенный Steam!\n\n(Не удалось инициализировать Steam Client)",
                        "TTS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return;
            }

            try
            {
                SteamFriends.ListenForFriendsMessages = true;

                SteamFriends.OnChatMessage += (Friend friend, string typeName, string content) =>
                {
                    if(typeName == "ChatMsg")
                    OnSteamMessage(friend, content);
                };

                TtsService = new TTSService();

                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

                SteamTTSForm TTSForm = new SteamTTSForm();
                TTSForm.LoadUserSettings();

                System.Windows.Forms.Application.Run(TTSForm);
            }
            catch (Exception){}
        }
    }
}
