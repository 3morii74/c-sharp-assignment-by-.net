using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi9_1
{
    public partial class Form1 : Form
    {
        private class Face
        {
            public Rectangle rcSrc;
            public Rectangle rcDst;
            public List<Bitmap> img = new List<Bitmap>();
            public int frame;
            public bool isClicked;
        }

        private Timer tt = new Timer();
        private Bitmap off;
        private int ctTick = 0;
        private List<Face> faces = new List<Face>();

        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            tt.Tick += Tt_Tick;
            tt.Interval = 1;
            tt.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    for (int i = 0; i < faces.Count; i++)
                    {
                        if (e.X >= faces[i].rcDst.X && e.X <= faces[i].rcDst.X + faces[i].rcDst.Width && e.Y >= faces[i].rcDst.Y && e.Y <= faces[i].rcDst.Y + faces[i].rcDst.Height)
                        {
                            faces[i].isClicked = true;
                            break;
                        }
                    }
                    break;
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if (ctTick % 50 == 0)
            {
                createFace();
                Clicked();
            }

            ctTick++;
            DrawDubb(this.CreateGraphics());
        }

        private void Clicked()
        {
            for (int i = 0; i < faces.Count; i++)
            {
                if (faces[i].isClicked)
                {
                    faces[i].frame = 1;
                    faces[i].rcDst.Width -= faces[i].rcDst.Width / 3;
                    faces[i].rcDst.Height -= faces[i].rcDst.Height / 3;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createFace();
        }

        private void createFace()
        {
            Random rr = new Random();
            int x = rr.Next(0, this.ClientSize.Width);
            int y = rr.Next(0, this.ClientSize.Height);
            Face pnn = new Face();
            for (int i = 1; i < 3; i++)
            {
                Bitmap img = new Bitmap($"{i}.bmp");
                pnn.img.Add(img);
            }
            pnn.frame = 0;
            pnn.isClicked = false;
            pnn.rcSrc = new Rectangle(0, 0, pnn.img[0].Width, pnn.img[0].Height); //بتحكم فى شكل الصورة و ايه اللى عاوز اظهرو
            pnn.rcDst = new Rectangle(x, y, pnn.img[0].Width, pnn.img[0].Height);// بتحكم فى بوزشن و حجم الصورة فى الفورم
            faces.Add(pnn);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Red);
            for (int i = 0; i < faces.Count; i++)
            {
                int frame = faces[i].frame;
                g.DrawImage(faces[i].img[frame], faces[i].rcDst, faces[i].rcSrc, GraphicsUnit.Pixel);
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