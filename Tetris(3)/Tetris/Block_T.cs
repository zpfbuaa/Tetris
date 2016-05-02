using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// �����࣬Ʒ����
    /// </summary>
    public sealed class T : Block_Base
    {
        public T(TetrisCanvas backBlockArray)
            : base(backBlockArray)
        {
            this.Type = Enum_BlockTypes.T;
            transBlockList.Add(new TransBlock(new Position(0, 1),
                               new SquareBlock[3, 2]
                                                        { { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block)}}));
            transBlockList.Add(new TransBlock(new Position(0, 0),
                               new SquareBlock[2, 3] 
                                                        { { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)} }));
            transBlockList.Add(new TransBlock(new Position(0, 0),
                               new SquareBlock[3, 2]
                                                        { { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)}}));
            transBlockList.Add(new TransBlock(new Position(1, 0),
                               new SquareBlock[2, 3] 
                                                        { { new SquareBlock(Enum_BlockTypes.Null), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Null)},
                                                          { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block)} }));
            this.CurTransBlock = transBlockList[0];
            //�����ʼλ��
            this.position = new Position(4, -1);
        }
    }
}