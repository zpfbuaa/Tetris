using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tetris
{
    public abstract class Block_Base
    {
     
        
        //����任�����
        protected List<TransBlock> transBlockList
        {
            get;
            set;
        }
      
        //���鱳������
        protected TetrisCanvas NewCanvas;
       
        //�任ԭ������
        protected Position transformOriginPosition;
       

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        public Enum_BlockTypes Type
        {
            get;
            set;
        }

        /// <summary>
        /// ��ȡ��ǰ����״̬
        /// </summary>
        public TransBlock CurTransBlock
        {
            get;
            set;
        }

        /// <summary>
        /// ��ǰ�ڱ�������ռλ�ñ�
        /// </summary>
        public List<Position> CurPosList
        {
            get;
            set;
        }

        /// <summary>
        /// �任ʱ���������
        /// </summary>
        public int TransRectWidth
        {
            get { return Math.Max(CurTransBlock.XBlocks, CurTransBlock.YBlocks); }
        }

        /// <summary>
        /// ���鵱ǰ�ڱ����е�λ��
        /// </summary>
        public Position position
        {
            get;
            set;
        }

        /// <summary>
        /// �´α任������״
        /// </summary>
        protected TransBlock NextBlockStatus
        {
            get
            {
                //ȡ��ǰ�����������
                int index = transBlockList.IndexOf(this.CurTransBlock);
                //�����´δα任������״
                if (index >= transBlockList.Count - 1)
                    return transBlockList[0];
                else
                    return transBlockList[index + 1];
            }
        }

        /// <summary>
        /// �Ƿ�ֹͣ�½�
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
            //this.position = new Position();�������г�ʼ��
            this.transformOriginPosition = new Position();
        }

        /// <summary>
        /// �ƶ���ָ��λ��
        /// </summary>
        /// <param name="newPos">ָ��λ��</param>
        /// <returns>�ƶ��󱻸��ĵ�λ���б�</returns>
        protected List<Position> Move(Position newPos, TransBlock CurTransBlock)
        {
            //�ػ�����λ���б�
            List<Position> reDrawList = new List<Position>();
            //��ײ���
            if (!NewCanvas.IsBump(this.NewCanvas.NewPositions(this.CurPosList, newPos, CurTransBlock)))
            {
                //����ɷ���λ��
                NewCanvas.Clear(CurPosList);
                //�����ػ�����
                reDrawList = CurPosList;
                //��ӷ��鵽����
                CurPosList = NewCanvas.AddBlock(newPos, CurTransBlock, reDrawList);
                //���浱ǰ������ʼλ��
                position = newPos;
            }
            return reDrawList;
        }

        /// <summary>
        /// �����ƶ�
        /// </summary>        
        /// <returns>�Ƿ��ܹ��½�</returns>
        public bool Down()
        {
            List<Position> reDrawList = new List<Position>();
            if (!DropStop)
            {
                reDrawList = Move(new Position(position.X, position.Y + 1), CurTransBlock);
                //���ݷ����б�����ж��½��Ƿ�ɹ�
                if (reDrawList.Count > 0)
                {
                    //���õ�ǰ�����־
                    NewCanvas.NewBlockFlag = false;
                    //�ػ�����
                    NewCanvas.Draw(reDrawList);
                }
                

            }
            return DropStop;
        }


       

             
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>���ػ�λ���б�</returns>
        public List<Position> Left()
        {
            List<Position> reDrawList;
            reDrawList = Move(new Position(position.X - 1, position.Y), CurTransBlock);
            return reDrawList;
        }

        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>���ػ�λ���б�</returns>
        public List<Position> Right()
        {
            List<Position> reDrawList;
            reDrawList = Move(new Position(position.X + 1, position.Y), CurTransBlock);
            return reDrawList;
        }

        /// <summary>
        /// ���ñ任ԭ������
        /// </summary>
        protected void ResetTransformOriginPosition()
        {
            transformOriginPosition.X = position.X - CurTransBlock.Position.X;
            transformOriginPosition.Y = position.Y - CurTransBlock.Position.Y;
        }

        /// <summary>
        /// �ɷ�任
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanTrans()
        {
            ResetTransformOriginPosition();
            //����Ƿ��ܽ��б任
            bool canTrans = NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
            //ԭ�����ƣ������ܷ�任
            if (!canTrans)
            {
                for (int i = 0; i < TransRectWidth / 2 && (!canTrans); i++)
                {
                    transformOriginPosition.X--;
                    canTrans = NewCanvas.CanTransform(transformOriginPosition, this.CurPosList, this.TransRectWidth);
                }
            }
            //ԭ�����ƣ������ܷ�任
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
        /// �����ڱ���ͼ�еı��δ���
        /// </summary>
        /// <returns>���ػ�λ���б�</returns>
        public List<Position> Transform()
        {
            //�ػ�λ�ñ�
            List<Position> reDrawList = new List<Position>();

            //���б任
            if (CanTrans())
            {
                //��ȡ�任��ķ���λ��
                Position newPos = new Position(transformOriginPosition.X + NextBlockStatus.Position.X, transformOriginPosition.Y + NextBlockStatus.Position.Y);
                //ִ�б任
                reDrawList = Move(newPos, NextBlockStatus);
                this.CurTransBlock = NextBlockStatus;
            }
            return reDrawList;
        }
    }
}
