namespace MP3Player
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.OPEN = new System.Windows.Forms.Button();
            this.PLAY = new System.Windows.Forms.Button();
            this.SONGTIME = new System.Windows.Forms.TrackBar();
            this.SONGLABEL = new System.Windows.Forms.Label();
            this.STOP = new System.Windows.Forms.Button();
            this.TIMETIMER = new System.Windows.Forms.Timer(this.components);
            this.TIME = new System.Windows.Forms.Label();
            this.LOOP = new System.Windows.Forms.CheckBox();
            this.SONGVOLUME = new System.Windows.Forms.TrackBar();
            this.VOLUMELABEL = new System.Windows.Forms.Label();
            this.MUTE = new System.Windows.Forms.CheckBox();
            this.DECORATIVETIMELABEL = new System.Windows.Forms.Label();
            this.DECORATIVEVOLUMELABEL = new System.Windows.Forms.Label();
            this.SPEEDLABEL = new System.Windows.Forms.Label();
            this.SPEEDUP = new System.Windows.Forms.Button();
            this.TRAY = new System.Windows.Forms.NotifyIcon(this.components);
            this.TRAYMENU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.развернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.THEMESWITCH = new System.Windows.Forms.Button();
            this.THEMELABEL = new System.Windows.Forms.Label();
            this.TRACKPAN = new System.Windows.Forms.TrackBar();
            this.DECORATIVEBALANCELABEL = new System.Windows.Forms.Label();
            this.CAPTION = new System.Windows.Forms.Label();
            this.CAPTIONTEXT = new System.Windows.Forms.Label();
            this.EXITBUTTON = new System.Windows.Forms.Button();
            this.MINIMIZEBUTTON = new System.Windows.Forms.Button();
            this.ABOUTBUTTON = new System.Windows.Forms.Button();
            this.SONGPREVIEW = new System.Windows.Forms.PictureBox();
            this.VU_LEFT = new MP3Player.VerticalProgressBar();
            this.VU_RIGHT = new MP3Player.VerticalProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SONGTIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SONGVOLUME)).BeginInit();
            this.TRAYMENU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACKPAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SONGPREVIEW)).BeginInit();
            this.SuspendLayout();
            // 
            // OPEN
            // 
            this.OPEN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OPEN.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPEN.Location = new System.Drawing.Point(34, 308);
            this.OPEN.Name = "OPEN";
            this.OPEN.Size = new System.Drawing.Size(597, 25);
            this.OPEN.TabIndex = 0;
            this.OPEN.TabStop = false;
            this.OPEN.Text = "Открыть";
            this.OPEN.UseVisualStyleBackColor = true;
            this.OPEN.Click += new System.EventHandler(this.OPEN_Click);
            // 
            // PLAY
            // 
            this.PLAY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PLAY.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PLAY.Location = new System.Drawing.Point(34, 247);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(295, 23);
            this.PLAY.TabIndex = 1;
            this.PLAY.TabStop = false;
            this.PLAY.Text = "►";
            this.PLAY.UseVisualStyleBackColor = true;
            this.PLAY.Click += new System.EventHandler(this.PLAY_Click);
            // 
            // SONGTIME
            // 
            this.SONGTIME.AutoSize = false;
            this.SONGTIME.LargeChange = 2;
            this.SONGTIME.Location = new System.Drawing.Point(34, 339);
            this.SONGTIME.Maximum = 50;
            this.SONGTIME.Name = "SONGTIME";
            this.SONGTIME.Size = new System.Drawing.Size(597, 33);
            this.SONGTIME.TabIndex = 2;
            this.SONGTIME.TabStop = false;
            this.SONGTIME.Scroll += new System.EventHandler(this.SONGTIME_Scroll);
            // 
            // SONGLABEL
            // 
            this.SONGLABEL.AutoSize = true;
            this.SONGLABEL.Location = new System.Drawing.Point(34, 231);
            this.SONGLABEL.Name = "SONGLABEL";
            this.SONGLABEL.Size = new System.Drawing.Size(83, 13);
            this.SONGLABEL.TabIndex = 3;
            this.SONGLABEL.Text = "Сейчас играет:";
            this.SONGLABEL.Click += new System.EventHandler(this.SONGLABEL_Click);
            this.SONGLABEL.MouseEnter += new System.EventHandler(this.SONGLABEL_MouseEnter);
            this.SONGLABEL.MouseLeave += new System.EventHandler(this.SONGLABEL_MouseLeave);
            // 
            // STOP
            // 
            this.STOP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.STOP.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.STOP.Location = new System.Drawing.Point(336, 247);
            this.STOP.Name = "STOP";
            this.STOP.Size = new System.Drawing.Size(295, 23);
            this.STOP.TabIndex = 5;
            this.STOP.TabStop = false;
            this.STOP.Text = "■";
            this.STOP.UseVisualStyleBackColor = true;
            this.STOP.Click += new System.EventHandler(this.STOP_Click);
            // 
            // TIMETIMER
            // 
            this.TIMETIMER.Enabled = true;
            this.TIMETIMER.Interval = 1;
            this.TIMETIMER.Tick += new System.EventHandler(this.TIMETIMER_Tick);
            // 
            // TIME
            // 
            this.TIME.AutoSize = true;
            this.TIME.Location = new System.Drawing.Point(34, 179);
            this.TIME.Name = "TIME";
            this.TIME.Size = new System.Drawing.Size(43, 13);
            this.TIME.TabIndex = 6;
            this.TIME.Text = "Время:";
            // 
            // LOOP
            // 
            this.LOOP.AutoSize = true;
            this.LOOP.Location = new System.Drawing.Point(37, 30);
            this.LOOP.Name = "LOOP";
            this.LOOP.Size = new System.Drawing.Size(85, 17);
            this.LOOP.TabIndex = 7;
            this.LOOP.Text = "Автоповтор";
            this.LOOP.UseVisualStyleBackColor = true;
            // 
            // SONGVOLUME
            // 
            this.SONGVOLUME.AutoSize = false;
            this.SONGVOLUME.BackColor = System.Drawing.SystemColors.Control;
            this.SONGVOLUME.LargeChange = 1;
            this.SONGVOLUME.Location = new System.Drawing.Point(37, 389);
            this.SONGVOLUME.Maximum = 50;
            this.SONGVOLUME.Name = "SONGVOLUME";
            this.SONGVOLUME.Size = new System.Drawing.Size(597, 33);
            this.SONGVOLUME.TabIndex = 8;
            this.SONGVOLUME.TabStop = false;
            this.SONGVOLUME.Scroll += new System.EventHandler(this.SONGVOLUME_Scroll);
            // 
            // VOLUMELABEL
            // 
            this.VOLUMELABEL.AutoSize = true;
            this.VOLUMELABEL.Location = new System.Drawing.Point(34, 192);
            this.VOLUMELABEL.Name = "VOLUMELABEL";
            this.VOLUMELABEL.Size = new System.Drawing.Size(86, 13);
            this.VOLUMELABEL.TabIndex = 9;
            this.VOLUMELABEL.Text = "Громкость: 100";
            // 
            // MUTE
            // 
            this.MUTE.AutoSize = true;
            this.MUTE.Location = new System.Drawing.Point(37, 53);
            this.MUTE.Name = "MUTE";
            this.MUTE.Size = new System.Drawing.Size(80, 17);
            this.MUTE.TabIndex = 10;
            this.MUTE.Text = "Заглушить";
            this.MUTE.UseVisualStyleBackColor = true;
            this.MUTE.CheckedChanged += new System.EventHandler(this.MUTE_CheckedChanged);
            // 
            // DECORATIVETIMELABEL
            // 
            this.DECORATIVETIMELABEL.AutoSize = true;
            this.DECORATIVETIMELABEL.Location = new System.Drawing.Point(309, 373);
            this.DECORATIVETIMELABEL.Name = "DECORATIVETIMELABEL";
            this.DECORATIVETIMELABEL.Size = new System.Drawing.Size(40, 13);
            this.DECORATIVETIMELABEL.TabIndex = 11;
            this.DECORATIVETIMELABEL.Text = "Время";
            // 
            // DECORATIVEVOLUMELABEL
            // 
            this.DECORATIVEVOLUMELABEL.AutoSize = true;
            this.DECORATIVEVOLUMELABEL.Location = new System.Drawing.Point(300, 425);
            this.DECORATIVEVOLUMELABEL.Name = "DECORATIVEVOLUMELABEL";
            this.DECORATIVEVOLUMELABEL.Size = new System.Drawing.Size(62, 13);
            this.DECORATIVEVOLUMELABEL.TabIndex = 12;
            this.DECORATIVEVOLUMELABEL.Text = "Громкость";
            // 
            // SPEEDLABEL
            // 
            this.SPEEDLABEL.AutoSize = true;
            this.SPEEDLABEL.Location = new System.Drawing.Point(34, 205);
            this.SPEEDLABEL.Name = "SPEEDLABEL";
            this.SPEEDLABEL.Size = new System.Drawing.Size(72, 13);
            this.SPEEDLABEL.TabIndex = 13;
            this.SPEEDLABEL.Text = "Скорость: 1x";
            // 
            // SPEEDUP
            // 
            this.SPEEDUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SPEEDUP.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SPEEDUP.Location = new System.Drawing.Point(34, 277);
            this.SPEEDUP.Name = "SPEEDUP";
            this.SPEEDUP.Size = new System.Drawing.Size(597, 25);
            this.SPEEDUP.TabIndex = 14;
            this.SPEEDUP.TabStop = false;
            this.SPEEDUP.Text = "Ускорить";
            this.SPEEDUP.UseVisualStyleBackColor = true;
            this.SPEEDUP.Click += new System.EventHandler(this.SPEEDUP_Click);
            // 
            // TRAY
            // 
            this.TRAY.ContextMenuStrip = this.TRAYMENU;
            this.TRAY.Icon = ((System.Drawing.Icon)(resources.GetObject("TRAY.Icon")));
            this.TRAY.Text = "MP3Player";
            this.TRAY.Visible = true;
            this.TRAY.DoubleClick += new System.EventHandler(this.TRAY_DoubleClick);
            // 
            // TRAYMENU
            // 
            this.TRAYMENU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.развернутьToolStripMenuItem,
            this.паузаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.TRAYMENU.Name = "TRAYMENU";
            this.TRAYMENU.Size = new System.Drawing.Size(157, 76);
            // 
            // развернутьToolStripMenuItem
            // 
            this.развернутьToolStripMenuItem.Name = "развернутьToolStripMenuItem";
            this.развернутьToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.развернутьToolStripMenuItem.Text = "Развернуть";
            this.развернутьToolStripMenuItem.Click += new System.EventHandler(this.развернутьToolStripMenuItem_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.паузаToolStripMenuItem.Text = "Пауза";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // THEMESWITCH
            // 
            this.THEMESWITCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.THEMESWITCH.Location = new System.Drawing.Point(34, 152);
            this.THEMESWITCH.Name = "THEMESWITCH";
            this.THEMESWITCH.Size = new System.Drawing.Size(163, 24);
            this.THEMESWITCH.TabIndex = 18;
            this.THEMESWITCH.Text = "Поменять тему на:Тёмная";
            this.THEMESWITCH.UseVisualStyleBackColor = true;
            this.THEMESWITCH.Click += new System.EventHandler(this.THEMESWITCH_Click);
            // 
            // THEMELABEL
            // 
            this.THEMELABEL.AutoSize = true;
            this.THEMELABEL.Location = new System.Drawing.Point(32, 218);
            this.THEMELABEL.Name = "THEMELABEL";
            this.THEMELABEL.Size = new System.Drawing.Size(82, 13);
            this.THEMELABEL.TabIndex = 19;
            this.THEMELABEL.Text = "Тема: Светлая";
            // 
            // TRACKPAN
            // 
            this.TRACKPAN.Location = new System.Drawing.Point(37, 441);
            this.TRACKPAN.Minimum = -10;
            this.TRACKPAN.Name = "TRACKPAN";
            this.TRACKPAN.Size = new System.Drawing.Size(589, 45);
            this.TRACKPAN.TabIndex = 21;
            this.TRACKPAN.Scroll += new System.EventHandler(this.TRACKPAN_Scroll);
            // 
            // DECORATIVEBALANCELABEL
            // 
            this.DECORATIVEBALANCELABEL.AutoSize = true;
            this.DECORATIVEBALANCELABEL.Location = new System.Drawing.Point(311, 484);
            this.DECORATIVEBALANCELABEL.Name = "DECORATIVEBALANCELABEL";
            this.DECORATIVEBALANCELABEL.Size = new System.Drawing.Size(44, 13);
            this.DECORATIVEBALANCELABEL.TabIndex = 22;
            this.DECORATIVEBALANCELABEL.Text = "Баланс";
            // 
            // CAPTION
            // 
            this.CAPTION.BackColor = System.Drawing.Color.White;
            this.CAPTION.Location = new System.Drawing.Point(0, 0);
            this.CAPTION.Name = "CAPTION";
            this.CAPTION.Size = new System.Drawing.Size(671, 27);
            this.CAPTION.TabIndex = 23;
            // 
            // CAPTIONTEXT
            // 
            this.CAPTIONTEXT.BackColor = System.Drawing.SystemColors.Control;
            this.CAPTIONTEXT.Location = new System.Drawing.Point(0, 0);
            this.CAPTIONTEXT.Name = "CAPTIONTEXT";
            this.CAPTIONTEXT.Size = new System.Drawing.Size(663, 27);
            this.CAPTIONTEXT.TabIndex = 24;
            this.CAPTIONTEXT.Text = "MP3Player";
            this.CAPTIONTEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CAPTIONTEXT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CAPTIONTEXT_MouseDown);
            // 
            // EXITBUTTON
            // 
            this.EXITBUTTON.FlatAppearance.BorderSize = 0;
            this.EXITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXITBUTTON.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EXITBUTTON.Location = new System.Drawing.Point(640, 0);
            this.EXITBUTTON.Name = "EXITBUTTON";
            this.EXITBUTTON.Size = new System.Drawing.Size(27, 27);
            this.EXITBUTTON.TabIndex = 25;
            this.EXITBUTTON.Text = "X";
            this.EXITBUTTON.UseVisualStyleBackColor = true;
            this.EXITBUTTON.Click += new System.EventHandler(this.EXITBUTTON_Click);
            this.EXITBUTTON.MouseEnter += new System.EventHandler(this.EXITBUTTON_MouseEnter);
            this.EXITBUTTON.MouseLeave += new System.EventHandler(this.EXITBUTTON_MouseLeave);
            // 
            // MINIMIZEBUTTON
            // 
            this.MINIMIZEBUTTON.Cursor = System.Windows.Forms.Cursors.Default;
            this.MINIMIZEBUTTON.FlatAppearance.BorderSize = 0;
            this.MINIMIZEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINIMIZEBUTTON.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MINIMIZEBUTTON.Location = new System.Drawing.Point(-1, 0);
            this.MINIMIZEBUTTON.Name = "MINIMIZEBUTTON";
            this.MINIMIZEBUTTON.Size = new System.Drawing.Size(27, 27);
            this.MINIMIZEBUTTON.TabIndex = 26;
            this.MINIMIZEBUTTON.Text = "—";
            this.MINIMIZEBUTTON.UseVisualStyleBackColor = true;
            this.MINIMIZEBUTTON.Click += new System.EventHandler(this.MINIMIZEBUTTON_Click);
            this.MINIMIZEBUTTON.MouseEnter += new System.EventHandler(this.MINIMIZEBUTTON_MouseEnter);
            this.MINIMIZEBUTTON.MouseLeave += new System.EventHandler(this.MINIMIZEBUTTON_MouseLeave);
            // 
            // ABOUTBUTTON
            // 
            this.ABOUTBUTTON.BackColor = System.Drawing.Color.White;
            this.ABOUTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ABOUTBUTTON.Location = new System.Drawing.Point(34, 76);
            this.ABOUTBUTTON.Name = "ABOUTBUTTON";
            this.ABOUTBUTTON.Size = new System.Drawing.Size(107, 23);
            this.ABOUTBUTTON.TabIndex = 27;
            this.ABOUTBUTTON.Text = "О программе";
            this.ABOUTBUTTON.UseVisualStyleBackColor = false;
            this.ABOUTBUTTON.Click += new System.EventHandler(this.ABOUTBUTTON_Click);
            // 
            // SONGPREVIEW
            // 
            this.SONGPREVIEW.Image = ((System.Drawing.Image)(resources.GetObject("SONGPREVIEW.Image")));
            this.SONGPREVIEW.Location = new System.Drawing.Point(238, 46);
            this.SONGPREVIEW.Name = "SONGPREVIEW";
            this.SONGPREVIEW.Size = new System.Drawing.Size(192, 185);
            this.SONGPREVIEW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SONGPREVIEW.TabIndex = 28;
            this.SONGPREVIEW.TabStop = false;
            // 
            // VU_LEFT
            // 
            this.VU_LEFT.Location = new System.Drawing.Point(8, 30);
            this.VU_LEFT.Maximum = 32768;
            this.VU_LEFT.Name = "VU_LEFT";
            this.VU_LEFT.Size = new System.Drawing.Size(23, 473);
            this.VU_LEFT.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.VU_LEFT.TabIndex = 20;
            // 
            // VU_RIGHT
            // 
            this.VU_RIGHT.Location = new System.Drawing.Point(635, 30);
            this.VU_RIGHT.Maximum = 32768;
            this.VU_RIGHT.Name = "VU_RIGHT";
            this.VU_RIGHT.Size = new System.Drawing.Size(23, 473);
            this.VU_RIGHT.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.VU_RIGHT.TabIndex = 17;
            // 
            // main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 506);
            this.Controls.Add(this.SONGPREVIEW);
            this.Controls.Add(this.ABOUTBUTTON);
            this.Controls.Add(this.MINIMIZEBUTTON);
            this.Controls.Add(this.EXITBUTTON);
            this.Controls.Add(this.CAPTIONTEXT);
            this.Controls.Add(this.CAPTION);
            this.Controls.Add(this.DECORATIVEBALANCELABEL);
            this.Controls.Add(this.TRACKPAN);
            this.Controls.Add(this.VU_LEFT);
            this.Controls.Add(this.THEMELABEL);
            this.Controls.Add(this.THEMESWITCH);
            this.Controls.Add(this.VU_RIGHT);
            this.Controls.Add(this.SPEEDUP);
            this.Controls.Add(this.SPEEDLABEL);
            this.Controls.Add(this.DECORATIVEVOLUMELABEL);
            this.Controls.Add(this.DECORATIVETIMELABEL);
            this.Controls.Add(this.MUTE);
            this.Controls.Add(this.VOLUMELABEL);
            this.Controls.Add(this.SONGVOLUME);
            this.Controls.Add(this.LOOP);
            this.Controls.Add(this.TIME);
            this.Controls.Add(this.STOP);
            this.Controls.Add(this.SONGLABEL);
            this.Controls.Add(this.SONGTIME);
            this.Controls.Add(this.PLAY);
            this.Controls.Add(this.OPEN);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "main";
            this.Text = "MP3Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.main_DragEnter);
            this.DoubleClick += new System.EventHandler(this.main_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_KeyDown);
            this.Move += new System.EventHandler(this.main_Move);
            this.Resize += new System.EventHandler(this.main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SONGTIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SONGVOLUME)).EndInit();
            this.TRAYMENU.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TRACKPAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SONGPREVIEW)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OPEN;
        private System.Windows.Forms.Button PLAY;
        private System.Windows.Forms.TrackBar SONGTIME;
        private System.Windows.Forms.Label SONGLABEL;
        private System.Windows.Forms.Button STOP;
        private System.Windows.Forms.Timer TIMETIMER;
        private System.Windows.Forms.Label TIME;
        private System.Windows.Forms.CheckBox LOOP;
        private System.Windows.Forms.TrackBar SONGVOLUME;
        private System.Windows.Forms.Label VOLUMELABEL;
        private System.Windows.Forms.CheckBox MUTE;
        private System.Windows.Forms.Label DECORATIVETIMELABEL;
        private System.Windows.Forms.Label DECORATIVEVOLUMELABEL;
        private System.Windows.Forms.Label SPEEDLABEL;
        private System.Windows.Forms.Button SPEEDUP;
        private System.Windows.Forms.NotifyIcon TRAY;
        private System.Windows.Forms.ContextMenuStrip TRAYMENU;
        private System.Windows.Forms.ToolStripMenuItem развернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private VerticalProgressBar VU_RIGHT;
        private System.Windows.Forms.Button THEMESWITCH;
        private System.Windows.Forms.Label THEMELABEL;
        private VerticalProgressBar VU_LEFT;
        private System.Windows.Forms.TrackBar TRACKPAN;
        private System.Windows.Forms.Label DECORATIVEBALANCELABEL;
        private System.Windows.Forms.Label CAPTION;
        private System.Windows.Forms.Label CAPTIONTEXT;
        private System.Windows.Forms.Button EXITBUTTON;
        private System.Windows.Forms.Button MINIMIZEBUTTON;
        private System.Windows.Forms.Button ABOUTBUTTON;
        private System.Windows.Forms.PictureBox SONGPREVIEW;
    }
}

