using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisMainForm : Form
    {
        bool lostFocus = false;
        public TetrisMainForm()
        {
            InitializeComponent();
        }


        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tetrisGround1.State = GameState.Run;
        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.tetrisGround1.State == GameState.Run)
            {
                this.tetrisGround1.State = GameState.Pause;
            }
            else if (this.tetrisGround1.State == GameState.Pause)
            {
                this.tetrisGround1.State = GameState.Run;
            }
            this.SetPauseMenuText();
        }

        private void 暂停ToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            if (this.tetrisGround1.State == GameState.Run || this.tetrisGround1.State == GameState.Pause)
            {
                this.暂停ToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.暂停ToolStripMenuItem.Enabled = false;
            }
            SetPauseMenuText();
        }

        /// <summary>
        /// 设置暂停菜单文本
        /// </summary>
        private void SetPauseMenuText()
        {
            if (this.tetrisGround1.State == GameState.Pause)
            {
                this.暂停ToolStripMenuItem.Text = TetrisResource.Continue;
            }
            else if (this.tetrisGround1.State == GameState.Run)
            {
                this.暂停ToolStripMenuItem.Text = TetrisResource.PauseMenu;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tetrisGround1.About();
        }

        private void Level_Click(object sender, EventArgs e)
        {
            if (this.tetrisGround1.State != GameState.Run && this.tetrisGround1.State != GameState.Pause)
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;
                this.tetrisGround1.LevelNumber = Convert.ToInt32((string)menu.Tag);
                menu.Checked = true;
            }
        }

        private void Level_Paint(object sender, PaintEventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            menu.Checked = (this.tetrisGround1.LevelNumber == Convert.ToInt32((string)menu.Tag));
            if (this.tetrisGround1.State != GameState.Run && this.tetrisGround1.State != GameState.Pause)
            {
                menu.Enabled = true;
            }
            else
            {
                menu.Enabled = false;
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TetrisSet().ShowDialog();
        }

        private void 设置ToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            if (this.tetrisGround1.State == GameState.Run)
                menu.Enabled = false;
            else
                menu.Enabled = true;
        }

        private void 排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(HighScore.HighScoreListToString(), "高分排行榜");
        }

        private void TrisMainForm_Deactivate(object sender, EventArgs e)
        {
            if (this.tetrisGround1.State == GameState.Run)
            {
                this.tetrisGround1.State = GameState.Pause;
                lostFocus = true;
            }
        }

        private void TrisMainForm_Activated(object sender, EventArgs e)
        {
            if (lostFocus)
            {
                this.tetrisGround1.State = GameState.Run;
                lostFocus = false;
            }
        }
    }
}
