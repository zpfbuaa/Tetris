using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetris
{
    public abstract class Block_Base
    {
     
        
        //方块变换矩阵表
        protected List<TransBlock> transBlockList
        {
            get;
            set;
        }
      
        //方块背景矩阵
        protected TetrisCanvas NewCanvas;
       
        //变换原点坐标
        protected Position transformOriginPosition;
       

        /// <summary>
        /// 获取方块类型
        /// </summary>
        public Enum_BlockTypes Type
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前方块状态
        /// </summary>
        public TransBlock CurTransBlock
        {
            get;
            set;
        }

        /// <summary>
        /// 当前在背景中所占位置表
        /// </summary>
        public List<Position> CurPosList
        {
            get;
            set;
        }

        /// <summary>
        /// 变换时所需矩阵宽度
        /// </summary>
        public int TransRectWidth
        {
            get { return Math.Max(CurTransBlock.XBlocks, CurTransBlock.YBlocks); }
        }

        /// <summary>
        /// 方块当前在背景中的位置
        /// </summary>
        public Position position
        {
            get;
            set;
        }

        /// <summary>
        /// 下次变换方块形状
        /// </summary>
        protected TransBlock NextBlockStatus
        {
            get
            {
                //取当前方块表索引号
                int index = transBlockList.IndexOf(this.CurTransBlock);
                //设置下次次变换方块形状
                if (index >= transBlockList.Count - 1)
                    return transBlockList[0];
                else
                    return transBlockList[index + 1];
            }
        }

        /// <summary>
        /// 是否停止下降
        /// </summary>
        public bool DropStop
        {
            get 
            {
                return NewCanvas.IsBump(this.NewCanvas.NewPositions(this.CurPosList, new Position(position.X, position.Y + 1), CurTransBlock));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="backBlockRangle"></param>
        protected Block_Base(TetrisCanvas backBlockRangle)
        {
            this.NewCanvas = backBlockRangle;
            this.transBlockList = new List<TransBlock>();
            this.CurPosList = new List<Position>();
            //this.position = new Position();在子类中初始化
            this.transformOriginPosition = new Position();
        }

        /// <summary>
        /// 移动到指定位置
        /// </summary>
        /// <param name="newPos">指定位置</param>
        /// <returns>移动后被更改的位置列表</returns>
        protected List<Position> Move(Position newPos, TransBlock CurTransBlock)
        {
            //重绘区域位置列表
            List<Position> reDrawList = new List<Position>();
            //碰撞检测
            if (!NewCanvas.IsBump(this.NewCanvas.NewPositions(this.CurPosList, newPos, CurTransBlock)))
            {
                //清除旧方块位置
                NewCanvas.Clear(CurPosList);
                //保存重绘区域
                reDrawList = CurPosList;
                //添加方块到背景
                CurPosList = NewCanvas.AddBlock(newPos, CurTransBlock, reDrawList);
                //保存当前方块起始位置
                position = newPos;
            }
            return reDrawList;
        }

        /// <summary>
        /// 向下移动
        /// </summary>        
        /// <returns>是否能够下降</returns>
        public bool Down()
        {
            List<Position> reDrawList = new List<Position>();
            if (!DropStop)
            {
                reDrawList = Move(new Position(position.X, position.Y + 1), CurTransBlock);
                //根据返回列表个数判断下降是否成功
                if (reDrawList.Count > 0)
                {
                    //重置当前方块标志
                    NewCanvas.NewBlockFlag = false;
                    //重绘区域
                    NewCanvas.Draw(reDrawList);
                }
                

            }
            return DropStop;
        }


       

             
        /// <summary>
        /// 向左移动
        /// </summary>
        /// <returns>需重绘位置列表</returns>
        public List<Position> Left()
        {
            List<Position> reDrawList;
            reDrawList = Move(new Position(position.X - 1, position.Y), CurTransBlock);
            return reDrawList;
        }

        /// <summary>
        /// 向右移动
        /// </summary>
        /// <returns>需重绘位置列表</returns>
        public List<Position> Right()
        {
            List<Position> reDrawList;
            reDrawList = Move(new Position(position.X + 1, position.Y), CurTransBlock);
            return reDrawList;
        }

        /// <summary>
        /// 重置变换原点坐标
        /// </summary>
        protected void ResetTransformOriginPosition()
        {
            transformOriginPosition.X = position.X - CurTransBlock.Position.X;
            transformOriginPosition.Y = position.Y - CurTransBlock.Position.Y;
        }

        /// <summary>
        /// 可否变换
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanTrans()
        {
            ResetTransformOriginPosition();
            //检查是否能进行变换
            bool canTrans = NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
            //原点左移，尝试能否变换
            if (!canTrans)
            {
                for (int i = 0; i < TransRectWidth / 2 && (!canTrans); i++)
                {
                    transformOriginPosition.X--;
                    canTrans = NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
                }
            }
            //原点右移，尝试能否变换
            if (!canTrans)
            {
                transformOriginPosition.X = transformOriginPosition.X + 2;
                for (int j = 0; j < TransRectWidth / 2 && (!canTrans); j++)
                {
                    transformOriginPosition.X++;
                    canTrans = NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
                }
            }

            return canTrans;
        }

        /// <summary>
        /// 方块在背景图中的变形处理
        /// </summary>
        /// <returns>需重绘位置列表</returns>
        public List<Position> Transform()
        {
            //重绘位置表
            List<Position> reDrawList = new List<Position>();

            //进行变换
            if (CanTrans())
            {
                //获取变换后的方块位置
                Position newPos = new Position(transformOriginPosition.X + NextBlockStatus.Position.X, transformOriginPosition.Y + NextBlockStatus.Position.Y);
                //执行变换
                reDrawList = Move(newPos, NextBlockStatus);
                this.CurTransBlock = NextBlockStatus;
            }
            return reDrawList;
        }
    }
}
