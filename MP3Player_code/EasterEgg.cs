using System;
using System.Drawing;
using System.Windows.Forms;

namespace MP3Player
{
    public partial class EasterEgg : Form
    {
        private int clicks = 0;
        private Random rnd = new Random();

        private void CloseThisForm()
        {
            this.Close();
        }
        private void LaunchConfetti()
        {
            Timer confettiTimer = new Timer { Interval = 10 };
            int count = 0;
            string[] symbols = { "☀", "♫", "✨", "ツ", "♪", "♦" };

            confettiTimer.Tick += (s, e) =>
            {
                Label l = new Label();
                l.Text = symbols[rnd.Next(symbols.Length)];
                l.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

                l.BackColor = Color.Gray;

                l.AutoSize = true;
                l.Font = new Font("Arial", rnd.Next(10, 25), FontStyle.Bold);

                l.Location = new Point(rnd.Next(this.Width), rnd.Next(this.Height));

                this.Controls.Add(l);
                l.BringToFront();

                count++;
                if (count > 1000)
                {
                    confettiTimer.Stop();
                    MessageBox.Show("Победа!");
                    this.Close();
                }
            };
            confettiTimer.Start();
        }

        private void SpawnButton()
        {
            Button btn = new Button();
            btn.Text = "КЛИК!";
            btn.Size = new Size(80, 40);
            btn.BackColor = Color.Gold;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Location = new Point(rnd.Next(10, this.Width - 90), rnd.Next(10, this.Height - 50));

            btn.Click += (s, e) => {
                clicks++;
                this.Controls.Remove(btn);

                if (clicks < 10)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    SpawnButton();
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    LaunchConfetti();
                }
            };
            this.Controls.Add(btn);
        }

        public EasterEgg()
        {
            InitializeComponent();
        }

        private void EasterEgg_Load(object sender, EventArgs e)
        {
            SpawnButton();
        }

        private void CLOSE_Click(object sender, EventArgs e)
        {
            CloseThisForm();
        }
    }
}
