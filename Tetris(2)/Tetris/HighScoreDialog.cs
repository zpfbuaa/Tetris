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
    public partial class HighScoreDialog : Form
    {
        public HighScoreDialog()
        {
            InitializeComponent();
        }

        int score;
        int order;

        public HighScoreDialog(int order, int score)
        {
            InitializeComponent();
            this.score = score;
            this.order = order;
            this.lbOrder.Text = order.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            HighScore.Insert(order, tbName.Text, score);
            HighScore.Save();
            this.Close();
        }
    }
}
