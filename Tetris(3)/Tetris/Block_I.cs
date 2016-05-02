using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 方块类，长条形，4个横形方块或4个竖形方块
    /// </summary>
    public sealed class I : Block_Base
    {
        public I(TetrisCanvas backBlockArray)
            : base(backBlockArray)
        {
            this.Type = Enum_BlockTypes.I;
            transBlockList.Add(new TransBlock(new Position(0, 1), 
                               new SquareBlock[4, 1]
                                                        { { new SquareBlock( Enum_BlockTypes.Block)},
                                                          { new SquareBlock( Enum_BlockTypes.Block)},
                                                          { new SquareBlock( Enum_BlockTypes.Block)},
                                                          { new SquareBlock( Enum_BlockTypes.Block)} }));
            transBlockList.Add(new TransBlock(new Position(1, 0),
                               new SquareBlock[1, 4] { { new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block), new SquareBlock(Enum_BlockTypes.Block) } }));
            this.CurTransBlock = transBlockList[0];
            //定义初始位置
            this.position = new Position(3, 0);
        }

        /// <summary>
        /// 能否变换
        /// </summary>
        /// <returns>返回布尔值</returns>
        protected override bool CanTrans()
        {
            bool canTrans = base.CanTrans();
            //如果基类的判断为不能变换且当前为横条时，则再尝试Y轴上移
            if (!canTrans && this.CurTransBlock == transBlockList[0])
            {
                //重置变换原点坐标
                ResetTransformOriginPosition();
                //Y轴上移
                transformOriginPosition.Y--;
                return NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
            }

            return canTrans;
        }
    }
}
