using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Microsoft.Win32;

using NAudio.Wave;

namespace RingaDing
{

    public partial class Form1 : Form
    {
        public static List<Tuple<HourTime, string>> data;
        public static string directory;
        private List<string> music;
        private NotifyIcon notifyIcon;
        private bool closedByIcon;
        
        public static WaveOut waveOutDevice;
        private AudioFileReader audioFileReader;

        public Form1()
        {
            InitializeComponent();

            data = new List<Tuple<HourTime, string>>();

            SecTimer.Start();

            Day.Text = DateTime.Now.DayOfWeek.ToString();

            closedByIcon = false;

            notifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.Icon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Open App", Open),
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            waveOutDevice = new WaveOut();
            waveOutDevice.DeviceNumber = -1;
        }

        private void Open(Object obj, EventArgs evnt)
        {
            Show();
        }

        private void Exit(Object obj, EventArgs evnt)
        {
            closedByIcon = true;
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disableByDay();

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings.txt"))
            {
                string[] settings = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Settings.txt");
                directory = settings[0];
                waveOutDevice.DeviceNumber = int.Parse(settings[1]);
                runOnStartupToolStripMenuItem.Checked = bool.Parse(settings[2]);
            }
            
            string path = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.DayOfWeek + ".txt";

            init();

            if (File.Exists(path))
            {
                string[] timeData = File.ReadAllLines(path);

                foreach (string str in timeData)
                {
                    string[] input = str.Split('|');
                    data.Add(Tuple.Create(HourTime.Parse(input[0]), input[1]));
                    SongListBox.Items.Add(input[0] + " - " + input[1]);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.DayOfWeek + ".txt";
            string[] temp = new string[data.Count];

            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "Settings.txt",
                new string[] {
                    directory,
                    waveOutDevice.DeviceNumber.ToString(),
                    runOnStartupToolStripMenuItem.Checked.ToString()
                });

            for (int i = 0; i < data.Count; i++)
                temp[i] = data[i].Item1.ToString() + '|' + data[i].Item2;
            
            File.WriteAllLines(path, temp);

            waveOutDevice.Dispose();
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closedByIcon)
            {
                DialogResult confirmResult = MessageBox.Show("Continue in background?",
                                         "Confirm Close",
                                         MessageBoxButtons.YesNoCancel);

                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        Hide();
                        e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void PlayPause_Click(object sender, EventArgs e)
        {
            if (SongComboBox.SelectedIndex != -1)
            {
                if (audioFileReader == null)
                {
                    try
                    {
                        audioFileReader = new AudioFileReader(directory + '\\' + music[SongComboBox.SelectedIndex]);
                    }
                    catch
                    {
                        MessageBox.Show("there was a problem reading the mp3 file");
                        return;
                    }
                    waveOutDevice.Init(audioFileReader);
                }

                if (waveOutDevice.PlaybackState != PlaybackState.Playing)
                {
                    waveOutDevice.Play();
                    PlayPause.Image = Properties.Resources.pause;
                }
                else
                {
                    waveOutDevice.Pause();
                    audioFileReader.Close();
                    audioFileReader = null;
                    PlayPause.Image = Properties.Resources.play;
                }
            }
        }

        private void FolderDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (directory != null)
            {
                DialogResult confirm =
                    MessageBox.Show("Are You sure you want to Change Directory?\n" +
                    "Changing directory would mean the deletion of all previous setups",
                                         "Confirm Directory Change",
                                         MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                    foreach (DayOfWeek day in new DayOfWeek[] {
                        DayOfWeek.Sunday,
                        DayOfWeek.Monday,
                        DayOfWeek.Tuesday,
                        DayOfWeek.Wednesday,
                        DayOfWeek.Thursday,
                        DayOfWeek.Friday,
                        DayOfWeek.Saturday,
                    })
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + day + ".txt");
                if (confirm == DialogResult.No)
                    return;
            }

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                editSpecificDayToolStripMenuItem.Enabled = true;
                directory = folderBrowserDialog.SelectedPath;
                init();
            }
            else if(directory == null)
                MessageBox.Show("ERROR - problem loading folder");
        }

        private void init()
        {
            toolStripStatusFile.Text = directory;

            if (directory != null && directory != "")
            {
                music = new List<string>();
                music.AddRange(Directory.GetFiles(directory, "*.mp3"));

                SongComboBox.Items.Clear();

                for (int i = 0; i < music.Count; i++)
                {
                    music[i] = music[i].Replace(directory + '\\', "");
                    SongComboBox.Items.Add(music[i]);
                }
            }
            else
                editSpecificDayToolStripMenuItem.Enabled = false;
        }

        private void SongListBox_DoubleClick(object sender, EventArgs e)
        {
            if (SongListBox.SelectedIndex > -1)
                new EditBox(SongListBox.SelectedIndex, music, data, SongListBox.Items).Show();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (music != null)
                new EditBox(music, data, SongListBox.Items).ShowDialog();
            else
                MessageBox.Show("Please Choose A Folder First");
        }

        private void SecTimer_Tick(object sender, EventArgs e)
        {
            if(DateTime.Now.DayOfWeek.ToString() != Day.Text)
            {
                disableByDay();

                Day.Text = DateTime.Now.DayOfWeek.ToString();
                string path = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.DayOfWeek + ".txt";
                
                data.Clear();
                SongListBox.Items.Clear();

                if (File.Exists(path))
                {
                    string[] timeData = File.ReadAllLines(path);

                    for (int i = 0; i < timeData.Length; i++)
                    {
                        string[] input = timeData[i].Split('|');
                        data.Add(Tuple.Create(HourTime.Parse(input[0]), input[1]));

                        SongListBox.Items.Add(input[0] + " - " + input[1]);
                    }
                }
            }

            foreach (Tuple<HourTime, string> tuple in data)
                if (tuple.Item1.isNow())
                {
                    try
                    {
                        audioFileReader = new AudioFileReader(directory + '\\' + tuple.Item2);
                    }
                    catch
                    {
                        MessageBox.Show("there was a problem reading the mp3 file");
                        return;
                    }
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
        }

        private void changeSoundCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SoundCardForm().Show();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().Show();
        }

        private void runOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            runOnStartupToolStripMenuItem.Checked = !runOnStartupToolStripMenuItem.Checked;
            
            if (runOnStartupToolStripMenuItem.Checked)
                regKey.SetValue("RingaDing", Application.ExecutablePath);
            else
                regKey.DeleteValue("RingaDing");
        }

        #region dayClick

        private void sundayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Sunday, music).Show();
        }

        private void mondayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Monday, music).Show();
        }

        private void tusedayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Tuesday, music).Show();
        }

        private void wednesdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Wednesday, music).Show();
        }

        private void thursdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Thursday, music).Show();
        }

        private void fridayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Friday, music).Show();
        }

        private void saturdayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDayForm(DayOfWeek.Saturday, music).Show();
        }

        private void disableByDay()
        {
            sundayToolStripMenuItem.Enabled = true;
            mondayToolStripMenuItem.Enabled = true;
            tusedayToolStripMenuItem.Enabled = true;
            wednesdayToolStripMenuItem.Enabled = true;
            thursdayToolStripMenuItem.Enabled = true;
            fridayToolStripMenuItem.Enabled = true;
            saturdayToolStripMenuItem.Enabled = true;

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    sundayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Monday:
                    mondayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Tuesday:
                    tusedayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Wednesday:
                    wednesdayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Thursday:
                    thursdayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Friday:
                    fridayToolStripMenuItem.Enabled = false;
                    break;
                case DayOfWeek.Saturday:
                    saturdayToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        #endregion

    }
}