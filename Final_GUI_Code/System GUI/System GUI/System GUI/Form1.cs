using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

using NAudio.Wave;
using NAudio.Mixer;


namespace System_GUI
{
    public partial class Form1 : Form
    {
        string selectedPath;

        // This BackgroundWorker is used to demonstrate the 
        // preferred way of performing asynchronous operations.
        private BackgroundWorker hardWorker;
        public static System.IO.Ports.SerialPort port;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            hardWorker = new BackgroundWorker(); // What is this?
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            cmbSerialPorts.DataSource = ports;
            this.label2.Text = System.IO.Directory.GetCurrentDirectory();
            this.stopButton.Visible = false;

            foreach (string s in SerialPort.GetPortNames())
            {
                comPort.Items.Add(s);
            }
        }

        private void btnCollectData_Click(object sender, EventArgs e)
        {
            if (cmbSerialPorts.SelectedIndex > -1)
            {
                SerialPort _serialPort = new SerialPort(cmbSerialPorts.SelectedItem.ToString(), 19200, Parity.Odd, 8, StopBits.One);
                _serialPort.Open();

                int num_bytes = 17760;
                byte[] byteArray = new byte[num_bytes];
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();

                //_serialPort.Read(byteArray, 0, num_bytes);

                int k = 0;
                int ppg_indx = 0;
                byte[] b = new byte[1];

                int state = 0;
                int[] ppg = new int[num_bytes];
                int[] pulse = new int[num_bytes];
                int[] blip = new int[num_bytes];
                int[] ox = new int[num_bytes];

                string[] timestampArray = new string[num_bytes];

                const byte BIT_SIX_SET = 64;
                const byte BIT_SEVEN_SET = 128;

                DateTime begin;
                TimeSpan time;
                string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                time = DateTime.Now - DateTime.Now;
                double[] timeArray = new double[num_bytes];

                begin = DateTime.Now;

                while ((num_bytes - k) >= (5 - state))
                {
                    _serialPort.Read(b, 0, 1);
                    if (!Convert.ToBoolean(b[0] & 0))
                    {
                        if (state == 0)
                        {
                            if ((b[0] & BIT_SEVEN_SET) == BIT_SEVEN_SET)
                            {
                                if (Convert.ToBoolean(b[0] & BIT_SIX_SET))
                                {
                                    blip[ppg_indx] = 1;
                                }
                                else
                                {
                                    blip[ppg_indx] = 0;
                                }
                                state = 1;
                            }
                        }
                        else if (state == 1)
                        {
                            ppg[ppg_indx] = b[0];
                            byteArray[ppg_indx] = b[0];
                            state = 2;

                            // Get timestamp info
                            timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                            timestampArray[ppg_indx] = timestamp;

                            // Get time since start of data collection
                            time = DateTime.Now - begin;
                            timeArray[ppg_indx] = time.TotalSeconds;

                        }
                        else if (state == 2)
                        {
                            if (Convert.ToBoolean(b[0] & BIT_SIX_SET))
                                pulse[ppg_indx] = 128;
                            else
                                pulse[ppg_indx] = 0;
                            state = 3;
                        }
                        else if (state == 3)
                        {
                            pulse[ppg_indx] += b[0];
                            if ((ppg_indx % 10) == 0)
                            {
                                this.label4.Text = pulse[ppg_indx].ToString();
                                this.label11.Text = ox[ppg_indx].ToString();
                            }
                            state = 4;
                        }
                        else if (state == 4)
                        {
                            ox[ppg_indx] = b[0];
                            state = 0;

                            if ((ppg_indx % 10) == 0)
                            {
                                this.label7.Text = ox[ppg_indx].ToString();
                                this.label9.Text = ox[ppg_indx].ToString();
                            }

                            chart1.Series["PPG"].Points.AddXY(timeArray[ppg_indx], ppg[ppg_indx]); // Change back to ppg[ppg_indx]

                            ppg_indx++;
                        }
                        k++;
                    }
                }

                // Write PPG data
                string ppg_fn = selectedPath + "\\PPG_test.dat";
                System.IO.FileStream _FileStream = new System.IO.FileStream(ppg_fn, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                _FileStream.Write(byteArray, 0, byteArray.Length);
                _FileStream.Close();

                // Write timestamp data
                string timestamp_fn = selectedPath + "\\PPG_test.txt";
                System.IO.File.WriteAllLines(timestamp_fn, timestampArray);

            }
            else
            {
                MessageBox.Show("Please select a port first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                selectedPath = fbd.SelectedPath;
            this.label2.Text = selectedPath;
        }


        // Throat Microphone Code
        public WaveIn waveIn = null;
        public WaveFileWriter waveFile = null;
        public string myPath = System.IO.Path.Combine("C://Users/Kevin/Documents/AudioTesting");
        public string path_wav;

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

            customWaveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(path_wav);
            customWaveViewer1.FitToScreen();
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    customWaveViewer1.WaveStream = new NAudio.Wave.WaveFileReader(path_wav);
        //    customWaveViewer1.FitToScreen();
        //}

        // Respiratory Effort Band Code        
        delegate void SetTextCallback(string text);        

        private Thread readThread = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            System.ComponentModel.IContainer components =
                new System.ComponentModel.Container();
            port = new System.IO.Ports.SerialPort(components);
            port.PortName = comPort.SelectedItem.ToString();
            //port.BaudRate = Int32.Parse(baudRate.SelectedItem.ToString());
            port.BaudRate = 9600;
            port.DtrEnable = true;
            port.ReadTimeout = 5000;
            port.WriteTimeout = 500;
            port.Open();

            readThread = new Thread(new ThreadStart(this.Read));
            readThread.Start();
            this.hardWorker.RunWorkerAsync();

            btnConnect.Text = "<Connected>";

            btnConnect.Enabled = false;
            comPort.Enabled = false;
            //sendBtn.Enabled = true;
        }
        
        /*
                private void sendBtn_Click(object sender, EventArgs e)
                {
                    if (port.IsOpen)
                    {
                        port.Write(sendText.Text);
                    }
                }
                */
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.chart1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                //this.receiveText.Text += text;
                //this.receiveText.Text += "\n";
                try
                {
                    if (Convert.ToDouble(text) >= 0 & Convert.ToDouble(text) < 1024)
                        chart1.Series["Abdominal Movement"].Points.Add(Convert.ToDouble(text));
                }
                catch
                {
                    chart1.Series["Abdominal Movement"].Points.Add(0);
                }
            }
        }

        public void Read()
        {
            while (port.IsOpen)
            {
                try
                {
                    string message = port.ReadLine();
                    this.SetText(message);
                }
                catch (TimeoutException) { }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            readThread.Abort();

            port.Close();
        }
        /*
                private void clrBtn_Click(object sender, EventArgs e)
                {
                    if (port.IsOpen)
                    {
                        byte[] stuff = {0x7C, 0x00};
                        port.Write(stuff, 0, 2);
                    }
                }
                */
        /*
              private void demoBtn_Click(object sender, EventArgs e)
              {
                  if (port.IsOpen)
                  {
                      byte[] stuff = { 0x7C, 0x04 };
                      port.Write(stuff, 0, 2);
                  }
              }

              private void revBtn_Click(object sender, EventArgs e)
              {
                  if (port.IsOpen)
                  {
                      byte[] stuff = { 0x7C, 0x12 };
                      port.Write(stuff, 0, 2);
                  }
              }
              */
    }
}
