namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.board = new System.Windows.Forms.Panel();
            this.next = new System.Windows.Forms.Button();
            this.last = new System.Windows.Forms.Button();
            this.huiqi = new System.Windows.Forms.Button();
            this.bar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.quit = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gametypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人人对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人机对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.先手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.后手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.SystemColors.Info;
            this.board.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.board.Location = new System.Drawing.Point(12, 38);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(924, 912);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.SystemColors.Info;
            this.next.Location = new System.Drawing.Point(174, 649);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 36);
            this.next.TabIndex = 7;
            this.next.Text = "下一步";
            this.next.UseVisualStyleBackColor = false;
            this.next.Visible = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // last
            // 
            this.last.BackColor = System.Drawing.SystemColors.Info;
            this.last.Location = new System.Drawing.Point(60, 649);
            this.last.Name = "last";
            this.last.Size = new System.Drawing.Size(77, 37);
            this.last.TabIndex = 6;
            this.last.Text = "上一步";
            this.last.UseVisualStyleBackColor = false;
            this.last.Visible = false;
            this.last.Click += new System.EventHandler(this.last_Click);
            // 
            // huiqi
            // 
            this.huiqi.BackColor = System.Drawing.SystemColors.Info;
            this.huiqi.Location = new System.Drawing.Point(60, 708);
            this.huiqi.Name = "huiqi";
            this.huiqi.Size = new System.Drawing.Size(190, 55);
            this.huiqi.TabIndex = 5;
            this.huiqi.Text = "悔棋";
            this.huiqi.UseVisualStyleBackColor = false;
            this.huiqi.Visible = false;
            this.huiqi.Click += new System.EventHandler(this.huiqi_Click);
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(60, 369);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(190, 43);
            this.bar.TabIndex = 4;
            this.bar.Value = 100;
            this.bar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // quit
            // 
            this.quit.BackColor = System.Drawing.SystemColors.Info;
            this.quit.Location = new System.Drawing.Point(60, 803);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(190, 67);
            this.quit.TabIndex = 2;
            this.quit.Text = "退出";
            this.quit.UseVisualStyleBackColor = false;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.SystemColors.Info;
            this.restart.Location = new System.Drawing.Point(60, 167);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(190, 66);
            this.restart.TabIndex = 1;
            this.restart.Text = "重新开始";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Visible = false;
            this.restart.Click += new System.EventHandler(this.button2_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.Info;
            this.start.Location = new System.Drawing.Point(58, 60);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(192, 63);
            this.start.TabIndex = 0;
            this.start.Text = " 开始游戏";
            this.start.UseVisualStyleBackColor = false;
            this.start.Visible = false;
            this.start.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gametypeToolStripMenuItem,
            this.存盘ToolStripMenuItem,
            this.复盘ToolStripMenuItem,
            this.重新开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1194, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gametypeToolStripMenuItem
            // 
            this.gametypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人人对战ToolStripMenuItem,
            this.人机对战ToolStripMenuItem});
            this.gametypeToolStripMenuItem.Name = "gametypeToolStripMenuItem";
            this.gametypeToolStripMenuItem.Size = new System.Drawing.Size(114, 28);
            this.gametypeToolStripMenuItem.Text = "gametype";
            // 
            // 人人对战ToolStripMenuItem
            // 
            this.人人对战ToolStripMenuItem.Name = "人人对战ToolStripMenuItem";
            this.人人对战ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.人人对战ToolStripMenuItem.Text = "人人对战";
            this.人人对战ToolStripMenuItem.Click += new System.EventHandler(this.人人对战ToolStripMenuItem_Click);
            // 
            // 人机对战ToolStripMenuItem
            // 
            this.人机对战ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.先手ToolStripMenuItem,
            this.后手ToolStripMenuItem});
            this.人机对战ToolStripMenuItem.Name = "人机对战ToolStripMenuItem";
            this.人机对战ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.人机对战ToolStripMenuItem.Text = "人机对战";
            // 
            // 先手ToolStripMenuItem
            // 
            this.先手ToolStripMenuItem.Name = "先手ToolStripMenuItem";
            this.先手ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.先手ToolStripMenuItem.Text = "AI后手";
            this.先手ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.先手ToolStripMenuItem.Click += new System.EventHandler(this.先手ToolStripMenuItem_Click);
            // 
            // 后手ToolStripMenuItem
            // 
            this.后手ToolStripMenuItem.Name = "后手ToolStripMenuItem";
            this.后手ToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.后手ToolStripMenuItem.Text = "AI先手";
            this.后手ToolStripMenuItem.Click += new System.EventHandler(this.后手ToolStripMenuItem_Click);
            // 
            // 存盘ToolStripMenuItem
            // 
            this.存盘ToolStripMenuItem.Name = "存盘ToolStripMenuItem";
            this.存盘ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.存盘ToolStripMenuItem.Text = "存盘";
            this.存盘ToolStripMenuItem.Click += new System.EventHandler(this.存盘ToolStripMenuItem_Click);
            // 
            // 复盘ToolStripMenuItem
            // 
            this.复盘ToolStripMenuItem.Name = "复盘ToolStripMenuItem";
            this.复盘ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.复盘ToolStripMenuItem.Text = "复盘";
            this.复盘ToolStripMenuItem.Click += new System.EventHandler(this.复盘ToolStripMenuItem_Click);
            // 
            // 重新开始ToolStripMenuItem
            // 
            this.重新开始ToolStripMenuItem.Name = "重新开始ToolStripMenuItem";
            this.重新开始ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.重新开始ToolStripMenuItem.Text = "重新开始";
            this.重新开始ToolStripMenuItem.Click += new System.EventHandler(this.重新开始ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.next);
            this.panel2.Controls.Add(this.last);
            this.panel2.Controls.Add(this.huiqi);
            this.panel2.Controls.Add(this.bar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.quit);
            this.panel2.Controls.Add(this.restart);
            this.panel2.Controls.Add(this.start);
            this.panel2.Location = new System.Drawing.Point(914, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 907);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 950);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.board);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gametypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人人对战ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人机对战ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button huiqi;
        private System.Windows.Forms.ToolStripMenuItem 先手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 后手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 存盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复盘ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button last;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem 重新开始ToolStripMenuItem;
    }
}

