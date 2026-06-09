using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class Settings : Form
    {
        mainForm main = (mainForm)Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is mainForm);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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
        public Settings(bool dark)
        {
            InitializeComponent();

            RoundCorners(10);
            if (dark)
            {
                this.BackColor = Color.FromArgb(30, 30, 30);

                THEMESWITCH.ForeColor = Color.White;

                THEMESWITCH.Text = "Поменять тему на: Светлая";
            }
            else
            {
                this.BackColor = SystemColors.Control;

                THEMESWITCH.ForeColor = Color.Black;
            }
        }

        private void THEMESWITCH_Click(object sender, EventArgs e)
        {
            if (main != null)
            {
                main.isDarkTheme = !main.isDarkTheme;
                main.ApplyTheme();

                if (main.isDarkTheme)
                {
                    this.BackColor = Color.FromArgb(30, 30, 30);
                    THEMESWITCH.ForeColor = Color.White;
                    THEMESWITCH.Text = "Поменять тему на: Светлая";
                }
                else
                {
                    this.BackColor = SystemColors.Control;
                    THEMESWITCH.ForeColor = Color.Black;
                    THEMESWITCH.Text = "Поменять тему на: Тёмная";
                }

                double val = OPACITYTRACKBAR.Value / 100.0;
                main.Opacity = val;
                Properties.Settings.Default.PlayerOpacity = val;
                Properties.Settings.Default.TrackValue = OPACITYTRACKBAR.Value;

                Properties.Settings.Default.DarkTheme = main.isDarkTheme;
                Properties.Settings.Default.Save();
            }
        }

        private void OPACITYTRACKBAR_Scroll(object sender, EventArgs e)
        {
            mainForm main = (mainForm)Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is mainForm);

            if (main != null)
            {
                double val = OPACITYTRACKBAR.Value / 100.0;
                main.Opacity = val;
                
                Properties.Settings.Default.PlayerOpacity = val;
                Properties.Settings.Default.TrackValue = OPACITYTRACKBAR.Value;
                Properties.Settings.Default.Save();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            int savedValue = Properties.Settings.Default.TrackValue;

            if (savedValue == 0) savedValue = 100;

            OPACITYTRACKBAR.Value = savedValue;
        }

        private void CAPTION_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
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
            EXITBUTTON.BackColor = Color.LightGray;
            EXITBUTTON.ForeColor = Color.Black;
        }

        private void EXITBUTTON_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
