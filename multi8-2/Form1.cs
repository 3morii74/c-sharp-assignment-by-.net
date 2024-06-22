using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi8_2
{
    public partial class Form1 : Form
    {
        private class Actor
        {
            public int X, Y;
            public Bitmap img;
        }

        private class Shapes
        {
            public int X, Y, X2, Y2;
            public Color cl;
        }

        private class Character
        {
            public List<Shapes> shapes = new List<Shapes>();
            public int X, Y, W, H;
            public Color cl;
        }

        private Timer tt = new Timer();
        private Actor tom = new Actor();
        private Actor jerry = new Actor();
        private List<Character> col = new List<Character>();
        private List<Character> line = new List<Character>();
        private Bitmap off;
        private bool isDrag = false;
        private int xOld;
        private int yOld;
        private int FlagAnimate;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            tt.Tick += Tt_Tick;
            tt.Interval = 1;
            tt.Start();
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (FlagAnimate == 1)
            {
                Animation();
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Animation()
        {
            tom.Y += 2;
            int Ptom = tom.X + tom.img.Width * 1 / 2;

            for (int i = 0; i < line.Count; i++)
            {
                // right
                if (Ptom >= line[i].shapes[0].X - 5 && Ptom <= line[i].shapes[1].X + 5 && tom.Y + tom.img.Height * 1 / 4 >= line[i].shapes[0].Y && tom.Y + tom.img.Height * 1 / 4 <= line[i].shapes[0].Y + line[i].shapes[0].Y2)
                {
                    tom.X = line[i].shapes[2].X - tom.img.Width * 1 / 2;
                    tom.Y = line[i].shapes[2].Y;
                }

                //left
                if (Ptom <= line[i].shapes[2].X + line[i].shapes[2].X2 + 5 && Ptom >= line[i].shapes[1].X2 - 5 && tom.Y + tom.img.Height * 1 / 4 >= line[i].shapes[2].Y && tom.Y + tom.img.Height * 1 / 4 <= line[i].shapes[2].Y + line[i].shapes[2].Y2)
                {
                    tom.X = line[i].shapes[0].X - tom.img.Width * 1 / 2;
                    tom.Y = line[i].shapes[0].Y;
                }
            }
            ///checkHit
            if (Ptom >= jerry.X && Ptom <= jerry.X + jerry.img.Width && tom.Y >= jerry.Y)
            {
                tt.Stop();

                MessageBox.Show("Mabrroook");
            }
            else if (tom.Y >= jerry.Y)
            {
                tt.Stop();
                MessageBox.Show("Bad");
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            pc.shapes.Add(pl);
            pc.shapes.Add(pll);
            ppp.X = e.X - 2;
            ppp.Y = e.Y;
            ppp.X2 = 10;
            ppp.Y2 = 10;
            ppp.cl = Color.Red;
            pc.shapes.Add(ppp);
            line.Add(pc);
            pc = null;
            pl = null;
            pll = null;
            ppp = null;
        }

        private Character pc = new Character();
        private Shapes pl = new Shapes();
        private Shapes pll = new Shapes();
        private Shapes ppp = new Shapes();

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;

                pl.X = xOld;
                pl.Y = yOld;
                pl.X2 = 10;
                pl.Y2 = 10;
                pl.cl = Color.Red;

                /////////////////

                pll.X = xOld + 5;
                pll.Y = yOld;
                pll.X2 = e.X;
                pll.Y2 = e.Y;
                pll.cl = Color.Green;

                //////////////////////
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xOld = e.X;
                yOld = e.Y;
                pc = new Character();
                pl = new Shapes();
                pll = new Shapes();
                ppp = new Shapes();
                isDrag = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    col.Clear();
                    for (int i = 0; i < line.Count(); i++)
                    {
                        line[i].shapes.Clear();
                    }
                    line.Clear();
                    createColumn();
                    createActor();
                    createLines();
                    break;

                case Keys.Enter:
                    FlagAnimate = 1;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createColumn();
            createActor();
            createLines();
        }

        private void createLines()
        {
            Random rr = new Random(); // Instantiate Random object outside the loop\
            Random r = new Random(); // Instantiate Random object inside the loop
            for (int i = 0; i < col.Count() - 1; i++)
            {
                int v = rr.Next(1, 3); //no.of line one column
                for (int j = 0; j < v; j++)
                {
                    int yy = r.Next(col[i].Y + 2, col[i].Y + col[i].H - 2); //postion of y of each column
                    Character pnn = new Character();
                    Shapes pmm = new Shapes();
                    pmm.X = col[i].X;
                    pmm.Y = yy;
                    pmm.X2 = 10;
                    pmm.Y2 = 10;
                    pmm.cl = Color.Red;
                    pnn.shapes.Add(pmm);
                    /////////////////
                    Shapes pm = new Shapes();
                    pm.X = col[i].X + 5;
                    pm.Y = yy;
                    pm.X2 = col[i].X + 100;
                    pm.Y2 = yy;
                    pm.cl = Color.Green;
                    pnn.shapes.Add(pm);
                    //////////////////////
                    Shapes p = new Shapes();
                    p.X = col[i].X + 100 + 2;
                    p.Y = yy;
                    p.X2 = 10;
                    p.Y2 = 10;
                    p.cl = Color.Red;
                    pnn.shapes.Add(p);
                    line.Add(pnn);
                }
            }
        }

        private void createActor()
        {
            tom.img = new Bitmap("tom.bmp");
            tom.img.MakeTransparent(tom.img.GetPixel(0, 0));
            Random r = new Random();
            int v = r.Next(0, col.Count());
            tom.X = col[v].X - tom.img.Width * 1 / 2;
            tom.Y = col[v].Y - tom.img.Height + 5;
            // /// /// /// //// /// /// /// /// /// // // /// /// /// ///
            jerry.img = new Bitmap("jerry.bmp");
            jerry.img.MakeTransparent(jerry.img.GetPixel(0, 0));
            Random rr = new Random();
            int vv = r.Next(0, col.Count());
            jerry.X = col[vv].X - jerry.img.Width * 1 / 2;
            jerry.Y = col[vv].Y + col[vv].H;
        }

        private void createColumn()
        {
            Random rr = new Random();
            int v = rr.Next(2, 6);
            for (int i = 0; i < v; i++)
            {
                Character pnn = new Character();
                pnn.X = (this.ClientSize.Width * 1 / 4) + (i * 100);
                pnn.Y = 200;
                pnn.W = 5; pnn.H = 350;
                pnn.cl = Color.Black;
                col.Add(pnn);
            }
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Orange);

            Pen p = new Pen(col[0].cl);
            Brush b = new SolidBrush(col[0].cl);
            for (int i = 0; i < col.Count(); i++)
            {
                g.DrawRectangle(p, col[i].X, col[i].Y, col[i].W, col[i].H);
                g.FillRectangle(b, col[i].X, col[i].Y, col[i].W, col[i].H);
            }

            for (int i = 0; i < line.Count(); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 1)
                    {
                        p = new Pen(line[0].shapes[j].cl, 5);
                        g.DrawLine(p, line[i].shapes[j].X, line[i].shapes[j].Y, line[i].shapes[j].X2, line[i].shapes[j].Y2);
                    }
                    else
                    {
                        p = new Pen(line[0].shapes[j].cl);
                        b = new SolidBrush(line[0].shapes[j].cl);
                        g.DrawEllipse(p, line[i].shapes[j].X, line[i].shapes[j].Y, line[i].shapes[j].X2, line[i].shapes[j].Y2);
                        g.FillEllipse(b, line[i].shapes[j].X, line[i].shapes[j].Y, line[i].shapes[j].X2, line[i].shapes[j].Y2);
                    }
                    if (isDrag == true)
                    {
                        if (j == 1)
                        {
                            p = new Pen(pll.cl, 5);
                            g.DrawLine(p, pll.X, pll.Y, pll.X2, pll.Y2);
                        }
                        else
                        {
                            if (j == 0)
                            {
                                p = new Pen(pl.cl);
                                b = new SolidBrush(pl.cl);
                                g.DrawEllipse(p, pl.X, pl.Y, pl.X2, pl.Y2);
                                g.FillEllipse(b, pl.X, pl.Y, pl.X2, pl.Y2);
                            }
                        }
                    }
                }
            }
            g.DrawImage(tom.img, tom.X, tom.Y);
            g.DrawImage(jerry.img, jerry.X, jerry.Y);
        }

        private void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}