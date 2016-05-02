using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    public class Square : Class_PolygonBase
    {
        public override bool Init(byte[,] Bytes_TetrisByte)
        {
            int_State = -1;
            return InitBase(Bytes_TetrisByte, new KeyValuePair<int, int>(0, 4), new KeyValuePair<int, int>(0, 5),
                                              new KeyValuePair<int, int>(1, 4), new KeyValuePair<int, int>(1, 5));
        }
    }
}
