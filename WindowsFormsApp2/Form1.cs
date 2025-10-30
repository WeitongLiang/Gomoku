using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Point hh = new Point();
        private bool begin;
        private bool color;
        private const int size = 15;
        public int[,] ChessBoard = new int[size, size];
        public int judge = 0;
        public int AI_type = 0;
        public int count = 0;
        public int fupan = 0;
        public Data D = new Data();
        public Data D2 = new Data();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            judge = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++) ChessBoard[i, j] = 0;
            Graphics g = board.CreateGraphics();
            Board.DrawBoard(g);
            chess.DrawinGame(board, ChessBoard);
            timer1.Start();
            begin = true;
            color = true;
            start.Visible = false;
            restart.Visible = true;
            label1.Visible = true;
            bar.Visible = true;
            next.Visible = false;
            last.Visible = false;
            if (AI_type == 0) huiqi.Visible = true;
            else huiqi.Visible = false;
            if (AI_type == 1)
            {
                chess.DrawChess(board, true, 7, 7);
                color = !color;
            }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++) D2.Chess[i, j] = D.Chess[i, j] = 0;
            count = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            initializeGame();
            start.Visible = true;
            huiqi.Visible = false;
            label1.Visible = false;
        }
        private void initializeGame()
        {
            judge = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    ChessBoard[i, j] = 0;
                }
            Graphics g = board.CreateGraphics();
            Board.DrawBoard(g);
            chess.DrawinGame(board, ChessBoard);
            begin = false;
            start.Visible = true;
            restart.Visible = false;
            timer1.Stop();
            bar.Visible = false;
            AI_type = 0;
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 500; j++) D2.Chess[i,j]=D.Chess[i, j] = 0;
            count = 0;
            next.Visible = false;
            last.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Sizes.Formwidth;
            this.Height = Sizes.Formheight;
            this.Location = new Point(400, 75);
            start.Visible = false;
            label1.Visible = false;
            bar.Visible = false;
            huiqi.Visible = false;
        }
        private void quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = board.CreateGraphics();
            Board.DrawBoard(g);
            chess.DrawinGame(board, ChessBoard);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (begin)
            {
                int pX = e.X / Sizes.Gap;
                int pY = e.Y / Sizes.Gap;
                timer1.Start();
                if (AI_type == 0) huiqi.Visible = true;
                try
                {
                    if (ChessBoard[pX, pY] != 0) return;
                    hh.X = pX;
                    hh.Y = pY;
                    ChessBoard[pX, pY] = color ? 1 : 2;
                    D.Chess[0, count] = pX;
                    D.Chess[1, count] = pY;
                    count++;
                    chess.DrawChess(board, color, pX, pY);
                    judge=winjudgment.ChessJudgement(ChessBoard, color, pX, pY).win;
                    if (judge == 1)
                    {
                        count = 0;
                        begin = false;
                        timer1.Stop();
                        bar.Value = 100;
                        label1.Text = "游戏已经结束";
                        huiqi.Visible = false;
                        MessageBox.Show ("违背禁手，黑负"); 
                    }
                    else if (judge == 2&&color==true)
                    {
                        count = 0;
                        begin = false;
                        timer1.Stop();
                        bar.Value = 100;
                        huiqi.Visible = false;
                        label1.Text = "游戏已经结束";
                        MessageBox.Show("黑棋赢了");
                    }
                    else if (judge == 2 && color == false)
                    {
                        count = 0;
                        begin = false;
                        timer1.Stop();
                        huiqi.Visible = false;
                        bar.Value = 100;
                        label1.Text = "游戏已经结束";
                        MessageBox.Show("白棋赢了");
                    }
                    color = !color;
                    if (AI_type != 0)
                    {
                        judge = 0;
                        Point p = AI.AI_game(ChessBoard, color);
                        ChessBoard[p.X, p.Y] = color ? 1 : 2;
                        D.Chess[0, count] = p.X;
                        D.Chess[1, count] = p.Y;
                        chess.DrawChess(board, color, p.X, p.Y);
                        judge = winjudgment.ChessJudgement(ChessBoard, color, p.X, p.Y).win;
                        if (judge == 1)
                        { 
                            begin = false;
                            timer1.Stop();
                            bar.Value = 100;
                            label1.Text = "游戏已经结束";
                            MessageBox.Show("违背禁手，黑负");
                        }
                        else if (judge == 2 && color == true)
                        {
                            begin = false;
                            timer1.Stop();
                            bar.Value = 100;
                            label1.Text = "游戏已经结束";
                            MessageBox.Show("黑棋赢了");
                        }
                        else if (judge == 2 && color == false)
                        {
                            begin = false;
                            timer1.Stop();
                            bar.Value = 100;
                            label1.Text = "游戏已经结束";
                            MessageBox.Show("白棋赢了");
                        }
                        color = !color;
                    }
                    bar.Value = 100;
                }
                catch (Exception) { }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bar.Value > 0)
            {
                label1.Text = "剩余时间" + bar.Value/10+"秒";
                bar.Value--;
            }
            else if (bar.Value == 0 && color == true)
            {
                timer1.Stop();
                begin = false;
                bar.Value = 100;
                count = 0;
                AI_type = 0;
                MessageBox.Show("超时了，黑负");
            }
            else if (bar.Value == 0 && color == false)
            {
                timer1.Stop();
                begin = false;
                bar.Value = 100;
                count = 0;
                AI_type = 0;
                MessageBox.Show("超时了，白负");
            }
        }
        private void huiqi_Click(object sender, EventArgs e)
        {
            Graphics g = board.CreateGraphics();
            ChessBoard[hh.X, hh.Y] = 0;
            color = !color;
            count--;
            count = Math.Max(0, count);
            D.Chess[0, count + 1] = D.Chess[1, count + 1] = 0;
            Board.DrawBoard(g);
            chess.DrawinGame(board, ChessBoard);
            huiqi.Visible = false;
        }
        private void 先手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AI_type = 2;
            judge = 0;
            start.Visible = true;
        }
        private void 后手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AI_type = 1;
            ChessBoard[7, 7] = 1;
            judge = 0;
            start.Visible = true;
        }
        private void 人人对战ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start.Visible = true;
        }
        private void 存盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool jd=false ;
            timer1.Stop();
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    if (ChessBoard[i, j] != 0) jd = true;
            if (jd)
            {
                saveFileDialog1.ShowDialog();
                string s = "" + saveFileDialog1.FileName + ".da";
                FileStream fs = new FileStream(s, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, D);
                fs.Close();
                MessageBox.Show("存盘成功!");
            }
            else 
            {
                MessageBox.Show("请先进行游戏!");
            }
        }
        private void 复盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (begin == false)
            {
                openFileDialog1.ShowDialog();
                string s = "" + openFileDialog1.FileName;
                MessageBox.Show(s);
                FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                D2 = (Data)bf.Deserialize(fs);
                next.Visible = true;
                last.Visible = true;
                for (int i = 0; i < 15; i++)
                    for (int j = 0; j < 15; j++) ChessBoard[i, j] = 0;
                ChessBoard[D2.Chess[0, 0], D2.Chess[1, 0]] = 1;
                Graphics g = board.CreateGraphics();
                Board.DrawBoard(g);
                chess.DrawinGame(board, ChessBoard);
            }
            else 
            {
                MessageBox.Show("请先结束游戏！");
            }
        }
        private void last_Click(object sender, EventArgs e)
        {
            fupan--;
            fupan = Math.Max(fupan, 0);
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++) ChessBoard[i, j] = 0;
            Graphics g = board.CreateGraphics();
            Board.DrawBoard(g);
            for (int j = 0; j <= fupan; j++)
            {
                if (D2.Chess[0, j] == 0 && D2.Chess[1, j] == 0) break;
                if (j % 2 == 0) ChessBoard[D2.Chess[0, j], D2.Chess[1, j]] = 1;
                if (j % 2 == 1) ChessBoard[D2.Chess[0, j], D2.Chess[1, j]] = 2;
            }
            chess.DrawinGame(board, ChessBoard);
        }
        private void next_Click(object sender, EventArgs e)
        {
            fupan++;
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++) ChessBoard[i, j] = 0;
            ChessBoard[D2.Chess[0, 0], D2.Chess[1, 0]] = 1;
            Graphics g = board.CreateGraphics();
            Board.DrawBoard(g);
            for (int j = 0; j <= fupan; j++)
            {
                if (D2.Chess[0, j] == 0 && D2.Chess[1, j] == 0) break;
                if (j % 2 == 0) ChessBoard[D2.Chess[0, j], D2.Chess[1, j]] = 1;
                if (j % 2 == 1) ChessBoard[D2.Chess[0, j], D2.Chess[1, j]] = 2;
            }
            chess.DrawinGame(board, ChessBoard);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
           
        }

        private void 重新开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initializeGame();
            start.Visible = true;
            huiqi.Visible = false;
            label1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
              Application.Exit();
        }
    }
    [Serializable]
    public class Data
    {
        public int[,] Chess=new int [2,500];
    }
    partial class Sizes
    {
        public static int Formwidth { get { return 1500; } }
        public static int Formheight { get { return 1500; } }
        public static int Boardwidth { get { return 600; } }
        public static int Boardheight { get { return 600; } }
        public static int Gap { get { return 40; } }
        public static int ChessDiameter { get { return 36; } }
    }
    partial class Board
    {
        public static void DrawBoard(Graphics g)
        {
            int Gap = Sizes.Gap;
            int num = Sizes.Boardwidth / Gap - 1;
            g.Clear(Color.Bisque);
            Pen pen = new Pen(Color.FromArgb(192, 166, 107));
            for (int i = 0; i < num+1; i++)
            {
                g.DrawLine(pen, new Point(20, i * Gap + 20), new Point(Gap * num + 20, i * Gap + 20));
                g.DrawLine(pen, new Point(i * Gap + 20, 20), new Point(i * Gap + 20, Gap * num + 20));
            }
        }
    }
    partial class chess
    {
        public static void DrawChess(Panel p, bool myturn, int PX, int PY)
        {
            Graphics g = p.CreateGraphics();
            int AccurateX = PX * Sizes.Gap + 20 - 16;
            int AccurateY = PY * Sizes.Gap + 20 - 16;
            Rectangle C = new Rectangle(new Point(AccurateX, AccurateY), new Size(Sizes.ChessDiameter, Sizes.ChessDiameter));
            LinearGradientBrush LB = new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(122, 122, 122), Color.FromArgb(0, 0, 0));
            LinearGradientBrush LW = new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(255, 255, 255), Color.FromArgb(204, 204, 204));
            if (myturn)   g.FillEllipse(LB, C);
            else g.FillEllipse(LW, C);
        }
        public static void DrawinGame(Panel p, int[,] CheckBoard)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    int judge = CheckBoard[i,j];
                    if (judge!=0)
                    {
                        Graphics g = p.CreateGraphics();
                        int AccurateX = i * Sizes.Gap + 20 - 16;
                        int AccurateY = j * Sizes.Gap + 20 - 16;
                        Rectangle C = new Rectangle(new Point(AccurateX, AccurateY), new Size(Sizes.ChessDiameter, Sizes.ChessDiameter));
                        LinearGradientBrush LB = new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(122, 122, 122), Color.FromArgb(0, 0, 0));
                        LinearGradientBrush LW = new LinearGradientBrush(new Point(20, 0), new Point(20, 40), Color.FromArgb(255, 255, 255), Color.FromArgb(204, 204, 204));
                        if (judge==1)g.FillEllipse(LB, C);
                        else g.FillEllipse(LW, C);
                    }
                }
        }
    }
    struct result
    {
        public int livethree;
        public int livefour;
        public int win;
        public int rushfour;
    }
    struct findmood
    {
        public int one;
        public int two1;
        public int three;
        public int two2;
    }
    //带禁手
    partial class winjudgment
    {
        private static int win = 0;
        private static int[,] expandcb = new int[50, 50];
        private static int countthree;
        private static int countfour1 ;
        private static int countfour2 ;
        public static result ChessJudgement(int[,] chessboard,bool color, int pX, int pY)
        {
            result s = new result();
            win = 0;
            countthree = 0;
            countfour1 = 0;
            countfour2 = 0;
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (i < 7 || j < 7 || i > 21 || j > 21)
                    {
                        expandcb[i, j] = 3;
                    }
                    else
                    {
                        expandcb[i, j] = chessboard[i-7,j-7];
                    }
                }
            }
            pX = pX + 7;
            pY = pY + 7;
            int p = color ? 1 : 2;
            for (int i = pX - 3; i <= pX; i++)
            {
                int j = pY;
                if (Math.Max(expandcb[i - 1, j], expandcb[i + 4, j]) == 0 && Math.Min(expandcb[i, j], expandcb[i + 3, j]) == p)
                    if (Math.Min(expandcb[i + 1, j], expandcb[i + 2, j]) == 0 && Math.Max(expandcb[i + 1, j], expandcb[i + 2, j]) == p) countthree++;
            }
            for (int i = pX - 2; i <= pX; i++)
            {
                int j = pY;
                if (Math.Max(expandcb[i - 1, j], expandcb[i + 3, j]) == 0)
                    if (expandcb[i, j] == p && expandcb[i + 1, j] == p && expandcb[i + 2, j] == p) countthree++;
            }
            for (int i = pX - 3; i <= pX; i++)
            {
                int j = pY + pX - i;
                if (Math.Max(expandcb[i - 1, j + 1], expandcb[i + 4, j - 4]) == 0&&Math.Min(expandcb[i,j],expandcb[i+3,j-3])==p)
                    if (Math.Min(expandcb[i + 1, j-1], expandcb[i + 2, j-2]) == 0 && Math.Max(expandcb[i + 1, j-1], expandcb[i + 2, j-2]) == p) countthree++;

            }
            for (int i = pX - 2; i <= pX; i++)
            {
                int j = pY + pX - i;
                if (Math.Max(expandcb[i - 1, j + 1], expandcb[i + 3, j - 3])==0)
                    if (expandcb[i, j] == p && expandcb[i + 1, j-1] == p && expandcb[i + 2, j-2] == p) countthree++;

            }
            for (int i = pX + 3; i >= pX; i--)
            {
                int j = pY - pX + i;
                if (Math.Max(expandcb[i + 1, j + 1], expandcb[i - 4, j - 4]) == 0&& Math.Min(expandcb[i, j], expandcb[i - 3, j - 3]) == p)
                    if (Math.Min(expandcb[i - 1, j - 1], expandcb[i - 2, j - 2]) == 0 && Math.Max(expandcb[i - 1, j - 1], expandcb[i - 2, j - 2]) == p) countthree++;
            }
            for (int i = pX + 2; i >= pX; i--)
            {
                int j = pY - pX + i;
                if (Math.Max(expandcb[i + 1, j + 1], expandcb[i - 3, j - 3]) == 0)
                    if (expandcb[i, j] == p && expandcb[i -1, j-1] == p && expandcb[i - 2, j-2] == p) countthree++;

            }
            for (int j = pY - 3; j <= pY; j++)
            {
                int i = pX;
                if (Math.Max(expandcb[i , j-1], expandcb[i , j+4]) == 0&& Math.Min(expandcb[i, j], expandcb[i , j+3]) == p)
                    if (Math.Min(expandcb[i,j+1],expandcb[i,j+2])==0&& Math.Max(expandcb[i, j + 1], expandcb[i, j + 2]) == p) countthree++;
            }
            for (int j = pY - 2; j <= pY; j++)
            {
                int i = pX;
                if (Math.Max(expandcb[i, j - 1], expandcb[i, j + 3]) == 0)
                    if (expandcb[i, j] == p && expandcb[i, j + 1] == p && expandcb[i, j + 2] == p) countthree++;
            }
            for (int j = pY - 4; j <= pY; j++)
            {
                int i = pX;
                if (Math.Max(expandcb[i, j - 1], expandcb[i, j + 4]) == 0)
                {
                    int countblack = 0;
                    for (int n = j; n <= j + 3; n++)
                    {
                        int m = pX;
                        if (expandcb[m, n] == p) countblack++;
                    }
                    if (countblack == 4) countfour2++;
                }
            }
            for (int i = pX - 4; i <= pX; i++)
            {
                int j = pY;
                if (Math.Max(expandcb[i- 1, j ], expandcb[i + 4, j]) == 0)
                {
                    int countblack = 0;
                    for (int m = i; m <= i + 3; m++)
                    {
                        int n = pY;
                        if (expandcb[m, n] == p) countblack++;
                    }
                    if (countblack == 4) countfour2++;
                }
            }
            for (int i = pX + 4; i >= pX; i--)
            {
                int j = pY - pX + i;
                if (Math.Max(expandcb[i + 1, j + 1], expandcb[i - 4, j - 4]) == 0)
                {
                    int countblack = 0;
                    for (int m = i; m >= i - 3; m--)
                    {
                        int n = pY - pX + m;
                        if (expandcb[m, n] == p) countblack++;
                    }
                    if (countblack == 4) countfour2++;
                }
            }
            for (int i = pX - 4; i <= pX; i++)
            {
                int j = pY + pX - i;
                if (Math.Max(expandcb[i - 1, j + 1], expandcb[i + 4, j - 4]) == 0)
                {
                    int countblack = 0;
                    for (int m = i; m <= i + 3; m++)
                    {
                        int n = pY + pX - m;
                        if (expandcb[m, n] == p) countblack++;
                    }
                    if (countblack == 4) countfour2++;
                }
            }
            for (int i = pX - 4; i <= pX; i++)
            {
                int countblack = 0;
                int countempty = 0;
                int j = pY + pX - i;
                for (int m = i; m < i + 5; m++)
                {
                    int n = pY + pX - m;
                    if (expandcb[m, n] == p) countblack++;
                    else if (expandcb[m, n] == 0) countempty++;
                }
                if (countblack == 4 && countempty == 1 && Math.Min(expandcb[i, j], expandcb[i + 4, j - 4]) == p) countfour1++;
            }
            for (int i = pX + 4; i >= pX; i--)
            {
                int countblack = 0;
                int countempty = 0;
                int j = pY - pX + i;
                for (int m = i; m > i - 5; m--)
                {
                    int n = pY - pX + m;
                    if (expandcb[m, n] == p) countblack++;
                    else if (expandcb[m, n] == 0) countempty++;
                }
                if (countblack == 4 && countempty == 1 && Math.Min(expandcb[i, j], expandcb[i - 4, j - 4]) == p) countfour1++;
            }
            for (int i = pX - 4; i <= pX; i++)
            {
                int countblack = 0;
                int countempty = 0;
                int j = pY;
                for (int m = i; m < i + 5; m++)
                {
                    int n = pY;
                    if (expandcb[m, n] == p)   countblack++;
                    else if (expandcb[m, n] == 0)   countempty++;
                }
                if (countblack == 4 && countempty == 1 && Math.Min(expandcb[i, j], expandcb[i + 4, j]) == p) countfour1++;
            }
            for (int i = pY - 4; i <= pY; i++)
            {
                int countblack = 0;
                int countempty = 0;
                int j = pX;
                for (int n = i; n < i + 5; n++)
                {
                    int m = pX;
                    if (expandcb[m, n] == p) countblack++;
                    else if (expandcb[m, n] == 0) countempty++;
                }
                if (countblack == 4 && countempty == 1 && Math.Min(expandcb[j, i], expandcb[j, i + 4]) == p) countfour1++;
            }
            int x = pX;
            int y = pY;
            int[] count = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                x = pX ;
                y = pY ;
                switch (i) 
                {
                    case 0:
                        {
                            while (expandcb[++x, ++y] == p) continue;
                            while (expandcb[--x, --y] == p) ++count[i];
                            break;
                        }
                    case 1:
                        {
                            while (expandcb[++x, y] == p) continue;
                            while (expandcb[--x, y] == p) ++count[i];
                            break;
                        }
                    case 2:
                        {
                            while (expandcb[++x, --y] == p) continue;
                            while (expandcb[--x, ++y] == p) ++count[i];
                            break;
                        }
                    case 3:
                        {
                            while (expandcb[x, ++y] == p) continue;
                            while (expandcb[x, --y] == p) ++count[i];
                            break;
                        }
                }
            }
            s.livethree = countthree;
            s.rushfour = countfour1;
            s.livefour = countfour2;
            for (int i = 0; i < 4; i++)
            {
                if (count[i] == 5)
                { 
                    win = 2;
                    s.win = win;
                    return s;
                }
                else if (count[i] > 5&&color==true)
                {
                    win = 1;
                }
            }
            if((countthree >= 2 || (countfour1+countfour2) >= 2)&&color==true)
            {
                win = 1;
            }
            s.win = win;
            return s;
        }
    }
    partial class findfunc
    {
        public static findmood find(int[,] chessboard,bool color, int x, int y)
        {
            findmood f = new findmood();
            f.one = f.two1 = f.two2 = f.three = 0;
            int[,] expandcb = new int[50, 50];
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (i < 7 || j < 7 || i > 21 || j > 21)
                    {
                        expandcb[i, j] = 3;
                    }
                    else
                    {
                        expandcb[i, j] = chessboard[i - 7, j - 7];
                    }
                }
            }
            x = x + 7;
            y = y + 7;
            int p = color ? 1 : 2;
            //数1
            if (expandcb[x - 1, y] == 0 && expandcb[x, y + 1] == 0 && expandcb[x, y - 1] == 0 && expandcb[x + 1, y] == 0) f.one++;
            //数2
            if (expandcb[x - 1, y] == p && Math.Min(expandcb[x - 2, y], expandcb[x + 1, y]) == 0 && Math.Max(expandcb[x - 2, y], expandcb[x + 1, y]) == 3-p) f.two1++;
            else if (expandcb[x - 1, y] == p && Math.Min(expandcb[x - 2, y], expandcb[x + 1, y]) == 0) f.two2++;
            if (expandcb[x+1, y] == p && Math.Min(expandcb[x +2, y], expandcb[x -1, y]) == 0 && Math.Max(expandcb[x + 2, y], expandcb[x - 1, y]) == 3-p) f.two1++;
            else if (expandcb[x + 1, y] == p && Math.Min(expandcb[x + 2, y], expandcb[x - 1, y]) == 0) f.two2++;
            if (expandcb[x , y-1] == p && Math.Min(expandcb[x , y- 2], expandcb[x , y+ 1]) == 0 && Math.Max(expandcb[x, y - 2], expandcb[x , y+ 1]) == 3-p) f.two1++;
            else if (expandcb[x , y- 1] == p && Math.Min(expandcb[x , y- 2], expandcb[x , y+ 1]) == 0) f.two2++;
            if (expandcb[x , y+ 1] == p && Math.Min(expandcb[x , y+ 2], expandcb[x , y- 1]) == 0 && Math.Max(expandcb[x , y+ 2], expandcb[x , y- 1]) == 3 - p) f.two1++;
            else if (expandcb[x , y+ 1] == p && Math.Min(expandcb[x , y+ 2], expandcb[x , y- 1]) == 0) f.two2++;
            if (expandcb[x + 1, y+1] == p && Math.Min(expandcb[x + 2, y+2], expandcb[x - 1, y-1]) == 0 && Math.Max(expandcb[x + 2, y+2], expandcb[x - 1, y-1]) == 3 - p) f.two1++;
            else if (expandcb[x + 1, y+1] == p && Math.Min(expandcb[x + 2, y+2], expandcb[x - 1, y-1]) == 0) f.two2++;
            if (expandcb[x - 1, y - 1] == p && Math.Min(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 0 && Math.Max(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 3 - p) f.two1++;
            else if (expandcb[x - 1, y - 1] == p && Math.Min(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 0) f.two2++;
            if (expandcb[x + 1, y - 1] == p && Math.Min(expandcb[x + 2, y - 2], expandcb[x - 1, y + 1]) == 0 && Math.Max(expandcb[x + 2, y - 2], expandcb[x - 1, y - 1]) == 3 - p) f.two1++;
            else if (expandcb[x + 1, y + 1] == p && Math.Min(expandcb[x + 2, y + 2], expandcb[x - 1, y - 1]) == 0) f.two2++;
            if (expandcb[x - 1, y - 1] == p && Math.Min(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 0 && Math.Max(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 3 - p) f.two1++;
            else if (expandcb[x - 1, y - 1] == p && Math.Min(expandcb[x - 2, y - 2], expandcb[x + 1, y + 1]) == 0) f.two2++;
            for (int i = x - 2; i <= x; i++)
            {
                int j = y;
                if (Math.Max(expandcb[i - 1, j], expandcb[i + 3, j]) == 3 - p && Math.Min(expandcb[i - 1, j], expandcb[i + 3, j]) == 0)
                    if (expandcb[i, j] == p && expandcb[i + 1, j] == p && expandcb[i + 2, j] == p) f.three++;
            }
            for (int j = y - 2; j <= y; j++)
            {
                int i = x;
                if (Math.Max(expandcb[i , j-1], expandcb[i , j+ 3]) == 3 - p && Math.Min(expandcb[i , j- 1], expandcb[i , j+ 3]) == 0)
                    if (expandcb[i, j] == p && expandcb[i , j+ 1] == p && expandcb[i , j+ 2] == p) f.three++;
            }
            for (int i = x + 2; i >= x; i--)
            {
                int j = y-x + i;
                if (Math.Max(expandcb[i+1, j +1], expandcb[i-3, j -3]) == 3 - p && Math.Min(expandcb[i+1, j +1], expandcb[i-3, j -3]) == 0)
                    if (expandcb[i, j] == p && expandcb[i-1, j - 1] == p && expandcb[i-2, j - 2] == p) f.three++;
            }
            for (int i = x + 2; i >= x; i--)
            {
                int j = x + y - i;
                if (Math.Max(expandcb[i + 1, j - 1], expandcb[i - 3, j + 3]) == 3 - p && Math.Min(expandcb[i + 1, j - 1], expandcb[i -3 , j + 3]) == 0)
                    if (expandcb[i, j] == p && expandcb[i - 1, j + 1] == p && expandcb[i - 2, j + 2] == p) f.three++;
            }
            return f;

        }
    }
    partial class AI
    {
        public static Point AI_game(int[,] chessboard,bool color)
        {
            Point p = new Point();
            double score = 0;
            double temp = 0;
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (chessboard[i, j] == 0)
                    {
                        chessboard[i, j] = color?1:2;
                        findmood f1 = findfunc.find(chessboard, color, i, j);
                        result s1 = winjudgment.ChessJudgement(chessboard, color, i, j);
                        if (s1.win == 2)
                        {
                            p.X = i;
                            p.Y = j;
                            return p;
                        }
                        if (s1.win == 1) temp -= 100000;
                        temp += f1.one + f1.two1 * 5 + f1.two2 * 10 + f1.three * 50 + s1.livethree * 100 + s1.rushfour * 500 + s1.livefour * 1000;
                        if (f1.two2 >= 2) temp += 20;
                        if (s1.livethree >= 2) temp += 200;
                        if (s1.rushfour >= 2) temp += 500;
                        if (s1.livefour >= 2) temp += 2000;
                        chessboard[i, j] = !color ? 1 : 2;
                        findmood f2 = findfunc.find(chessboard, !color, i, j);
                        result s2 = winjudgment.ChessJudgement(chessboard, !color, i, j);
                        if (s2.win == 2)
                        {
                            p.X = i;
                            p.Y = j;
                            return p;
                        }
                        temp += 0.75 * (f2.one + f2.two1 * 5 + f2.two2 * 10 + f2.three * 50 + s2.livethree * 100 + s2.rushfour * 500 + s2.livefour * 1000);
                        if (s2.win == 1) temp -= 100000;
                        if (f1.two2 >= 2) temp += 0.75*20;
                        if (s1.livethree >= 2) temp += 0.75*200;
                        if (s1.rushfour >= 2) temp += 0.75*500;
                        if (s1.livefour >= 2) temp += 0.75*2000;
                        if (temp > score)
                        {
                            p.X = i;
                            p.Y = j;
                            score = temp;
                            temp = 0;
                        }
                        temp = 0;
                        chessboard[i, j] = 0;
                    }
                }
            return p;
        }
    }
} 