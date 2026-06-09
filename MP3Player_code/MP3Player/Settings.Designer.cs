namespace MP3Player
{
    partial class Settings
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
            this.THEMESWITCH = new System.Windows.Forms.Button();
            this.OPACITYTRACKBAR = new System.Windows.Forms.TrackBar();
            this.CAPTION = new System.Windows.Forms.Label();
            this.EXITBUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OPACITYTRACKBAR)).BeginInit();
            this.SuspendLayout();
            // 
            // THEMESWITCH
            // 
            this.THEMESWITCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.THEMESWITCH.Location = new System.Drawing.Point(12, 46);
            this.THEMESWITCH.Name = "THEMESWITCH";
            this.THEMESWITCH.Size = new System.Drawing.Size(401, 24);
            this.THEMESWITCH.TabIndex = 19;
            this.THEMESWITCH.Text = "Поменять тему на:Тёмная";
            this.THEMESWITCH.UseVisualStyleBackColor = true;
            this.THEMESWITCH.Click += new System.EventHandler(this.THEMESWITCH_Click);
            // 
            // OPACITYTRACKBAR
            // 
            this.OPACITYTRACKBAR.Location = new System.Drawing.Point(89, 87);
            this.OPACITYTRACKBAR.Maximum = 100;
            this.OPACITYTRACKBAR.Minimum = 20;
            this.OPACITYTRACKBAR.Name = "OPACITYTRACKBAR";
            this.OPACITYTRACKBAR.Size = new System.Drawing.Size(324, 45);
            this.OPACITYTRACKBAR.TabIndex = 20;
            this.OPACITYTRACKBAR.Value = 100;
            this.OPACITYTRACKBAR.Scroll += new System.EventHandler(this.OPACITYTRACKBAR_Scroll);
            // 
            // CAPTION
            // 
            this.CAPTION.BackColor = System.Drawing.Color.LightGray;
            this.CAPTION.Dock = System.Windows.Forms.DockStyle.Top;
            this.CAPTION.Font = new System.Drawing.Font("Segoe UI Variable Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CAPTION.ForeColor = System.Drawing.Color.Black;
            this.CAPTION.Location = new System.Drawing.Point(0, 0);
            this.CAPTION.Name = "CAPTION";
            this.CAPTION.Size = new System.Drawing.Size(425, 24);
            this.CAPTION.TabIndex = 21;
            this.CAPTION.Text = "Настройки";
            this.CAPTION.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CAPTION.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CAPTION_MouseDown);
            // 
            // EXITBUTTON
            // 
            this.EXITBUTTON.BackColor = System.Drawing.Color.LightGray;
            this.EXITBUTTON.FlatAppearance.BorderSize = 0;
            this.EXITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXITBUTTON.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EXITBUTTON.Location = new System.Drawing.Point(398, -3);
            this.EXITBUTTON.Name = "EXITBUTTON";
            this.EXITBUTTON.Size = new System.Drawing.Size(27, 27);
            this.EXITBUTTON.TabIndex = 26;
            this.EXITBUTTON.Text = "X";
            this.EXITBUTTON.UseVisualStyleBackColor = false;
            this.EXITBUTTON.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EXITBUTTON_MouseDown);
            this.EXITBUTTON.MouseEnter += new System.EventHandler(this.EXITBUTTON_MouseEnter);
            this.EXITBUTTON.MouseLeave += new System.EventHandler(this.EXITBUTTON_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Прозрачность:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 132);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EXITBUTTON);
            this.Controls.Add(this.CAPTION);
            this.Controls.Add(this.OPACITYTRACKBAR);
            this.Controls.Add(this.THEMESWITCH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OPACITYTRACKBAR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button THEMESWITCH;
        private System.Windows.Forms.TrackBar OPACITYTRACKBAR;
        private System.Windows.Forms.Label CAPTION;
        private System.Windows.Forms.Button EXITBUTTON;
        private System.Windows.Forms.Label label1;
    }
}