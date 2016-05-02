using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tetris
{
    public class TetrisCanvas
    {

        //随机数生成方块
        public Random rd = new Random();

        public System.IntPtr nextHandle; //场景的handle      

        public System.IntPtr winHandle; //场景的handle

        //已消除的行数
        public int destroyLines;
        //累计得分
        public int countScore;
        //当前关卡所得分
        public int curLevelScore;

        //等级列表
        public List<Level> levels = new List<Level>();
        //被填满了的行暂存列表
        public List<int> fullLines = new List<int>();       

        //要保留的行暂存列表
        public List<int> keepLines = new List<int>();

        /// <summary>
        /// 用来记录方块的最高函数，刷新界面用
        /// </summary>
        public int MinY
        {
            get;
            set;
        }

        //背景图片宽、高
        public readonly int backPicWidth;
        public readonly int backPicHeight;
        //方块类型总数
        public readonly int blockTypeCount;
        //每个小方格图片大小
        public readonly int blockPicWidth;
        public readonly int blockPicHeight;
        //横向方格数目
        public readonly int xBlocks;
        //纵向方格数目
        public readonly int yBlocks;

        //背景图片数组，被分成一块块的小方格
        public Bitmap[,] colorBackPicArray;
        public Bitmap[,] blackBackPicArray;
        //方块图片
        public Bitmap[] blockPics;
        //透明方块图片
        public Bitmap[] blockOpacityPics;
        //黑白方块图片
        public Bitmap blackBlockPic = TetrisResource.block;

        /// <summary>
        /// 游戏状态
        /// </summary>
        public GameState State
        {
            get;
            set;
        }
        /// <summary>
        /// 保存已经不能再下落了的方块
        /// </summary>

        public SquareBlock[,] ArrayBlock
        {
            get;
            set;
        }

        //当前是否升级状态
        public bool isUp;

        /// <summary>
        /// 关卡名称
        /// </summary>
        public string LevelName
        {
            get { return CurLevel.Name; }
        }

        /// <summary>
        /// 当前等级数
        /// </summary>
        public int LevelNumber
        {
            get { return levels.IndexOf(CurLevel) + 1; }
            set { SetLevel(value); }
        }

        /// <summary>
        /// 最高等级
        /// </summary>
        public int MaxLevelNumber
        {
            get { return levels.Count; }
        }

        /// <summary>
        /// 当前等级
        /// </summary>
        public Level CurLevel
        {
            get;
            set;
        }

        /// <summary>
        /// 空白方块数
        /// </summary>
        public int BlankBlockNumber
        {
            get
            {
                int number = 0;
                foreach (SquareBlock bt in this.ArrayBlock)
                {
                    if (bt == null || bt.EnumSquareBlockType == Enum_BlockTypes.Null)
                        number++;
                }
                return number;
            }
        }

        /// <summary>
        /// 是否升级，传递给调用方
        /// </summary>
        public bool IsUp
        {
            get { return this.isUp; }
            set { this.isUp = value; }
        }



        public int[] arrBitBlock = null;  //位数组：当某个位置有方块时，该行的该位为1
        private const int bitEmpty = 0x0;      //00 0000 0000
        private const int bitFull = 0x3FF;   //11 1111 1111       


        //音效播放器
        public SoundPlayer soundEffect = new SoundPlayer();
        //背景音乐播放器
        public Sound soundMusic;

        //当前方块是否为新方块
        public bool NewBlockFlag
        {
            get;
            set;
        }

        public TetrisCanvas()
        {
            destroyLines = 0;
            countScore = 0;
            curLevelScore = 0;
            //初始化等级表
          

            levels.Add(new Level(TetrisResource.Level1Name, 1000, 700));
            levels.Add(new Level(TetrisResource.Level2Name, 2000, 500));
            levels.Add(new Level(TetrisResource.Level3Name, 3000, 400));
            levels.Add(new Level(TetrisResource.Level4Name, 4000, 300));
            levels.Add(new Level(TetrisResource.Level5Name, 5000, 200));
            levels.Add(new Level(TetrisResource.Level6Name, 6000, 100));
            levels.Add(new Level(TetrisResource.Level7Name, 7000, 70));



            CurLevel = levels[0];

            blockTypeCount = 7;
            //设置图片长度参数
            backPicWidth = 200;
            backPicHeight = 400;
            blockPicWidth = 20;
            blockPicHeight = 20;
            xBlocks = backPicWidth / blockPicWidth;
            yBlocks = backPicHeight / blockPicHeight;
            //设置方块图片
            blockPics = new Bitmap[] { TetrisResource.BlockNull, TetrisResource.block };
            blockOpacityPics = new Bitmap[] { TetrisResource.BlockNull2, TetrisResource.blockOpacity, };


            //初始化方块背景
            ArrayBlock = new SquareBlock[xBlocks, yBlocks];

            arrBitBlock = new int[yBlocks];
            //默认认当前为第一关
            LevelNumber = 1;

            //初始化背景音乐
            soundMusic = new Sound(TetrisConfig.GetBackMusic(LevelNumber));
            //初始化音效
            soundEffect.Stream = TetrisResource.DeleteLinesSound;





        }


        public int XBlocks
        {
            get
            {
                if (ArrayBlock != null)
                    return ArrayBlock.GetUpperBound(0) + 1;
                else
                    return 0;
            }
        }

        public int YBlocks
        {
            get
            {
                if (ArrayBlock != null)
                    return ArrayBlock.GetUpperBound(1) + 1;
                else
                    return 0;
            }
        }



        /// <summary>
        /// 设置当前等级
        /// </summary>
        /// <param name="i">等级数</param>
        private void SetLevel(int i)
        {
            if (i >= 1 && i <= levels.Count)
            {
                //设置指定等级
                this.CurLevel = levels[i - 1];
            }
        }

        /// <summary>
        /// 下一等级
        /// </summary>
        public Level NextLevel
        {
            get
            {
                if (LevelNumber >= levels.Count)
                {
                    return this.CurLevel;
                }
                else
                {
                    return levels[LevelNumber];
                }
            }
        }

        /// <summary>
        /// 已消除的行数
        /// </summary>
        public int DestroyLines
        {
            get { return destroyLines; }
        }

        /// <summary>
        /// 得分
        /// </summary>
        public int Score
        {
            get { return countScore; }
        }



        /// <summary>
        /// 删除背景图中的指定区域
        /// </summary>
        /// <param name="posList"></param>
        public void Clear(List<Position> posList)
        {
            foreach (Position pos in posList)
            {
                this.arrBitBlock[pos.Y] = arrBitBlock[pos.Y] ^ (1 << pos.X);

                this.ArrayBlock[pos.X, pos.Y] = null;
            }
        }

        /// <summary>
        /// 将指定方块加入到背景区域
        /// </summary>
        /// <param name="originPos">方块在背景中的起始位置</param>
        /// <param name="blockRect">传入的方块形状描述表</param>
        /// <param name="reDrawList">需重绘的位置列表</param>
        /// <returns>返回当前方块位置坐标表</returns>
        public List<Position> AddBlock(Position originPos, TransBlock CurTransBlock, List<Position> reDrawList)
        {
            List<Position> blockPosList = new List<Position>();

            for (int i = 0; i < CurTransBlock.XBlocks; i++)
            {
                for (int j = 0; j < CurTransBlock.YBlocks; j++)
                {
                    if (CurTransBlock.ArrayBlock[i, j].EnumSquareBlockType != Enum_BlockTypes.Null && originPos.X + i >= 0 && originPos.Y + j >= 0)
                    {
                        this.ArrayBlock[originPos.X + i, originPos.Y + j] = new SquareBlock(CurTransBlock.ArrayBlock[i, j].EnumSquareBlockType);


                        arrBitBlock[originPos.Y + j] = arrBitBlock[originPos.Y + j] | (1 << originPos.X + i);
                        Position tmpPos = new Position(originPos.X + i, originPos.Y + j);
                        //保存方块位置表
                        blockPosList.Add(tmpPos);
                        //如果该方块不在重给区域中，加入重绘区域
                        if (!Position.HasPosition(reDrawList, tmpPos))
                        {
                            reDrawList.Add(tmpPos);
                        }
                    }
                }
            }
            return blockPosList;
        }

        /// <summary>
        /// 计算新方块在背景图中的位置
        /// </summary>
        /// <param name="oldPosList">方块在背景图的原有位置</param>
        /// <param name="newPos">方块在背景图中的起始位置</param>
        /// <param name="blockRectangle"></param>
        /// <returns></returns>
        public List<Position> NewPositions(List<Position> oldPosList, Position originPos, TransBlock CurTransBlock)
        {
            List<Position> newPosList = new List<Position>();
            //计算方块新位置在背景图中的区域
            for (int i = 0; i < CurTransBlock.XBlocks; i++)
            {
                for (int j = 0; j < CurTransBlock.YBlocks; j++)
                {
                    if (CurTransBlock.ArrayBlock[i, j].EnumSquareBlockType != Enum_BlockTypes.Null)
                    {
                        newPosList.Add(new Position(originPos.X + i, originPos.Y + j));
                    }
                }
            }
            //删除方块新区域中旧位置区域
            if (newPosList.Count > 0)
            {
                for (int k = newPosList.Count - 1; k >= 0; k--)
                {
                    if (Position.HasPosition(oldPosList, newPosList[k]))
                        newPosList.RemoveAt(k);
                }
            }

            return newPosList;
        }

        /// <summary>
        /// 碰撞或过界检测
        /// </summary>
        public bool IsBump(List<Position> posList)
        {
            foreach (Position pos in posList)
            {
                //X轴过界检查
                if (pos.X < 0 || pos.X >= this.XBlocks)
                    return true;
                //Y轴过界检查
                if (pos.Y < -2 || pos.Y >= this.YBlocks)
                    return true;
                //碰撞检查
                if (pos.Y >= 0 && this.ArrayBlock[pos.X, pos.Y] != null && this.ArrayBlock[pos.X, pos.Y].EnumSquareBlockType != Enum_BlockTypes.Null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 检查是否能进行变换
        /// </summary>
        /// <param name="originPos">变换区域的原点位置</param>
        /// <returns>返回布尔值</returns>
        public bool CanTransform(Position originPos, List<Position> CurPosList, int transRectWidth)
        {
            //检查变换所需空间
            for (int i = 0; i < transRectWidth; i++)
            {
                for (int j = 0; j < transRectWidth; j++)
                {
                    Position pos = new Position(originPos.X + i, originPos.Y + j);
                    //坐标越界检查
                    if (pos.X < 0 || pos.X >= this.XBlocks || pos.Y >= this.YBlocks)
                        return false;
                    //如果变换空间中已有方块且不是当前形状所占方块，则不能变换
                    if (pos.Y >= 0)
                    {
                        if (this.ArrayBlock[pos.X, pos.Y] != null && this.ArrayBlock[pos.X, pos.Y].EnumSquareBlockType != Enum_BlockTypes.Null && !Position.HasPosition(CurPosList, pos))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }





        /// <summary>
        /// 重新开始
        /// </summary>
        public void ReStart()
        {
            this.ClearAll();
            this.destroyLines = 0;
            this.countScore = 0;
        }

        /// <summary>
        /// 清空所有方块
        /// </summary>
        /// <returns></returns>
        public List<Position> ClearAll()
        {
            List<Position> reDrawList = new List<Position>();

            for (int i = 0; i < this.XBlocks; i++)
            {
                for (int j = 0; j < this.YBlocks; j++)
                {
                    if (this.ArrayBlock[i, j] != null && this.ArrayBlock[i, j].EnumSquareBlockType != Enum_BlockTypes.Null)
                    {
                        this.ArrayBlock[i, j].EnumSquareBlockType = Enum_BlockTypes.Null;
                        reDrawList.Add(new Position(i, j));
                    }
                }
            }
            return reDrawList;
        }

        /// <summary>
        /// 通关加分
        /// </summary>
        /// <param name="sc">传入的加分数</param>
        /// <returns>返回加分后的分数</returns>
        public int AddScore()
        {
            //计算通关加分=剩余空方块数*当前关卡数*5
            int addScore = (this.LevelNumber - 1) * this.BlankBlockNumber * 5;
            this.countScore += addScore;
            return addScore;
        }

        /// <summary>
        /// 查找已被填满的行
        /// </summary>
        /// <returns></returns>
        public List<int>  FindFullLines()
        {
            
            //清空原暂存表
            fullLines.Clear();
            keepLines.Clear();
            List<Position> reDrawPosList = new List<Position>();
            //从最底行开始检查是否有消除行
            for (int y = this.YBlocks - 1; y >= 0 && arrBitBlock[y] != bitEmpty; )
            {
                if (arrBitBlock[y] == bitFull)
                {
                    for (int x = 0; x < xBlocks; x++) //消除该行的block
                        ArrayBlock[x, y] = null;
                    SquareBlock[] arr = null;
                    //将该行之上的block下移，如果到顶则不执行
                    for (int i = y; i - 1 >= 0; i--)
                    {
                       //记录最高的 图形
                        arr = new SquareBlock[10];
                        for (int x = 0; x < xBlocks; x++)
                        {
                          
                           if ((arrBitBlock[i - 1] & (1 << x)) != 0) //如果上方有block
                           
                            {
                                this.ArrayBlock[x, i] = this.ArrayBlock[x, i - 1] == null ? null : this.ArrayBlock[x, i - 1].Clone() as SquareBlock;                              

                                ArrayBlock[x, i - 1] = null;
                                reDrawPosList.Add(new Position(x, i));

                                //ArrayBlock[x, i] = ArrayBlock[x, i - 1].Clone() as SquareBlock;
                            }
                        }
                        arrBitBlock[i] = arrBitBlock[i - 1];//转移监控位
                    }

                    destroyLines++;
                    fullLines.Add(y - fullLines.Count());

                   
                }
                else
                {
                    keepLines.Add(y - fullLines.Count());
                    y--;//当消除一行后指针不下移，当没有消除的时候指针才下移
                   
                }
                MinY = y - fullLines.Count();
            }
            return fullLines;
        }

        /// <summary>
        /// 删除行
        /// </summary>
        public int DeleteLines()
        {
            //获取当前已被填满的行
            fullLines = FindFullLines();

            if (fullLines.Count > 0)
            {
                //将状态转换到Deleting
                this.State = GameState.Deleting;
                //播放消除行音效
                if (TetrisConfig.SoundOn)
                {
                    soundEffect.Play();
                }
                //闪烁处理
                Graphics g = Graphics.FromHwnd(winHandle);
                DrawOpacityBlocks(g);
                g.Dispose();

                List<Position> reDrawPosList = new List<Position>();
                //执行删除
                if (fullLines.Count > 0)
                {
                    //更新得分，得分=消除行数*当前等级*消除方块数
                    for (int p = 1; p <= fullLines.Count; p++)
                    {
                        countScore += p * LevelNumber * XBlocks;
                        curLevelScore += p * LevelNumber * XBlocks;
                    }
                    //检查是否升级，
                    if (this.LevelNumber != this.MaxLevelNumber && curLevelScore >= this.CurLevel.UpScore)
                    {
                        //置升级标志
                        this.isUp = true;
                        //转向下一关
                        this.CurLevel = NextLevel;
                        curLevelScore = 0;
                    }
                }

                //删除行并更新相关数据
                Draw(MinY);

            }
            return fullLines.Count;

        }





        /// <summary>
        /// 查找已被填满的行
        /// </summary>
        /// <returns></returns>
        public List<int> FindFullLines_Old()
        {
            //清空原暂存表
            fullLines.Clear();
            keepLines.Clear();

            //从最底行开始检查是否有消除行
            for (int i = this.YBlocks - 1; i >= 0; i--)
            {
                //该行是否满
                bool full = true;
                //该行是否空
                bool isNull = true;
                //检查每一行
                for (int j = 0; j < this.XBlocks; j++)
                {
                    bool blockIsNull = (this.ArrayBlock[j, i] == null || this.ArrayBlock[j, i].EnumSquareBlockType == Enum_BlockTypes.Null);
                    full = full && (!blockIsNull);
                    isNull = isNull && blockIsNull;
                }

                //要保留的行
                if (!full)
                    keepLines.Add(i);
                else
                {
                    destroyLines++;
                    fullLines.Add(i);
                }
                //如果当前行全为空，则不用再查找
                if (isNull)
                    break;
            }
            return fullLines;
        }



        /// <summary>
        /// 分割背景图
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="backPicArray"></param>
        public void SplitBackPic(Bitmap pic, out Bitmap[,] backPicArray)
        {
            //分割背景图片放入背景图片数组
            backPicArray = new Bitmap[xBlocks, yBlocks];
            for (int i = 0; i < xBlocks; i++)
            {
                for (int j = 0; j < yBlocks; j++)
                {
                    backPicArray[i, j] = new Bitmap(blockPicWidth, blockPicHeight);
                    Graphics gBack = Graphics.FromImage(backPicArray[i, j]);
                    gBack.DrawImage(pic, new Rectangle(0, 0, blockPicWidth, blockPicHeight), new Rectangle(i * blockPicWidth, j * blockPicHeight, blockPicWidth, blockPicHeight), GraphicsUnit.Pixel);
                    gBack.Dispose();
                }
            }
        }

        /// <summary>
        /// 设置背景图片
        /// </summary>
        public void SetBackPic()
        {

            Bitmap colorPic = TetrisConfig.GetBackPic(LevelNumber);
            Bitmap blackPic = ColorPicToBlack(colorPic);
            SplitBackPic(colorPic, out colorBackPicArray);
            SplitBackPic(blackPic, out blackBackPicArray);
            colorPic.Dispose();
            blackPic.Dispose();
            DrawBackPic();
        }



        /// <summary>
        /// 将彩色背景图片转换成黑白背景图片
        /// </summary>
        public Bitmap ColorPicToBlack(Bitmap colorPic)
        {
            Bitmap blackPic = new Bitmap(colorPic.Width, colorPic.Height);

            for (int x = 0; x < colorPic.Width; x++)
            {
                for (int y = 0; y < colorPic.Height; y++)
                {
                    //取三元色中的红色分量
                    Color c1 = colorPic.GetPixel(x, y);
                    Color c2 = Color.FromArgb(c1.R, c1.R, c1.R);
                    blackPic.SetPixel(x, y, c2);
                }
            }
            return blackPic;
        }

        /// <summary>
        /// 绘制游戏区中的背景
        /// </summary>
        public void DrawBackPic()
        {
            Graphics g = Graphics.FromHwnd(winHandle);
            DrawBackPic(g);
            g.Dispose();
        }


        public void DrawBackPic(Graphics g)
        {
            Position pos = new Position(0, 0);
            for (int i = 0; i < xBlocks; i++)
            {
                for (int j = 0; j < yBlocks; j++)
                {
                    pos.X = i;
                    pos.Y = j;
                    Draw(g, pos);
                }
            }
        }

        /// <summary>
        /// 将方块停住
        /// </summary>
        /// <param name="sq"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void StopSquare(SquareBlock sq)
        {
            ArrayBlock[sq.Position.X, sq.Position.Y] = sq.Clone() as SquareBlock;
            arrBitBlock[sq.Position.Y] = arrBitBlock[sq.Position.Y] | (1 << sq.Position.X);
        }


        /// <summary>
        /// 创建方块
        /// </summary>
        /// <returns>返回的方块</returns>
        public Block_Base CreateBlock()
        {
            //int i = rd.Next(blockTypeCount);
            int i = (int)Enum_BlockTypes.S;
            switch (i)
            {
                case 1:
                    return new I(this);
                case 2:
                    return new J(this);
                case 3:
                    return new L(this);
                case 4:
                    return new Z(this);
                case 5:
                    return new S(this);
                case 6:
                    return new T(this);
                case 7:
                    return new O(this);
                default:
                    return new I(this);
            }
        }

        /// <summary>
        /// 绘制指定列表中的方格
        /// </summary>
        /// <param name="posList"></param>
        public void Draw(int maxId)
        {
            if (maxId > 0)
            {
                Graphics g = Graphics.FromHwnd(winHandle);
                Draw(g, maxId);
                g.Dispose();
            }
        }

        /// <summary>
        /// 绘制指定列表中的方格
        /// </summary>
        /// <param name="posList"></param>
        public void Draw(List<Position> posList)
        {
            if (posList.Count > 0)
            {
                Graphics g = Graphics.FromHwnd(winHandle);
                Draw(g, posList);
                g.Dispose();
            }
        }

        /// <summary>
        /// 绘制指定位置图片
        /// </summary>
        /// <param name="g">传入的Graphics</param>
        /// <param name="pos">传入的指定位置</param>
        public void Draw(Graphics g, Position pos)
        {
            if (State != GameState.Over)
            {
                //绘制方块
                if (this.ArrayBlock[pos.X, pos.Y] != null && this.ArrayBlock[pos.X, pos.Y].EnumSquareBlockType != Enum_BlockTypes.Null)
                    Draw(g, pos, blockPics[1]);
                else//绘制背景
                    Draw(g, pos, colorBackPicArray[pos.X, pos.Y]);
            }
            else
            {
                //绘制方块
                if (this.ArrayBlock[pos.X, pos.Y] != null && this.ArrayBlock[pos.X, pos.Y].EnumSquareBlockType != Enum_BlockTypes.Null)
                    Draw(g, pos, blackBlockPic);
                else//绘制背景
                    Draw(g, pos, blackBackPicArray[pos.X, pos.Y]);
            }
        }


        /// <summary>
        /// 绘制指定列表中的方格
        /// </summary>
        /// <param name="g"></param>
        /// <param name="posList"></param>
        public void Draw(Graphics g, List<Position> posList)
        {
            foreach (Position pos in posList)
            {
                Draw(g, pos);
            }
        }


        /// <summary>
        /// 绘制指定列表中的方格
        /// </summary>
        /// <param name="g"></param>
        /// <param name="posList"></param>
        public void Draw(Graphics g, int minY)
        {
            for (int y = minY - 1; y < yBlocks; y++)
            {
                for (int x = 0; x < xBlocks; x++)
                {
                    Position pos = new Position(x, y);
                    Draw(g, pos);
                }
            }
        }

        /// <summary>
        /// 绘制小方格
        /// </summary>
        /// <param name="g">传入的Graphics对象</param>
        /// <param name="pos">小方格位置</param>
        /// <param name="image">方格图片</param>
        public void Draw(Graphics g, Position pos, Image image)
        {
            g.DrawImage(image,
                        new Rectangle(pos.X * blockPicWidth, pos.Y * blockPicHeight, blockPicWidth, blockPicHeight),
                        new Rectangle(0, 0, blockPicWidth, blockPicHeight),
                        GraphicsUnit.Pixel);
        }


        /// <summary>
        /// 播放背景音乐
        /// </summary>
        public void PlayMusic()
        {
            if (TetrisConfig.MusicOn)
            {
                //更新背景音乐
                soundMusic.MicName = TetrisConfig.GetBackMusic(this.LevelNumber);
                soundMusic.PlayRepeat();
            }
        }



        /// <summary>
        /// 将待消除的行做闪烁处理
        /// </summary>
        /// <param name="fullLines"></param>
        public void DrawOpacityBlocks(Graphics g)
        {
            //取闪烁时间，至少不能小于100ms
            int flashTime = CurLevel.Interval / 3;
            if (flashTime < 100)
                flashTime = 100;

            for (int t = 0; t < 3; t++)
            {
                for (int i = fullLines.Count - 1; i >= 0; i--)
                {
                    int y = fullLines[i];

                    for (int x = 0; x < xBlocks; x++)
                    {
                        if (t % 2 == 0)
                            DrawOpacityBlock(g, new Position(x, y));
                        else
                          //  Draw(g, new Position(x, y));
                            DrawHeadBlock(g, new Position(x, y));
                    }
                }

                Thread.Sleep(flashTime);
            }
        }

        public void DrawOpacityBlock(Graphics g, Position pos)
        {
            //首先用空白清除背景，然后再绘图
           // Draw(g, pos, blockOpacityPics[0]);
            Draw(g, pos, blockOpacityPics[1]);
        }

        public void DrawHeadBlock(Graphics g, Position pos)
        {
            //首先用空白清除背景，然后再绘图
          //  Draw(g, pos, blockPics[0]);
            Draw(g, pos, blockPics[1]);
        }

        /// <summary>
        /// 绘制下一个方块图片
        /// </summary>
        public void DrawNextBlock(Block_Base nextBlock)
        {
            if (this.State == GameState.Run)
            {
                Graphics g = Graphics.FromHwnd(nextHandle);
                //绘制空白背景
                for (int k = 0; k < 4; k++)
                {
                    for (int l = 0; l < 4; l++)
                    {
                        Draw(g, new Position(k, l), blockPics[0]);
                    }
                }

                //绘制方块
                for (int i = 0; i < nextBlock.CurTransBlock.XBlocks; i++)
                {
                    for (int j = 0; j < nextBlock.CurTransBlock.YBlocks; j++)
                    {
                        //如果方块的变换矩阵长度小于4，则将其绘制位置右移一个单位
                        int offset = 0;
                        if (nextBlock.TransRectWidth < 4)
                            offset++;
                        //绘制小方块
                        if (nextBlock.CurTransBlock.ArrayBlock[i, j].EnumSquareBlockType != Enum_BlockTypes.Null)
                        {
                            Draw(g, new Position(nextBlock.CurTransBlock.Position.X + i + offset, nextBlock.CurTransBlock.Position.Y + j), blockPics[1]);
                        }
                    }
                }
                g.Dispose();
            }
        }


        /// <summary>
        /// 获取并绘制新方块
        /// </summary>
        public void GetAndDrawNextBlock(ref Block_Base curBlock, ref Block_Base nextBlock)
        {
            //获取下一个方块
            GetNextBlock(ref curBlock, ref nextBlock);
            //绘制方块起始图片
            Draw(AddBlock(curBlock.position, curBlock.CurTransBlock, curBlock.CurPosList));
            //置新方块标志
            NewBlockFlag = true;
        }



        /// <summary>
        /// 获取下一个方块
        /// </summary>
        private void GetNextBlock(ref Block_Base curBlock, ref Block_Base nextBlock)
        {
            curBlock = nextBlock;
            nextBlock = CreateBlock();
            DrawNextBlock(nextBlock);



        }


    }
}
