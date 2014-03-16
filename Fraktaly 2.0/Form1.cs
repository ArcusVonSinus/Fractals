using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fraktaly_2._0
{
   
    public partial class Form1 : Form
    {
        public Fractal vykreslenyFraktal;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vykreslenyFraktal = new Sier((int)(numericUpDown1.Value));

        }
    }
    public class Fractal
    {

    }

}
