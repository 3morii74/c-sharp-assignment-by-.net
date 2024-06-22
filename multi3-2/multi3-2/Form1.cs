using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multi3_2
{
    public partial class Form1 : Form
    {
        private List<Form1> lefRightFrm = new List<Form1>();
        public List<Form1> updownFrm = new List<Form1>();
        public int flag = 0;
        public int flagH = 0;
        private int flagRev = 0;
        private int flagUp = 0;

        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    if (flag == 0)
                    {
                        this.Location = new Point(560, 310);
                        flag = 1;
                    }
                    else if (flag == 1)
                    {
                        flag = 2;
                        for (int i = 0; i < 4; i++)
                        {
                            Form1 pnn = new Form1();
                            pnn.Show();
                            pnn.Size = new Size(150, 150);
                            if (i % 2 == 0)
                            {
                                pnn.BackColor = Color.Tomato;
                                pnn.Opacity = 0.75;
                            }
                            else
                            {
                                pnn.BackColor = Color.Green;
                                pnn.Opacity = 0.75;
                            }
                            if (i == 0)
                            {
                                pnn.Location = new Point(this.Location.X - this.ClientSize.Width, (this.Location.Y) + (this.ClientSize.Height) / 2);
                                lefRightFrm.Add(pnn);
                            }
                            if (i == 1)
                            {
                                pnn.Location = new Point(this.Location.X - (this.ClientSize.Width) / 2, (this.Location.Y));
                                lefRightFrm.Add(pnn);
                            }
                            if (i == 2)
                            {
                                pnn.Location = new Point(this.Location.X + (this.ClientSize.Width) + pnn.Width, (this.Location.Y) + (this.ClientSize.Height) / 2);
                                lefRightFrm.Add(pnn);
                            }
                            if (i == 3)
                            {
                                pnn.Location = new Point(this.Location.X + (this.ClientSize.Width) + 5, (this.Location.Y));
                                lefRightFrm.Add(pnn);
                            }
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            Form1 pnn = new Form1();
                            pnn.Show();
                            pnn.Size = new Size(150, 150);
                            if (i % 2 == 0)
                            {
                                pnn.BackColor = Color.Tomato;
                                pnn.Opacity = 0.75;
                            }
                            else
                            {
                                pnn.BackColor = Color.Green;
                                pnn.Opacity = 0.75;
                            }
                            if (i == 0)
                            {
                                pnn.Location = new Point(this.Location.X, (this.Location.Y) - ((this.Height) / 2));
                            }
                            if (i == 1)
                            {
                                pnn.Location = new Point(this.Location.X + (this.Width) / 2, (this.Location.Y) - ((this.Height) / 2));
                            }
                            if (i == 2)
                            {
                                pnn.Location = new Point(this.Location.X, (this.Location.Y) + ((this.Height)));
                            }
                            if (i == 3)
                            {
                                pnn.Location = new Point(this.Location.X + (this.Width) / 2, (this.Location.Y) + ((this.Height)));
                            }

                            updownFrm.Add(pnn);
                        }
                    }

                    break;

                ///////////////////////////////////////////////
                case Keys.D1:
                    flagH = 1;
                    break;
                ///////////////////////////////////////////
                case Keys.D2:
                    flagH = 2;
                    break;

                case Keys.Space:
                    if (flagH == 1)
                    {
                        if (lefRightFrm[0].Location.X >= this.Location.X - (this.ClientSize.Width) / 2)
                        {
                            flagRev = 1;
                        }
                        if (lefRightFrm[0].Location.X <= this.Location.X - this.ClientSize.Width)
                        {
                            flagRev = 0;
                        }
                        if (flagRev == 1)
                        {
                            lefRightFrm[0].Location = new Point((lefRightFrm[0].Location.X) - 5, (lefRightFrm[0].Location.Y) + 5);
                            lefRightFrm[1].Location = new Point((lefRightFrm[1].Location.X) + 5, (lefRightFrm[1].Location.Y) - 5);
                            lefRightFrm[2].Location = new Point((lefRightFrm[2].Location.X) + 5, (lefRightFrm[2].Location.Y) + 5);
                            lefRightFrm[3].Location = new Point((lefRightFrm[3].Location.X) - 5, (lefRightFrm[3].Location.Y) - 5);
                        }
                        else if (flagRev == 0)
                        {
                            lefRightFrm[0].Location = new Point((lefRightFrm[0].Location.X) + 5, (lefRightFrm[0].Location.Y) - 5);
                            lefRightFrm[1].Location = new Point((lefRightFrm[1].Location.X) - 5, (lefRightFrm[1].Location.Y) + 5);
                            lefRightFrm[2].Location = new Point((lefRightFrm[2].Location.X) - 5, (lefRightFrm[2].Location.Y) - 5);
                            lefRightFrm[3].Location = new Point((lefRightFrm[3].Location.X) + 5, (lefRightFrm[3].Location.Y) + 5);
                        }
                    }
                    if (flagH == 2)
                    {
                        if (updownFrm[0].Location.X >= this.Location.X + (this.Width) / 2)
                        {
                            flagUp = 1;
                        }
                        if (updownFrm[0].Location.X <= this.Location.X)
                        {
                            flagUp = 0;
                        }
                        if (flagUp == 0)
                        {
                            updownFrm[0].Location = new Point((updownFrm[0].Location.X) + 5, (updownFrm[0].Location.Y));
                            updownFrm[1].Location = new Point((updownFrm[1].Location.X) - 5, (updownFrm[1].Location.Y));
                            updownFrm[2].Location = new Point((updownFrm[2].Location.X) + 5, (updownFrm[2].Location.Y));
                            updownFrm[3].Location = new Point((updownFrm[3].Location.X) - 5, (updownFrm[3].Location.Y));
                        }
                        else if (flagUp == 1)
                        {
                            updownFrm[0].Location = new Point((updownFrm[0].Location.X) - 5, (updownFrm[0].Location.Y));
                            updownFrm[1].Location = new Point((updownFrm[1].Location.X) + 5, (updownFrm[1].Location.Y));
                            updownFrm[2].Location = new Point((updownFrm[2].Location.X) - 5, (updownFrm[2].Location.Y));
                            updownFrm[3].Location = new Point((updownFrm[3].Location.X) + 5, (updownFrm[3].Location.Y));
                        }
                    }
                    break;
            }
        }
    }
}