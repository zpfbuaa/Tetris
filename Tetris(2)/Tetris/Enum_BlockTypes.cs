using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 方块类型
    /// </summary>
    public enum Enum_BlockTypes
    {
        //悬空，表示当前方格中没有方块
        Null=0,   
        I = 1,
        J = 2,
        L = 3,        
        Z = 4,
        S = 5,
        T = 6,
        O = 7,       
        Block=8,
      
    }
}
