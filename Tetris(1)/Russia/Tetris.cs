using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RussiaLibrary;
using System.Threading;

namespace Russia
{
    /// <summary>
    /// 界面方法类
    /// </summary>
    public partial class Tetris : Form
    {
        Class_ControlArray _control = new Class_ControlArray();
        Paint pan;
        int interTime;
        delegate void DelegateMethod();

        //初始化界面。
        public Tetris()
        {
            InitializeComponent();
            Show();
            pan = new Paint(this.panelAll);
            pan.FillPanel(_control.Bytes_TetrisByte);
        }

        //点击开始。开启线程。
        private void button_Begin_Click(object sender, EventArgs e)
        {
            interTime = 200;
            Thread th = new Thread(new ParameterizedThreadStart(BeginGame));
            th.Start(interTime);
        }
        
        private void BeginGame(object interTime)
        {
            DelegateMethod dm = new DelegateMethod(GameOver);
            _control = new Class_ControlArray();
            while (true)//无限循环：生成方块----下落----落底----生成方块。
            {
                if (!_control.InitPolygon())
                {
                    break;
                }
                while (true)
                {
                    lock (Class_Common.TetrisLocker)
                    {
                        pan.FillPanel(_control.Bytes_TetrisByte);
                        if (!_control.MoveDown())
                        {
                            break;
                        }
                    }
                    Thread.Sleep((int)interTime);//调节下落速度。
                }
            }
            Invoke(dm);
        }

        private void GameOver() 
        {
            pan.DrawGameOver();
        }

        //捕获键盘上下左右按键的事件。
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            lock (Class_Common.TetrisLocker)
            {
                switch (keyData)
                {
                    case Keys.Right:
                        _control.MoveLeftOrRight("MoveRight");
                        break;
                    case Keys.Left:
                        _control.MoveLeftOrRight("MoveLeft");
                        break;
                    case Keys.Up:
                        _control.Change();//还没有实现好，只是对外接口。
                        break;
                    case Keys.Down:
                        _control.MoveToEnd();
                        break;
                }
                pan.FillPanel(_control.Bytes_TetrisByte);
            }
            return true;
        }
    }
}
