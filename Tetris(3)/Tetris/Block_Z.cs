using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 方块类，左S形
    /// </summary>
    public sealed class Z : Block_Base
    {
        public Z(TetrisCanvas backBlockArray)
            : base(backBlockArray)
        {
            this.Type = Enum_BlockTypes.Z;
            transBlockList.Add(new TransBlock(new Position(0, 0),
                               new SquareBlock[2, 3]
                                                        { { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)} }));

            transBlockList.Add(new TransBlock(new Position(0, 0),
                               new SquareBlock[3, 2] 
                                                        { { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block)}}));
            this.CurTransBlock = transBlockList[0];
            //定义初始位置
            this.position = new Position(4, -1);
        }
    }
}
