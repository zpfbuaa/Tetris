using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Tetris
{
    public class SquareBlock : ICloneable 
    {

        public Point location;
        public Size size;      
        public Enum_BlockTypes EnumSquareBlockType;  

        /// <summary>
        /// 方块在变换矩阵中的起始位置
        /// </summary>
        public Position Position
        {
            get;
            set;
        }
      

        public SquareBlock(Position pos, Enum_BlockTypes type)
        {
            this.Position = pos;
            this.EnumSquareBlockType = type;
        }

        public object Clone() { return this.MemberwiseClone(); } 

        public SquareBlock(SquareBlock squareBlock)
        {
            this.location = squareBlock.location;
            this.Position = squareBlock.Position;
            this.size = squareBlock.size;
            this.EnumSquareBlockType = squareBlock.EnumSquareBlockType;
           
        }


        public SquareBlock(Enum_BlockTypes type)
        {
            this.EnumSquareBlockType = type;
        }
       
    }
}
