using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi6_3
{
    public class Ball
    {
        public int X, Y;
        public Bitmap img;
    }

    public class Hero
    {
        public int X, Y;
        public List<Bitmap> img = new List<Bitmap>();
        public List<Ball> balls = new List<Ball>();
    }

    public partial class Form1 : Form
    {
        private Bitmap off;
        private List<Ball> ball = new List<Ball>();
        private List<Ball> ball2 = new List<Ball>();

        private Hero hero = new Hero();

        private int ctsh;
        private int numBlocks1;
        private int numBlocks2;
        private int saveBlocks;
        private int space;
        private int y;
        private int index = 0;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;

            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (index == 9)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    if (hero.balls.Count > 0)
                    {
                        hero.balls[0].Y -= 8;
                    }
                    hero.Y -= 8;

                    break;

                case Keys.Down:
                    if (index == 9)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                    if (hero.balls.Count > 0)
                    {
                        hero.balls[0].Y += 8;
                    }
                    hero.Y += 8;

                    break;

                case Keys.Enter:
                    if (hero.balls.Count == 0)
                    {
                        if (hero.Y >= this.ClientSize.Height - 150)
                        {
                            Ball pnn = new Ball();
                            pnn.img = new Bitmap("ball.bmp");
                            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                            pnn.X = hero.X - pnn.img.Width * 1 / 2;
                            pnn.Y = hero.Y;
                            hero.balls.Add(pnn);
                            ball.RemoveAt(ball.Count - 1);
                        }
                    }
                    else
                    {
                        if (hero.Y <= 105)
                        {
                            Ball pnn = new Ball();
                            pnn.img = new Bitmap("ball.bmp");
                            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                            pnn.X = hero.X - pnn.img.Width * 1 / 2;
                            pnn.Y = hero.Y;
                            ball2.Add(pnn);
                            hero.balls.RemoveAt(0);
                        }
                    }
                    break;
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            // CreateBall();
            CreateHero();
            CreateGoals();
        }

        private void CreateGoals()
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.Green);
            Brush brush = new SolidBrush(Color.Green);
            Pen p2 = new Pen(Color.OrangeRed);
            Brush brush2 = new SolidBrush(Color.OrangeRed);

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int rectWidth = 350; // Width of the rectangle
            int rectHeight = 130; // Height of the rectangle

            // Calculate the top-left corner of the rectangle
            int x = (formWidth - rectWidth) / 2;
            int y = formHeight - rectHeight - 20; // 20 is the margin from the bottom of the form

            // Draw the rectangle

            g.DrawRectangle(p, x, y, rectWidth, rectHeight);
            g.FillRectangle(brush, x, y, rectWidth, rectHeight);

            x = (formWidth - rectWidth) / 2;
            y = 0;
            // Draw the upper rectangle
            g.DrawRectangle(p2, x, y, rectWidth, rectHeight);
            g.FillRectangle(brush2, x, y, rectWidth, rectHeight);

            Random RR = new Random();
            y = formHeight - rectHeight - 20 + 5;
            x = (formWidth - rectWidth) / 2;
            numBlocks1 = RR.Next(5, 12);
            saveBlocks = numBlocks2;
            for (int i = 0; i < numBlocks1; i++)
            {
                if (i > 5 && i % 6 == 0)
                {
                    space = 0;
                    y += 50;
                }
                Ball c = new Ball();
                c.X = x + space + 1;
                c.Y = y;
                c.img = new Bitmap("ball.bmp");
                c.img.MakeTransparent(c.img.GetPixel(0, 0));

                g.DrawImage(c.img, c.X, c.Y, c.img.Width, c.img.Height);
                ball.Add(c);
                space += 45;
            }
        }

        private void CreateHero()
        {
            Graphics g = this.CreateGraphics();
            hero.X = (this.ClientSize.Width) * 1 / 2;
            hero.Y = (this.ClientSize.Height) * 1 / 4;
            for (int k = 0; k < 10; k++)
            {
                Bitmap img = new Bitmap("T" + (k + 1) + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                hero.img.Add(img);
            }
            g.DrawImage(hero.img[0], hero.X, hero.Y, hero.img[0].Width, hero.img[0].Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Yellow);

            Pen p = new Pen(Color.Green);
            Brush brush = new SolidBrush(Color.Green);
            Pen p2 = new Pen(Color.OrangeRed);
            Brush brush2 = new SolidBrush(Color.OrangeRed);

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int rectWidth = 350; // Width of the rectangle
            int rectHeight = 130; // Height of the rectangle

            // Calculate the top-left corner of the rectangle
            int x = (formWidth - rectWidth) / 2;
            int y = formHeight - rectHeight - 20; // 20 is the margin from the bottom of the form

            // Draw the rectangle
            g.DrawRectangle(p, x, y, rectWidth, rectHeight);
            g.FillRectangle(brush, x, y, rectWidth, rectHeight);

            x = (formWidth - rectWidth) / 2;
            y = 0;
            // Draw the upper rectangle
            g.DrawRectangle(p2, x, y, rectWidth, rectHeight);
            g.FillRectangle(brush2, x, y, rectWidth, rectHeight);

            g.DrawImage(hero.img[index], hero.X, hero.Y, hero.img[index].Width, hero.img[index].Height);
            for (int i = 0; i < ball.Count; i++)
            {
                g.DrawImage(ball[i].img, ball[i].X, ball[i].Y, ball[i].img.Width, ball[i].img.Height);
            }
            if (hero.balls.Count > 0)
            {
                g.DrawImage(hero.balls[0].img, hero.balls[0].X, hero.balls[0].Y, hero.balls[0].img.Width, hero.balls[0].img.Height);
            }
            if (ball2.Count > 0)
            {
                for (int i = 0; i < ball2.Count; i++)
                {
                    g.DrawImage(ball2[i].img, ball2[i].X, ball2[i].Y, ball2[i].img.Width, ball2[i].img.Height);
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