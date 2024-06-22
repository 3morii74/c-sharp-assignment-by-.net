using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi7_2
{
    public partial class Form1 : Form
    {
        public class CActorBall
        {
            public int X, Y, W, H;
            public Color cl;
        }

        public class Rectanglle
        {
            public int X, Y, W, H;
            public Color cl;
            public int speed = 1;
            public int dirX, dirY;
        }

        public class Mapp
        {
            public int X1, Y1, X2, Y2;
            public Color cl;
        }

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;

            tt.Interval = 1;
            tt.Start();
            tt.Tick += Tt_Tick;
        }

        private Bitmap off;
        private Timer tt = new Timer();
        private List<CActorBall> LBall = new List<CActorBall>();
        private List<Mapp> LPath = new List<Mapp>();
        private List<Rectanglle> LAnimateRectangle = new List<Rectanglle>();

        private int flag = 1;

        private void Tt_Tick(object sender, EventArgs e)
        {
            AnimateRectangle();
            CheckPush();

            DrawDubb(this.CreateGraphics());
        }

        private void CheckPush()
        {
            for (int i = 0; i < LAnimateRectangle.Count; i++)
            {
                if (LBall[0].X >= LAnimateRectangle[i].X && LBall[0].X <= LAnimateRectangle[i].X + LAnimateRectangle[i].W && LBall[0].Y <= LAnimateRectangle[i].Y + LAnimateRectangle[i].H && LBall[0].Y + LBall[0].H >= LAnimateRectangle[i].Y)
                {
                    // LAnimateRectangle[0].speed = 0;
                    // LAnimateRectangle[1].speed = 0;
                    // flag = 0;
                    tt.Stop();
                }

                if (LBall[0].X + LBall[0].W >= LAnimateRectangle[i].X && LBall[0].X + LBall[0].W <= LAnimateRectangle[i].X + LAnimateRectangle[i].W && LBall[0].Y >= LAnimateRectangle[i].Y && LBall[0].Y <= LAnimateRectangle[i].Y + LAnimateRectangle[i].H)
                {
                    // LAnimateRectangle[0].speed = 0;
                    // LAnimateRectangle[1].speed = 0;
                    // flag = 0;
                    tt.Stop();
                }
            }

            for (int i = 0; i < LPath.Count; i++)
            {
                Mapp path = LPath[i];

                if ((LBall[0].X + LBall[0].W >= path.X1 && LBall[0].X <= path.X1 && LBall[0].Y <= path.Y2 && LBall[0].Y + LBall[0].H >= path.Y1) ||
                    (LBall[0].X <= path.X2 && LBall[0].X + LBall[0].W >= path.X2 && LBall[0].Y <= path.Y2 && LBall[0].Y + LBall[0].H >= path.Y1) ||
                    (LBall[0].Y <= path.Y1 && LBall[0].Y + LBall[0].H >= path.Y1 && LBall[0].X <= path.X2 && LBall[0].X + LBall[0].W >= path.X1) ||
                    (LBall[0].Y + LBall[0].H >= path.Y2 && LBall[0].Y <= path.Y2 && LBall[0].X <= path.X2 && LBall[0].X + LBall[0].W >= path.X1))
                {
                    tt.Stop();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag == 1)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        LBall[0].X -= 4;
                        break;

                    case Keys.Right:
                        LBall[0].X += 4;

                        break;

                    case Keys.Up:
                        LBall[0].Y -= 4;

                        break;

                    case Keys.Down:
                        LBall[0].Y += 4;

                        break;
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            CreateBall();
            CreateMap();
            Rectangle();
        }

        private void CreateBall()
        {
            CActorBall ball = new CActorBall();
            ball.X = 110;
            ball.Y = 350;
            ball.W = 30;
            ball.H = 30;
            ball.cl = Color.HotPink;

            LBall.Add(ball);
        }

        private void CreateMap()
        {
            Mapp pnn = new Mapp();
            pnn.X1 = 70;
            pnn.Y1 = 300;
            pnn.X2 = 70;
            pnn.Y2 = 420;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 70;
            pnn.Y1 = 300;
            pnn.X2 = 300;
            pnn.Y2 = 300;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 70;
            pnn.Y1 = 420;
            pnn.X2 = 300;
            pnn.Y2 = 420;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 300;
            pnn.Y1 = 180;
            pnn.X2 = 300;
            pnn.Y2 = 300;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 300;
            pnn.Y1 = 180;
            pnn.X2 = 550;
            pnn.Y2 = 180;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 550;
            pnn.Y1 = 180;
            pnn.X2 = 550;
            pnn.Y2 = 300;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 300;
            pnn.Y1 = 420;
            pnn.X2 = 300;
            pnn.Y2 = 540;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 300;
            pnn.Y1 = 540;
            pnn.X2 = 550;
            pnn.Y2 = 540;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 550;
            pnn.Y1 = 420;
            pnn.X2 = 550;
            pnn.Y2 = 540;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 550;
            pnn.Y1 = 300;
            pnn.X2 = 800;
            pnn.Y2 = 300;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 800;
            pnn.Y1 = 300;
            pnn.X2 = 800;
            pnn.Y2 = 420;
            pnn.cl = Color.White;
            LPath.Add(pnn);

            pnn = new Mapp();
            pnn.X1 = 550;
            pnn.Y1 = 420;
            pnn.X2 = 800;
            pnn.Y2 = 420;
            pnn.cl = Color.White;
            LPath.Add(pnn);
        }

        private void Rectangle()
        {
            Rectanglle pnn = new Rectanglle();
            pnn.X = 300;
            pnn.Y = 180;
            pnn.W = 120;
            pnn.H = 120;
            pnn.cl = Color.Tomato;
            pnn.speed = 1;
            pnn.dirX = 1;
            pnn.dirY = 0;

            LAnimateRectangle.Add(pnn);

            pnn = new Rectanglle();
            pnn.X = 430;
            pnn.Y = 535 - 120;
            pnn.W = 120;
            pnn.H = 120;
            pnn.cl = Color.Teal;
            pnn.speed = 1;
            pnn.dirX = -1;
            pnn.dirY = 0;

            LAnimateRectangle.Add(pnn);
        }

        private void AnimateRectangle()
        {
            for (int i = 0; i < LAnimateRectangle.Count; i++)
            {
                if (LAnimateRectangle[i].X == 300 && LAnimateRectangle[i].Y == 180)
                {
                    LAnimateRectangle[i].dirX = 1;
                    LAnimateRectangle[i].dirY = 0;
                }
                else if (LAnimateRectangle[i].X + LAnimateRectangle[i].W == 550 && LAnimateRectangle[i].Y == 180)
                {
                    LAnimateRectangle[i].dirX = 0;
                    LAnimateRectangle[i].dirY = 1;
                }
                else if (LAnimateRectangle[i].X + LAnimateRectangle[i].W == 550 && LAnimateRectangle[i].Y + LAnimateRectangle[i].H == 535)
                {
                    LAnimateRectangle[i].dirX = -1;
                    LAnimateRectangle[i].dirY = 0;
                }
                else if (LAnimateRectangle[i].X == 300 && LAnimateRectangle[i].Y + LAnimateRectangle[i].H == 535)
                {
                    LAnimateRectangle[i].dirX = 0;
                    LAnimateRectangle[i].dirY = -1;
                }

                if (LAnimateRectangle[i].dirX == 0 && LAnimateRectangle[i].dirY == 1)
                {
                    LAnimateRectangle[i].Y += LAnimateRectangle[i].speed;
                }
                else if (LAnimateRectangle[i].dirX == 0 && LAnimateRectangle[i].dirY == -1)
                {
                    LAnimateRectangle[i].Y -= LAnimateRectangle[i].speed;
                }
                else if (LAnimateRectangle[i].dirX == 1 && LAnimateRectangle[i].dirY == 0)
                {
                    LAnimateRectangle[i].X += LAnimateRectangle[i].speed;
                }
                else if (LAnimateRectangle[i].dirX == -1 && LAnimateRectangle[i].dirY == 0)
                {
                    LAnimateRectangle[i].X -= LAnimateRectangle[i].speed;
                }
            }
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < LBall.Count; i++)
            {
                Pen pn = new Pen(LBall[i].cl);
                g.DrawEllipse(pn, LBall[i].X, LBall[i].Y, LBall[i].W, LBall[i].H);

                SolidBrush brush = new SolidBrush(LBall[i].cl);
                g.FillEllipse(brush, LBall[i].X, LBall[i].Y, LBall[i].W, LBall[i].H);
            }

            for (int i = 0; i < LAnimateRectangle.Count; i++)
            {
                Pen pn = new Pen(LAnimateRectangle[i].cl);
                g.DrawRectangle(pn, LAnimateRectangle[i].X, LAnimateRectangle[i].Y, LAnimateRectangle[i].W, LAnimateRectangle[i].H);

                SolidBrush brush = new SolidBrush(LAnimateRectangle[i].cl);
                g.FillRectangle(brush, LAnimateRectangle[i].X, LAnimateRectangle[i].Y, LAnimateRectangle[i].W, LAnimateRectangle[i].H);
            }

            for (int i = 0; i < LPath.Count; i++)
            {
                Pen pn = new Pen(LPath[i].cl, 5);
                g.DrawLine(pn, LPath[i].X1, LPath[i].Y1, LPath[i].X2, LPath[i].Y2);
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