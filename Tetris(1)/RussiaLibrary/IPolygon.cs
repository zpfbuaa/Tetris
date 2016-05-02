using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    public class IPolygon : Class_PolygonBase
    {
        //重写Init函数，生成方块的4个点位。
        public override bool Init(byte[,] Bytes_TetrisByte)
        {
            int_State = Class_Common.GetRandomInt() % 2;
            switch (int_State)
            {
                case 0:// ---
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(1, 3), new KeyValuePair<int, int>(1, 4),
                                                      new KeyValuePair<int, int>(1, 5), new KeyValuePair<int, int>(1, 6));
                case 1:// |
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 4), new KeyValuePair<int, int>(1, 4),
                                                      new KeyValuePair<int, int>(2, 4), new KeyValuePair<int, int>(3, 4));
            }
            return false;
        }

        //变形函数。这块写的不好，只是提供一个思路。。。。。
        public override void Change(byte[,] Bytes_TetrisByte)
        {
            points.Sort(SortPoints);
            bool canChange = true;
            if (int_State == 0)
            {
                if (points[1].Key + 1 < Class_Common.Length && points[1].Key - 2 >= 0) //判断变化之后不越界！
                {
                    for (int i = points[1].Key - 2; i <= points[1].Key + 1; i++)//以第二个点为轴！
                    {
                        if (Bytes_TetrisByte[i, points[1].Value] == 2)
                        {
                            canChange = false;
                        }
                    }
                    if (canChange)
                    {
                        List<KeyValuePair<int, int>> newPoints = new List<KeyValuePair<int, int>>();
                        for (int i = 0; i < points.Count; i++)
                        {
                            Bytes_TetrisByte[points[i].Key, points[i].Value] = 0;
                            KeyValuePair<int, int> tempPoint;
                            switch (i)
                            {
                                case 0:
                                    tempPoint = new KeyValuePair<int, int>(points[i].Key + 1, points[i].Value + 1);
                                    newPoints.Add(tempPoint);
                                    Bytes_TetrisByte[tempPoint.Key, tempPoint.Value] = 1;
                                    break;
                                case 1:
                                    newPoints.Add(points[1]);
                                    Bytes_TetrisByte[points[1].Key, points[1].Value] = 1;
                                    break;
                                case 2:
                                    tempPoint = new KeyValuePair<int, int>(points[i].Key - 1, points[i].Value - 1);
                                    newPoints.Add(tempPoint);
                                    Bytes_TetrisByte[tempPoint.Key, tempPoint.Value] = 1;
                                    break;
                                case 3:
                                    tempPoint = new KeyValuePair<int, int>(points[i].Key - 2, points[i].Value - 2);
                                    newPoints.Add(tempPoint);
                                    Bytes_TetrisByte[tempPoint.Key, tempPoint.Value] = 1;
                                    break;
                            }
                        }
                        int_State = int_State + 1 % 2;
                        points = newPoints;
                    }
                }
            }
        }
    }
}
