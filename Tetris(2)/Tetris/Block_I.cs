using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// �����࣬�����Σ�4�����η����4�����η���
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
            //�����ʼλ��
            this.position = new Position(3, 0);
        }

        /// <summary>
        /// �ܷ�任
        /// </summary>
        /// <returns>���ز���ֵ</returns>
        protected override bool CanTrans()
        {
            bool canTrans = base.CanTrans();
            //���������ж�Ϊ���ܱ任�ҵ�ǰΪ����ʱ�����ٳ���Y������
            if (!canTrans && this.CurTransBlock == transBlockList[0])
            {
                //���ñ任ԭ������
                ResetTransformOriginPosition();
                //Y������
                transformOriginPosition.Y--;
                return NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
            }

            return canTrans;
        }
    }
}
