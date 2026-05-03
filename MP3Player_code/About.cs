using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class About : Form
    {
        private void Thanks()
        {
            THANKS.Text = "Спасибо что зашёл на мой профиль GITHUB!";
        }
        private void StartResizing(int targetWidth, int targetHeight)
        {
            Timer resizeTimer = new Timer { Interval = 30 };
            resizeTimer.Tick += (s, ev) =>
            {
                bool widthDone = false;
                bool heightDone = false;

                if (Math.Abs(this.Width - targetWidth) > 5)
                    this.Width += (this.Width < targetWidth) ? 5 : -5;
                else
                {
                    this.Width = targetWidth;
                    widthDone = true;
                }

                if (Math.Abs(this.Height - targetHeight) > 5)
                    this.Height += (this.Height < targetHeight) ? 5 : -5;
                else
                {
                    this.Height = targetHeight;
                    heightDone = true;
                }

                if (widthDone && heightDone)
                {
                    resizeTimer.Stop();
                    resizeTimer.Dispose();

                    System.Media.SystemSounds.Exclamation.Play();
                }
            };
            resizeTimer.Start();
        }
        private int originalTop;
        private int speed = 0;
        private int gravity = 1;
        private bool isFalling = false;

        public About()
        {
            InitializeComponent();
        }

        private void ICON_Click(object sender, EventArgs e)
        {
            if (isFalling) return;
            isFalling = true;
            speed = 1;

            Timer timer = new Timer { Interval = 20 };
            timer.Tick += (s, ev) =>
            {
                speed += gravity;
                ICON.Top += speed;

                if (ICON.Top > this.Height)
                {
                    timer.Stop();
                    timer.Dispose();

                    StartResizing(241, 489);
                }
            };
            timer.Start();
        }

        private void LTMP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://github.com/ilyabloger123") { UseShellExecute = true });
            Thanks();
        }
    }
}
