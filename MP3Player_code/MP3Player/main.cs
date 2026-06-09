using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;


namespace MP3Player
{
    public partial class mainForm : Form
    {
        private void StartFalling()
        {
            Timer fallTimer = new Timer { Interval = 15 };
            int velocity = 0;

            fallTimer.Tick += (s, ev) =>
            {
                velocity += 2;
                CAPTION.Top += velocity;
                CAPTIONTEXT.Top = CAPTION.Top;

                if (CAPTION.Top >= this.Height - CAPTION.Height)
                {
                    fallTimer.Stop();
                    isBroken = true;

                    this.Opacity = 0.6;

                    Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_TEMPO, -80f);

                    Timer repair = new Timer { Interval = 3000 };
                    repair.Tick += (s2, ev2) => {
                        CAPTION.Top = 0;
                        CAPTIONTEXT.Top = 0;
                        CAPTION.Left = 0;
                        CAPTIONTEXT.Left = 0;
                        isBroken = false;

                        Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, -1f, 0);
                        Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_TEMPO, -1f, 0);

                        Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_TEMPO, isFast ? 100f : 0f);
                        Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_FREQ, 44100f);

                        float targetVol = MUTE.Checked ? 0f : (SONGVOLUME.Value / 50.0f);
                        Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, targetVol);

                        CAPTIONTEXT.Text = "MP3Player by ilyabloger123";
                        this.Opacity = 1.0;

                        foreach (Control c in this.Controls) c.Refresh();
                        this.Refresh();

                        captionClicks = 0;
                        repair.Stop();
                    };
                    repair.Start();
                }
            };
            fallTimer.Start();
        }
        public void RoundCorners(int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(this.Width - d, 0, d, d, 270, 90);
            path.AddArc(this.Width - d, this.Height - d, d, d, 0, 90);
            path.AddArc(0, this.Height - d, d, d, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public void ApplyTheme()
        {
            Color darkBack = Color.FromArgb(30, 30, 30);
            Color darkAccent = Color.FromArgb(40, 40, 40);
            Color lightBack = SystemColors.Control;
            Color lightAccent = Color.FromArgb(220, 220, 220);

            if (isDarkTheme)
            {
                this.BackColor = darkBack;

                Color textC = Color.White;
                SONGLABEL.ForeColor = VOLUMELABEL.ForeColor = TIME.ForeColor = textC;
                SPEEDLABEL.ForeColor = THEMELABEL.ForeColor = MUTE.ForeColor = LOOP.ForeColor = textC;
                DECORATIVETIMELABEL.ForeColor = DECORATIVEVOLUMELABEL.ForeColor = DECORATIVEBALANCELABEL.ForeColor = textC;

                CAPTION.BackColor = CAPTIONTEXT.BackColor = darkAccent;
                CAPTIONTEXT.ForeColor = textC;
                EXITBUTTON.BackColor = MINIMIZEBUTTON.BackColor = darkAccent;
                EXITBUTTON.ForeColor = MINIMIZEBUTTON.ForeColor = textC;

                Color btnC = Color.FromArgb(50, 50, 50);
                PLAY.BackColor = STOP.BackColor = OPEN.BackColor = GOTOSETTINGS.BackColor = SPEEDUP.BackColor = btnC;
                PLAY.ForeColor = STOP.ForeColor = OPEN.ForeColor = GOTOSETTINGS.ForeColor = SPEEDUP.ForeColor = textC;

                SONGVOLUME.BackColor = SONGTIME.BackColor = darkBack;

                if (SONGPREVIEW.Tag == null)
                {
                    SONGPREVIEW.Image = Properties.Resources.audio_file_white;
                }

                THEMELABEL.Text = "Тема: Тёмная";
            }
            else
            {
                this.BackColor = lightBack;

                Color textC = Color.Black;
                SONGLABEL.ForeColor = VOLUMELABEL.ForeColor = TIME.ForeColor = textC;
                SPEEDLABEL.ForeColor = THEMELABEL.ForeColor = MUTE.ForeColor = LOOP.ForeColor = textC;
                DECORATIVETIMELABEL.ForeColor = DECORATIVEVOLUMELABEL.ForeColor = DECORATIVEBALANCELABEL.ForeColor = textC;

                CAPTION.BackColor = CAPTIONTEXT.BackColor = lightAccent;
                CAPTIONTEXT.ForeColor = textC;
                EXITBUTTON.BackColor = MINIMIZEBUTTON.BackColor = lightAccent;
                EXITBUTTON.ForeColor = MINIMIZEBUTTON.ForeColor = textC;

                Color btnC = SystemColors.ControlLight;
                PLAY.BackColor = STOP.BackColor = OPEN.BackColor = GOTOSETTINGS.BackColor = SPEEDUP.BackColor = btnC;
                PLAY.ForeColor = STOP.ForeColor = OPEN.ForeColor = GOTOSETTINGS.ForeColor = SPEEDUP.ForeColor = textC;

                SONGVOLUME.BackColor = SONGTIME.BackColor = lightBack;

                if (SONGPREVIEW.Tag == null)
                {
                    SONGPREVIEW.Image = Properties.Resources.audio_file_black;
                }

                THEMELABEL.Text = "Тема: Светлая";
            }
        }

        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void UpdateVolumeLabel()
        {
            if (MUTE.Checked)
            {
                VOLUMELABEL.Text = "Громкость: 0";
            }
            else
            {
                VOLUMELABEL.Text = $"Громкость: {SONGVOLUME.Value * 2}";
            }
        }
        private void LoadFile(string path)
        {
            CloseStream();
            SONGLABEL.Text = "Сейчас играет: " + System.IO.Path.GetFileName(path);

            stream = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_STREAM_DECODE);

            try
            {
                var file = TagLib.File.Create(path);

                if (file.Tag.Pictures.Length > 0)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    using (MemoryStream ms = new MemoryStream(bin))
                    {
                        Image img = Image.FromStream(ms);
                        SONGPREVIEW.Image = new Bitmap(img);
                        SONGPREVIEW.Tag = "cover";
                    }
                }
                else
                {
                    SONGPREVIEW.Tag = null;
                    SONGPREVIEW.Image = isDarkTheme ? Properties.Resources.audio_file_white : Properties.Resources.audio_file_black;
                }
            }
            catch
            {
                SONGPREVIEW.Tag = null;
                SONGPREVIEW.Image = isDarkTheme ? Properties.Resources.audio_file_white : Properties.Resources.audio_file_black;
            }

            tempoStream = BassFx.BASS_FX_TempoCreate(stream, BASSFlag.BASS_FX_FREESOURCE);

            CAPTIONTEXT.Text = "MP3Player — Играет";

            Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, SONGVOLUME.Value / 50f);
            Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_PAN, TRACKPAN.Value / 10f);

            long bytes = Bass.BASS_ChannelGetLength(tempoStream);
            SONGTIME.Maximum = (int)Bass.BASS_ChannelBytes2Seconds(tempoStream, bytes);

            Bass.BASS_ChannelPlay(tempoStream, false);

            PLAY.Text = "Ⅱ";
            PLAY.ForeColor = isDarkTheme ? Color.Cyan : Color.Blue;
        }

        private void CloseStream()
        {
            if (tempoStream != 0)
            {
                Bass.BASS_StreamFree(tempoStream);
                tempoStream = 0;
            }
        }

        private int stream;
        private int tempoStream;
        private bool isFast;
        private bool userStopped = false;
        public bool isDarkTheme = true;
        private int captionClicks = 0;
        private int timeUpdateCounter = 0;
        private bool isBroken = false;
        private OpenFileDialog open = new OpenFileDialog();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isBroken)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    using (Pen p = new Pen(isDarkTheme ? Color.White : Color.Black, 2))
                    {
                        Random r = new Random();
                        int hitX = Width / 2;
                        int hitY = Height - 10;

                        for (int i = 0; i < 20; i++)
                        {
                            g.DrawLine(p, hitX, hitY, r.Next(Width), r.Next(Height));
                        }
                        g.DrawEllipse(p, hitX - 10, hitY - 10, 20, 20);
                    }
                }
            }
        }
        public mainForm()
        {
            InitializeComponent();

            isBroken = false;

            CAPTION.MouseDown += main_MouseDown;

            RoundCorners(10);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            this.Opacity = Properties.Settings.Default.PlayerOpacity;

            isDarkTheme = Properties.Settings.Default.DarkTheme;
            ApplyTheme();

            CAPTIONTEXT.Text = "MP3Player — Ожидание";

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            SONGVOLUME.Value = Properties.Settings.Default.Volume;
            LOOP.Checked = Properties.Settings.Default.isLoop;

            SONGLABEL.Text = "Сейчас играет:";
            TIME.Text = "00:00 / 00:00";

            UpdateVolumeLabel();
        }

        private void OPEN_Click(object sender, EventArgs e)
        {
            open.Filter = "Аудио *.mp3, *.wav|*.mp3;*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
                isFast = !isFast;
                SPEEDUP.Text = "Ускорить"; SPEEDLABEL.Text = "Скорость: 1x";
                LoadFile(open.FileName);
            }
        }

        private void PLAY_Click(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                if (Bass.BASS_ChannelIsActive(tempoStream) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, 0f, 200);
                    Bass.BASS_ChannelPause(tempoStream);
                    PLAY.Text = "►";
                    CAPTIONTEXT.Text = "MP3Player — Пауза";

                    PLAY.ForeColor = isDarkTheme ? Color.White : Color.Black;
                }
                else
                {
                    Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, -1f, 0);

                    Bass.BASS_ChannelPlay(tempoStream, false);

                    float targetVol = MUTE.Checked ? 0f : (SONGVOLUME.Value / 50.0f);
                    Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, targetVol, 500);

                    PLAY.Text = "Ⅱ";
                    CAPTIONTEXT.Text = "MP3Player — Играет";

                    PLAY.ForeColor = Color.Cyan;
                }
            }
        }

        private void STOP_Click(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                userStopped = true;
                Bass.BASS_ChannelStop(tempoStream);
                Bass.BASS_ChannelSetPosition(tempoStream, 0);

                PLAY.Text = "►";
                CAPTIONTEXT.Text = "MP3Player — Ожидание";
                SONGTIME.Value = 0;

                VU_LEFT.Value = 0;
                VU_RIGHT.Value = 0;
            }
        }

        private void TIMETIMER_Tick(object sender, EventArgs e)
        {
            if (isBroken)
            {
                Random r = new Random();
                using (Pen p = new Pen(Color.Red, 1))
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.DrawLine(p, Width / 2, Height - 10, r.Next(Width), r.Next(Height));
                    }
                    foreach (Control c in this.Controls)
                    {
                        using (Graphics g = c.CreateGraphics())
                        {
                            int hitX = (Width / 2) - c.Left;
                            int hitY = (Height - 10) - c.Top;
                            g.DrawLine(p, hitX, hitY, r.Next(-Width, Width), r.Next(-Height, Height));
                        }
                    }
                }
            }
                if (tempoStream != 0 && Bass.BASS_ChannelIsActive(tempoStream) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                int level = Bass.BASS_ChannelGetLevel(tempoStream);
                float pan = TRACKPAN.Value / 10f;
                int leftVal = Math.Abs((int)Utils.LowWord(level));
                int rightVal = Math.Abs((int)Utils.HighWord(level));
                float leftMult = pan > 0 ? (1.0f - pan) : 1.0f;
                float rightMult = pan < 0 ? (1.0f + pan) : 1.0f;
                if (MUTE.Checked) { leftMult = 0; rightMult = 0; }

                VU_LEFT.Value = (int)(leftVal * leftMult);
                VU_RIGHT.Value = (int)(rightVal * rightMult);

                int avgLevel = (VU_LEFT.Value + VU_RIGHT.Value) / 2;

                if (avgLevel > 20000)
                {
                    PLAY.ForeColor = Color.Aquamarine;
                    STOP.ForeColor = Color.Aquamarine;
                }
                else
                {
                    if (isDarkTheme)
                    {
                        PLAY.ForeColor = Color.White;
                        STOP.ForeColor = Color.White;
                    }
                    else
                    {
                        PLAY.ForeColor = Color.Black;
                        STOP.ForeColor = Color.Black;
                    }
                }

                if (avgLevel > 22000)
                {
                    CAPTIONTEXT.ForeColor = Color.Aquamarine;
                }
                else
                {
                    if (isDarkTheme) CAPTIONTEXT.ForeColor = Color.White;
                    else CAPTIONTEXT.ForeColor = Color.Black;
                }
            }
            else
            {
                VU_LEFT.Value = 0;
                VU_RIGHT.Value = 0;

                if (isDarkTheme)
                {
                    CAPTIONTEXT.ForeColor = Color.White;
                    PLAY.ForeColor = Color.White;
                }
                else
                {
                    CAPTIONTEXT.ForeColor = Color.Black;
                    PLAY.ForeColor = Color.Black;
                }
            }

            if (tempoStream != 0)
            {
                double currentSec = Bass.BASS_ChannelBytes2Seconds(tempoStream, Bass.BASS_ChannelGetPosition(tempoStream));
                double totalSec = Bass.BASS_ChannelBytes2Seconds(tempoStream, Bass.BASS_ChannelGetLength(tempoStream));

                timeUpdateCounter++;
                if (timeUpdateCounter >= 5)
                {
                    if (!SONGTIME.Capture)
                    {
                        SONGTIME.Maximum = (int)totalSec;
                        if (currentSec <= totalSec) SONGTIME.Value = (int)currentSec;
                    }

                    TimeSpan tc = TimeSpan.FromSeconds(currentSec);
                    TimeSpan tt = TimeSpan.FromSeconds(totalSec);
                    TIME.Text = string.Format("{0:mm\\:ss} / {1:mm\\:ss}", tc, tt);

                    timeUpdateCounter = 0;
                }

                if (Bass.BASS_ChannelIsActive(tempoStream) == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    if (LOOP.Checked && !userStopped)
                    {
                        Bass.BASS_ChannelSetPosition(tempoStream, 0);
                        Bass.BASS_ChannelPlay(tempoStream, false);
                        CAPTIONTEXT.Text = "MP3Player — Играет";
                        PLAY.Text = "Ⅱ";
                    }
                    else
                    {
                        PLAY.Text = "►";
                        if (userStopped) CAPTIONTEXT.Text = "MP3Player — Ожидание";
                    }
                }
            }
        }


        private void SONGVOLUME_Scroll(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                float volume = SONGVOLUME.Value / 50f;
                Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, volume);

                if (!MUTE.Checked)
                {
                    Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, volume);
                }
            }

            UpdateVolumeLabel();
        }

        private void MUTE_CheckedChanged(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                float vol = MUTE.Checked ? 0f : (float)(SONGVOLUME.Value / 50f);

                Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, vol);
            }

            SONGVOLUME.Enabled = !MUTE.Checked;

            UpdateVolumeLabel();
        }

        private void SONGTIME_Scroll(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                double seconds = SONGTIME.Value;

                Bass.BASS_ChannelSetPosition(tempoStream, seconds);
            }
        }

        private void SPEEDUP_Click(object sender, EventArgs e)
        {
            isFast = !isFast;

            if (isFast)
            {
                SPEEDUP.Text = "Замедлить"; SPEEDLABEL.Text = "Скорость: 2x";
            }
            else
            {
                SPEEDUP.Text = "Ускорить"; SPEEDLABEL.Text = "Скорость: 1x";
            }

            float speed = isFast ? 100f : 0f;

            Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_TEMPO, speed);
        }

        private void SONGLABEL_MouseEnter(object sender, EventArgs e)
        {
            SONGLABEL.ForeColor = Color.DeepSkyBlue;
            SONGLABEL.Cursor = Cursors.Hand;
        }

        private void SONGLABEL_MouseLeave(object sender, EventArgs e)
        {
            ApplyTheme();
            SONGLABEL.Cursor = Cursors.Default;
        }

        private void SONGLABEL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(open.FileName))
            {
                string argument = "/select, \"" + open.FileName + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        private void main_DoubleClick(object sender, EventArgs e)
        {
            OPEN_Click(sender, e);
        }

        private void main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];

                if (filePath.EndsWith(".mp3") || filePath.EndsWith(".wav"))
                {
                    LoadFile(filePath);
                }
            }
        }

        private void main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                TRAY.Visible = true;

                TRAY.BalloonTipTitle = "MP3 Player";
                TRAY.BalloonTipText = "Плеер работает в фоновом режиме";
                TRAY.ShowBalloonTip(2000);
            }
        }

        private void TRAY_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show(); this.WindowState = FormWindowState.Normal;
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLAY_Click(null, null);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                PLAY_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.M)
            {
                MUTE.Checked = !MUTE.Checked;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                if (tempoStream != 0)
                {
                    double currentPos = Bass.BASS_ChannelBytes2Seconds(tempoStream, Bass.BASS_ChannelGetPosition(tempoStream));
                    Bass.BASS_ChannelSetPosition(tempoStream, currentPos + 5);
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (tempoStream != 0)
                {
                    double currentPos = Bass.BASS_ChannelBytes2Seconds(tempoStream, Bass.BASS_ChannelGetPosition(tempoStream));
                    Bass.BASS_ChannelSetPosition(tempoStream, Math.Max(0, currentPos - 5));
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                if (SONGVOLUME.Value <= 45) SONGVOLUME.Value += 2;
                else SONGVOLUME.Value = 50;

                SONGVOLUME_Scroll(sender, e);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                if (SONGVOLUME.Value >= 5) SONGVOLUME.Value -= 2;
                else SONGVOLUME.Value = 0;

                SONGVOLUME_Scroll(sender, e);
                e.Handled = true;
            }
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            TIMETIMER.Stop();

            if (tempoStream != 0)
            {
                Bass.BASS_ChannelStop(tempoStream);
                Bass.BASS_StreamFree(tempoStream);
                tempoStream = 0;
            }
            Bass.BASS_Free();

            Properties.Settings.Default.DarkTheme = isDarkTheme;
            Properties.Settings.Default.Volume = SONGVOLUME.Value;
            Properties.Settings.Default.Save();

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private void TRACKPAN_Scroll(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                float pan = TRACKPAN.Value / 10f;
                Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_PAN, pan);
            }
        }

        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            MoveForm(e);
        }
        private void CAPTIONTEXT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                captionClicks++;

                if (captionClicks >= 10)
                {
                    StartFalling();
                }
                else
                {
                    MoveForm(e);
                }
            }
        }

        private void EXITBUTTON_MouseEnter(object sender, EventArgs e)
        {
            EXITBUTTON.Text = "!!";
            EXITBUTTON.BackColor = Color.Red;
            EXITBUTTON.ForeColor = Color.White;
        }

        private void EXITBUTTON_MouseLeave(object sender, EventArgs e)
        {
            EXITBUTTON.Text = "X";
            ApplyTheme();
        }

        private void EXITBUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MINIMIZEBUTTON_MouseEnter(object sender, EventArgs e)
        {
            MINIMIZEBUTTON.Text = "▼";
            MINIMIZEBUTTON.BackColor = isDarkTheme ? Color.FromArgb(70, 70, 70) : Color.LightGray;
        }

        private void MINIMIZEBUTTON_MouseLeave(object sender, EventArgs e)
        {
            MINIMIZEBUTTON.Text = "—";
            ApplyTheme();
        }

        private void MINIMIZEBUTTON_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ABOUTBUTTON_Click(object sender, EventArgs e)
        {
            Form openAbout = Application.OpenForms["About"];

            if (openAbout != null)
            {
                openAbout.Focus();
            }
            else
            {
                About about = new About();
                about.Show();
            }
        }

        private void GOTOSETTINGS_Click(object sender, EventArgs e)
        {
            Settings sett = new Settings(this.isDarkTheme);
            sett.ShowDialog();
        }
    }
}
