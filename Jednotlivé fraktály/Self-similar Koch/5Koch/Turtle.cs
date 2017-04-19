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
    class SelfSim : Fractal
    {
        Bitmap bmp;
        public struct similarity
        {
            public double angle;
            public double scale;
            public PointF shift;
            public similarity(double u, double z, float x, float y)
            {
                angle = u;
                scale = z;
                shift = new PointF(x, y);
            }
            public similarity(double u, double z, double x, double y)
            {
                angle = u;
                scale = z;
                shift = new PointF((float)x, (float)y);
            }
        };
        public List<similarity> fce = new List<similarity>();
        public SelfSim()
        {
            fce.Add(new similarity(0, 3, 0, 0));
            fce.Add(new similarity(Math.PI / 3f, 3, 1, 0));
            fce.Add(new similarity(-Math.PI / 3f, 3, 1.5f, Math.Sqrt(3.0) / 2f));
            fce.Add(new similarity(0, 3, 2, 0));                       
        }
        public override void vykresli(PictureBox pb)
        {
            double a;
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            this.bmp = bmp;
            pb.Image = bmp;
            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
            }
            /*PointF now = new PointF(0, 0);
            Random rnd = new Random();
            for (int i = 1; i < 100000; i++)
            {

                bmp.SetPixel((int)(10 + now.X * ((bmp.Width - 20) / 3)), (int)(bmp.Height - 10 - now.Y * ((bmp.Height - 20) / 3)), Color.Black);                
                int r = rnd.Next(fce.Count);
                now = transform(now, fce[r]);
            }*/

            int width = bmp.Width; int height = bmp.Height;

            Random rnd = new Random();
            List<similarity> sims = new List<similarity>();
            double scale = 1f + Math.Sqrt(2);
            sims.Add(new similarity(0, scale, -1, 0));
            sims.Add(new similarity(0, scale, +1, 0));
            sims.Add(new similarity(0, scale, 0, 1));
            sims.Add(new similarity(0, scale, 0, -1));
            //sims.Add(new similarity(Math.PI / 3, 3, 1, 0));
            //sims.Add(new similarity(-Math.PI / 3, 3, 1.5, Math.Sqrt(3.0) / 2));
            //sims.Add(new similarity(0, 3, 2, 0));
            PointF now = new PointF(0, 0);

            for (int i = 1; i < 1000; i++)
            {
                int r = rnd.Next(sims.Count);
                now = transform(now, sims[r]);
                SetPixel(now.X, now.Y);
            }





            pb.Refresh();
        }        
        public void SetPixel(double x, double y)
        {
                bmp.SetPixel((int)(100*x+bmp.Width/2f),(int)(bmp.Height/2f - y*100-1), Color.Black);
        }
        public PointF transform(PointF a, similarity t)
        {
            PointF b = new PointF((float)(a.X * Math.Cos(t.angle) - a.Y * Math.Sin(t.angle)), (float)(a.X * Math.Sin(t.angle) + a.Y * Math.Cos(t.angle)));
            b.X /= (float)(t.scale);
            b.Y /= (float)(t.scale);
            b.X += t.shift.X;
            b.Y += t.shift.Y;
            return b;
        }

    }     
        /*
    public vykresli()
    {
        PointF now = new PointF(0, 0);
        Random rnd = new Random();
        for(int i = 1;i<100000;i++)
        {
            int r = rnd.Next(4);
            if (r == 0)
                now = transform(now, new similarity(0, 3, 0, 0));
            else if (r == 1)
                now = transform(now, new similarity(Math.PI / 3f, 3, 1, 0));
            else if (r == 2)
                now = transform(now, new similarity(-Math.PI / 3f, 3, 1.5f, Math.Sqrt(3.0) / 2f));
            else
                now = transform(now, new similarity(0, 3, 2, 0));
            bmp.SetPixel((int)(10 + now.X * ((bmp.Width - 20) / 3)), (int)(bmp.Height - 10 - now.Y * ((bmp.Height - 20) / 3)), Color.Black);
        }
        
    }
    */
    


    public class Fractal
    {
        public virtual void vykresli(PictureBox pb, int n) { }
        public virtual void vykresli(PictureBox pb) { }
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
