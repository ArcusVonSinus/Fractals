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
    class Crooked : Fractal
    {
        Bitmap bmp;
        Graphics gfx;
        Pen p;
        public Crooked()
        {
            
        }
        triangle firstTriangle(int width, int height)
        {
            int a; //pomocna promenna, odpovida velikosti fraktalu;
            PointF[] vrcholy = new PointF[3];
            if (height > width)
                a = (int)((width - 20) / 2);
            else
                a = (int)((height - 20) / 2);
            for (int i = 0; i < 3; i++)
            {
                vrcholy[i].Y = (float)(((height / 2.0) + a * Math.Cos(Math.PI - (i * 2 * Math.PI) / (1.0 * 3))));
                vrcholy[i].X = (float)((width / 2.0) - a * Math.Sin(Math.PI - (i * 2 * Math.PI) / (1.0 * 3)));
            }
            return new triangle(vrcholy,0);
        }
        void drawTriangle(triangle T)
        {
            drawTriangle(T.a, T.b, T.c);
        }
        void drawTriangle(PointF a, PointF b, PointF c)
        {
            PointF[] pnt = new PointF[3];

            pnt[0] = a;
            pnt[1] = b;
            pnt[2] = c;
            gfx.DrawPolygon(p, pnt);
        }
        class triangle
        {
            public triangle(PointF a, PointF b, PointF c, int depth)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                this.depth = depth;
            }
            public triangle(PointF[] T,int depth)
            {
                a = T[0];
                b = T[1];
                c = T[2];
                this.depth = depth;
            }
            public PointF a, b, c;
            public int depth;
        };
        PointF midpoint(PointF a, PointF b, double k)
        {
            double l = 1-k;
            return new PointF((float)(k*a.X + l*b.X), (float)(k*a.Y + l*b.Y));
        }
        public override void vykresli(PictureBox pb, double k, int tarDepth)
        {                       
            bmp = new Bitmap(pb.Width, pb.Height);
            pb.Image = bmp;
            gfx = Graphics.FromImage(bmp);
            using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
            {
                gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
            }
            p = new Pen(Barvy.popredi);
            //drawTriangle(new Point(0, 0), new Point(0, 100), new Point(100, 0));
            Queue<triangle> qu = new Queue<triangle>();
            triangle T = firstTriangle(pb.Width, pb.Height);
            qu.Enqueue(T);
            drawTriangle(T);
            
            while(true)
            {
                T = qu.Dequeue();
                if(T.depth>tarDepth)
                {
                    break;
                }
                triangle temp;
                temp = new triangle(T.a, midpoint(T.a, T.b, k), midpoint(T.c, T.a, k), T.depth + 1);
                drawTriangle(temp);
                qu.Enqueue(temp);
                //---------------------
                temp = new triangle(midpoint(T.a, T.b, k),T.b , midpoint(T.b, T.c, k), T.depth + 1);
                drawTriangle(temp);
                qu.Enqueue(temp);
                //---------------------
                temp = new triangle(T.c, midpoint(T.c, T.a, k), midpoint(T.b, T.c, k), T.depth + 1);
                drawTriangle(temp);
                qu.Enqueue(temp);
            }
           /* if (vrcholu != this.vrcholu || bodu != this.bodu || width!=pb.Width || height!= pb.Height)
            {
                this.bodu = bodu;
                this.vrcholu = vrcholu;
                width = pb.Width;
                height = pb.Height;

                InicSier();
                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;                
                using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }
                PointF bod = new PointF();
                bod.X = vrcholy[0].X;
                bod.Y = vrcholy[0].Y;
                Random rand = new Random();
                int ranint;
                for(int i = 0;i<bodu;i++)
                {
                    ranint = rand.Next(vrcholu);
                    bod.X = (float)(vrcholy[ranint].X + ((bod.X - vrcholy[ranint].X) / k));
                    bod.Y = (float)(vrcholy[ranint].Y + ((bod.Y - vrcholy[ranint].Y) / k));
                    bmp.SetPixel((int)(bod.X),(int)(bod.Y), Barvy.popredi);
                }
                
            }
            else
            {
                pb.Image = bmp;                
            }*/
            pb.Refresh();
        }
    }
}
