using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Mixer;
using System.Globalization;

namespace System_GUI
{
    class audioRecord
    {
        public WaveIn waveIn = null;
        public WaveFileWriter waveFile = null;
        public string myPath = System.IO.Path.Combine("C://Users/Kevin/Documents/AudioTesting");
        public string path_wav;

        public void recordAudio()
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

        public void audioStopRecording()
        {
            waveIn.StopRecording();
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

    }
}
