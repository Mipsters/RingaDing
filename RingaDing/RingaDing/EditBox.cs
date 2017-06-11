using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace RingaDing
{
    public partial class EditBox : Form
    {
        private ListBox.ObjectCollection originList;
        private bool overwrite;
        private int dataLoc;
        private List<string> data;
        private List<Tuple<HourTime, string>> originData;
        private DayOfWeek dayOfWeek;

        public EditBox(List<string> data, List<Tuple<HourTime, string>> originData, ListBox.ObjectCollection originList)
        {
            InitializeComponent();

            overwrite = false;

            Text = "Add Song Dialog";
            this.originList = originList;
            this.originData = originData;
            this.data = data;
            dayOfWeek = DateTime.Now.DayOfWeek;
            
            foreach (string str in data)
                SongComboBox.Items.Add(str);

            Delete.Hide();
        }

        public EditBox(int dataLoc, List<string> data, List<Tuple<HourTime, string>> originData, ListBox.ObjectCollection originList, DayOfWeek dayOfWeek)
        {
            InitializeComponent();

            Text = "Edit Song Dialog";
            overwrite = true;
            this.dataLoc = dataLoc;
            this.originData = originData;
            this.data = data;
            this.dayOfWeek = dayOfWeek;

            this.originList = originList;

            foreach (string str in data)
                SongComboBox.Items.Add(str);
            

            SongComboBox.SelectedIndex = data.FindIndex(x => x == originData[dataLoc].Item2);

            TimeData.Text = originData[dataLoc].Item1.ToString();

            Delete.Show();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (SongComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Song");
                return;
            }
            
            if (!HourTime.isParsable(TimeData.Text))
            {
                MessageBox.Show("The time is not in the format \"HH:MM:SS\"");
                return;
            }

            if (overwrite)
            {
                originList[dataLoc] = TimeData.Text + " - " + SongComboBox.Text;
                originData[dataLoc] = Tuple.Create(HourTime.Parse(TimeData.Text), data[SongComboBox.SelectedIndex]);


            } else {
                originList.Add(TimeData.Text + " - " + SongComboBox.Text);
                originData.Add(Tuple.Create(HourTime.Parse(TimeData.Text), data[SongComboBox.SelectedIndex]));
            }

            save();
            Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are You sure you want to delete that item?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                originData.RemoveAt(dataLoc);
                originList.RemoveAt(dataLoc);

                save();
                Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save()
        {
            string finalDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RingaDing") + '\\';
            string path = finalDir + dayOfWeek + ".txt";
            string[] temp = new string[originData.Count];

            for (int i = 0; i < originData.Count; i++)
                temp[i] = originData[i].Item1.ToString() + '|' + originData[i].Item2;

            File.WriteAllLines(path, temp);
        }
    }
}