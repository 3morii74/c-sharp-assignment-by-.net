using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi8_1
{
    public class Helo
    {
        public int X, Y;
        public Bitmap img;
        public List<Bird> bird = new List<Bird>();
    }

    public class Bird
    {
        public int X, Y;
        public Bitmap img;
    }

    public class Ground
    {
        public int X, Y;
        public Bitmap img;
        public List<Bird> bird = new List<Bird>();
        public int dirX;
    }

    public partial class Form1 : Form
    {
        private Timer tt = new Timer();
        private Bitmap off;
        private List<Helo> helo = new List<Helo>();
        private List<Ground> grounds = new List<Ground>();
        private int flagDown;
        private int flagEnter = 0;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint; ;
            this.Load += Form1_Load; ;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            tt.Tick += Tt_Tick; ;
            tt.Interval = 1;
            tt.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                flagDown = 0;
            }
            if (e.KeyCode == Keys.Enter)
            {
                flagEnter = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    helo[0].X += 3;

                    for (int i = 0; i < helo[0].bird.Count; i++)
                    {
                        helo[0].bird[i].X += 3;
                    }

                    break;

                case Keys.Left:
                    helo[0].X -= 3;
                    for (int i = 0; i < helo[0].bird.Count; i++)
                    {
                        helo[0].bird[i].X -= 3;
                    }
                    break;

                case Keys.Up:
                    flagDown = 1;

                    break;

                case Keys.Enter:
                    flagEnter = 1;

                    break;
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (flagDown == 0)
            {
                helo[0].Y += 1;
                for (int i = 0; i < helo[0].bird.Count; i++)
                {
                    helo[0].bird[i].Y += 1;
                }
            }
            else
            {
                helo[0].Y -= 2;
                for (int i = 0; i < helo[0].bird.Count; i++)
                {
                    helo[0].bird[i].Y -= 2;
                }
            }

            AnimateGrounds();
            isCatsh();

            DrawDubb(this.CreateGraphics());
        }

        private void isCatsh()
        {
            for (int i = 1; i < 5; i++)
            {
                if (grounds[i].bird.Count != 0)
                {
                    if (helo[0].Y + helo[0].img.Height >= grounds[i].bird[0].Y - 100 && helo[0].X + helo[0].img.Width * 1 / 2 >= grounds[i].X && helo[0].X + helo[0].img.Width * 1 / 2 <= grounds[i].X + grounds[i].img.Width)
                    {
                        //Bird pnn = new Bird();
                        //pnn.img = new Bitmap("4.bmp");
                        //pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                        //pnn.X = grounds[i].bird[0].X;
                        //pnn.Y = helo[0].Y + helo[0].img.Height;
                        grounds[i].bird.RemoveAt(0);
                        // helo[0].bird.Add(pnn);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            createHelo();
            createground();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void AnimateGrounds()
        {
            for (int i = 1; i < 5; i++)
            {
                if (grounds[i].dirX == 1)
                {
                    grounds[i].X += 1;
                    if (grounds[i].bird.Count != 0)
                    {
                        grounds[i].bird[0].X += 1;
                    }
                }
                else if (grounds[i].dirX == -1)
                {
                    grounds[i].X -= 1;
                    if (grounds[i].bird.Count != 0)
                    {
                        grounds[i].bird[0].X -= 1;
                    }
                }
            }
            isHit();
        }

        private void isHit()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < grounds.Count; j++)
                {
                    if (i != j)
                    {
                        if (grounds[i].X + grounds[i].img.Width == grounds[j].X)
                        {
                            grounds[i].dirX = -1;
                            break;
                        }
                        if (grounds[i].X == grounds[j].X + grounds[j].img.Width)
                        {
                            grounds[i].dirX = 1;
                            break;
                        }
                    }
                }
            }
        }

        private void createground()
        {
            Ground pnn = new Ground();
            pnn.img = new Bitmap("2.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.X = pnn.img.Width - 25;
            pnn.Y = (this.ClientSize.Height) - pnn.img.Height;
            grounds.Add(pnn);

            for (int i = 0; i < 4; i++)
            {
                Ground pn = new Ground();
                Bird pb = new Bird();
                pn.img = new Bitmap("2.bmp");
                pb.img = new Bitmap("3.bmp");
                pb.img.MakeTransparent(pb.img.GetPixel(0, 0));
                pb.X = (300 * (i + 1)) - 8;
                pb.Y = (this.ClientSize.Height) - pn.img.Height - pb.img.Height;
                pn.bird.Add(pb);
                pn.X = (300 * (i + 1)) - (pb.img.Width * 1 / 2);
                pn.Y = (this.ClientSize.Height) - pn.img.Height;
                pn.img.MakeTransparent(pn.img.GetPixel(0, 0));
                if (i < 2)
                {
                    pn.dirX = 1;
                }
                else
                {
                    pn.dirX = -1;
                }
                grounds.Add(pn);
            }
            Ground pm = new Ground();
            pm.img = new Bitmap("2.bmp");
            pm.img.MakeTransparent(pm.img.GetPixel(0, 0));
            pm.X = this.ClientSize.Width - pm.img.Width - 50;
            pm.Y = (this.ClientSize.Height) - pm.img.Height;
            grounds.Add(pm);
        }

        private void createHelo()
        {
            Helo pnn = new Helo();

            pnn.X = (this.ClientSize.Width) * 1 / 2;
            pnn.Y = (this.ClientSize.Height) * 1 / 8;
            pnn.img = new Bitmap("1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            helo.Add(pnn);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.PaleGreen);

            g.DrawImage(helo[0].img, helo[0].X, helo[0].Y, helo[0].img.Width, helo[0].img.Height);
            for (int i = 0; i < grounds.Count; i++)
            {
                g.DrawImage(grounds[i].img, grounds[i].X, grounds[i].Y, grounds[i].img.Width, grounds[i].img.Height);
            }
            for (int i = 0; i < grounds.Count; i++)
            {
                if (grounds[i].bird.Count != 0)
                {
                    g.DrawImage(grounds[i].bird[0].img, grounds[i].bird[0].X, grounds[i].bird[0].Y, grounds[i].bird[0].img.Width, grounds[i].bird[0].img.Height);
                }
            }
            for (int i = 0; i < helo[0].bird.Count; i++)
            {
                g.DrawImage(helo[0].bird[i].img, helo[0].bird[i].X, helo[0].bird[i].Y, helo[0].bird[i].img.Width, helo[0].bird[i].img.Height);
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