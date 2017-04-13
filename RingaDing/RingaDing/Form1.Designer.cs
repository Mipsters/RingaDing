namespace RingaDing
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeSoundCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSpecificDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mondayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tusedayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wednesdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thursdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saturdayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SongComboBox = new System.Windows.Forms.ComboBox();
            this.SongListBox = new System.Windows.Forms.ListBox();
            this.InfoStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayPause = new System.Windows.Forms.Button();
            this.SecTimer = new System.Windows.Forms.Timer(this.components);
            this.Day = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.InfoStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.editSpecificDayToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FolderDirectoryToolStripMenuItem,
            this.addItemToolStripMenuItem,
            this.changeSoundCardToolStripMenuItem,
            this.runOnStartupToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsToolStripMenuItem.Text = "Options";
            // 
            // FolderDirectoryToolStripMenuItem
            // 
            this.FolderDirectoryToolStripMenuItem.Name = "FolderDirectoryToolStripMenuItem";
            this.FolderDirectoryToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.FolderDirectoryToolStripMenuItem.Text = "Select Music Folder";
            this.FolderDirectoryToolStripMenuItem.Click += new System.EventHandler(this.FolderDirectoryToolStripMenuItem_Click);
            // 
            // addItemToolStripMenuItem
            // 
            this.addItemToolStripMenuItem.Name = "addItemToolStripMenuItem";
            this.addItemToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.addItemToolStripMenuItem.Text = "Add Song Time";
            this.addItemToolStripMenuItem.Click += new System.EventHandler(this.addItemToolStripMenuItem_Click);
            // 
            // changeSoundCardToolStripMenuItem
            // 
            this.changeSoundCardToolStripMenuItem.Name = "changeSoundCardToolStripMenuItem";
            this.changeSoundCardToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.changeSoundCardToolStripMenuItem.Text = "Change Sound Output Device";
            this.changeSoundCardToolStripMenuItem.Click += new System.EventHandler(this.changeSoundCardToolStripMenuItem_Click);
            // 
            // runOnStartupToolStripMenuItem
            // 
            this.runOnStartupToolStripMenuItem.Name = "runOnStartupToolStripMenuItem";
            this.runOnStartupToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.runOnStartupToolStripMenuItem.Text = "Run on startup";
            this.runOnStartupToolStripMenuItem.Click += new System.EventHandler(this.runOnStartupToolStripMenuItem_Click);
            // 
            // editSpecificDayToolStripMenuItem
            // 
            this.editSpecificDayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sundayToolStripMenuItem,
            this.mondayToolStripMenuItem,
            this.tusedayToolStripMenuItem,
            this.wednesdayToolStripMenuItem,
            this.thursdayToolStripMenuItem,
            this.fridayToolStripMenuItem,
            this.saturdayToolStripMenuItem});
            this.editSpecificDayToolStripMenuItem.Name = "editSpecificDayToolStripMenuItem";
            this.editSpecificDayToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.editSpecificDayToolStripMenuItem.Text = "Edit Specific Day";
            // 
            // sundayToolStripMenuItem
            // 
            this.sundayToolStripMenuItem.Name = "sundayToolStripMenuItem";
            this.sundayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sundayToolStripMenuItem.Text = "Sunday";
            this.sundayToolStripMenuItem.Click += new System.EventHandler(this.sundayToolStripMenuItem_Click);
            // 
            // mondayToolStripMenuItem
            // 
            this.mondayToolStripMenuItem.Name = "mondayToolStripMenuItem";
            this.mondayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.mondayToolStripMenuItem.Text = "Monday";
            this.mondayToolStripMenuItem.Click += new System.EventHandler(this.mondayToolStripMenuItem_Click);
            // 
            // tusedayToolStripMenuItem
            // 
            this.tusedayToolStripMenuItem.Name = "tusedayToolStripMenuItem";
            this.tusedayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.tusedayToolStripMenuItem.Text = "Tuesday";
            this.tusedayToolStripMenuItem.Click += new System.EventHandler(this.tusedayToolStripMenuItem_Click);
            // 
            // wednesdayToolStripMenuItem
            // 
            this.wednesdayToolStripMenuItem.Name = "wednesdayToolStripMenuItem";
            this.wednesdayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.wednesdayToolStripMenuItem.Text = "Wednesday";
            this.wednesdayToolStripMenuItem.Click += new System.EventHandler(this.wednesdayToolStripMenuItem_Click);
            // 
            // thursdayToolStripMenuItem
            // 
            this.thursdayToolStripMenuItem.Name = "thursdayToolStripMenuItem";
            this.thursdayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.thursdayToolStripMenuItem.Text = "Thursday";
            this.thursdayToolStripMenuItem.Click += new System.EventHandler(this.thursdayToolStripMenuItem_Click);
            // 
            // fridayToolStripMenuItem
            // 
            this.fridayToolStripMenuItem.Name = "fridayToolStripMenuItem";
            this.fridayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.fridayToolStripMenuItem.Text = "Friday";
            this.fridayToolStripMenuItem.Click += new System.EventHandler(this.fridayToolStripMenuItem_Click);
            // 
            // saturdayToolStripMenuItem
            // 
            this.saturdayToolStripMenuItem.Name = "saturdayToolStripMenuItem";
            this.saturdayToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.saturdayToolStripMenuItem.Text = "Saturday";
            this.saturdayToolStripMenuItem.Click += new System.EventHandler(this.saturdayToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // SongComboBox
            // 
            this.SongComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SongComboBox.FormattingEnabled = true;
            this.SongComboBox.Location = new System.Drawing.Point(63, 40);
            this.SongComboBox.Name = "SongComboBox";
            this.SongComboBox.Size = new System.Drawing.Size(209, 21);
            this.SongComboBox.TabIndex = 2;
            // 
            // SongListBox
            // 
            this.SongListBox.FormattingEnabled = true;
            this.SongListBox.Location = new System.Drawing.Point(12, 79);
            this.SongListBox.Name = "SongListBox";
            this.SongListBox.Size = new System.Drawing.Size(260, 186);
            this.SongListBox.TabIndex = 3;
            this.SongListBox.DoubleClick += new System.EventHandler(this.SongListBox_DoubleClick);
            // 
            // InfoStatusStrip
            // 
            this.InfoStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusFile});
            this.InfoStatusStrip.Location = new System.Drawing.Point(0, 272);
            this.InfoStatusStrip.Name = "InfoStatusStrip";
            this.InfoStatusStrip.ShowItemToolTips = true;
            this.InfoStatusStrip.Size = new System.Drawing.Size(284, 22);
            this.InfoStatusStrip.TabIndex = 4;
            this.InfoStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusFile
            // 
            this.toolStripStatusFile.AutoSize = false;
            this.toolStripStatusFile.AutoToolTip = true;
            this.toolStripStatusFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusFile.Name = "toolStripStatusFile";
            this.toolStripStatusFile.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusFile.Size = new System.Drawing.Size(270, 17);
            this.toolStripStatusFile.Text = "Select a Folder";
            // 
            // PlayPause
            // 
            this.PlayPause.Image = global::RingaDing.Properties.Resources.play;
            this.PlayPause.Location = new System.Drawing.Point(12, 27);
            this.PlayPause.Name = "PlayPause";
            this.PlayPause.Size = new System.Drawing.Size(45, 45);
            this.PlayPause.TabIndex = 1;
            this.PlayPause.UseVisualStyleBackColor = true;
            this.PlayPause.Click += new System.EventHandler(this.PlayPause_Click);
            // 
            // SecTimer
            // 
            this.SecTimer.Interval = 1000;
            this.SecTimer.Tick += new System.EventHandler(this.SecTimer_Tick);
            // 
            // Day
            // 
            this.Day.AutoSize = true;
            this.Day.Location = new System.Drawing.Point(63, 63);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(67, 13);
            this.Day.TabIndex = 5;
            this.Day.Text = "Day of week";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 294);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.InfoStatusStrip);
            this.Controls.Add(this.SongListBox);
            this.Controls.Add(this.SongComboBox);
            this.Controls.Add(this.PlayPause);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RingaDing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.InfoStatusStrip.ResumeLayout(false);
            this.InfoStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderDirectoryToolStripMenuItem;
        private System.Windows.Forms.Button PlayPause;
        private System.Windows.Forms.ComboBox SongComboBox;
        private System.Windows.Forms.ListBox SongListBox;
        private System.Windows.Forms.StatusStrip InfoStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFile;
        private System.Windows.Forms.ToolStripMenuItem addItemToolStripMenuItem;
        private System.Windows.Forms.Timer SecTimer;
        private System.Windows.Forms.Label Day;
        private System.Windows.Forms.ToolStripMenuItem changeSoundCardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSpecificDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mondayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tusedayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wednesdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thursdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fridayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saturdayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runOnStartupToolStripMenuItem;
    }
}

