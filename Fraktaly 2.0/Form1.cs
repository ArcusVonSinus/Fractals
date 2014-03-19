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
    public enum FractalType { sierpinski,koch,hilbert,cross,siercur,apoll,zmatrix} //NEWFRACTAL
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
                        }
                    case FractalType.siercur:
                        {

                            JmenoFraktalu.Text = "Sier. curve";
                            break;
                        }
                    case FractalType.apoll:
                        {

                            JmenoFraktalu.Text = "Apollonian";
                            break;
                        }
                    case FractalType.zmatrix:
                        {

                            JmenoFraktalu.Text = "Apollonian";
                            break;
                        }
                    //NEWFRACTAL

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

            invCenter = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            panely = new Panel[Enum.GetNames(typeof(FractalType)).Length];
            panely[0] = panel_sier;
            panely[1] = panel_koch;
            panely[2] = panel_hilbert;
            panely[3] = panel_hilbert;
            panely[4] = panel_hilbert;
            panely[5] = panel_apoll;
            panely[6] = panel_hilbert;
            //NEWFRACTAL

            foreach(Panel p in panely)
            {
                p.Visible = false;
                p.Location = new Point(10, 94);
            }
            panel_all.Location = new Point(10, 444);

            menuStrip1.Renderer = new MyRenderer();           

            typVykreslenehoFraktalu = FractalType.koch;
            sierpinskiToolStripMenuItem_Click(null, null);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            invCenter = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
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
                case FractalType.siercur:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.apoll:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown5.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown5.Maximum - 20000)
                                numericUpDown5.Value += 20000;
                        }
                        break;
                    }
                case FractalType.zmatrix:
                    {
                        vykreslenyFraktal.vykresli(pictureBox1, (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum )
                                numericUpDown4.Value ++;
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
                numericUpDown1.Value = 3;
                numericUpDown2.Value = 100000;
                typVykreslenehoFraktalu = FractalType.sierpinski;
                vykreslenyFraktal = new Sier();
                button1_Click(null, null);
            }


        }

        private void kochToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.koch)
            {
                numericUpDown3.Value = 0;
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
                    }
                case FractalType.siercur:
                    {
                        vykreslenyFraktal = new SierCurve();
                        break;
                    }
                case FractalType.apoll:
                    {
                        vykreslenyFraktal = new Apoll();
                        break;
                    }
                case FractalType.zmatrix:
                    {
                        vykreslenyFraktal = new ZMatrix();
                        break;
                    }
                //NEWFRACTAL

            }
            button1_Click(null, null);
        }
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Barvy.pozadi = colorDialog1.Color;
                reloadfrac();
            }

        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Barvy.popredi = colorDialog1.Color;
                reloadfrac();
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

        private void hilbertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.hilbert)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.hilbert;
                vykreslenyFraktal = new Hilbert();
                button1_Click(null, null);
            }
        }
        
        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.cross)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.cross;
                vykreslenyFraktal = new Cross();
                button1_Click(null, null);
            }
        }

        private void sierpinskisCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.siercur)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.siercur;
                vykreslenyFraktal = new SierCurve();
                button1_Click(null, null);
            }
        }


        private void apollonianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.apoll)
            {
                numericUpDown5.Value = 10000;
                typVykreslenehoFraktalu = FractalType.apoll;
                vykreslenyFraktal = new Apoll();
                button1_Click(null, null);
            }
        }



        private void zMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.zmatrix)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.zmatrix;
                vykreslenyFraktal = new ZMatrix();
                button1_Click(null, null);
            }
        }

        Point invCenter;        
        private void button4_Click(object sender, EventArgs e)
        {
         
            Bitmap newbmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics gfx = Graphics.FromImage(newbmp))
            using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
            {
                gfx.FillRectangle(brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            Bitmap oldbmp = (Bitmap)pictureBox1.Image;

            int r = trackBar1.Value;
            double v;
            double k;
            int tx, ty;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            Color c = Barvy.popredi;
            for(int x = 0;x<pictureBox1.Width;x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    
	                v=(x-invCenter.X)*(x-invCenter.X)+(y-invCenter.Y)*(y-invCenter.Y);
	                k=1.0*r*r/(1.0*v);
	                tx=(int)((x-invCenter.X)*k+invCenter.X);
	                ty=(int)((y-invCenter.Y)*k+invCenter.Y);
                    if (tx >= 0 && tx < w && ty >= 0 && ty < h)
                        if (oldbmp.GetPixel(tx, ty) == c)
                            newbmp.SetPixel(x, y, c);
                }
            }
            pictureBox1.Image = newbmp;
            pictureBox1.Refresh();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)(numericUpDown6.Value);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown6.Value = trackBar1.Value;
        }
        bool invCenterPicking = false;
        private void button2_Click(object sender, EventArgs e)
        {
            invCenterPicking = !invCenterPicking;
            if(invCenterPicking)
            {
                this.Cursor = Cursors.Cross;
                button2.Text = "Cancel";
            }
            else
            {
                this.Cursor = Cursors.Default;
                button2.Text = "Pick center";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(invCenterPicking)
            {
                MouseEventArgs ee = (MouseEventArgs)e;
                this.Cursor = Cursors.Default;
                button2.Text = "Pick center";
                invCenterPicking = false;
                invCenter.X = ee.X;
                invCenter.Y = ee.Y;
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
