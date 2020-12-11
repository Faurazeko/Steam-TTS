using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows;
using Steamworks;

namespace Steam_TTS
{
    public static class Program
    {
        static SteamId lastSteamId;
        public static TTSService TTS;
        static Regex LinkPattern = new Regex(@"(?:https?:\/\/)?(?:[\w\.]+)\.(?:[a-z]{2,6}\.?)(?:\/[\w\.]*)*\/?", RegexOptions.Compiled);
        static Regex SmilePattern = new Regex(":[A-Za-z0-9_]+:", RegexOptions.Compiled);

        static void OnSteamMessage(Friend friend, string content)
        {

            content = SmilePattern.Replace(content, "смайлик");
            content = LinkPattern.Replace(content, "ссылка");

            if (!TTS.DontRepeatNick || lastSteamId != friend.Id)
            {
                lastSteamId = friend.Id;
                content = friend.Name + " сказал: " + content;
            }

            TTS.Speak(content);
        }

        [STAThread]
        static void Main()
        {
            try
            {
                SteamClient.Init(480);
            }
            catch (System.Exception)
            {
                System.Windows.MessageBox.Show(
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

                TTS = new TTSService();

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
