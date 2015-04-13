using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using spiro_data_reading;


namespace SpirometerPlot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int a = 1;
            int b = 1;
           // MWNumericArray arr1 = a;
           // MWNumericArray arr2 = b;
            spirofunc obj = new spirofunc();
            MWArray[] result = obj.spiro_data_reading(2,1,1);
            //Console.WriteLine(result); //Result is displayed
             

        }
    }
}
