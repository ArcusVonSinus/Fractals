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

    class Sier : Fractal
    {
        int vrcholu = 0, bodu = 0;
        int width=0, height=0;
        double k; //koeficient priblížení;
        Bitmap bmp;
        PointF[] vrcholy;
        public Sier(PictureBox pb)
        {
			this.pb = pb;
        }
        void InicSier() 
        {
            int a; //pomocna promenna, odpovida velikosti fraktalu;
            vrcholy = new PointF[vrcholu];
            if (height > width)
                a = (int)((width - 20) / 2);
            else
                a = (int)((height - 20) / 2);
            for (int i = 0; i < vrcholu; i++)
            {
                vrcholy[i].Y = (float)(((height / 2.0) + a * Math.Cos(Math.PI - (i * 2 * Math.PI) / (1.0 * vrcholu))));
                vrcholy[i].X = (float)((width / 2.0) - a * Math.Sin(Math.PI - (i * 2 * Math.PI) / (1.0 * vrcholu)));
            }
            if (vrcholu == 3)
                k = 2;
            else if (vrcholu == 4)
                k = 2.3;
            else
                k = 2 + Math.Sqrt(2 - 2 * Math.Cos(2 * (Math.PI * (1 - (2.0 / vrcholu))) - Math.PI));
        }
        public override void vykresli(int vrcholu, int bodu)
        {
            if (vrcholu != this.vrcholu || bodu != this.bodu || width!=pb.Width || height!= pb.Height)
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
            }
            pb.Refresh();
        }
    }
}
