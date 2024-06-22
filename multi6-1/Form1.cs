using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi6_1
{
    public class Egg
    {
        public int X, Y;
        public int dir;
        public List<Bitmap> img = new List<Bitmap>();
    }

    public class Bonus
    {
        public int X, Y;
        public Bitmap img;
    }

    public class Mickey
    {
        public int X, Y;
        public List<Bitmap> img = new List<Bitmap>();
    }

    public partial class Form1 : Form
    {
        private Bitmap off;
        private Mickey mickey = new Mickey();
        private List<Egg> eggs = new List<Egg>();
        private List<Bonus> bonus = new List<Bonus>();
        private int flag = 1;
        private int ImgMickey = 0;
        private int ImgEgg = 0;

        public Form1()
        {
            this.BackColor = Color.Goldenrod;
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint; ;
            this.Load += Form1_Load; ;
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown; ;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < bonus.Count; i++)
            {
                if (i == 0)
                {
                    if (e.X >= bonus[i].X && e.X <= bonus[i].X + bonus[i].img.Width && e.Y >= bonus[i].Y && e.Y <= bonus[i].Y + 70)
                    {
                        Egg pnn = new Egg();
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                            img.MakeTransparent(img.GetPixel(0, 0));
                            pnn.img.Add(img);
                        }
                        Random random = new Random();

                        pnn.X = bonus[i].X;
                        pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img[0].Height;
                        pnn.dir = 1;
                        bonus[i].X = random.Next(0, (this.ClientSize.Width * 1 / 2) - 50);
                        eggs.Add(pnn);
                    }
                }
                if (i == 1)
                {
                    if (e.X >= bonus[i].X && e.X <= bonus[i].X + bonus[i].img.Width - 10 && e.Y >= bonus[i].Y + bonus[i].img.Height - 70 && e.Y <= bonus[i].Y + bonus[i].img.Height - 5)
                    {
                        Egg pnn = new Egg();
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                            img.MakeTransparent(img.GetPixel(0, 0));
                            pnn.img.Add(img);
                        }
                        Random random = new Random();

                        pnn.X = bonus[i].X;
                        pnn.Y = (this.ClientSize.Height * 1 / 2) - pnn.img[0].Height;
                        pnn.dir = 1;
                        bonus[i].X = random.Next(0, (this.ClientSize.Width * 1 / 2) - 50);
                        eggs.Add(pnn);
                    }
                }
                if (i == 2)
                {
                    if (e.X >= bonus[i].X && e.X <= bonus[i].X + bonus[i].img.Width && e.Y >= bonus[i].Y && e.Y <= bonus[i].Y + 70)
                    {
                        Egg pnn = new Egg();
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                            img.MakeTransparent(img.GetPixel(0, 0));
                            pnn.img.Add(img);
                        }
                        Random random = new Random();

                        pnn.X = bonus[i].X;
                        pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img[0].Height;
                        pnn.dir = -1;
                        bonus[i].X = random.Next((this.ClientSize.Width * 1 / 2) + 200, this.ClientSize.Width - pnn.img[0].Width);
                        eggs.Add(pnn);
                    }
                }
                if (i == 3)
                {
                    if (e.X >= bonus[i].X && e.X <= bonus[i].X + bonus[i].img.Width - 10 && e.Y >= bonus[i].Y + bonus[i].img.Height - 70 && e.Y <= bonus[i].Y + bonus[i].img.Height - 5)
                    {
                        Egg pnn = new Egg();
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                            img.MakeTransparent(img.GetPixel(0, 0));
                            pnn.img.Add(img);
                        }
                        Random random = new Random();

                        pnn.X = bonus[i].X;
                        pnn.Y = (this.ClientSize.Height * 1 / 2) - pnn.img[0].Height;
                        pnn.dir = -1;
                        bonus[i].X = random.Next((this.ClientSize.Width * 1 / 2) + 200, this.ClientSize.Width - pnn.img[0].Width);
                        eggs.Add(pnn);
                    }
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    ImgMickey = 0;
                    break;

                case Keys.Down:
                    ImgMickey = 1;

                    break;

                case Keys.Right:
                    ImgMickey = 3;

                    break;

                case Keys.Left:
                    ImgMickey = 2;

                    break;

                case Keys.Space:
                    for (int j = 0; j < eggs.Count; j++)
                    {
                        if (eggs[j].dir == 1)
                        {
                            eggs[j].X += eggs[j].img[ImgEgg].Height * 3 / 4;
                        }
                        if (eggs[j].dir == -1)
                        {
                            eggs[j].X -= eggs[j].img[ImgEgg].Height * 3 / 4;
                        }
                        if (eggs[j].X >= mickey.X && eggs[j].X <= mickey.X + mickey.img[0].Width)
                        {
                            MessageBox.Show("There is an  egg reaches MICKEY ");
                            if (flag == 1)
                            {
                                createBonus();
                                flag = 0;
                            }
                            else
                            {
                                bonus.Clear();
                                createBonus();
                            }

                            eggs.Clear();
                            break;
                        }
                    }
                    ImgEgg++;
                    if (ImgEgg == 4)
                    {
                        ImgEgg = 0;
                    }

                    break;
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateMap();
            CreateMickey();
            CreateEggs();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void createBonus()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Bonus pnn = new Bonus();

                    Bitmap img = new Bitmap("B" + (i + 1) + ".bmp");
                    img.MakeTransparent(img.GetPixel(0, 0));
                    pnn.img = img;
                    if (flag == 1)
                    {
                        pnn.X = eggs[i].X - eggs[i].img[0].Width - 20;
                        pnn.Y = eggs[i].Y - pnn.img.Height + 22;
                    }
                    else
                    {
                        Random RR = new Random();
                        pnn.X = RR.Next((this.ClientSize.Width * 1 / 3) - 100);
                        pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img.Height;
                    }

                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    bonus.Add(pnn);
                }
                if (i == 1)
                {
                    Bonus pnn = new Bonus();

                    Bitmap img = new Bitmap("B" + (i + 1) + ".bmp");
                    img.MakeTransparent(img.GetPixel(0, 0));
                    pnn.img = img;
                    if (flag == 1)
                    {
                        pnn.X = eggs[i].X - 50;
                        pnn.Y = eggs[i].Y + 43;
                    }
                    else
                    {
                        Random RR = new Random();
                        pnn.X = RR.Next((this.ClientSize.Width * 1 / 6) - 100, (this.ClientSize.Width * 1 / 2) - 100);
                        pnn.Y = (this.ClientSize.Height * 1 / 2) + 21;
                    }

                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    bonus.Add(pnn);
                }
                if (i == 2)
                {
                    Bonus pnn = new Bonus();

                    Bitmap img = new Bitmap("B" + (i + 1) + ".bmp");
                    img.MakeTransparent(img.GetPixel(0, 0));
                    pnn.img = img;
                    if (flag == 1)
                    {
                        pnn.X = eggs[i].X - eggs[i].img[0].Width - 20;
                        pnn.Y = eggs[i].Y - pnn.img.Height + 22;
                    }
                    else
                    {
                        Random RR = new Random();
                        pnn.X = RR.Next((this.ClientSize.Width * 3 / 4) + 200, this.ClientSize.Width - pnn.img.Width);
                        pnn.Y = pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img.Height;
                    }

                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    bonus.Add(pnn);
                }
                if (i == 3)
                {
                    Bonus pnn = new Bonus();

                    Bitmap img = new Bitmap("B" + (i + 1) + ".bmp");
                    img.MakeTransparent(img.GetPixel(0, 0));
                    pnn.img = img;
                    if (flag == 1)
                    {
                        pnn.X = eggs[i].X - 50;
                        pnn.Y = eggs[i].Y + 43;
                    }
                    else
                    {
                        Random RR = new Random();
                        pnn.X = RR.Next((this.ClientSize.Width * 3 / 4) + 200, this.ClientSize.Width - pnn.img.Width);
                        pnn.Y = (this.ClientSize.Height * 1 / 2) + 21;
                    }

                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    bonus.Add(pnn);
                }
            }
            for (int j = 0; j < 4; j++)
            {
                g.DrawImage(bonus[j].img, bonus[j].X, bonus[j].Y, bonus[j].img.Width, bonus[j].img.Height);
            }
        }

        private void CreateEggs()
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Egg pnn = new Egg();
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                        img.MakeTransparent(img.GetPixel(0, 0));
                        pnn.img.Add(img);
                    }
                    Random random = new Random();
                    pnn.X = random.Next((this.ClientSize.Width * 1 / 3) - 100);
                    pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img[0].Height;
                    pnn.dir = 1;
                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    eggs.Add(pnn);
                }
                if (i == 1)
                {
                    Egg pnn = new Egg();
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap img = new Bitmap("egg(2)" + (j + 1) + ".bmp");
                        img.MakeTransparent(img.GetPixel(0, 0));
                        pnn.img.Add(img);
                    }
                    Random random2 = new Random();
                    pnn.X = random2.Next((this.ClientSize.Width * 1 / 6) - 100, (this.ClientSize.Width * 1 / 2) - 100);
                    pnn.Y = (this.ClientSize.Height * 1 / 2) - pnn.img[0].Height;
                    pnn.dir = 1;

                    //  g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    eggs.Add(pnn);
                }
                if (i == 2)
                {
                    Egg pnn = new Egg();
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap img = new Bitmap("egg" + (j + 1) + ".bmp");
                        img.MakeTransparent(img.GetPixel(0, 0));
                        pnn.img.Add(img);
                    }
                    Random random3 = new Random();
                    pnn.X = random3.Next((this.ClientSize.Width * 1 / 2) + 200, this.ClientSize.Width - pnn.img[0].Width);
                    // pnn.X = this.ClientSize.Width - pnn.img[0].Width;
                    pnn.Y = (this.ClientSize.Height * 1 / 2) - 50 - pnn.img[0].Height;
                    pnn.dir = -1;

                    // g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    eggs.Add(pnn);
                }
                if (i == 3)
                {
                    Egg pnn = new Egg();
                    for (int j = 0; j < 4; j++)
                    {
                        Bitmap img = new Bitmap("egg" + (j + 1) + ".bmp");
                        img.MakeTransparent(img.GetPixel(0, 0));
                        pnn.img.Add(img);
                    }
                    Random random4 = new Random();
                    pnn.X = random4.Next((this.ClientSize.Width * 3 / 4) + 200, this.ClientSize.Width - pnn.img[0].Width);
                    pnn.Y = (this.ClientSize.Height * 1 / 2) - pnn.img[0].Height;
                    pnn.dir = -1;

                    // g.DrawImage(pnn.img[0], pnn.X, pnn.Y, pnn.img[0].Width, pnn.img[0].Height);
                    eggs.Add(pnn);
                }
            }
            for (int j = 0; j < 4; j++)
            {
                g.DrawImage(eggs[j].img[0], eggs[j].X, eggs[j].Y, eggs[j].img[0].Width, eggs[j].img[0].Height);
            }
        }

        private void CreateMickey()
        {
            Graphics g = this.CreateGraphics();
            mickey.X = ((this.ClientSize.Width) * 1 / 2) - 50;
            mickey.Y = ((this.ClientSize.Height) * 1 / 2) - 55;
            for (int k = 0; k < 4; k++)
            {
                Bitmap img = new Bitmap("T" + (k + 1) + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                mickey.img.Add(img);
            }
            g.DrawImage(mickey.img[0], mickey.X, mickey.Y, mickey.img[0].Width, mickey.img[0].Height);
        }

        private void CreateMap()
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.DarkRed);
            Brush b = new SolidBrush(Color.DarkRed);
            g.DrawRectangle(p, 0, (this.ClientSize.Height * 1 / 2) - 50, (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.FillRectangle(b, 0, (this.ClientSize.Height * 1 / 2) - 50, (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.DrawRectangle(p, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2) - 50, this.ClientSize.Width, 20);
            g.FillRectangle(b, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2) - 50, this.ClientSize.Width, 20);
            ////////////
            g.DrawRectangle(p, 0, (this.ClientSize.Height * 1 / 2), (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.FillRectangle(b, 0, (this.ClientSize.Height * 1 / 2), (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.DrawRectangle(p, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2), this.ClientSize.Width, 20);
            g.FillRectangle(b, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2), this.ClientSize.Width, 20);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Goldenrod);
            Pen p = new Pen(Color.DarkRed);
            Brush b = new SolidBrush(Color.DarkRed);
            g.DrawRectangle(p, 0, (this.ClientSize.Height * 1 / 2) - 50, (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.FillRectangle(b, 0, (this.ClientSize.Height * 1 / 2) - 50, (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.DrawRectangle(p, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2) - 50, this.ClientSize.Width, 20);
            g.FillRectangle(b, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2) - 50, this.ClientSize.Width, 20);
            ////////////
            g.DrawRectangle(p, 0, (this.ClientSize.Height * 1 / 2), (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.FillRectangle(b, 0, (this.ClientSize.Height * 1 / 2), (this.ClientSize.Width * 1 / 2) - 50, 20);
            g.DrawRectangle(p, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2), this.ClientSize.Width, 20);
            g.FillRectangle(b, (this.ClientSize.Width * 1 / 2) + 50, (this.ClientSize.Height * 1 / 2), this.ClientSize.Width, 20);
            ////
            g.DrawImage(mickey.img[ImgMickey], mickey.X, mickey.Y, mickey.img[ImgMickey].Width, mickey.img[ImgMickey].Height);
            for (int j = 0; j < bonus.Count; j++)
            {
                g.DrawImage(bonus[j].img, bonus[j].X, bonus[j].Y, bonus[j].img.Width, bonus[j].img.Height);
            }
            for (int j = 0; j < eggs.Count; j++)
            {
                // if (j%2==0)
                // {
                //     g.DrawImage(eggs[j].img[0], eggs[j].X, eggs[j].Y, eggs[j].img[0].Width, eggs[j].img[0].Height);
                // }
                if (ImgEgg % 2 != 0)
                {
                    g.DrawImage(eggs[j].img[ImgEgg], eggs[j].X, eggs[j].Y + eggs[j].img[ImgEgg].Height * 1 / 2, eggs[j].img[ImgEgg].Width, eggs[j].img[ImgEgg].Height);
                }
                else
                {
                    g.DrawImage(eggs[j].img[ImgEgg], eggs[j].X, eggs[j].Y, eggs[j].img[ImgEgg].Width, eggs[j].img[ImgEgg].Height);
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