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
    public partial class Form2 : Form
    {
        public Bitmap result;

        public Form2(Bitmap result)
        {
            InitializeComponent();
            this.result = result;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = result;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void saveFileBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string filepath = saveFileDialog1.FileName;
            result.Save(filepath);
        }
    }
}
