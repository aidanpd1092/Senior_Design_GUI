using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Mixer;
using System.Globalization;
using System.Threading;

namespace VoiceRecorderBest
{
    public partial class Form1 : Form
    {
        public WaveIn waveIn = null;
        public WaveFileWriter waveFile = null;
        public string myPath = System.IO.Path.Combine("C://Users/Kevin/Documents/AudioTesting");
        public string path_wav;

        public Form1()
        {
            InitializeComponent();
            //this.recordButton.IsEnabled = true;
            this.stopButton.Visible = false;
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            record();
            this.recordButton.Visible = false;
            this.stopButton.Visible = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();
            this.recordButton.Visible = true;
            this.stopButton.Visible = false;
            //Thread.Sleep(100);
            
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            myPath = dialog.SelectedPath;
        }

        public void record()
        {
            waveIn = new WaveIn();
            //waveIn.DeviceNumber = deviceNumber;
            waveIn.WaveFormat = new WaveFormat(44100, 1);

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
            string time = System.DateTime.Now.ToString("yyyy'-'M'-'d'-'hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string fname = String.Format("AudioTest_{0}.wav", time);
            path_wav = System.IO.Path.Combine(myPath, fname);
            waveFile = new WaveFileWriter(path_wav, waveIn.WaveFormat);

            waveIn.StartRecording();

        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customWaveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(path_wav);
            customWaveViewer1.FitToScreen();
        }
    }
}
