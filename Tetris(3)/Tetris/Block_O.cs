using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 方块类，田字形
    /// </summary>
    public sealed class O : Block_Base
    {
        public O(TetrisCanvas backBlockArray)
            : base(backBlockArray)
        {
            this.position = new Position(4, -1);
            this.Type = Enum_BlockTypes.O;
            transBlockList.Add(new TransBlock(new Position(0, 0),
                               new SquareBlock[2, 2]{{ new SquareBlock(Enum_BlockTypes.Block) , new SquareBlock(Enum_BlockTypes.Block) },
                                                          { new SquareBlock(Enum_BlockTypes.Block) , new SquareBlock(Enum_BlockTypes.Block) } }));
            this.CurTransBlock = transBlockList[0];
            //定义初始位置

        }
    }
}
