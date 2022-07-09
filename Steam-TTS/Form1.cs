using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace Steam_TTS
{
    public partial class SteamTTSForm : Form
    {
        public static RegistryKey regKey;
        public void LoadUserSettings()
        {
            checkBox2.Checked = Program.TtsService.DontRepeatNick;
            checkBox1.Checked = Program.TtsService.Mute;
            VolumeNumeric.Value = Program.TtsService.Volume;
            numericUpDown1.Value = Program.TtsService.Rate;
            autoload.Checked = Program.TtsService.LoadWithWindows;

            this.FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Program.TtsService.SaveSettings();
            Program.TtsService.ForceDispose();
        }

        public static void TestVoice()
        {
            Program.TtsService.Speak("Скушай еще этих мягких французких булок, да выпей чаю");
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Program.TtsService.SaveSettings();
            Program.TtsService.ForceDispose();
        }

        public SteamTTSForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void VolumeNumeric_ValueChanged(object sender, EventArgs e)
        {
            Program.TtsService.Volume = (int)VolumeNumeric.Value;
            Program.TtsService.SaveSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.TtsService.Mute = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            Program.TtsService.Rate = (int)numericUpDown1.Value;
            Program.TtsService.SaveSettings();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Program.TtsService.DontRepeatNick = checkBox2.Checked;
            Program.TtsService.SaveSettings();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void TestVoiceButton_Click(object sender, EventArgs e)
        {
            Thread MyThread = new Thread(TestVoice);
            MyThread.Start();
        }

        private void autoload_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                regKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");

                if (autoload.Checked)
                {
                    regKey.SetValue("Steam-TTS", Assembly.GetExecutingAssembly().Location);
                    Program.TtsService.LoadWithWindows = true;
                }
                else
                {
                    regKey.DeleteValue("Steam-TTS");
                    Program.TtsService.LoadWithWindows = false;
                }
                regKey.Flush();
                regKey.Close();
                Program.TtsService.SaveSettings();
            }
            catch (Exception){}
        }

        private void SkipMessage_Click(object sender, EventArgs e)
        {
            Program.TtsService.SkipMessage();
        }

    }
}
