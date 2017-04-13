using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.IO;

namespace RingaDing
{
    public partial class EditDayForm : Form
    {
        private DayOfWeek dayOfWeek;
        private List<string> music;
        private List<Tuple<HourTime, string>> data;

        public EditDayForm(DayOfWeek dayOfWeek, List<string> music)
        {
            InitializeComponent();

            Text = "Edit " + dayOfWeek + " Songs";
            this.dayOfWeek = dayOfWeek;
            this.music = music;
            data = new List<Tuple<HourTime, string>>();
        }

        private void EditDayForm_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + dayOfWeek + ".txt";
            
            if (File.Exists(path))
            {
                string[] timemusic = File.ReadAllLines(path);

                for (int i = 0; i < timemusic.Length; i++)
                {
                    string[] input = timemusic[i].Split('|');
                    SongListBox.Items.Add(input[0] + " - " + input[1]);
                    data.Add(Tuple.Create(HourTime.Parse(input[0]), input[1]));
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + dayOfWeek + ".txt";
            string[] temp = new string[data.Count];

            for (int i = 0; i < data.Count; i++)
                temp[i] = data[i].Item1.ToString() + '|' + data[i].Item2;

            File.WriteAllLines(path, temp);

            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SongListBox_DoubleClick(object sender, EventArgs e)
        {
            new EditBox(SongListBox.SelectedIndex, music, data, SongListBox.Items).Show();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            new EditBox(music, data, SongListBox.Items).Show();
        }
    }
}