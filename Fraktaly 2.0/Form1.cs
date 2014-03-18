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
    public enum FractalType { sierpinski,koch,hilbert,cross} //NEWFRACTAL
    public partial class Form1 : Form
    {
        public Fractal vykreslenyFraktal;
        FractalType _typVykreslenehoFraktalu;
        Panel[] panely;
        public FractalType typVykreslenehoFraktalu
        {
            set
            {
                foreach(Panel p in panely)
                {
                    p.Visible = false;
                }
                panely[(int)value].Visible = true;
                switch(value)
                {
                    case FractalType.sierpinski:
                        {
                            
                            JmenoFraktalu.Text = "Sierpinski";
                            break;
                        }
                    case FractalType.koch:
                        {
                            
                            JmenoFraktalu.Text = "Koch";
                            break;
                        }
                    case FractalType.hilbert:
                        {
                            
                            JmenoFraktalu.Text = "Hilbert";
                            break;
                        }
                    case FractalType.cross:
                        {
                            
                            JmenoFraktalu.Text = "Cross";
                            break;
                        } //NEWFRACTAL

                    default:
                        {
                            JmenoFraktalu.Text = value.ToString();
                            break;
                        }
                }                
                _typVykreslenehoFraktalu = value;                                 
            }
            get { return _typVykreslenehoFraktalu; }
        }
        public Form1()
        {
            InitializeComponent();


            panely = new Panel[Enum.GetNames(typeof(FractalType)).Length];
            panely[0] = panel_sier;
            panely[1] = panel_koch;
            panely[2] = panel_hilbert;
            panely[3] = panel_hilbert;
            //NEWFRACTAL

            foreach(Panel p in panely)
            {
                p.Visible = false;
                p.Location = new Point(10, 94);
            }


            menuStrip1.Renderer = new MyRenderer();           

            typVykreslenehoFraktalu = FractalType.koch;
            sierpinskiToolStripMenuItem_Click(null, null);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            switch(typVykreslenehoFraktalu)
            {
                case FractalType.sierpinski:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown1.Value), (int)(numericUpDown2.Value));
                        break;
                    }
                case FractalType.koch:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown3.Value));
                        if (sender != null)
                        {
                            if (numericUpDown3.Value < numericUpDown3.Maximum)
                                numericUpDown3.Value++;
                        }
                        break;
                    }
                case FractalType.hilbert:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.cross:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                    //NEWFRACTAL
            }

        }

        private void sierpinskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(typVykreslenehoFraktalu!=FractalType.sierpinski)
            {
                typVykreslenehoFraktalu = FractalType.sierpinski;
                vykreslenyFraktal = new Sier();
                button1_Click(null, null);
            }


        }

        private void kochToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.koch)
            {
                typVykreslenehoFraktalu = FractalType.koch;
                vykreslenyFraktal = new Koch();
                button1_Click(null, null);
            }
        }
        private void reloadfrac()
        {
            switch(typVykreslenehoFraktalu)
            {
                case FractalType.sierpinski:
                    {
                        vykreslenyFraktal = new Sier();
                        break;
                    }
                case FractalType.koch:
                    {
                        vykreslenyFraktal = new Koch();
                        break;
                    }
                case FractalType.hilbert:
                    {
                        vykreslenyFraktal = new Hilbert();
                        break;
                    }
                case FractalType.cross:
                    {
                        vykreslenyFraktal = new Cross();
                        break;
                    }//NEWFRACTAL

            }
            button1_Click(null, null);
        }
        private void hilbertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.hilbert)
            {
                typVykreslenehoFraktalu = FractalType.hilbert;
                vykreslenyFraktal = new Hilbert();
                button1_Click(null, null);
            }
        }
        private void bWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barvy.pozadi = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            Barvy.popredi = System.Drawing.ColorTranslator.FromHtml("#000000");
            reloadfrac();
        }

        private void greenWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Barvy.pozadi = System.Drawing.ColorTranslator.FromHtml("#2b2b2b");
            Barvy.popredi = System.Drawing.ColorTranslator.FromHtml("#519f50");
            reloadfrac();
        }

        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.cross)
            {
                typVykreslenehoFraktalu = FractalType.cross;
                vykreslenyFraktal = new Cross();
                button1_Click(null, null);
            }
        }

        


        
    }
    public static class Barvy
    {
        public static Color pozadi = System.Drawing.ColorTranslator.FromHtml("#2b2b2b");
        public static Color popredi = System.Drawing.ColorTranslator.FromHtml("#519f50");
    }
    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }
    public class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#da4939"); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#ea5949"); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#ca3929"); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#fa6959"); }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#ba1919"); }
        }
        public override Color MenuItemBorder
        {
            get { return System.Drawing.ColorTranslator.FromHtml("#da3939"); }
        }        
    }
    public class Fractal
    {
        public virtual void vykresli(PictureBox pb, int n){}
        public virtual void vykresli(PictureBox pb, int n, int m){}
        protected void DrawLine(Bitmap bmp, float x1, float y1, float x2, float y2)
        {
            double x = x2 - x1;
            double y = y2 - y1;
            double length = Math.Sqrt(x * x + y * y);
            double addx = x / length;
            double addy = y / length;
            x = x1;
            y = y1;
            for (double i = 0; i < length; i += 1)
            {
                if(x-1>=0&&y-1>=0&&x+1<bmp.Width&&y+1<bmp.Height)
                    bmp.SetPixel((int)(x + 0.5), (int)(y + 0.5), Barvy.popredi); 
                x += addx;
                y += addy;
            }
        }
        protected void DrawLine(Bitmap bmp,Point a, Point b)
        {
            DrawLine(bmp, a.X, a.Y, b.X, b.Y);
        }
        protected void DrawLine(Bitmap bmp, PointF a, PointF b)
        {
            DrawLine(bmp, a.X, a.Y, b.X, b.Y);
        }
       
    }
   
}
