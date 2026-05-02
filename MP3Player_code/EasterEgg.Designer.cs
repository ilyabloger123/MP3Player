namespace MP3Player
{
    partial class EasterEgg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
        private void InitializeComponent()
        {
            this.CLOSE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CLOSE
            // 
            this.CLOSE.BackColor = System.Drawing.Color.White;
            this.CLOSE.Dock = System.Windows.Forms.DockStyle.Top;
            this.CLOSE.FlatAppearance.BorderSize = 0;
            this.CLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CLOSE.Location = new System.Drawing.Point(0, 0);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(284, 23);
            this.CLOSE.TabIndex = 0;
            this.CLOSE.Text = "Закрыть";
            this.CLOSE.UseVisualStyleBackColor = false;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            // 
            // EasterEgg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CLOSE);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "EasterEgg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EasterEgg";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EasterEgg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CLOSE;
    }
}