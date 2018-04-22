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
    public class kruznice  : IComparable<kruznice>
    {
        
        public int CompareTo(kruznice other)
        {
            if (other == null)
            {
                return 1;
            }

            if (other.r == this.r)
            {
                return 0;
            }
            else if (this.r < other.r)
                return 1;
            else
                return -1;           
        }
        
        public float x, y, r;
        public kruznice(float x, float y, float r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public kruznice(double x, double y, double r)
        {
            this.x = (float)x;
            this.y = (float)y;
            this.r = (float)r;
        }
    }
    public class ByRadius : IComparer<kruznice>
    {
        public int Compare(kruznice x, kruznice y)
        {
            if (x.r > y.r)
                return 1;
            if (x.r < y.r)
                return -1;
            else return 0;
        }
    }
    class Apoll : Fractal
    {
        void SetPixel2(int x, int y)
        {
            /*vypada lepe, pokud se misto jednoho pixelu vykresli ctverecek 2x2 pixely,
            plus posun souradnic kvuli menu*/
            bmp.SetPixel(x, y, Barvy.popredi);
            bmp.SetPixel(x + 1, y, Barvy.popredi);
            bmp.SetPixel(x, y + 1, Barvy.popredi);
            bmp.SetPixel(x + 1, y + 1, Barvy.popredi);

        }
        int pocet = 0;//kolik kruznic je nakresleno;
        int target = 0;   //kolik kruznic chci nakreslit;
        int width = 0, height = 0;
        double rad = 1;
        Bitmap bmp;
        Queue<kruznice> q1, q2, q3;
        public Apoll(PictureBox pb)
        {
            q1 = new Queue<kruznice>();
            q2 = new Queue<kruznice>();
            q3 = new Queue<kruznice>();
			this.pb = pb;
        }
        void DrawCircle(kruznice k)
        {
            /*Tato procedura neni moje,
            zkopirovana z http://en.wikipedia.org/wiki/Midpoint_circle_algorithm */
            int radius = (int)k.r;
            int x0 = (int)k.x;
            int y0 = (int)k.y;
            int f = 1 - radius;
            int ddF_x = 1;
            int ddF_y = -2 * radius;
            int x = 0;
            int y = radius;

            SetPixel2(x0, y0 + radius);
            SetPixel2(x0, y0 - radius);
            SetPixel2(x0 + radius, y0);
            SetPixel2(x0 - radius, y0);

            while (x < y)
            {

                if (f >= 0)
                {
                    y--;
                    ddF_y += 2;
                    f += ddF_y;
                }
                x++;
                ddF_x += 2;
                f += ddF_x;
                SetPixel2(x0 + x, y0 + y);
                SetPixel2(x0 - x, y0 + y);
                SetPixel2(x0 + x, y0 - y);
                SetPixel2(x0 - x, y0 - y);
                SetPixel2(x0 + y, y0 + x);
                SetPixel2(x0 - y, y0 + x);
                SetPixel2(x0 + y, y0 - x);
                SetPixel2(x0 - y, y0 - x);
            }
			if (slowDraw)
			{
				//pb.Image = bmp;
				pb.Refresh();
			}
        }
        void ApIn(double x1, double y1, double a, double x2, double y2, double b, double x3, double y3, double c)
        {
            //pripad tri vnejsich dotyku
            double k1 = 1.0 / a;
            double k2 = 1.0 / b;
            double k3 = 1.0 / c;
            double k4 = k1 + k2 + k3 + 2 * Math.Sqrt(1.0 * (k1 * k2 + k2 * k3 + k3 * k1));
            double r = 1.0 / k4;
            double tempa;
            double tempb;
            tempa = k1 * k2 * x1 * x2 + k2 * k3 * x2 * x3 + k1 * k3 * x1 * x3 - (k1 * k2 * y1 * y2 + k2 * k3 * y2 * y3 + k1 * k3 * y1 * y3);
            tempb = k1 * k2 * x1 * y2 + k1 * k2 * x2 * y1 + k1 * k3 * x1 * y3 + k1 * k3 * x3 * y1 + k3 * k2 * x3 * y2 + k3 * k2 * x2 * y3;
            double tempabs;
            tempabs = Math.Sqrt(tempa * tempa + tempb * tempb);
            double x = k1 * x1 + k2 * x2 + k3 * x3 + 2 * (Math.Sqrt((tempabs + tempa) / 2.0));
            x /= k4;
            double y = k1 * y1 + k2 * y2 + k3 * y3 + 2 * (Math.Sqrt((tempabs - tempa) / 2.0));
            y /= k4;

            DrawCircle(new kruznice(x, y, r + 0.5));
            DrawCircle(new kruznice(x, height - y, r + 0.5));
			/*
			if (slowDraw)
				pb.Refresh();
				*/
			q1.Enqueue(new kruznice(x1, y1, a));
            q1.Enqueue(new kruznice(x1, y1, a));
            q1.Enqueue(new kruznice(x2, y2, b));

            q2.Enqueue(new kruznice(x2, y2, b));
            q2.Enqueue(new kruznice(x3, y3, c));
            q2.Enqueue(new kruznice(x3, y3, c));

            q3.Enqueue(new kruznice(x, y, r));
            q3.Enqueue(new kruznice(x, y, r));
            q3.Enqueue(new kruznice(x, y, r));

        }
        void ApOut(double x1, double y1, double a, double x2, double y2, double b, double x3, double y3, double c)
        {
            //pripad dvou vnejsich a jednoho vnitrniho dotyku
            double k1 = 1.0 / a;
            double k2 = 1.0 / b;
            double k3 = 1.0 / c;
            double k4 = -k1 + k2 + k3 + 2 * Math.Sqrt(1.0 * (-k1 * k2 + k2 * k3 - k3 * k1));
            double r = 1.0 / k4;

            double tempa;
            double tempb;
            k1 = -k1;
            tempa = k1 * k2 * x1 * x2 + k2 * k3 * x2 * x3 + k1 * k3 * x1 * x3 - (k1 * k2 * y1 * y2 + k2 * k3 * y2 * y3 + k1 * k3 * y1 * y3);
            tempb = k1 * k2 * x1 * y2 + k1 * k2 * x2 * y1 + k1 * k3 * x1 * y3 + k1 * k3 * x3 * y1 + k3 * k2 * x3 * y2 + k3 * k2 * x2 * y3;
            double tempabs;
            tempabs = Math.Sqrt(tempa * tempa + tempb * tempb);
            double x = k1 * x1 + k2 * x2 + k3 * x3 + 2 * (Math.Sqrt((tempabs + tempa) / 2.0));
            x /= k4;
            double y = k1 * y1 + k2 * y2 + k3 * y3 + 2 * (Math.Sqrt((tempabs - tempa) / 2.0));
            y /= k4;

            DrawCircle(new kruznice(x, y, r + 0.5));
            DrawCircle(new kruznice(x, height - y, r + 0.5));
			/*
			if (slowDraw)
				pb.Refresh();
				*/
            q1.Enqueue(new kruznice(x1, y1, a));
            q1.Enqueue(new kruznice(x1, y1, a));
            q1.Enqueue(new kruznice(x2, y2, b));
               
            q2.Enqueue(new kruznice(x2, y2, b));
            q2.Enqueue(new kruznice(x3, y3, c));
            q2.Enqueue(new kruznice(x3, y3, c));
               
            q3.Enqueue(new kruznice(x, y, r));
            q3.Enqueue(new kruznice(x, y, r));
            q3.Enqueue(new kruznice(x, y, r));
        }
        public override void vykresli(int kruznic)
        {
            if (target == 0 || height != pb.Height || width != pb.Width || slowDraw)
            {
                width = pb.Width;
                height = pb.Height;
                bmp = new Bitmap(pb.Width, pb.Height);
				using (Graphics gfx = Graphics.FromImage(bmp))
                using (SolidBrush brush = new SolidBrush(Barvy.pozadi))
                {
                    gfx.FillRectangle(brush, 0, 0, pb.Width, pb.Height);
                }
				pb.Image = bmp;
				if (width < height)
                {
                    rad = width - 30;
                }
                else
                {
                    rad = height - 30;
                }
                rad /= 4.0;

                pocet = 0;                
                q1 = new Queue<kruznice>();
                q2 = new Queue<kruznice>();
                q3 = new Queue<kruznice>();
                q1.Enqueue(new kruznice(width / 2f, height / 2f, 2f * rad));
                q2.Enqueue(new kruznice(rad + width / 2f, height / 2f, rad));
                q3.Enqueue(new kruznice(-rad + width / 2f, height / 2f, rad));
               
                DrawCircle(q1.Peek());
                DrawCircle(q2.Peek());
                DrawCircle(q3.Peek());
                
                pocet = 3;
            }
            if (pocet != kruznic)
            {
                while (pocet < kruznic)
                {
                    
                    if (q1.Peek().r >= 2 * rad - 1)
                    {
                        ApOut(q1.Peek().x, q1.Peek().y, q1.Peek().r, q2.Peek().x, q2.Peek().y, q2.Peek().r, q3.Peek().x, q3.Peek().y, q3.Peek().r);
                    }
                    else
                    {
                        ApIn(q1.Peek().x, q1.Peek().y, q1.Peek().r, q2.Peek().x, q2.Peek().y, q2.Peek().r, q3.Peek().x, q3.Peek().y, q3.Peek().r);
                    }
                    pocet += 2;
                    q1.Dequeue();
                    q2.Dequeue();
                    q3.Dequeue();
                    /*q1.RemoveAt(0);
                    q2.RemoveAt(0);
                    q3.RemoveAt(0);*/
                    //q1.OrderBy(new ByRadius);
                }
                
                
                
            }
            
            pb.Refresh();
            slowDraw = false;
        }
    }
}
