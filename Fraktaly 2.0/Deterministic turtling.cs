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
    class Koch : Turtle
    {	
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public Koch(PictureBox pb)
        {
            L = Math.PI / 3f;
            P = 2f * Math.PI / 3f;
			this.pb = pb;
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
        public override void vykresli(int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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
            slowDraw = false;
        }
    }
    class Hilbert : Turtle
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public Hilbert(PictureBox pb)
        {
            L = Math.PI / 3f;
            P = 2f * Math.PI / 3f;
			this.pb = pb;
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
        public override void vykresli(int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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
            slowDraw = false;
        }
    }
	class Cross : Turtle
	{
		Bitmap bmp;
		int depth = 0;
		int width = 0, height = 0;
		int hloubka;
		public Cross(PictureBox pb)
		{
			P = 3f * Math.PI / 2f;
			L = P;
			this.pb = pb;
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
		public override void vykresli(int hloubka)
		{
            this.hloubka = hloubka;
            vykreslovac = new Thread(vykresliThread);
            vykreslovac.Start();
		}
		public void vykresliThread()
		{
			if (depth != hloubka || width != pb.Width || height != pb.Height || slowDraw)
			{
				depth = hloubka;
				width = pb.Width;
				height = pb.Height;

				bmp = new Bitmap(pb.Width, pb.Height);
                //pb.Image = bmp;
                setPicture(bmp);
                paintBackground();
				
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
                //pb.Image = bmp;
                setPicture(bmp);
            }
            //pb.Refresh();
            refreshPictureBox();
            slowDraw = false;
        }
	}
	class CrossRound : Turtle
	{
		Bitmap bmp;
		int depth = 0;
		int width = 0, height = 0;
		protected PointF temp2 = new PointF(0, 0);
		void SetPixel2(int x, int y)
		{
			int w = bmp.Width;
			int h = bmp.Height;
			if (0 <= x)
				if (x + 1 < w)
					if (y >= 0)
						if (y + 1 <= h)
						{
							bmp.SetPixel(x, y, Barvy.popredi);
							bmp.SetPixel(x + 1, y, Barvy.popredi);
							bmp.SetPixel(x, y + 1, Barvy.popredi);
							bmp.SetPixel(x + 1, y + 1, Barvy.popredi);
						}
		}
		void DrawQuarterCircle(int x0, int y0, int x1, int y1)//Ctvrtkruznice o stredu (x0,y0) zacinajici v (x1,y1) jdouci v kladnem smeru
		{
			
			double phi = Math.PI / 2f;
			int radius = (int)(Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0)));
			int delka = (int)(phi * radius);
			for(int i = 0; i<delka;i++)
			{
				double temp = phi * i / ((double)(delka));
				int x = (int)(x0 + (x1 - x0) * Math.Cos(temp) - (y1 - y0) * Math.Sin(temp));
				int y = (int)(y0 + (x1 - x0) * Math.Sin(temp) + (y1 - y0) * Math.Cos(temp));
				SetPixel2(x, y);
			}
            if (slowDraw)
                refreshPictureBox();
		}
		void krokRounded(Bitmap bmp,bool doleva)
		{
			temp.X = (float)(poloha.X + 0.5f*delkakroku * Math.Cos(smer));
			temp.Y = (float)(poloha.Y - 0.5f*delkakroku * Math.Sin(smer));
			if (doleva)
				tocL();
			else
				tocP();
			temp2.X = (float)(temp.X + 0.5f * delkakroku * Math.Cos(smer));
			temp2.Y = (float)(temp.Y - 0.5f * delkakroku * Math.Sin(smer));
			int x0 = (int)(poloha.X + (temp2.X - temp.X));
			int y0 = (int)(poloha.Y + (temp2.Y - temp.Y));
			int x1, y1;
			if(doleva)
			{
				x1 = (int) poloha.X;
				y1 = (int) poloha.Y;
			}
			else
			{
				x1 = (int) temp2.X;
				y1 = (int) temp2.Y;
			}
			DrawQuarterCircle(x0, y0, x1, y1);

			//DrawLine(bmp, poloha, temp);
			//DrawLine(bmp, temp, temp2);

			poloha.X = temp2.X;
			poloha.Y = temp2.Y;
		}
		public CrossRound(PictureBox pb)
		{
			P = 3f * Math.PI / 2f;
			L = P;
			this.pb = pb;
		}
		void drawRek(int dept, int toc)
		{
			if (dept >= depth)
			{
				if (toc == 1)
				{
					krokRounded(bmp,true);
					//tocL();
				}
				else
				{
					krokRounded(bmp, false);
					//tocP();
				}
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
		public override void vykresli(int hloubka)
		{
			if (depth != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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

				poloha.X = 20f + (float)((Math.Pow(2f, hloubka)-0.5) * delkakroku);
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
            slowDraw = false;
        }
	}
	class SierCurve : Turtle
    {
        Bitmap bmp;
        bool sikmo = true;
        int kamCur = 0;
        int width = 0, height = 0;
        public SierCurve(PictureBox pb)
        {
            L = Math.PI / 4f;
            P = Math.PI / 2f;
			this.pb = pb;
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
        public override void vykresli(int hloubka)
        {
            if (kamCur != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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
            slowDraw = false;
        }
    }
    class ZMatrix : Fractal
    {
        Bitmap bmp;
        int depth = 0;
        int width = 0, height = 0;
        public ZMatrix(PictureBox pb)
        {
			this.pb = pb;
        }
        public override void vykresli(int hloubka)
        {
            if (depth != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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
            slowDraw = false;
        }
    }
    class Hexacurve : Turtle
    {
        Bitmap bmp;        
        int hloubka = 0;
        int width = 0, height = 0;
        public Hexacurve(PictureBox pb)
        {
            L = Math.PI / 3f;
            P = Math.PI / 3f;
			this.pb = pb;
        }
        void drawRek(int dept, bool ven)
        {
            if (dept >= hloubka)
            {                
                if (ven)
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
                if (ven)
                {
                    //if(prvniVen)
                    {
                        drawRek(dept + 1, true);
                        tocP();
                        drawRek(dept + 1, false);
                        tocP();
                        drawRek(dept + 1, true);
                    }
                    
                }
                else
                {
                    {
                        drawRek(dept + 1, false);
                        tocL();
                        drawRek(dept + 1, true);
                        tocL();
                        drawRek(dept + 1, false);
                    }
                }

            }
        }
        public override void vykresli(int hloubka)
        {
            if (this.hloubka != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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

                
                smer = (hloubka+1) * Math.PI/3f;
                smer %= 2f * Math.PI;

                double sirka;
                double coef = Math.Pow(2.0, hloubka);                
                if ((width-40)/3.5 < (height-40)/1.5)
                    sirka = (width - 40)/3.5;
                else
                    sirka = (height - 40)/1.5;
                //sirka *= 2;
                delkakroku = sirka / coef;
                poloha.X = width-(float)sirka*3.5f;
                poloha.X /= 2f;
                poloha.X += (1.5f / 2f) * (float)sirka;
                poloha.Y = height;
                poloha.Y -= (float)((height - sirka * 2f) / 2f);
                poloha.Y -= (float)(0.5 * sirka);
                drawRek(0, true);
            }
            slowDraw = false;
        }
    }
    class Hexacurve2 : Turtle
    {
        Bitmap bmp;
        int hloubka = 0;
        int width = 0, height = 0;
        public Hexacurve2(PictureBox pb)
        {
            L = Math.PI / 3f;
            P = Math.PI / 3f;
			this.pb = pb;
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
        public override void vykresli(int hloubka)
        {
            if (this.hloubka != hloubka || width != pb.Width || height != pb.Height || slowDraw)
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


                smer = ((1+hloubka) % 2) * Math.PI / 3f;                

                double sirka;
                double coef = Math.Pow(2.0, hloubka+1);
                sirka = Math.Min(width - 40, (height - 40) *2f/ Math.Sqrt(3));
                
                delkakroku = sirka / coef;
                poloha.X = width - (float)sirka;
                poloha.X /= 2f;
                
                poloha.Y = height;
                poloha.Y -= (float)((height - sirka * Math.Sqrt(3)/2f) / 2f);
                

                drawRek(0, true);
            }
                slowDraw = false;
        }
    }
}
