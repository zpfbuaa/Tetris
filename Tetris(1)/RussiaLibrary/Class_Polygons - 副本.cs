using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    public class Class_PolygonBase
    {
        protected List<KeyValuePair<int, int>> points = new List<KeyValuePair<int, int>>();
        protected int int_State = -2;
        public virtual void Init(byte[,] Bytes_TetrisByte) { }
        public virtual int Change(byte[,] Bytes_TetrisByte) { return -2; }

        public bool MoveDown(byte[,] Bytes_TetrisByte) 
        {
            lock (Class_Common.TetrisLocker) 
            {
                if (CheckContinue(Bytes_TetrisByte,"MoveDown"))
                {
                    RealMoveDown(Bytes_TetrisByte);
                    return true;
                }
                else 
                {
                    Fasten(Bytes_TetrisByte);
                    return false;
                }
            }
        }

        private void RealMoveDown(byte[,] Bytes_TetrisByte) 
        {
            List<KeyValuePair<int, int>> newPoints = new List<KeyValuePair<int, int>>();
            foreach (KeyValuePair<int, int> point in points) 
            {
                Bytes_TetrisByte[point.Key, point.Value] = 0;
            }
            foreach (KeyValuePair<int, int> point in points)
            {
                Bytes_TetrisByte[point.Key + 1, point.Value] = 1;
                newPoints.Add(new KeyValuePair<int, int>(point.Key + 1, point.Value));
            }
            points = newPoints;
        }

        private void Fasten(byte[,] Bytes_TetrisByte) 
        {
            foreach (KeyValuePair<int, int> point in points)
            {
                Bytes_TetrisByte[point.Key, point.Value] = 2;
            }
        }

        private bool CheckContinue(byte[,] Bytes_TetrisByte,string option) 
        {
            if (option.Equals("MoveDown"))
            {
                foreach (KeyValuePair<int, int> point in points)
                {
                    if (point.Key + 1 > Class_Common.Length || Bytes_TetrisByte[point.Key + 1, point.Value] == 2)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        protected void InitBase(byte[,] Bytes_TetrisByte, params KeyValuePair<int, int>[] initPoints) 
        {
            foreach (KeyValuePair<int, int> point in points) 
            {
                Bytes_TetrisByte[point.Key, point.Value] = 1;
                points.Add(point);
            }
        }
    }

    public class LPolygon : Class_PolygonBase
    {
        public override void Init(byte[,] Bytes_TetrisByte)
        {
            int_State = Class_Common.GetRandomInt() % 8;
            switch (int_State)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
        }
    }

    public class ZPolygon : Class_PolygonBase
    {
        public override void Init(byte[,] Bytes_TetrisByte)
        {
            int_State = Class_Common.GetRandomInt() % 4;
            switch (int_State)
            {
                case 0:
                    Bytes_TetrisByte[0, 4] = 1;
                    Bytes_TetrisByte[0, 5] = 1;
                    Bytes_TetrisByte[1, 5] = 1;
                    Bytes_TetrisByte[1, 6] = 1;
                    break;
                case 1:
                    Bytes_TetrisByte[0, 5] = 1;
                    Bytes_TetrisByte[1, 4] = 1;
                    Bytes_TetrisByte[1, 5] = 1;
                    Bytes_TetrisByte[2, 4] = 1;
                    break;
                case 2:
                    Bytes_TetrisByte[0, 5] = 1;
                    Bytes_TetrisByte[0, 6] = 1;
                    Bytes_TetrisByte[1, 4] = 1;
                    Bytes_TetrisByte[1, 5] = 1;
                    break;
                case 3:
                    Bytes_TetrisByte[0, 4] = 1;
                    Bytes_TetrisByte[1, 4] = 1;
                    Bytes_TetrisByte[1, 5] = 1;
                    Bytes_TetrisByte[2, 5] = 1;
                    break;
            }
        }
    }

    public class Square : Class_PolygonBase
    {
        public override void Init(byte[,] Bytes_TetrisByte)
        {
            int_State = -1;
            Bytes_TetrisByte[0, 4] = 1;
            points.Add(new KeyValuePair<int, int>(0, 4));
            Bytes_TetrisByte[0, 5] = 1;
            points.Add(new KeyValuePair<int, int>(0, 5));
            Bytes_TetrisByte[1, 4] = 1;
            points.Add(new KeyValuePair<int, int>(1, 4));
            Bytes_TetrisByte[1, 5] = 1;
            points.Add(new KeyValuePair<int, int>(1, 5));
        }
    }

    public class TPolygon : Class_PolygonBase
    {
        public override void Init(byte[,] Bytes_TetrisByte)//初始化T型
        {
            int_State = Class_Common.GetRandomInt() % 4;
            switch (int_State)
            {
                case 0:
                    InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 4), new KeyValuePair<int, int>(1, 4), new KeyValuePair<int, int>(2, 4), new KeyValuePair<int, int>(1, 5));
                    Bytes_TetrisByte[0, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 4));
                    Bytes_TetrisByte[1, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 4));
                    Bytes_TetrisByte[2, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(2, 4));
                    Bytes_TetrisByte[1, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 5));
                    break;
                case 1:
                    Bytes_TetrisByte[1, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 4));
                    Bytes_TetrisByte[1, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 5));
                    Bytes_TetrisByte[1, 6] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 6));
                    Bytes_TetrisByte[0, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 5));
                    break;
                case 2:
                    Bytes_TetrisByte[0, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 5));
                    Bytes_TetrisByte[1, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 5));
                    Bytes_TetrisByte[2, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(2, 5));
                    Bytes_TetrisByte[1, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 4));
                    break;
                case 3:
                    Bytes_TetrisByte[0, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 4));
                    Bytes_TetrisByte[0, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 5));
                    Bytes_TetrisByte[0, 6] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 6));
                    Bytes_TetrisByte[1, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 5));
                    break;
                default:
                    break;
            }
        }
    }

    public class IPolygon : Class_PolygonBase 
    {
        public override void Init(byte[,] Bytes_TetrisByte)
        {
            int_State = Class_Common.GetRandomInt() % 2;
            switch (int_State)
            {
                case 0:
                    Bytes_TetrisByte[1, 3] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 3));
                    Bytes_TetrisByte[1, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 4));
                    Bytes_TetrisByte[1, 5] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 5));
                    Bytes_TetrisByte[1, 6] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 6));
                    break;
                case 1:
                    Bytes_TetrisByte[0, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(0, 4));
                    Bytes_TetrisByte[1, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(1, 4));
                    Bytes_TetrisByte[2, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(2, 4));
                    Bytes_TetrisByte[3, 4] = 1;
                    points.Add(new KeyValuePair<int, int>(3, 4));
                    break;
            }
        }
    }
}
