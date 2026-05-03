namespace MP3Player
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.ICON = new System.Windows.Forms.PictureBox();
            this.MP3PLAYERLABEL = new System.Windows.Forms.Label();
            this.AUTHORNAME = new System.Windows.Forms.Label();
            this.UPDATENOTE = new System.Windows.Forms.Label();
            this.LTMP = new System.Windows.Forms.LinkLabel();
            this.THANKS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ICON)).BeginInit();
            this.SuspendLayout();
            // 
            // ICON
            // 
            this.ICON.Image = ((System.Drawing.Image)(resources.GetObject("ICON.Image")));
            this.ICON.Location = new System.Drawing.Point(225, 8);
            this.ICON.Name = "ICON";
            this.ICON.Size = new System.Drawing.Size(88, 88);
            this.ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ICON.TabIndex = 0;
            this.ICON.TabStop = false;
            this.ICON.Click += new System.EventHandler(this.ICON_Click);
            // 
            // MP3PLAYERLABEL
            // 
            this.MP3PLAYERLABEL.AutoSize = true;
            this.MP3PLAYERLABEL.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MP3PLAYERLABEL.Location = new System.Drawing.Point(9, 8);
            this.MP3PLAYERLABEL.Name = "MP3PLAYERLABEL";
            this.MP3PLAYERLABEL.Size = new System.Drawing.Size(210, 62);
            this.MP3PLAYERLABEL.TabIndex = 1;
            this.MP3PLAYERLABEL.Text = "MP3Player  v1.1\r\n(64-разрядная)";
            // 
            // AUTHORNAME
            // 
            this.AUTHORNAME.AutoSize = true;
            this.AUTHORNAME.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AUTHORNAME.Location = new System.Drawing.Point(24, 77);
            this.AUTHORNAME.Name = "AUTHORNAME";
            this.AUTHORNAME.Size = new System.Drawing.Size(166, 19);
            this.AUTHORNAME.TabIndex = 2;
            this.AUTHORNAME.Text = "Автор: ilyabloger123";
            // 
            // UPDATENOTE
            // 
            this.UPDATENOTE.AutoSize = true;
            this.UPDATENOTE.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UPDATENOTE.Location = new System.Drawing.Point(24, 134);
            this.UPDATENOTE.Name = "UPDATENOTE";
            this.UPDATENOTE.Size = new System.Drawing.Size(180, 76);
            this.UPDATENOTE.TabIndex = 3;
            this.UPDATENOTE.Text = "Что добавилось:\r\n\r\n-Кнопка \"О программе\"\r\n-Новая пасхалка";
            // 
            // LTMP
            // 
            this.LTMP.AutoSize = true;
            this.LTMP.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LTMP.Location = new System.Drawing.Point(-2, 430);
            this.LTMP.Name = "LTMP";
            this.LTMP.Size = new System.Drawing.Size(164, 19);
            this.LTMP.TabIndex = 4;
            this.LTMP.TabStop = true;
            this.LTMP.Text = "Мой профиль в GITHUB";
            this.LTMP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LTMP_LinkClicked);
            // 
            // THANKS
            // 
            this.THANKS.Location = new System.Drawing.Point(-1, 401);
            this.THANKS.Name = "THANKS";
            this.THANKS.Size = new System.Drawing.Size(220, 29);
            this.THANKS.TabIndex = 5;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 450);
            this.Controls.Add(this.THANKS);
            this.Controls.Add(this.LTMP);
            this.Controls.Add(this.UPDATENOTE);
            this.Controls.Add(this.AUTHORNAME);
            this.Controls.Add(this.MP3PLAYERLABEL);
            this.Controls.Add(this.ICON);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.ICON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ICON;
        private System.Windows.Forms.Label MP3PLAYERLABEL;
        private System.Windows.Forms.Label AUTHORNAME;
        private System.Windows.Forms.Label UPDATENOTE;
        private System.Windows.Forms.LinkLabel LTMP;
        private System.Windows.Forms.Label THANKS;
    }
}