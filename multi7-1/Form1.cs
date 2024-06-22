using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi7_1
{
    public class CActor
    {
        public int X, Y;
        public Bitmap img;
        public int Speed = 3;
        public int shake = 0;
    }

    public class Laser
    {
        public int X, Y, W, H;
        public Color cl;
    }

    public partial class Form1 : Form
    {
        private Bitmap off;
        private Timer tt = new Timer();
        private List<CActor> stars = new List<CActor>();
        private CActor rocket = new CActor();
        private int ctTick = 0;
        private int Space = 100;
        private Random rr = new Random();
        private int numOfStars;
        private int accel;
        private bool up;
        private int ct = 0;
        private List<Laser> laser = new List<Laser>();

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            tt.Tick += Tt_Tick;
            tt.Interval = 1;
            tt.Start();
        }

        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    rocket.X -= rocket.Speed;
                    rocket.Speed += 1;
                    accel = 1;
                    up = false;
                    break;

                case Keys.Right:
                    rocket.X += rocket.Speed;
                    rocket.Speed += 1;
                    accel = 2;
                    up = false;
                    break;

                case Keys.Space:
                    createLaser();
                    for (int i = 0; i < stars.Count; i++)
                    {
                        if (laser[0].X >= stars[i].X && laser[0].X <= stars[i].X + stars[i].img.Width)
                        {
                            stars.RemoveAt(i);
                        }
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            up = true;
        }

        private void CreateRocket()
        {
            rocket.img = new Bitmap("1.bmp");
            rocket.img.MakeTransparent(rocket.img.GetPixel(0, 0));
            rocket.X = this.ClientSize.Width * 1 / 2;
            rocket.Y = this.ClientSize.Height - rocket.img.Height;
        }

        private void CreateStars()
        {
            Random r = new Random();
            int pos = r.Next(0, this.ClientSize.Width);
            CActor pnn = new CActor();
            pnn.img = new Bitmap("2.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.X = pos;
            pnn.Y = 0;
            stars.Add(pnn);
        }

        private void createLaser()
        {
            Laser pnn = new Laser();
            pnn.X = rocket.X + rocket.img.Width * 1 / 2;
            pnn.Y = 0;
            pnn.H = this.ClientSize.Height - rocket.img.Height;
            pnn.W = 3;
            pnn.cl = Color.Yellow;
            laser.Add(pnn);
        }

        private void AnimateAll()
        {
            for (int i = 0; i < stars.Count; i++)
            {
                CActor ptrav = stars[i];
                if (ctTick % 20 == 0)
                {
                    if (ptrav.shake == 1)
                    {
                        ptrav.shake = 0;
                    }
                    else
                    {
                        ptrav.shake = 1;
                    }
                }
                if (ptrav.shake == 1)
                {
                    ptrav.X--;
                }
                else
                {
                    ptrav.X++;
                }

                ptrav.Y += 1;
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (ctTick % Space == 0)
            {
                if (stars.Count < numOfStars)
                {
                    CreateStars();
                    Random RR = new Random();
                    Space = RR.Next(220, 340);
                }
            }
            if (ctTick % 10 == 0 && laser.Count > 0)
            {
                laser.Clear();
            }
            if (up)
            {
                if (rocket.Speed > 0)
                {
                    if (accel == 1)
                    {
                        rocket.Speed -= 2;
                        rocket.X -= rocket.Speed;
                    }
                    if (accel == 2)
                    {
                        rocket.Speed -= 2;
                        rocket.X += rocket.Speed;
                    }
                }
            }

            AnimateAll();

            ctTick++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numOfStars = rr.Next(20, 30);
            off = new Bitmap(this.ClientSize.Width, ClientSize.Height);
            CreateRocket();
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            // loop actors
            g.DrawImage(rocket.img, rocket.X, rocket.Y, rocket.img.Width, rocket.img.Height);
            for (int i = 0; i < stars.Count; i++)
            {
                CActor ptrav = stars[i];
                g.DrawImage(ptrav.img, ptrav.X, ptrav.Y, ptrav.img.Width, ptrav.img.Height);
            }
            for (int i = 0; i < laser.Count; i++)
            {
                Laser ptrav = laser[i];
                Pen p = new Pen(ptrav.cl);
                SolidBrush b = new SolidBrush(ptrav.cl);
                g.DrawRectangle(p, ptrav.X, ptrav.Y, ptrav.W, ptrav.H);
                g.FillRectangle(b, ptrav.X, ptrav.Y, ptrav.W, ptrav.H);
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