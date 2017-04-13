using System;
using System.Windows.Forms;

namespace RingaDing
{
    public partial class SoundCardForm : Form
    {
        public SoundCardForm()
        {
            InitializeComponent();
        }

        private void SoundCardForm_Load(object sender, EventArgs e)
        {
            SoundCards.Items.AddRange(SystemDevices.GetSoundDevices());
            SoundCards.Items.Add("Default");

            SoundCards.SelectedIndex = (Form1.waveOutDevice.DeviceNumber == -1 ? SoundCards.Items.Count - 1 : Form1.waveOutDevice.DeviceNumber);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Form1.waveOutDevice.DeviceNumber = (SoundCards.SelectedIndex == SoundCards.Items.Count - 1 ? -1 : SoundCards.SelectedIndex);
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
