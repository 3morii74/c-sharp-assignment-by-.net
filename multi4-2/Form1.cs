using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi4_2
{
    internal class cActor
    {
        public int X, Y;
        public int W, H;
        public Color cl;
    }

    public partial class Form1 : Form
    {
        private int xOld;
        private int yOld;
        private bool isDrag;
        private int flag = 0;
        private List<cActor> circle = new List<cActor>();

        public Form1()
        {
            this.BackColor = Color.Gray;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int space = 0;

                for (int i = 0; i < 24; i++)
                {
                    if (i == 4 || i == 8 || i == 16)
                    {
                        space = 0;
                    }
                    if (i < 4)
                    {
                        cActor pnn = new cActor();
                        pnn.X = 300 + space;
                        pnn.Y = 400;
                        pnn.W = 40;
                        pnn.H = 40;
                        pnn.cl = Color.Green;
                        circle.Add(pnn);
                    }
                    if (i >= 4 && i < 8)
                    {
                        cActor pnn = new cActor();
                        pnn.X = 1050 + space;
                        pnn.Y = 400;
                        pnn.W = 40;
                        pnn.H = 40;
                        pnn.cl = Color.Green;
                        circle.Add(pnn);
                    }
                    if (i >= 8 && i < 16)
                    {
                        cActor pnn = new cActor();
                        pnn.X = 550 + space;
                        pnn.Y = 200;
                        pnn.W = 40;
                        pnn.H = 40;
                        pnn.cl = Color.Yellow;
                        circle.Add(pnn);
                    }
                    if (i >= 16 && i < 24)
                    {
                        cActor pnn = new cActor();
                        pnn.X = 550 + space;
                        pnn.Y = 600;
                        pnn.W = 40;
                        pnn.H = 40;
                        pnn.cl = Color.Yellow;
                        circle.Add(pnn);
                    }
                    space += 46;
                }
                DrawScene(this.CreateGraphics());
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            flag = 0;
            DrawScene(this.CreateGraphics());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag == true && flag == 1)
            {
                int dx = e.X - xOld;
                int dy = e.Y - yOld;
                for (int i = 0; i < circle.Count; i++)
                {
                    circle[i].X += dx;
                    circle[i].Y += dy;
                }
                xOld = e.X;
                yOld = e.Y;
                DrawScene(this.CreateGraphics());
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X >= circle[8].X && e.X <= circle[15].X && e.Y >= circle[8].Y && e.Y <= circle[16].Y)
                {
                    xOld = e.X;
                    yOld = e.Y;
                    isDrag = true;
                    flag = 1;
                }
            }
        }

        private void DrawScene(Graphics g)
        {
            g = this.CreateGraphics();
            g.Clear(Color.Gray);

            for (int i = 0; i < circle.Count; i++)
            {
                Pen P = new Pen(circle[i].cl, 5);
                SolidBrush brsh = new SolidBrush(circle[i].cl);
                int x = circle[i].X;
                int y = circle[i].Y;
                g.FillEllipse(brsh, x, y, circle[i].W, circle[i].H);
                g.DrawEllipse(P, x, y, circle[i].W, circle[i].H);
            }
        }
    }
}