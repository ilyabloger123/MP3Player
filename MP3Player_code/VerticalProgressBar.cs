using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MP3Player
{
    public class VerticalProgressBar : ProgressBar
    {
        public VerticalProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            g.FillRectangle(Brushes.Silver, rect);

            double scale = (double)Value / Maximum;
            int high = (int)(rect.Height * scale);
            Rectangle fillRect = new Rectangle(0, rect.Height - high, rect.Width, high);

            if (high > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, rect.Height),
                    new Point(0, 0),
                    Color.Lime,
                    Color.Red))
                {
                    g.FillRectangle(brush, fillRect);
                }
            }

            g.DrawRectangle(Pens.DimGray, 0, 0, rect.Width - 1, rect.Height - 1);
        }
    }
}
