using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Manipulator
{
    public partial class Form1 : Form
    {
        public Bitmap source;
        public Bitmap result;
        public string filename;
        public string method;
        public Form2 form2;
        public int[,] filter;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            source = new Bitmap(filename);
            pictureBox1.Image = source;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(filename);
        }

        private void processImageBtn_Click(object sender, EventArgs e)
        {
            result = ImageProcessor.Laplace(source, Convert.ToInt32(toleranceTxtBox.Text));
            form2 = new Form2(result);
            form2.Show();
        }

        private void brightnessProcessBtn_Click(object sender, EventArgs e)
        {
            result = ImageProcessor.Brightness(source, Convert.ToInt32(brightnessTxtBox.Text));
            form2 = new Form2(result);
            form2.Show();
        }

        private void sharpenProcessBtn_Click(object sender, EventArgs e)
        {
            method = "sharpen";
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (method == "sharpen") result = ImageProcessor.Sharpen(source);
            if (method == "filter") result = ImageProcessor.Filter(source, filter);
            if (method == "sobel")
            {
                //if (thresholdCheckBox.Checked)
                //{
                //    result = ImageProcessor.Sobel(source);
                //    result = ImageProcessor.Threshold(result, Convert.ToInt32(thresholdTxtBox.Text), whiteCheckBox.Checked);
                //}
                //else
                //{
                //    result = ImageProcessor.Sobel(source);
                //    result = ImageProcessor.Threshold(result, 0, whiteCheckBox.Checked);
                //}
                result = ImageProcessor.Sobel(source);
                if (grayCheckBox.Checked) result = ImageProcessor.ConvertToGrayscale(result);
            }
            if (method == "3x3gaussian")
            {
                double[,] gaussian = new double[3, 3]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        gaussian[x, y] = gaussian[x, y] * (1 / (double)16);
                        Debug.WriteLine(gaussian[x,y]);
                    }
                }
                result = ImageProcessor.ConvolutionBad3x3(source, gaussian);
            }
            if (method == "canny") result = ImageProcessor.Canny(source, Convert.ToInt32(lowThresholdTxtBox.Text), Convert.ToInt32(highThresholdTxtBox.Text), customThresholdCheckBox.Checked);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            form2 = new Form2(result);
            form2.Show();
        }

        private void filterProcessBtn_Click(object sender, EventArgs e)
        {
            filter = new int[,]
            {
                { Convert.ToInt32(filter1.Text), Convert.ToInt32(filter2.Text), Convert.ToInt32(filter3.Text) },
                { Convert.ToInt32(filter4.Text), Convert.ToInt32(filter5.Text), Convert.ToInt32(filter6.Text) },
                { Convert.ToInt32(filter7.Text), Convert.ToInt32(filter8.Text), Convert.ToInt32(filter9.Text) }
            };
            method = "filter";
            backgroundWorker1.RunWorkerAsync();
        }

        private void sobelProcessBtn_Click(object sender, EventArgs e)
        {
            method = "sobel";
            backgroundWorker1.RunWorkerAsync();
        }

        private void gaussian3x3Btn_Click(object sender, EventArgs e)
        {
            method = "3x3gaussian";
            backgroundWorker1.RunWorkerAsync();
        }

        private void CannyProcessBtn_Click(object sender, EventArgs e)
        {
            method = "canny";
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
