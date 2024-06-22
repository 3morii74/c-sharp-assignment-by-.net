using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi4_3
{
    public partial class Form1 : Form
    {
        public class cActor
        {
            public int X, Y;
            public int W, H;
            public Color cl;
        }

        private List<cActor> Circles = new List<cActor>();
        private List<cActor> SquaresLeft = new List<cActor>();
        private List<cActor> SquaresRight = new List<cActor>();
        private int space = 0;
        private int y = 30;
        private int i = 0;
        private int k = 0;
        private int ctLastRow = 0;
        private int row = 0;
        private int numBlocks1, numBlocks2;
        private int saveBlocks;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += Form1_KeyDown;
            this.Paint += Form1_Paint;
            this.BackColor = Color.Black;
            Random rr = new Random();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            createScene();
            DrawScene(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    cActor pnn = new cActor();
                    if (k > 5 && k % 6 == 0)
                    {
                        space = 0;
                        y += 50;
                    }
                    pnn.X = 351 + space;
                    pnn.W = 40;
                    pnn.Y = y;
                    pnn.H = 40;
                    pnn.cl = Color.Yellow;
                    SquaresRight.Add(pnn);
                    numBlocks2 += 1;
                    break;

                case Keys.Space:
                    if (SquaresLeft.Count == SquaresRight.Count)
                    {
                        MessageBox.Show("Correct");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
            }
            DrawScene(this.CreateGraphics());
        }

        private void createScene()
        {
            Graphics g = this.CreateGraphics();

            Pen p = new Pen(Color.Orange);

            g.DrawLine(p, 20, 30, 300, 30);
            g.DrawLine(p, 20, 300, 300, 300);
            g.DrawLine(p, 20, 30, 20, 300);
            g.DrawLine(p, 300, 30, 300, 300);

            g.DrawLine(p, 350, 30, 630, 30);
            g.DrawLine(p, 350, 300, 630, 300);
            g.DrawLine(p, 350, 30, 350, 300);
            g.DrawLine(p, 630, 30, 630, 300);

            Random RR = new Random();

            numBlocks1 = RR.Next(5, 20);
            numBlocks2 = RR.Next(5, 10);
            saveBlocks = numBlocks2;
            for (int i = 0; i < numBlocks1; i++)
            {
                if (i > 5 && i % 6 == 0)
                {
                    space = 0;
                    y += 50;
                }
                cActor c = new cActor();
                c.X = 20 + space;
                c.Y = y;
                c.H = 40;
                c.W = 40;
                c.cl = Color.Red;
                SquaresLeft.Add(c);
                space += 45;
                Pen P = new Pen(SquaresLeft[i].cl);
                g.DrawRectangle(P, SquaresLeft[i].X, SquaresLeft[i].Y, SquaresLeft[i].W, SquaresLeft[i].H);
                SolidBrush brush = new SolidBrush(SquaresLeft[i].cl);
                g.FillRectangle(brush, SquaresLeft[i].X, SquaresLeft[i].Y, SquaresLeft[i].W, SquaresLeft[i].H);
            }
            space = 0;
            y = 30;
            for (k = 0; k < numBlocks2; k++)
            {
                if (k > 5 && k % 6 == 0)
                {
                    space = 0;
                    y += 50;
                }
                cActor c = new cActor();
                c.X = 351 + space;
                c.Y = y;
                c.H = 40;
                c.W = 40;
                c.cl = Color.Green;
                SquaresRight.Add(c);
                space += 45;
                Pen P = new Pen(SquaresRight[k].cl);
                g.DrawRectangle(P, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
                SolidBrush brush = new SolidBrush(SquaresRight[k].cl);
                g.FillRectangle(brush, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
            }
        }

        private void DrawScene(Graphics g)
        {
            g = this.CreateGraphics();

            Pen p = new Pen(Color.Orange);

            g.DrawLine(p, 20, 30, 300, 30);
            g.DrawLine(p, 20, 300, 300, 300);
            g.DrawLine(p, 20, 30, 20, 300);
            g.DrawLine(p, 300, 30, 300, 300);

            g.DrawLine(p, 350, 30, 630, 30);
            g.DrawLine(p, 350, 300, 630, 300);
            g.DrawLine(p, 350, 30, 350, 300);
            g.DrawLine(p, 630, 30, 630, 300);

            Random RR = new Random();

            for (int i = 0; i < numBlocks1; i++)
            {
                if (i > 5 && i % 6 == 0)
                {
                    space = 0;
                    y += 50;
                }
                space += 45;

                Pen P = new Pen(SquaresLeft[i].cl);
                g.DrawRectangle(P, SquaresLeft[i].X, SquaresLeft[i].Y, SquaresLeft[i].W, SquaresLeft[i].H);
                SolidBrush brush = new SolidBrush(SquaresLeft[i].cl);
                g.FillRectangle(brush, SquaresLeft[i].X, SquaresLeft[i].Y, SquaresLeft[i].W, SquaresLeft[i].H);
            }
            space = 0;
            y = 30;
            for (k = 0; k < numBlocks2; k++)
            {
                if (k > 5 && k % 6 == 0)
                {
                    space = 0;
                    y += 50;
                }
                if (k < saveBlocks)
                {
                    space += 45;
                    Pen P = new Pen(SquaresRight[k].cl);
                    g.DrawRectangle(P, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
                    SolidBrush brush = new SolidBrush(SquaresRight[k].cl);
                    g.FillRectangle(brush, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
                }
                else
                {
                    space += 45;
                    Pen P = new Pen(SquaresRight[k].cl);
                    g.DrawEllipse(P, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
                    SolidBrush brush = new SolidBrush(SquaresRight[k].cl);
                    g.FillEllipse(brush, SquaresRight[k].X, SquaresRight[k].Y, SquaresRight[k].W, SquaresRight[k].H);
                }
            }
        }
    }
}