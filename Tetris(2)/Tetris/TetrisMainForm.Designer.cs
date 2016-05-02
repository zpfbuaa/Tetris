namespace Tetris
{
    partial class TetrisMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第一关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第二关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第三关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第四关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第五关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第六关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第七关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tetrisGround1 = new Tetris.TetrisGround();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.关卡ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(430, 25);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "游戏";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.暂停ToolStripMenuItem,
            this.toolStripSeparator1,
            this.设置ToolStripMenuItem,
            this.toolStripSeparator3,
            this.排行榜ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            this.暂停ToolStripMenuItem.Click += new System.EventHandler(this.暂停ToolStripMenuItem_Click);
            this.暂停ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.暂停ToolStripMenuItem_Paint);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            this.设置ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.设置ToolStripMenuItem_Paint);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(124, 6);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.排行榜ToolStripMenuItem.Text = "排行榜";
            this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.排行榜ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(124, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.ShortcutKeyDisplayString = "Esc";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 关卡ToolStripMenuItem
            // 
            this.关卡ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.第一关ToolStripMenuItem,
            this.第二关ToolStripMenuItem,
            this.第三关ToolStripMenuItem,
            this.第四关ToolStripMenuItem,
            this.第五关ToolStripMenuItem,
            this.第六关ToolStripMenuItem,
            this.第七关ToolStripMenuItem});
            this.关卡ToolStripMenuItem.Name = "关卡ToolStripMenuItem";
            this.关卡ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关卡ToolStripMenuItem.Text = "关卡";
            // 
            // 第一关ToolStripMenuItem
            // 
            this.第一关ToolStripMenuItem.Checked = true;
            this.第一关ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.第一关ToolStripMenuItem.Name = "第一关ToolStripMenuItem";
            this.第一关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第一关ToolStripMenuItem.Tag = "1";
            this.第一关ToolStripMenuItem.Text = "第一关";
            this.第一关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第一关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第二关ToolStripMenuItem
            // 
            this.第二关ToolStripMenuItem.Name = "第二关ToolStripMenuItem";
            this.第二关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第二关ToolStripMenuItem.Tag = "2";
            this.第二关ToolStripMenuItem.Text = "第二关";
            this.第二关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第二关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第三关ToolStripMenuItem
            // 
            this.第三关ToolStripMenuItem.Name = "第三关ToolStripMenuItem";
            this.第三关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第三关ToolStripMenuItem.Tag = "3";
            this.第三关ToolStripMenuItem.Text = "第三关";
            this.第三关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第三关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第四关ToolStripMenuItem
            // 
            this.第四关ToolStripMenuItem.Name = "第四关ToolStripMenuItem";
            this.第四关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第四关ToolStripMenuItem.Tag = "4";
            this.第四关ToolStripMenuItem.Text = "第四关";
            this.第四关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第四关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第五关ToolStripMenuItem
            // 
            this.第五关ToolStripMenuItem.Name = "第五关ToolStripMenuItem";
            this.第五关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第五关ToolStripMenuItem.Tag = "5";
            this.第五关ToolStripMenuItem.Text = "第五关";
            this.第五关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第五关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第六关ToolStripMenuItem
            // 
            this.第六关ToolStripMenuItem.Name = "第六关ToolStripMenuItem";
            this.第六关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第六关ToolStripMenuItem.Tag = "6";
            this.第六关ToolStripMenuItem.Text = "第六关";
            this.第六关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第六关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 第七关ToolStripMenuItem
            // 
            this.第七关ToolStripMenuItem.Name = "第七关ToolStripMenuItem";
            this.第七关ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.第七关ToolStripMenuItem.Tag = "7";
            this.第七关ToolStripMenuItem.Text = "第七关";
            this.第七关ToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            this.第七关ToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Level_Paint);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // tetrisGround1
            // 
            this.tetrisGround1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(180)))), ((int)(((byte)(240)))));
            this.tetrisGround1.LevelNumber = 1;
            this.tetrisGround1.Location = new System.Drawing.Point(15, 28);
            this.tetrisGround1.Name = "tetrisGround1";
            this.tetrisGround1.Size = new System.Drawing.Size(396, 455);
            this.tetrisGround1.State = Tetris.GameState.Wait;
            this.tetrisGround1.TabIndex = 2;
            // 
            // TetrisMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(430, 496);
            this.Controls.Add(this.tetrisGround1);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.Name = "TetrisMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "俄罗斯方块";
            this.Activated += new System.EventHandler(this.TrisMainForm_Activated);
            this.Deactivate += new System.EventHandler(this.TrisMainForm_Deactivate);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第一关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第二关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第三关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第四关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第五关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第六关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第七关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private TetrisGround tetrisGround1;

    }
}