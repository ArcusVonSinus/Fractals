using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Fraktaly_2._0
{
    public enum FractalType { sierpinski,koch,hilbert,cross,siercur,apoll,zmatrix,hexacurve,hexacurve2,recursion, crooked, crossRound} //NEWFRACTAL
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
                    case FractalType.hexacurve:
                        {

                            JmenoFraktalu.Text = "Hexacurve";
                            break;
                        }
                    case FractalType.hexacurve2:
                        {

                            JmenoFraktalu.Text = "Hexacurve 2";
                            break;
                        }
                    case FractalType.recursion:
                        {

                            JmenoFraktalu.Text = "Recursion";
                            break;
                        }
                    case FractalType.crooked:
                        {

                            JmenoFraktalu.Text = "Crooked";
                            break;
                        }
					case FractalType.crossRound:
						{
							JmenoFraktalu.Text = "Rounded cross";
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
            panely[7] = panel_hilbert;
            panely[8] = panel_hilbert;
            panely[9] = panel_recursion;
            panely[10] = panel_crooked;
			panely[11] = panel_hilbert;
            //NEWFRACTAL

            foreach(Panel p in panely)
            {
                p.Visible = false;
                p.Location = new Point(20, 188);
            }
            panel_all.Location = new Point(20, 888);

            menuStrip1.Renderer = new MyRenderer();           

            typVykreslenehoFraktalu = FractalType.koch;
            sierpinskiToolStripMenuItem_Click(null, null);

			bWToolStripMenuItem_Click(null,null); //blac&whitening 

		}


        

        private void button1_Click(object sender, EventArgs e)
        {
            invCenter = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            switch(typVykreslenehoFraktalu)
            {
                case FractalType.sierpinski:
                    {
                        vykreslenyFraktal.vykresli((int)(numericUpDown1.Value), (int)(numericUpDown2.Value));
                        break;
                    }
                case FractalType.koch:
                    {
						if (sender == this)
							if (numericUpDown3.Value > numericUpDown3.Minimum)
								numericUpDown3.Value--;

						vykreslenyFraktal.vykresli((int)(numericUpDown3.Value));
                        if (sender != null )
                        {
                            if (numericUpDown3.Value < numericUpDown3.Maximum)
                                numericUpDown3.Value++;
                        }
                        break;
                    }
                case FractalType.hilbert:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli((int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.cross:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.siercur:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.apoll:
                    {
						if (sender == this)
							if (numericUpDown5.Value > numericUpDown5.Minimum)
								numericUpDown5.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown5.Value));
                        if (sender != null)
                        {
                            if (numericUpDown5.Value < numericUpDown5.Maximum - 20000)
                                numericUpDown5.Value += 20000;
                        }
                        break;
                    }
                case FractalType.zmatrix:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.hexacurve:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.hexacurve2:
                    {
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
                        if (sender != null)
                        {
                            if (numericUpDown4.Value < numericUpDown4.Maximum)
                                numericUpDown4.Value++;
                        }
                        break;
                    }
                case FractalType.recursion:
                    {
						if (sender == this)
							if (numericUpDown7.Value > numericUpDown7.Minimum)
								numericUpDown7.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown7.Value), textBox1.Text);
                        if (sender != null)
                        {
                            if (numericUpDown7.Value < numericUpDown7.Maximum)
                                numericUpDown7.Value++;
                        }
                        break;
                    }
                case FractalType.crooked:
                    {
                        vykreslenyFraktal.vykresli( (double)(trackBar2.Value)/128.0, (int) numericUpDown8.Value);                       
                        break;
                    }
				case FractalType.crossRound:
					{
						if (sender == this)
							if (numericUpDown4.Value > numericUpDown4.Minimum)
								numericUpDown4.Value--;

						vykreslenyFraktal.vykresli( (int)(numericUpDown4.Value));
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
                numericUpDown1.Value = 3;
                numericUpDown2.Value = 600000;
                typVykreslenehoFraktalu = FractalType.sierpinski;
                vykreslenyFraktal = new Sier(pictureBox1);
                button1_Click(null, null);
            }


        }

        private void kochToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.koch)
            {
                numericUpDown3.Value = 0;
                typVykreslenehoFraktalu = FractalType.koch;
                vykreslenyFraktal = new Koch(pictureBox1);
                button1_Click(null, null);
            }
        }
        private void reloadfrac()
        {
            switch(typVykreslenehoFraktalu)
            {
                case FractalType.sierpinski:
                    {
                        vykreslenyFraktal = new Sier(pictureBox1);
                        break;
                    }
                case FractalType.koch:
                    {
                        vykreslenyFraktal = new Koch(pictureBox1);
                        break;
                    }
                case FractalType.hilbert:
                    {
                        vykreslenyFraktal = new Hilbert(pictureBox1);
                        break;
                    }
                case FractalType.cross:
                    {
                        vykreslenyFraktal = new Cross(pictureBox1);
                        break;
                    }
                case FractalType.siercur:
                    {
                        vykreslenyFraktal = new SierCurve(pictureBox1);
                        break;
                    }
                case FractalType.apoll:
                    {
                        vykreslenyFraktal = new Apoll(pictureBox1);
                        break;
                    }
                case FractalType.zmatrix:
                    {
                        vykreslenyFraktal = new ZMatrix(pictureBox1);
                        break;
                    }
                case FractalType.hexacurve:
                    {
                        vykreslenyFraktal = new Hexacurve(pictureBox1);
                        break;
                    }
                case FractalType.hexacurve2:
                    {
                        vykreslenyFraktal = new Hexacurve2(pictureBox1);
                        break;
                    }
                case FractalType.recursion:
                    {
                        vykreslenyFraktal = new Recursion(pictureBox1);
                        break;
                    }
				case FractalType.crossRound:
					{
						vykreslenyFraktal = new CrossRound(pictureBox1);
						break;
					}
					//NEWFRACTAL

            }
            button1_Click(null, null);
        }
		/* 
		 * Přidat fraktal do nabidky menu
		 * NEWFRACTAL
		 * 
		 */
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
                vykreslenyFraktal = new Hilbert(pictureBox1);
                button1_Click(null, null);
            }
        }
        
        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.cross)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.cross;
                vykreslenyFraktal = new Cross(pictureBox1);
                button1_Click(null, null);
            }
        }

        private void sierpinskisCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.siercur)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.siercur;
                vykreslenyFraktal = new SierCurve(pictureBox1);
                button1_Click(null, null);
            }
        }


        private void apollonianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.apoll)
            {
                numericUpDown5.Value = 10000;
                typVykreslenehoFraktalu = FractalType.apoll;
                vykreslenyFraktal = new Apoll(pictureBox1);
                button1_Click(null, null);
            }
        }



        private void zMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.zmatrix)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.zmatrix;
                vykreslenyFraktal = new ZMatrix(pictureBox1);
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

        private void hexacurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.hexacurve)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.hexacurve;
                vykreslenyFraktal = new Hexacurve(pictureBox1);
                button1_Click(null, null);
            }
        }

        private void hexacurve2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.hexacurve2)
            {
                numericUpDown4.Value = 0;
                typVykreslenehoFraktalu = FractalType.hexacurve2;
                vykreslenyFraktal = new Hexacurve2(pictureBox1);
                button1_Click(null, null);
            }
        }

        private void recursionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.recursion)
            {
                numericUpDown7.Value = 1;
                typVykreslenehoFraktalu = FractalType.recursion;
                vykreslenyFraktal = new Recursion(pictureBox1);
                button1_Click(null, null);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("save.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void crookedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (typVykreslenehoFraktalu != FractalType.crooked)
            {                
                typVykreslenehoFraktalu = FractalType.crooked;
                vykreslenyFraktal = new Crooked();
                button1_Click(null, null);
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            vykreslenyFraktal.vykresli((double)trackBar2.Value/128.0, 1);
        }

        private void trackBar2_MouseUp(object sender, EventArgs e)
        {
            vykreslenyFraktal.vykresli( (double)trackBar2.Value / 128.0, (int)numericUpDown8.Value);
        }

		private void wBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Barvy.pozadi = System.Drawing.ColorTranslator.FromHtml("#000000");
			Barvy.popredi = System.Drawing.ColorTranslator.FromHtml("#ffffff");
			reloadfrac();
		}

		private void roundedCrossToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (typVykreslenehoFraktalu != FractalType.crossRound)
			{
				numericUpDown4.Value = 0;
				typVykreslenehoFraktalu = FractalType.crossRound;
				vykreslenyFraktal = new CrossRound(pictureBox1);
				button1_Click(null, null);
			}
		}

		private void slowDrawButton_Click(object sender, EventArgs e)
		{
			vykreslenyFraktal.slowDraw = true;
			if(numericUpDown4.Value>numericUpDown4.Minimum)
				numericUpDown4.Value--;
			button1_Click(null, null);
		}

		private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
		{

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
		public PictureBox pb;
		public bool slowDraw = false;
        public Thread vykreslovac;
        public virtual void vykresli(int n) { }
        public virtual void vykresli(int n,string pat) { }
        public virtual void vykresli(int n, int m){}
        public virtual void vykresli(double k, int tarDepth) { }

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
				if(slowDraw && i%10==0 && pb!=null)
				{
                    //pb.Refresh();
                    refreshPictureBox();
				}
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

        delegate void refreshPictureBoxDel();
        public void refreshPictureBox()
        {
            if (pb.InvokeRequired)
            {
                pb.Invoke(new refreshPictureBoxDel(refreshPictureBox));
            }
            else
            {
                pb.Refresh();
            }
        }

        delegate void setPictureDel(Bitmap bm);
        public void setPicture(Bitmap bm)
        {
            if (pb.InvokeRequired)
            {
                //setPictureDel d = new setPictureDel(setPicture);
                //pb.BeginInvoke(new setPictureDel(setPicture),  bm );
                pb.Invoke(new setPictureDel(setPicture), bm);
                //Invoke(d, new object[] { bm });
            }
            else
            {
                pb.Image = bm;
                pb.Refresh();
            }
        }

        delegate void paintBackgroundDel();
        public void paintBackground()
        {
            if (pb.InvokeRequired)
            {
                //setPictureDel d = new setPictureDel(setPicture);
                pb.Invoke(new paintBackgroundDel(paintBackground));

                //Invoke(d, new object[] { bm });
            }
            else
            {
        
                using (Graphics gfx = Graphics.FromImage(pb.Image))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }
                pb.Refresh();
            }
        }



    }
   
}
