using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class About : Form
    {
        private async void Thanks()
        {
            LTMP.Text = "Спасибо!";

            await Task.Delay(5000);

            LTMP.Text = "Мой профиль в GITHUB";
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

                    UPDATENOTE.Text = "Что добавилось:\r\n\r\n-Визуализация: Добавлено отображение обложек альбомов.\r\n-Новая пасхалка\r\n-Поменялся размер окна \"О программе\"";

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

                    StartResizing(471, 489);
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
