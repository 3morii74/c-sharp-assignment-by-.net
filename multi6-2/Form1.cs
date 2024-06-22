using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi6_2
{
    public class Chicken
    {
        public int X, Y;
        public Bitmap img;
    }

    public class Eggs
    {
        public int X, Y;
        public Bitmap img;
    }

    public class Basket
    {
        public int X, Y;
        public Bitmap img;
        public List<Eggs> eggs = new List<Eggs>();
    }

    public partial class Form1 : Form
    {
        private Bitmap off;
        private Chicken chicken = new Chicken();
        private List<Eggs> egg = new List<Eggs>();
        private List<Basket> basket = new List<Basket>();
        private bool isDrag = false;
        private int xOld;
        private int yOld;
        private int ctsh;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    chicken.X -= 10;
                    DrawDubb(this.CreateGraphics());

                    break;

                case Keys.Right:
                    chicken.X += 10;
                    DrawDubb(this.CreateGraphics());

                    break;

                case Keys.Enter:
                    int flag = 0;
                    Eggs pnn = new Eggs();
                    pnn.X = chicken.X + chicken.img.Width * 1 / 2;
                    pnn.img = new Bitmap("egg.bmp");
                    pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                    for (int i = 0; i < basket.Count; i++)
                    {
                        if (chicken.X >= basket[i].X - 40 && chicken.X <= basket[i].X + basket[i].img.Width - 50)
                        {
                            pnn.Y = basket[i].Y + pnn.img.Height + 5;
                            basket[i].eggs.Add(pnn);
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        pnn.Y = this.ClientSize.Height - pnn.img.Height;
                        egg.Add(pnn);
                    }
                    DrawDubb(this.CreateGraphics());

                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < basket.Count; i++)
                {
                    if (e.X >= basket[i].X && e.X <= basket[i].X + basket[i].img.Width && e.Y >= basket[i].Y + 50 && e.Y <= basket[i].Y + basket[i].img.Height - 15)
                    {
                        xOld = e.X;
                        yOld = e.Y;
                        ctsh = i;
                        isDrag = true;
                    }
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;
                int xx = basket[ctsh].X;
                basket[ctsh].X += dx;
                basket[ctsh].Y += dy;

                for (int i = 0; i < basket[ctsh].eggs.Count; i++)
                {
                    basket[ctsh].eggs[i].X += (int)(dx * 0.5);
                    basket[ctsh].eggs[i].Y = basket[ctsh].Y + basket[ctsh].eggs[i].img.Height + 5;
                    // basket[ctsh].eggs[i].X += dx;
                    //  basket[ctsh].eggs[i].Y += dy;
                }
            }

            xOld = e.X;
            yOld = e.Y;

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateChicken();
            CreateBasket();
        }

        private void CreateChicken()
        {
            Graphics g = this.CreateGraphics();
            chicken.X = (this.ClientSize.Width) * 1 / 2;
            chicken.Y = (this.ClientSize.Height) * 1 / 8;
            chicken.img = new Bitmap("chicken.bmp");
            chicken.img.MakeTransparent(chicken.img.GetPixel(0, 0));
            g.DrawImage(chicken.img, chicken.X, chicken.Y, chicken.img.Width, chicken.img.Height);
        }

        private void CreateBasket()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 3; i++)
            {
                Basket pnn = new Basket();
                pnn.X = 350 * (i + 1);
                pnn.Y = (this.ClientSize.Height) * 3 / 4;
                pnn.img = new Bitmap("basket.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                basket.Add(pnn);
                g.DrawImage(pnn.img, pnn.X, pnn.Y, pnn.img.Width, pnn.img.Height);
                basket.Add(pnn);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            g.DrawImage(chicken.img, chicken.X, chicken.Y, chicken.img.Width, chicken.img.Height);
            for (int i = 0; i < egg.Count; i++)
            {
                g.DrawImage(egg[i].img, egg[i].X, egg[i].Y, egg[i].img.Width, egg[i].img.Height);
            }
            for (int i = 0; i < basket.Count; i++)
            {
                g.DrawImage(basket[i].img, basket[i].X, basket[i].Y, basket[i].img.Width, basket[i].img.Height);
                for (int j = 0; j < basket[i].eggs.Count; j++)
                {
                    g.DrawImage(basket[i].eggs[j].img, basket[i].eggs[j].X, basket[i].eggs[j].Y, basket[i].eggs[j].img.Width, basket[i].eggs[j].img.Height);
                }
            }
        }

        private void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}