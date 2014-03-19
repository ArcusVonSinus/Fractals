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
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
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
    class Hilbert : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public Hilbert()
        {
            L = Math.PI / 3f;
            P = 2f * Math.PI / 3f;
        }
        float t1 = (float)(3f * Math.PI / 2f);
        float t3 = (float)(Math.PI / 2f);
        void step(float reldir)
        {
            smer += reldir;
            krok(bmp);
            smer -= reldir;
        }
        void step(double reldir)
        {
            step((float)reldir);
        }
        void drawRek(int typ, double orientace, int hloubka)
        {
            double _smerbckp = smer;
            smer = (2 * Math.PI + orientace) % (2 * Math.PI);

            if (hloubka == 0)
            {
                if (typ == 0)
                {
                    step(t3);
                    step(0);
                    step(t1);
                }
                else
                {
                    step(t1);
                    step(0);
                    step(t3);
                }
            }
            else if (typ == 0)
            {
                drawRek((typ + 1) % 2, t3 + smer, hloubka - 1);
                step((t3));
                drawRek(typ, smer, hloubka - 1);
                step(0);
                drawRek(typ, smer, hloubka - 1);
                step(t1);
                drawRek((typ + 1) % 2, t1 + smer, hloubka - 1);
            }
            else
            {
                drawRek((typ + 1) % 2, t1 + smer, hloubka - 1);
                step(t1);
                drawRek(typ, smer, hloubka - 1);
                step(0);
                drawRek(typ, smer, hloubka - 1);
                step(t3);
                drawRek((typ + 1) % 2, t3 + smer, hloubka - 1);
            }
            smer = _smerbckp;

        }
        public override void vykresli(PictureBox pb, int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height)
            {
                depth = hloubka;
                width = pb.Width;
                height = pb.Height;

                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }

                double sirka;
                double coef = Math.Pow(2f, hloubka + 1f);
                coef -= 1;
                if (width < height)
                    sirka = width - 40;
                else
                    sirka = height - 40;
                delkakroku = sirka / coef;
                poloha.X = 20;
                poloha.Y = height - 20;

                drawRek(0, 0f, hloubka);
            }
            else
            {
                pb.Image = bmp;
            }
            pb.Refresh();
        }
    }
    class Cross : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;

        public Cross()
        {
            P = 3f * Math.PI / 2f;
            L = P;
        }
        void drawRek(int dept, int toc)
        {
            if (dept >= depth)
            {
                krok(bmp);
                if (toc == 1)
                    tocL();
                else
                    tocP();
            }
            else
            {
                if (toc == 2)
                {
                    drawRek(dept + 1, 2);
                    drawRek(dept + 1, 1);
                    drawRek(dept + 1, 2);
                }
                else
                {
                    drawRek(dept + 1, 2);
                    drawRek(dept + 1, 1);
                    drawRek(dept + 1, 1);
                    drawRek(dept + 1, 1);
                    drawRek(dept + 1, 2);
                }
            }
        }
        public override void vykresli(PictureBox pb, int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height)
            {
                depth = hloubka;
                width = pb.Width;
                height = pb.Height;

                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }
                smer = Math.PI;
                double sirka;
                double coef = Math.Pow(2f, depth + 1);
                coef -= 1;
                if (width < height)
                    sirka = width - 40;
                else
                    sirka = height - 40;

                delkakroku = sirka / coef;

                poloha.X = 20f + (float)((Math.Pow(2f, hloubka)) * delkakroku);
                poloha.Y = 20;

                drawRek(0, 2);
                drawRek(0, 2);
                drawRek(0, 2);
                drawRek(0, 2);
            }
            else
            {
                pb.Image = bmp;
            }
            pb.Refresh();

        }
    }
    class SierCurve : Turtle
    {
        Bitmap bmp;
        bool sikmo = true;
        int kamCur = 0;
        int width = 0, height = 0;
        public SierCurve()
        {
            L = Math.PI / 4f;
            P = Math.PI / 2f;
        }
        void KrokCur()
        {
            if (sikmo)
            {
                delkakroku = delkakroku / Math.Sqrt(2);
            }
            krok(bmp);
            if (sikmo)
            {
                delkakroku = delkakroku * Math.Sqrt(2);
            }
        }
        void DrawCur(int dept, int toc)
        {
            if (dept >= kamCur)
            {
                KrokCur();
                if (toc == 1)
                {
                    tocL();
                    sikmo = !sikmo;
                    KrokCur();
                    tocL();
                    sikmo = !sikmo;
                }
                else
                    tocP();
            }
            else
            {
                if (toc == 2)
                {
                    DrawCur(dept + 1, 2);
                    DrawCur(dept + 1, 1);
                    DrawCur(dept + 1, 2);
                }
                else
                {
                    DrawCur(dept + 1, 2);
                    DrawCur(dept + 1, 1);
                    DrawCur(dept + 1, 1);
                    DrawCur(dept + 1, 1);
                    DrawCur(dept + 1, 2);
                }

            }
        }
        public override void vykresli(PictureBox pb, int hloubka)
        {
            if (kamCur != hloubka || width != pb.Width || height != pb.Height)
            {
                kamCur = hloubka;
                width = pb.Width;
                height = pb.Height;
                
                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }

                sikmo = true;
                smer = Math.PI / 4;
                double sirka;
                double coef = Math.Pow(2.0, kamCur + 1);
                coef -= 1;
                if (width < height)
                    sirka = width - 40;
                else
                    sirka = height - 40;
                delkakroku = sirka / coef;
                poloha.X = 20;
                poloha.Y = (float)(20 + delkakroku / 2f);
                DrawCur(0, 2);
                DrawCur(0, 2);
                DrawCur(0, 2);
                DrawCur(0, 2);
            }
        }
    }
    class ZMatrix : Fractal
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public ZMatrix()
        {

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
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }

                double sirka, KrokMatice;
                double coef = Math.Pow(2.0, hloubka + 1);
                coef -= 1;
                if (width < height)
                    sirka = width - 40;
                else
                    sirka = height - 40;
                KrokMatice = sirka / coef;
                PointF ak = new PointF(20, 20);
                PointF cil = new PointF(20, 20);
                for (long i = 1; i < Math.Pow(2.0, 2 * (hloubka + 1)); i++)
                {
                    float x = 0, y = 0;
                    int hod = 1;
                    long tempi = i;
                    for (int ii = 0; ii < 25; ii++)
                    {
                        if (ii % 2 == 0)
                        {
                            x += hod * (tempi % 2);
                        }
                        else
                        {
                            y += hod * (tempi % 2);
                            hod *= 2;
                        }
                        tempi /= 2;
                    }


                    cil.X = (float)(20 + x * KrokMatice);
                    cil.Y = (float)(20 + y * KrokMatice);
                    DrawLine(bmp, ak, cil);
                    ak = new PointF(cil.X, cil.Y);
                }
            }
            else
            {
                pb.Image = bmp;
            }
            pb.Refresh();
        }
    }


}
