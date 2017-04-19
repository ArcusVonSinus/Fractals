using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5Koch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KochN k = new KochN();
            k.vykresli(pictureBox1, (int) numericUpDownDepth.Value, (int) numericUpDownN.Value);
            if (numericUpDownDepth.Value != numericUpDownDepth.Maximum)
                numericUpDownDepth.Value++;
        }

        private void numericUpDownN_ValueChanged(object sender, EventArgs e)
        {
            /*if (numericUpDownN.Value % 2 == 0)
                numericUpDownDepth.Value = 0;
            else
                numericUpDownDepth.Value = 1;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {                        
            KochN k = new KochN();
            k.save(2000, 2000, (int)numericUpDownDepth.Value, (int)numericUpDownN.Value);
        }
    }
}
