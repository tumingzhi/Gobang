using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0516_01
{
    public partial class Form1 : Form
    {
        int flag = 0;
        int[,] board = new int[100, 100];
        int confirm = 0;
        int number=0;
        string chesscolor = "黑色";
        int blackwin = 0;
        int whitewin = 0;
        int count = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(251, 210, 47)),50,50,700, 700);
            for (int i=50;i<=750;i+=50)
            {
                e.Graphics.DrawLine(new Pen(Color.Black,2),50,i,750,i);
            }
            for (int i = 50; i <= 750; i += 50)
           {
              e.Graphics.DrawLine(new Pen(Color.Black, 2), i, 50, i, 750);
           }
            e.Graphics.DrawString("A      C      E       G      I      K      M      O", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(40, 20));
            e.Graphics.DrawString("B      D      F       H      J      L      N", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(90, 20));
            e.Graphics.DrawString("1", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 30));
            e.Graphics.DrawString("2", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 80));
            e.Graphics.DrawString("3", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 130));
            e.Graphics.DrawString("4", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 180));
            e.Graphics.DrawString("5", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 230));
            e.Graphics.DrawString("6", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 280));
            e.Graphics.DrawString("7", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 330));
            e.Graphics.DrawString("8", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 380));
            e.Graphics.DrawString("9", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(20, 430));
            e.Graphics.DrawString("10", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 480));
            e.Graphics.DrawString("11", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 530));
            e.Graphics.DrawString("12", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 580));
            e.Graphics.DrawString("13", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 630));
            e.Graphics.DrawString("14", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 680));
            e.Graphics.DrawString("15", new Font("宋体", 20), new SolidBrush(Color.Black), new Point(10, 730));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(194, 194, 12, 12));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(194, 594, 12, 12));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(594, 594, 12, 12));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(594, 194, 12, 12));
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(394, 394, 12, 12));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                    board[i, j] = 0;
            }
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            /*
            Graphics gc = this.CreateGraphics();
            int x = this.PointToClient(Control.MousePosition).X;
            int y = this.PointToClient(Control.MousePosition).Y;
            if ((x % 50 <= 4 || x % 50 >= 46) & (y % 50 <= 4 || y % 50 >= 46) & 24 <= x & x <= 736 & y >= 40 & y <= 736)
            {
                if (flat == 0)
                {
                    gc.FillEllipse(new SolidBrush(Color.Black), this.PointToClient(Control.MousePosition).X - 18, this.PointToClient(Control.MousePosition).Y - 18, 36, 36);
                    flat = 1;
                    number = number + 1;
                    string chesscolor = "白色";
                }
                else
                {
                    gc.FillEllipse(new SolidBrush(Color.White), this.PointToClient(Control.MousePosition).X - 18, this.PointToClient(Control.MousePosition).Y - 18, 36, 36);
                    flat = 0;
                    number = number + 1;
                    string chesscolor = "黑色";
                }
            }
            */
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics gc = this.CreateGraphics();
            int x = this.PointToClient(Control.MousePosition).X;
            int y = this.PointToClient(Control.MousePosition).Y;

            if ((y % 50 < 4 || y % 50 > 46) && (x % 50 < 4 || x % 50 > 46)&&board[(y - 18) / 50 + 6, (x - 18) / 50 + 4] ==0)
            {
                if (flag == 0&confirm==0)
                {
                    gc.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x - 18, y - 18, 36, 36));
                    flag = 1;
                    chesscolor = "白色";
                    timer1.Enabled = true;
                    number = number+1;
                    int a, b;
                    int y1 = (x - 18) / 50 + 4;//列
                    int x1 = (y - 18) / 50 + 6;//行
                                               //MessageBox.Show("坐标（"+x1.ToString()+","+y1.ToString()+")");
                    board[x1, y1] = 1;//黑棋在二维数组中为1
                    for (a = y1 - 4; a <= y1 + 4; a++)
                    {

                        //判断横向
                        if ((board[x1, a] == 1) && (board[x1, a + 1] == 1) && (board[x1, a + 2] == 1) && (board[x1, a + 3] == 1) && (board[x1, a + 4] == 1))
                        {
                            MessageBox.Show("黑棋赢了");
                            blackwin = blackwin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }
                    }
                    for (b = x1 - 4; b <= x1 + 4; b++)
                    {
                        if ((board[b, y1] == 1) && (board[b + 1, y1] == 1) && (board[b + 2, y1] == 1) && (board[b + 3, y1] == 1) && (board[b + 4, y1] == 1))
                        {
                            MessageBox.Show("黑棋赢了");
                            blackwin = blackwin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }
                    }
                    //主对角线
                    for (a = x1 - 4, b = y1 - 4; b <= x1 + 4; a++, b++)
                    {
                        if ((board[a, b] == 1) && (board[a + 1, b + 1] == 1) && (board[a + 2, b + 2] == 1) && (board[a + 3, b + 3] == 1) && (board[a + 4, b + 4] == 1))
                        {
                            MessageBox.Show("黑棋赢了");
                            blackwin = blackwin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }

                    }
                    for (a = x1 + 4, b = y1 - 4; b <= y1 + 4; a--, b++)
                    {
                        if ((board[a, b] == 1) && (board[a - 1, b + 1] == 1) && (board[a - 2, b + 2] == 1) && (board[a - 3, b + 3] == 1) && (board[a - 4, b + 4] == 1))
                        {
                            MessageBox.Show("黑棋赢了");
                            blackwin = blackwin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }

                    }


                }

                else if(confirm == 0)
                {
                    gc.FillEllipse(new SolidBrush(Color.White), new Rectangle(x - 18, y - 18, 36, 36));
                    flag = 0;
                    chesscolor = "黑色";
                    number = number + 1;
                    int a, b;
                    int y1 = (x - 18) / 50 + 4;//列
                    int x1 = (y - 18) / 50 + 6;//行
                    // MessageBox.Show("坐标（"+x1.ToString()+","+y1.ToString()+")");
                    board[x1, y1] = 2;//黑棋在二维数组中为1
                    for (a = y1 - 4; a <= y1 + 4; a++)
                    {

                        //判断横向
                        if ((board[x1, a] == 2) && (board[x1, a + 1] == 2) && (board[x1, a + 2] == 2) && (board[x1, a + 3] == 2) && (board[x1, a + 4] == 2))
                        {
                            MessageBox.Show("白棋赢了");
                            whitewin = whitewin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }
                    }
                    for (b = x1 - 4; b <= x1 + 4; b++)
                    {
                        if ((board[b, y1] == 2) && (board[b + 1, y1] == 2) && (board[b + 2, y1] == 2) && (board[b + 3, y1] == 2) && (board[b + 4, y1] == 2))
                        {
                            MessageBox.Show("白棋赢了");
                            whitewin = whitewin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }
                    }
                    //主对角线
                    for (a = x1 - 4, b = y1 - 4; b <= x1 + 4; a++, b++)
                    {
                        if ((board[a, b] == 2) && (board[a + 1, b + 1] == 2) && (board[a + 2, b + 2] == 2) && (board[a + 3, b + 3] == 2) && (board[a + 4, b + 4] == 2))
                        {
                            MessageBox.Show("白棋赢了");
                            whitewin = whitewin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }

                    }
                    for (a = x1 + 4, b = y1 - 4; b <= y1 + 4; a--, b++)
                    {
                        if ((board[a, b] == 2) && (board[a - 1, b + 1] == 2) && (board[a - 2, b + 2] == 2) && (board[a - 3, b + 3] == 2) && (board[a - 4, b + 4] == 2))
                        {
                            MessageBox.Show("白棋赢了");
                            whitewin = whitewin + 1;
                            confirm = 1;
                            count = blackwin + whitewin + 1;
                        }

                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
            confirm = 0;
            flag = 0;
            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                    board[i, j] = 0;
            }
            chesscolor = "黑色";
            number = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label2.Text = chesscolor;
            label4.Text = Convert.ToString(number);
            label6.Text = Convert.ToString(number-number/2);
            label8.Text = Convert.ToString(number / 2);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label14.Text = Convert.ToString(count);
            label10.Text = Convert.ToString(blackwin);
            label12.Text = Convert.ToString(whitewin);
        }
    }
}
