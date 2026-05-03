using System;
using System.Drawing;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using System.Drawing.Drawing2D;


namespace MP3Player
{
    public partial class main : Form
    {
        About about = new About();
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

        private void RoundCorners(int radius)
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

        private void ApplyTheme()
        {
            if (isDarkTheme)
            {
                this.BackColor = Color.FromArgb(30, 30, 30);

                SONGLABEL.ForeColor = Color.White;
                VOLUMELABEL.ForeColor = Color.White;
                TIME.ForeColor = Color.White;
                SPEEDLABEL.ForeColor = Color.White;
                THEMELABEL.ForeColor = Color.White;
                DECORATIVETIMELABEL.ForeColor = Color.White;
                DECORATIVEVOLUMELABEL.ForeColor = Color.White;
                DECORATIVEBALANCELABEL.ForeColor = Color.White;

                EXITBUTTON.BackColor = Color.FromArgb(45, 45, 45);
                EXITBUTTON.ForeColor = Color.White;
                MINIMIZEBUTTON.BackColor = Color.FromArgb(45, 45, 45);
                MINIMIZEBUTTON.ForeColor = Color.White;

                EXITBUTTON.BackColor = Color.FromArgb(40, 40, 40);
                MINIMIZEBUTTON.BackColor = Color.FromArgb(40, 40, 40);

                CAPTIONTEXT.BackColor = Color.FromArgb(40, 40, 40);
                CAPTIONTEXT.ForeColor = Color.White;
                CAPTION.BackColor = Color.FromArgb(40, 40, 40);

                MUTE.ForeColor = Color.White;
                LOOP.ForeColor = Color.White;

                Color buttonColor = Color.FromArgb(50, 50, 50);
                PLAY.BackColor = buttonColor; PLAY.ForeColor = Color.White;
                STOP.BackColor = buttonColor; STOP.ForeColor = Color.White;
                OPEN.BackColor = buttonColor; OPEN.ForeColor = Color.White;
                THEMESWITCH.BackColor = buttonColor; THEMESWITCH.ForeColor = Color.White;
                SPEEDUP.BackColor = buttonColor; SPEEDUP.ForeColor = Color.White;

                SONGVOLUME.BackColor = Color.FromArgb(30, 30, 30);
                SONGTIME.BackColor = Color.FromArgb(30, 30, 30);

                THEMELABEL.Text = "Тема: Тёмная";
                THEMESWITCH.Text = "Поменять тему на:Светлая";
            }
            else
            {
                this.BackColor = SystemColors.Control;

                SONGLABEL.ForeColor = Color.Black;
                VOLUMELABEL.ForeColor = Color.Black;
                THEMELABEL.ForeColor = Color.Black;
                SPEEDLABEL.ForeColor = Color.Black;
                DECORATIVETIMELABEL.ForeColor = Color.Black;
                DECORATIVEVOLUMELABEL.ForeColor = Color.Black;
                DECORATIVEBALANCELABEL.ForeColor = Color.Black;

                EXITBUTTON.BackColor = Color.FromArgb(230, 230, 230);
                EXITBUTTON.ForeColor = Color.Black;
                MINIMIZEBUTTON.BackColor = Color.FromArgb(230, 230, 230);
                MINIMIZEBUTTON.ForeColor = Color.Black;

                EXITBUTTON.BackColor = Color.FromArgb(220, 220, 220);
                MINIMIZEBUTTON.BackColor = Color.FromArgb(220, 220, 220);

                CAPTIONTEXT.BackColor = Color.FromArgb(220, 220, 220);
                CAPTIONTEXT.ForeColor = Color.Black;
                CAPTION.BackColor = Color.FromArgb(220, 220, 220);

                TIME.ForeColor = Color.Black;
                MUTE.ForeColor = Color.Black;
                LOOP.ForeColor = Color.Black;

                Color btnDefault = SystemColors.ControlLight;
                PLAY.BackColor = btnDefault; PLAY.ForeColor = Color.Black;
                STOP.BackColor = btnDefault; STOP.ForeColor = Color.Black;
                OPEN.BackColor = btnDefault; OPEN.ForeColor = Color.Black;
                THEMESWITCH.BackColor = btnDefault; THEMESWITCH.ForeColor = Color.Black;
                SPEEDUP.BackColor = btnDefault; SPEEDUP.ForeColor = Color.Black;

                SONGVOLUME.BackColor = SystemColors.Control;
                SONGTIME.BackColor = SystemColors.Control;

                THEMELABEL.Text = "Тема: Светлая";
                THEMESWITCH.Text = "Поменять тему на:Темная";
            }
        }
        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                normalPos = this.Location;
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
            tempoStream = BassFx.BASS_FX_TempoCreate(stream, BASSFlag.BASS_FX_FREESOURCE);

