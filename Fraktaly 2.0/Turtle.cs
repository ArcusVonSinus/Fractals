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
}
