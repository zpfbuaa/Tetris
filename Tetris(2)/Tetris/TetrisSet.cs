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
    public partial class TetrisSet : Form
    {
    

        public TetrisSet()
        {
            InitializeComponent();

            tbLeftKey.Text = TetrisConfig.LeftKey;
            tbRightKey.Text = TetrisConfig.RightKey;
            tbDownKey.Text = TetrisConfig.DownKey;
            tbTransformKey.Text = TetrisConfig.TransformKey;
            tbConfirmKey.Text = TetrisConfig.ConfirmKey;

            if (TetrisConfig.MusicOn)
                rbtMusicOn.Checked = true;
            else
                rbtMusicOff.Checked = true;

            if (TetrisConfig.SoundOn)
                rbtSoundOn.Checked = true;
            else
                rbtSoundOff.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            TetrisConfig.LeftKey = tbLeftKey.Text;
            TetrisConfig.RightKey = tbRightKey.Text;
            TetrisConfig.DownKey = tbDownKey.Text;
            TetrisConfig.TransformKey = tbTransformKey.Text;
            TetrisConfig.ConfirmKey = tbConfirmKey.Text;

            TetrisConfig.MusicOn = rbtMusicOn.Checked;
            TetrisConfig.SoundOn = rbtSoundOn.Checked;

            this.Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //取输入键值和相应文本框控件
            string str = e.KeyData.ToString();
            TextBox textBox2 = (TextBox)sender;
            //检查输入键是否与其他操作有冲突
            if (CheckInputKey(tbLeftKey, textBox2, str) && CheckInputKey(tbRightKey, textBox2, str)
                && CheckInputKey(tbDownKey, textBox2, str) && CheckInputKey(tbTransformKey, textBox2, str)
                && CheckInputKey(tbConfirmKey, textBox2, str))
            {
                textBox2.Text = e.KeyData.ToString();
            }
            else
            {
                //如有冲突，提示错误消息
                MessageBox.Show(TetrisResource.SameKey, TetrisResource.Error);
            }
        }

        /// <summary>
        /// 输入键检查函数
        /// </summary>
        /// <param name="textBox1">对比输入文本框</param>
        /// <param name="textBox2">源输入文本框</param>
        /// <param name="str">输入键码</param>
        /// <returns>返回布尔值</returns>
        private bool CheckInputKey(TextBox textBox1, TextBox textBox2, string str)
        {
            if (textBox1 != textBox2 && textBox1.Text == str)
            {
                return false;
            }

            return true;
        }
    }
}