            CAPTIONTEXT.Text = "MP3Player — Играет";

            Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, SONGVOLUME.Value / 50f);

            Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_PAN, TRACKPAN.Value / 10f);

            long bytes = Bass.BASS_ChannelGetLength(tempoStream);
            SONGTIME.Maximum = (int)Bass.BASS_ChannelBytes2Seconds(tempoStream, bytes);

            Bass.BASS_ChannelPlay(tempoStream, false);
            PLAY.Text = "Ⅱ";
            PLAY.ForeColor = Color.Cyan;
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
        private Point normalPos;
        private bool isFast;
        private bool userStopped = false;
        private bool isDarkTheme = false;
        private int captionClicks = 0;
        private int timeUpdateCounter = 0;
        private bool isBroken = false;
        private string gameBuffer = "";
        private OpenFileDialog open = new OpenFileDialog();

        Random rnd = new Random();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;

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
        public main()
        {
            InitializeComponent();

            isBroken = false;

            CAPTION.MouseDown += main_MouseDown;

            RoundCorners(10);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            isDarkTheme = Properties.Settings.Default.DarkTheme;
            ApplyTheme();

            CAPTIONTEXT.Text = "MP3Player — Ожидание";

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            SONGVOLUME.Value = Properties.Settings.Default.Volume;
            LOOP.Checked = Properties.Settings.Default.isLoop;

            SONGLABEL.Text = "Сейчас играет:";
            TIME.Text = "00:00 / 00:00";

            UpdateVolumeLabel();

            normalPos = this.Location;
        }

        private void OPEN_Click(object sender, EventArgs e)
        {
            open.Filter = "Аудио *.mp3, *.wav|*.mp3;*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
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
                float vol = MUTE.Checked ? 0f : (SONGVOLUME.Value / 100f);
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
            string key = e.KeyCode.ToString().ToUpper();

            if (key == "D3") key = "3";

            gameBuffer += key;
            if (gameBuffer.Length > 9) gameBuffer = gameBuffer.Substring(1);

            if (gameBuffer.EndsWith("MP3PLAYER"))
            {
                gameBuffer = "";

                if (tempoStream != 0)
                    Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, 0.1f, 500);

                EasterEgg game = new EasterEgg();
                game.ShowDialog();

                if (tempoStream != 0)
                {
                    float targetVol = MUTE.Checked ? 0f : (SONGVOLUME.Value / 50.0f);
                    Bass.BASS_ChannelSlideAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_VOL, targetVol, 500);
                }
            }

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

        private void THEMESWITCH_Click(object sender, EventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            ApplyTheme();
        }

        private void TRACKPAN_Scroll(object sender, EventArgs e)
        {
            if (tempoStream != 0)
            {
                float pan = TRACKPAN.Value / 10f;
                Bass.BASS_ChannelSetAttribute(tempoStream, BASSAttribute.BASS_ATTRIB_PAN, pan);
            }
        }
        private void main_Move(object sender, EventArgs e)
        {
            normalPos = this.Location;
        }

        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            MoveForm(e);
        }

        private void main_MouseUp(object sender, MouseEventArgs e)
        {
            normalPos = this.Location;
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
            about.Show();
        }
    }
}
