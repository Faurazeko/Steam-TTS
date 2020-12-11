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
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Steam_TTS
{
    public partial class SteamTTSForm : Form
    {
        public static RegistryKey regKey;
        public void LoadUserSettings()
        {
            checkBox2.Checked = Program.TTS.DontRepeatNick;
            checkBox1.Checked = Program.TTS.Mute;
            VolumeNumeric.Value = Program.TTS.Volume;
            numericUpDown1.Value = Program.TTS.Rate;
            autoload.Checked = Program.TTS.LoadWithWindows;
        }

        public static void TestVoice()
        {
            Program.TTS.Speak("Скушай еще этих мягких французких булок, да выпей чаю");
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Program.TTS.SaveSettings();
            Program.TTS.ForceDispose();
        }

        public SteamTTSForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void VolumeNumeric_ValueChanged(object sender, EventArgs e)
        {
            Program.TTS.Volume = (int)VolumeNumeric.Value;
            Program.TTS.SaveSettings();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.TTS.Mute = checkBox1.Checked;
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            Program.TTS.Rate = (int)numericUpDown1.Value;
            Program.TTS.SaveSettings();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Program.TTS.DontRepeatNick = checkBox2.Checked;
            Program.TTS.SaveSettings();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
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
                    Program.TTS.LoadWithWindows = true;
                }
                else
                {
                    regKey.DeleteValue("Steam-TTS");
                    Program.TTS.LoadWithWindows = false;
                }
                regKey.Flush();
                regKey.Close();
                Program.TTS.SaveSettings();
            }
            catch (Exception){}
        }

        private void SkipMessage_Click(object sender, EventArgs e)
        {
            Program.TTS.SkipMessage();
        }

    }
}
