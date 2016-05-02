namespace Tetris
{
    partial class TetrisGround
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.lbGameOver = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tmDown = new System.Windows.Forms.Timer(this.components);
            this.lbLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbLines = new System.Windows.Forms.Label();
            this.lbPause = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlNextBlock = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(90, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "F1";
            // 
            // lbGameOver
            // 
            this.lbGameOver.AutoSize = true;
            this.lbGameOver.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbGameOver.Font = new System.Drawing.Font("华文琥珀", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbGameOver.ForeColor = System.Drawing.Color.Red;
            this.lbGameOver.Location = new System.Drawing.Point(29, 186);
            this.lbGameOver.Name = "lbGameOver";
            this.lbGameOver.Size = new System.Drawing.Size(155, 36);
            this.lbGameOver.TabIndex = 10;
            this.lbGameOver.Text = "游戏结束";
            this.lbGameOver.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(43, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "帮助：";
            // 
            // tmDown
            // 
            this.tmDown.Enabled = true;
            this.tmDown.Interval = 70;
            this.tmDown.Tick += new System.EventHandler(this.tmDown_Tick);
            // 
            // lbLevel
            // 
            this.lbLevel.BackColor = System.Drawing.Color.Transparent;
            this.lbLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLevel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLevel.Location = new System.Drawing.Point(92, 244);
            this.lbLevel.Name = "lbLevel";
            this.lbLevel.Size = new System.Drawing.Size(25, 19);
            this.lbLevel.TabIndex = 7;
            this.lbLevel.Text = "0";
            this.lbLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(52, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "当前关卡";
            // 
            // lbScore
            // 
            this.lbScore.BackColor = System.Drawing.Color.Transparent;
            this.lbScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbScore.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbScore.Location = new System.Drawing.Point(41, 61);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(85, 19);
            this.lbScore.TabIndex = 5;
            this.lbScore.Text = "0";
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbLines
            // 
            this.lbLines.BackColor = System.Drawing.Color.Transparent;
            this.lbLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLines.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLines.Location = new System.Drawing.Point(57, 18);
            this.lbLines.Name = "lbLines";
            this.lbLines.Size = new System.Drawing.Size(62, 19);
            this.lbLines.TabIndex = 4;
            this.lbLines.Text = "0";
            this.lbLines.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPause
            // 
            this.lbPause.AutoSize = true;
            this.lbPause.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbPause.Font = new System.Drawing.Font("华文琥珀", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPause.ForeColor = System.Drawing.Color.Red;
            this.lbPause.Location = new System.Drawing.Point(29, 186);
            this.lbPause.Name = "lbPause";
            this.lbPause.Size = new System.Drawing.Size(155, 36);
            this.lbPause.TabIndex = 11;
            this.lbPause.Text = "游戏结束";
            this.lbPause.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbLevel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbScore);
            this.panel1.Controls.Add(this.lbLines);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnlNextBlock);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(202, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 337);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(78, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "得分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(40, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "已消除行数";
            // 
            // pnlNextBlock
            // 
            this.pnlNextBlock.BackColor = System.Drawing.Color.Transparent;
            this.pnlNextBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNextBlock.Location = new System.Drawing.Point(19, 109);
            this.pnlNextBlock.Name = "pnlNextBlock";
            this.pnlNextBlock.Size = new System.Drawing.Size(86, 92);
            this.pnlNextBlock.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(78, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "下一个";
            // 
            // TetrisGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbGameOver);
            this.Controls.Add(this.lbPause);
            this.Controls.Add(this.panel1);
            this.Name = "TetrisGround";
            this.Size = new System.Drawing.Size(347, 345);
            this.Load += new System.EventHandler(this.TetrisGround_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BlockGround_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbGameOver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmDown;
        private System.Windows.Forms.Label lbLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbLines;
        private System.Windows.Forms.Label lbPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlNextBlock;
        private System.Windows.Forms.Label label1;
    }
}
