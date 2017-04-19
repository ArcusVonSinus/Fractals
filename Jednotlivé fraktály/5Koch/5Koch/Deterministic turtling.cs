using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5Koch
{
    class Koch5 : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public Koch5()
        {
            L = 2f*Math.PI / 5f;
            P = 4f*Math.PI / 5f;
        }
        void drawRek(int dive)
        {
            if (dive == depth)
            {
                tocL();
                krok(bmp);

                tocP();
                krok(bmp);

                tocL();
                krok(bmp);
            }
            else
            {
                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
                tocP();
                krok(bmp);

                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
            }

        }
        public override void vykresli(PictureBox pb, int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height)
            {
                depth = hloubka;
                width = pb.Width;
                height = pb.Height;

                double a;
                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }
                double gr = 0.5f * (1 + Math.Sqrt(5));
                a = Math.Min(1.0*(width-20) / gr, 1.0*(height-20) / gr);

                /*int ax = (int)((width) / 2);
                int ay = (int)(10);*/
                
                delkakroku = (gr*a) / Math.Pow(gr, 2*(depth+1));

                poloha.X = (width) / 2;
                poloha.Y = 10;

                smer = 8f * Math.PI / 5f;
                krok(bmp);
                drawRek(0);

                //smer = Math.PI;
                //krok(bmp);
                tocP();
                krok(bmp);
                drawRek(0);

                tocP();
                krok(bmp);
                drawRek(1);
                tocL();
                krok(bmp);
                drawRek(1);
                /*smer = Math.PI / 3f;
                krok(bmp);
                drawRek(0);*/
            }
            else
            {
                pb.Image = bmp;
            }
            pb.Refresh();
        }
    }
    class Koch : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public Koch()
        {
            L = Math.PI / 3f;
            P = 2f * Math.PI / 3f;
        }
        void drawRek(int dive)
        {
            if (dive == depth)
            {
                tocL();
                krok(bmp);

                tocP();
                krok(bmp);

                tocL();
                krok(bmp);
            }
            else
            {
                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
                tocP();
                krok(bmp);

                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
            }

        }
        public override void vykresli(PictureBox pb, int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height)
            {
                depth = hloubka;
                width = pb.Width;
                height = pb.Height;

                double a;
                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }

                if (height / (2f / Math.Sqrt(3)) > width)
                {
                    a = (width) - 20;
                }
                else
                {
                    a = height / ((2.0) / (Math.Sqrt(3.0)));
                    a -= 20;
                }

                int ax = (int)((width) / 2);
                int ay = (int)(10);
                int bx = (int)(((width) / 2) - (a / 2));
                int by = (int)(10 + Math.Sqrt(3.0) * 0.5 * a);
                int cx = (int)(((width) / 2) + (a / 2));
                int cy = (int)(10 + Math.Sqrt(3.0) * 0.5 * a);
                poloha.X = ax;
                poloha.Y = ay;

                delkakroku = (cx - bx) / Math.Pow(3.0, depth + 1);

                smer = 5 * Math.PI / 3f;
                krok(bmp);
                drawRek(0);
                smer = Math.PI;
                krok(bmp);
                drawRek(0);
                smer = Math.PI / 3f;
                krok(bmp);
                drawRek(0);
            }
            else
            {
                pb.Image = bmp;
            }
            pb.Refresh();
        }
    }
    class KochN : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public KochN()
        {
            L = Math.PI / 3f;
            P = 2f * Math.PI / 3f;            
        }
        void drawRek(int dive)
        {
            if (dive == depth)
            {
                tocL();
                krok(bmp);

                tocP();
                krok(bmp);

                tocL();
                krok(bmp);
            }
            else
            {
                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
                tocP();
                krok(bmp);

                drawRek(dive + 1);
                tocL();
                krok(bmp);

                drawRek(dive + 1);
            }

        }
        public void save(int w, int h, int hloubka, int n)
        {
            PictureBox pb = new PictureBox();
            bmp = new Bitmap(w, h);
            pb.Image = bmp;
            vykresli(pb, hloubka, n);
            string s = Application.StartupPath + "\\" + n.ToString() + "-" + hloubka.ToString() + ".png";
            bmp.Save(s, System.Drawing.Imaging.ImageFormat.Png);
        }

        public override void vykresli(PictureBox pb, int hloubka, int n)
        {
           
                depth = hloubka;

                if (pb.Image != null)
                {
                    width = pb.Image.Width;
                    height = pb.Image.Height;
                }
                else
                {
                    width = pb.Width;
                    height = pb.Height;
                }

                double r;
                bmp = new Bitmap(width, height);
                    
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    gfx.FillRectangle(brush, 0, 0, width, height);
                }

                double hk, wk;
                if (n % 2 == 0)
                {
                    hk = 2;
                    wk = 2f * Math.Cos(Math.PI / n);
                }
                else
                {
                    hk = 1+ Math.Cos(Math.PI / n);
                    wk = 2;
                }

                double vnitrniUhel = (n - 2) * Math.PI / n;
                double ostryVnitrniUhel = 2f * vnitrniUhel - Math.PI;
                P = 3f*Math.PI - ostryVnitrniUhel;
                P %= Math.PI * 2f;
                L = Math.PI - ostryVnitrniUhel;
                L /= 2f;



                r = Math.Min(1.0 * (width - 20) / wk, 1.0 * (height - 20) / hk);

                double a = 2f * r * Math.Sin(Math.PI / n);
                double b = (a + a*2*Math.Sin((n - 2) * Math.PI / n - Math.PI / 2));
                double nafouknuti = (a+b)/a;


                /*int ax = (int)((width) / 2);
                int ay = (int)(10);*/

                double delkaIterace = Math.Sqrt(2f * a * a - 2 * a * a * Math.Cos(vnitrniUhel));
                delkakroku = (delkaIterace) / Math.Pow(nafouknuti,  (depth+1));

                poloha.X = (width) / 2;
                poloha.Y = 10;

                smer = 2f * Math.PI - ((Math.PI / 2f) - ostryVnitrniUhel / 2f);
                for (int i = 1; 2*i <= n; i++)
                {
                    krok(bmp);
                    drawRek(0);
                    tocP();
                }
                if(n%2 != 0)
                {
                    krok(bmp);
                    drawRek(1);
                    tocL();
                    krok(bmp);
                    drawRek(1);
                }                            
            pb.Refresh();
        }
    }

}
