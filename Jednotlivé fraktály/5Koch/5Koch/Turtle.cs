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
    class Turtle : Fractal
    {
        protected double P=Math.PI/6f;
        protected double L=Math.PI / 6f;
        protected double smer = 0;
        protected double delkakroku = 1;
        protected PointF poloha = new PointF(0, 0);
        protected PointF temp = new PointF(0, 0);
        protected void krok(Bitmap bmp)
        {
            temp.X = (float)(poloha.X + delkakroku * Math.Cos(smer));
            temp.Y = (float)(poloha.Y - delkakroku * Math.Sin(smer));
            DrawLine(bmp, poloha, temp);
            poloha.X = temp.X;
            poloha.Y = temp.Y;
        }
        protected void tocL()
        {
            smer += L;
            smer %= 2 * Math.PI;
        }
        protected void tocP()
        {
            smer += 2 * Math.PI;
            smer -= P;
            smer %= 2 * Math.PI;
        }

    }
    public class Fractal
    {
        public virtual void vykresli(PictureBox pb, int n) { }
        public virtual void vykresli(PictureBox pb, int n, string pat) { }
        public virtual void vykresli(PictureBox pb, int n, int m) { }
        public virtual void vykresli(PictureBox pb, double k, int tarDepth) { }
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
                if (x - 1 >= 0 && y - 1 >= 0 && x + 1 < bmp.Width && y + 1 < bmp.Height)
                    bmp.SetPixel((int)(x + 0.5), (int)(y + 0.5), Color.Black);
                x += addx;
                y += addy;
            }
        }
        protected void DrawLine(Bitmap bmp, Point a, Point b)
        {
            DrawLine(bmp, a.X, a.Y, b.X, b.Y);
        }
        protected void DrawLine(Bitmap bmp, PointF a, PointF b)
        {
            DrawLine(bmp, a.X, a.Y, b.X, b.Y);
        }

    }
}
