using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Windows.Forms;

namespace Steam_TTS
{
    partial class SteamTTSForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SteamTTSForm));
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.VolumeNumeric = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.version = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.RateLable = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TestVoiceButton = new System.Windows.Forms.Button();
            this.autoload = new System.Windows.Forms.CheckBox();
            this.SkipMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(9, 22);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(45, 13);
            this.VolumeLabel.TabIndex = 0;
            this.VolumeLabel.Text = "Volume:";
            // 
            // VolumeNumeric
            // 
            this.VolumeNumeric.Location = new System.Drawing.Point(65, 13);
            this.VolumeNumeric.Name = "VolumeNumeric";
            this.VolumeNumeric.Size = new System.Drawing.Size(50, 20);
            this.VolumeNumeric.TabIndex = 1;
            this.VolumeNumeric.ValueChanged += new System.EventHandler(this.VolumeNumeric_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Mute";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(9, 428);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(53, 13);
            this.version.TabIndex = 3;
            this.version.Text = "Beta v0.6";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(683, 428);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(105, 13);
            this.copyright.TabIndex = 4;
            this.copyright.Text = "(c) Faurazeko, _zXor";
            // 
            // RateLable
            // 
            this.RateLable.AutoSize = true;
            this.RateLable.Location = new System.Drawing.Point(12, 50);
            this.RateLable.Name = "RateLable";
            this.RateLable.Size = new System.Drawing.Size(33, 13);
            this.RateLable.TabIndex = 5;
            this.RateLable.Text = "Rate:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(65, 40);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "(0 is deafault)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 89);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(312, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Do not repeat nickname if the message has the same sender";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Steam-TTS";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // TestVoiceButton
            // 
            this.TestVoiceButton.Location = new System.Drawing.Point(121, 12);
            this.TestVoiceButton.Name = "TestVoiceButton";
            this.TestVoiceButton.Size = new System.Drawing.Size(75, 23);
            this.TestVoiceButton.TabIndex = 10;
            this.TestVoiceButton.Text = "Test voice";
            this.TestVoiceButton.UseVisualStyleBackColor = true;
            this.TestVoiceButton.Click += new System.EventHandler(this.TestVoiceButton_Click);
            // 
            // autoload
            // 
            this.autoload.AutoSize = true;
            this.autoload.Location = new System.Drawing.Point(12, 112);
            this.autoload.Name = "autoload";
            this.autoload.Size = new System.Drawing.Size(139, 17);
            this.autoload.TabIndex = 11;
            this.autoload.Text = "Load with windows start";
            this.autoload.UseVisualStyleBackColor = true;
            this.autoload.CheckedChanged += new System.EventHandler(this.autoload_CheckedChanged);
            // 
            // SkipMessage
            // 
            this.SkipMessage.Location = new System.Drawing.Point(12, 135);
            this.SkipMessage.Name = "SkipMessage";
            this.SkipMessage.Size = new System.Drawing.Size(138, 23);
            this.SkipMessage.TabIndex = 12;
            this.SkipMessage.Text = "Skip current message";
            this.SkipMessage.UseVisualStyleBackColor = true;
            this.SkipMessage.Click += new System.EventHandler(this.SkipMessage_Click);
            // 
            // SteamTTSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SkipMessage);
            this.Controls.Add(this.autoload);
            this.Controls.Add(this.TestVoiceButton);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.RateLable);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.version);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.VolumeNumeric);
            this.Controls.Add(this.VolumeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SteamTTSForm";
            this.Text = "Steam-TTS";
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.NumericUpDown VolumeNumeric;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label RateLable;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button TestVoiceButton;
        private CheckBox autoload;
        private Button SkipMessage;
    }
}

