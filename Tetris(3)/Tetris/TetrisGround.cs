using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace Tetris
{
    public partial class TetrisGround : UserControl
    {

        public TetrisCanvas NewCanvas = null;  
        //当前方块
        Block_Base curBlock;
        //下一个方块
        Block_Base nextBlock;
        
        //游戏状态
        GameState state;
      
        //同步对象
        readonly object syncObj = new object();
      
        //当前方块是否为新方块
        public bool NewBlockFlag
        {
            get { return NewCanvas.NewBlockFlag; }
            set { NewCanvas.NewBlockFlag = value; }
        }

        /// <summary>
        /// 游戏状态
        /// </summary>
        public GameState State
        {
            get { return this.state; }
            set { SetState(value); }
        }

        /// <summary>
        /// 当前是否处于游戏状态
        /// </summary>
        public bool IsRunning
        {
            get { return NewCanvas.State == GameState.Run; }
        }

        /// <summary>
        /// 当前等级数
        /// </summary>
        public int LevelNumber
        {
            get { return NewCanvas.LevelNumber; }
            set { NewCanvas.LevelNumber = value; }
        }

        public TetrisGround()
        {
            InitializeComponent();

            NewCanvas = new TetrisCanvas();
            NewCanvas.nextHandle = pnlNextBlock.Handle;
            NewCanvas.winHandle = this.Handle;

            //设置背景图片
            NewCanvas.SetBackPic();
             this.BackColor = Color.FromArgb(135, 180, 240);          
            
           
            this.lbPause.Text = TetrisResource.PauseDescript;
            this.lbGameOver.Text = TetrisResource.GameOver;

            //设置游戏状态
            this.State = GameState.Wait;          

            //消除重绘时引起的闪烁
            SetStyle(ControlStyles.UserPaint, true);
            //禁止擦除背景
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //双缓冲
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// 设置游戏状态
        /// </summary>
        /// <param name="state"></param>
        private void SetState(GameState state)
        {
            if (state == GameState.Run)
            {
                if (NewCanvas.State == GameState.Pause && TetrisConfig.MusicOn)
                {
                    NewCanvas.soundMusic.Resume();
                }
                if (NewCanvas.State == GameState.Wait || NewCanvas.State == GameState.Over || NewCanvas.State == GameState.Run)
                {
                    NewCanvas.State = state;
                    this.state = state;
                    ReStart();
                }
            }

            this.state = state;
            NewCanvas.State = state;

            if (NewCanvas.State == GameState.Pause)
            {
                NewCanvas.soundMusic.Pause();
            }
            else if (NewCanvas.State == GameState.Over)
            {
                NewCanvas.soundMusic.Close();
            }

            this.lbPause.Visible = (NewCanvas.State == GameState.Pause);
            this.lbGameOver.Visible = (NewCanvas.State == GameState.Over);
        }  
       

        /// <summary>
        /// 背景重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlockGround_Paint(object sender, PaintEventArgs e)
        {
            //绘制背景
            NewCanvas.DrawBackPic(e.Graphics);
            //绘制下一个方块图片
            NewCanvas.DrawNextBlock(nextBlock);
        }           

        /// <summary>
        /// 下移定时器处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmDown_Tick(object sender, EventArgs e)
        {
            if (NewCanvas.State == GameState.Run)
            {
                lock (syncObj)
                {
                    //当前不能下降处理
                    if (curBlock.DropStop)
                    {
                        //如果为新方块，则说明游戏结束
                        if (NewBlockFlag)
                        {
                            ProcessGameOver();
                        }
                        else//如果为旧方块，则取下一个方块
                        {
                            NewCanvas.GetAndDrawNextBlock(ref curBlock,ref nextBlock );
                        }
                    }
                    else
                    {
                        //下降处理 删除前的方块没有保存下来
                        if (curBlock.Down())
                        {                           
                            //删除行处理
                            DeleteLines();
                        }                     

                    }
                }
            }
        }

        private void DeleteLines()
        {
                if (curBlock.DropStop)
                {
                int count = NewCanvas.DeleteLines();

               if (count > 0)
               {
                   //通关处理
                   if (NewCanvas.IsUp)
                   {
                       MessageBox.Show("恭喜您通过了第" + lbLevel.Text.Substring(0, 1) + "关，通关加分：" + NewCanvas.AddScore() + Environment.NewLine + "按确定进入下一关！", "通关");
                       //重置通关标志
                       NewCanvas.IsUp = false;
                       //更新当前关卡
                       this.lbLevel.Text = NewCanvas.LevelNumber.ToString() + "：" + NewCanvas.LevelName;
                       this.tmDown.Interval = NewCanvas.CurLevel.Interval;
                       //更新背景图
                       NewCanvas.ClearAll();
                       NewCanvas.SetBackPic();
                       //更新背景音乐
                      NewCanvas.PlayMusic();
                   }

                   //恢复状态
                   this.State = GameState.Run;
                   //更新成绩
                    this.lbLines.Text = NewCanvas.DestroyLines.ToString();
                    this.lbScore.Text = NewCanvas.Score.ToString();
                   //取下一个方块
                    NewCanvas.GetAndDrawNextBlock(ref curBlock, ref  nextBlock);
               }
              
            }

        }   

        /// 键盘处理
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            string keyStr = keyData.ToString();

            if (IsRunning)
            {
                //左移
                if (keyStr == TetrisConfig.LeftKey)
                {
                    lock (syncObj)
                    {
                        NewCanvas.Draw(curBlock.Left());
                        DeleteLines();
                    }
                }
                //右移
                else if (keyStr == TetrisConfig.RightKey)
                {
                    lock (syncObj)
                    {
                        NewCanvas.Draw(curBlock.Right());
                        DeleteLines();
                    }
                }
                //下移
                else if (keyStr == TetrisConfig.DownKey)
                {
                    lock (syncObj)
                    {
                        curBlock.Down();
                        DeleteLines();
                    }
                }
                //变换
                else if (keyStr == TetrisConfig.TransformKey)
                {
                    lock (syncObj)
                    {
                        List<Position> reDrawList = curBlock.Transform();
                        if (reDrawList.Count > 0)
                            NewCanvas.Draw(reDrawList);
                        DeleteLines();
                    }
                }
                //确定
                else if (keyStr == TetrisConfig.ConfirmKey)
                {
                    lock (syncObj)
                    {
                        while (!curBlock.DropStop)
                        {
                            curBlock.Down();
                        }
                        DeleteLines();
                    }
                }
            }

            switch (keyData)
            {
                //暂停
                case Keys.F3:
                    if (this.State == GameState.Run)
                        this.State = GameState.Pause;
                    else if (this.State == GameState.Pause)
                        this.State = GameState.Run;
                    break;
                //重新开始
                case Keys.F2:
                    this.State = GameState.Run;
                    break;
                //帮助
                case Keys.F1:
                    this.About();
                    break;
                //退出
                case Keys.Escape:
                    Application.Exit();
                    break;
                default:
                    break;
            }

            return true;
        }

        /// <summary>
        /// 重新开始
        /// </summary>
        private void ReStart()
        {
            //清空背景
           NewCanvas.ReStart();
            //清空分数
           lbLines.Text = NewCanvas.DestroyLines.ToString();
           lbScore.Text = NewCanvas.Score.ToString();
           lbLevel.Text = NewCanvas.LevelNumber.ToString() + "：" + NewCanvas.LevelName;
           tmDown.Interval = NewCanvas.CurLevel.Interval;
            //创建新方块
            curBlock = NewCanvas.CreateBlock();
            nextBlock = NewCanvas.CreateBlock();
            NewBlockFlag = true;

            //重绘控件
            NewCanvas.DrawBackPic();
            NewCanvas.DrawNextBlock(nextBlock);

            //重置背景
            NewCanvas.SetBackPic();
            //播放音乐
            NewCanvas.PlayMusic();
        }


        /// <summary>
        /// 游戏结束处理
        /// </summary>
        private void ProcessGameOver()
        {
            this.State = GameState.Over;
            //重绘黑白背景
            NewCanvas.DrawBackPic();
            //如果得分在前十名，则保存用户信息
            if (NewCanvas.Score > 0)
            {
                int order = HighScore.Rank(NewCanvas.Score);
                if (order <= 10)
                {
                    new HighScoreDialog(order, NewCanvas.Score).ShowDialog();
                }
            }
        }

       
        /// <summary>
        /// 显示帮助信息
        /// </summary>
        public void About()
        {
            if (NewCanvas.State == GameState.Run)
            {
                this.State = GameState.Pause;
                MessageBox.Show(TetrisResource.Help, TetrisResource.Caption);
                this.State = GameState.Run;
            }
            else
                MessageBox.Show(TetrisResource.Help, TetrisResource.Caption);
        }

        private void TetrisGround_Load(object sender, EventArgs e)
        {
            //State = GameState.Run;
        }





    }
}
