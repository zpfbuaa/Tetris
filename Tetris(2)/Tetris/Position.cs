using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public sealed class Position
    {
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Position()
        {
            x = y = 0;
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// ���λ���б����Ƿ���ָ��λ��
        /// </summary>
        /// <param name="posList">�����λ���б�</param>
        /// <param name="pos">������ָ��λ��</param>
        /// <returns>���ز���ֵ</returns>
        public static bool HasPosition(List<Position> posList, Position pos)
        {
            foreach (Position p in posList)
            {
                if (pos.X == p.X && pos.Y == p.Y)
                    return true;
            }
            return false;
        }
    }
}
