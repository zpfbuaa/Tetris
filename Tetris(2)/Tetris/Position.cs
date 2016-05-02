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
        /// 检查位置列表中是否含有指定位置
        /// </summary>
        /// <param name="posList">传入的位置列表</param>
        /// <param name="pos">待查找指定位置</param>
        /// <returns>返回布尔值</returns>
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
