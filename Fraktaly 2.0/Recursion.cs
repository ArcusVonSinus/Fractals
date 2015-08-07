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
    class Recursion : Turtle
    {
        Bitmap bmp;
        int hloubka = 0;
        int width = 0, height = 0;
        public Recursion()
        {
            L = Math.PI / 3f;
            P = Math.PI / 3f;
        }
        void drawRek(int dept, bool pravotoc)
        {
            if (dept >= hloubka)
            {
                if (pravotoc)
                {
                    krok(bmp);
                    tocP();
                    krok(bmp);
                    tocP();
                    krok(bmp);
                }
                else
                {
                    krok(bmp);
                    tocL();
                    krok(bmp);
                    tocL();
                    krok(bmp);
                }
            }
            else
            {
                if (pravotoc)
                {
                    //if(prvniVen)
                    {
                        drawRek(dept + 1, false);
                        tocP();
                        drawRek(dept + 1, true);
                        tocP();
                        drawRek(dept + 1, false);
                    }

                }
                else
                {
                    {
                        drawRek(dept + 1, true);
                        tocL();
                        drawRek(dept + 1, false);
                        tocL();
                        drawRek(dept + 1, true);
                    }
                }

            }
        }
        public override void vykresli(PictureBox pb, int hloubka, string pattern)
        {
            if (this.hloubka != hloubka || width != pb.Width || height != pb.Height)
            {
                this.hloubka = hloubka;
                width = pb.Width;
                height = pb.Height;

                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }


                smer = ((1 + hloubka) % 2) * Math.PI / 3f;

                double sirka;
                double coef = Math.Pow(2.0, hloubka + 1);
                sirka = Math.Min(width - 40, (height - 40) * 2f / Math.Sqrt(3));

                delkakroku = sirka / coef;
                poloha.X = width - (float)sirka;
                poloha.X /= 2f;

                poloha.Y = height;
                poloha.Y -= (float)((height - sirka * Math.Sqrt(3) / 2f) / 2f);


                drawRek(0, true);
            }
        }
    }
}
