using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 变换矩阵方块
    /// </summary>
    public class TransBlock
    {
        /// <summary>
        /// 方块在变换矩阵中的起始位置
        /// </summary>
        public Position Position
        {
            get;
            set;
        }    

        public SquareBlock[,] ArrayBlock
        {
            get;
            set;
        }

        public TransBlock(SquareBlock[,] array)
        {
            
            this.ArrayBlock = array;
        }

        public TransBlock(Position pos, SquareBlock[,] array)
        {
            this.Position = pos;
            this.ArrayBlock = array;
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

       
    }
}
