using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    public class ZPolygon : Class_PolygonBase
    {
        public override bool Init(byte[,] Bytes_TetrisByte)
        {
            int_State = Class_Common.GetRandomInt() % 4;
            switch (int_State)
            {
                case 0:// z
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 4), new KeyValuePair<int, int>(0, 5),
                                                      new KeyValuePair<int, int>(1, 5), new KeyValuePair<int, int>(1, 6));
                case 1://  |
                       // |
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 5), new KeyValuePair<int, int>(1, 4),
                                                      new KeyValuePair<int, int>(1, 5), new KeyValuePair<int, int>(2, 4));
                case 2://   _
                       //  —
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 5), new KeyValuePair<int, int>(0, 6),
                                                      new KeyValuePair<int, int>(1, 4), new KeyValuePair<int, int>(1, 5));
                case 3:// |
                       //  |
                    return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 4), new KeyValuePair<int, int>(1, 4),
                                                      new KeyValuePair<int, int>(1, 5), new KeyValuePair<int, int>(2, 5));
            }
            return false;
        }
    }
}
