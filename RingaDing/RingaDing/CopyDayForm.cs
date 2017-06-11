using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.IO;

namespace RingaDing
{
    public partial class CopyDayForm : Form
    {
        private DayOfWeek dayOfWeek;
        private ListBox.ObjectCollection listObject;
        private List<Tuple<HourTime, string>> data;
        private string finalDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RingaDing") + '\\';


        public CopyDayForm(DayOfWeek dayOfWeek, ListBox.ObjectCollection listObject, List<Tuple<HourTime, string>> data)
        {
            InitializeComponent();

            this.dayOfWeek = dayOfWeek;
            this.listObject = listObject;
            this.data = data;
        }

        private void CopyDayForm_Load(object sender, EventArgs e)
        {
            songComboBox.Items.AddRange(new string[]
            {
                DayOfWeek.Sunday.ToString(),
                DayOfWeek.Monday.ToString(),
                DayOfWeek.Tuesday.ToString(),
                DayOfWeek.Wednesday.ToString(),
                DayOfWeek.Thursday.ToString(),
                DayOfWeek.Friday.ToString(),
                DayOfWeek.Saturday.ToString()
            });

            songComboBox.Items.Remove(dayOfWeek.ToString());
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (songComboBox.SelectedIndex != -1)
            {
                string path = finalDir + songComboBox.Text + ".txt";

                if (File.Exists(path))
                {
                    string[] timemusic = File.ReadAllLines(path);

                    listObject.Clear();
                    data.Clear();

                    for (int i = 0; i < timemusic.Length; i++)
                    {
                        string[] input = timemusic[i].Split('|');
                        listObject.Add(input[0] + " - " + input[1]);
                        data.Add(Tuple.Create(HourTime.Parse(input[0]), input[1]));
                    }
                }
                else
                    MessageBox.Show("The day is empty");
                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}