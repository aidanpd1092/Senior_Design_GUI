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
using Spirometer;





namespace SpirometerPlot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         //   this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            // Create the MATLAB instance 
            MLApp.MLApp matlab = new MLApp.MLApp();

            // Change to the directory where the function is located 
            matlab.Execute(@"cd C:\Users\ArjunS\Desktop\Senior_Design_GUI\Spirometer_Code");

            // Define the output 
            object result = null;

            // Call the MATLAB function myfunc
            matlab.Feval("spiro_data_reading", 2, out result, 1, 1);

            // Display result 
            object[] res = result as object[];

            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
            Console.ReadLine(); 
             * */
           
            
            int a = 1;
            int b = 1;
           // MWNumericArray arr1 = a;
           // MWNumericArray arr2 = b;
            spirofunc obj = new spirofunc();
            MWArray[] result = obj.spiro_data_reading(2, a, b);
            //Console.WriteLine(result[0]); //Result is displayed

            // convert 1-dim array (vector) to 2-dim array

            double[] vec0 = (double[])((MWNumericArray)result[0]).ToVector(MWArrayComponent.Real);
            double[] vec1 = (double[])((MWNumericArray)result[1]).ToVector(MWArrayComponent.Real);

            for (int i = 0; i <= vec0.GetLength(0); i++)
                chart1.Series["Series1"].Points.AddXY(vec0[i], vec1[i]);
                //chart1.Series["Series1"].Points.AddXY(mat[i,0], mat[i,1]);
            
       
             


        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}
