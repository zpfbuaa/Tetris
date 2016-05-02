using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    /// <summary>
    /// 通用类，放一些公用的方法和常量。
    /// </summary>
    public class Class_Common
    {
        //获取随即数。
        public static int GetRandomInt()
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            return ran.Next();
        }

        //锁，防止多个线程同时操作数组，导致异常。
        public static object TetrisLocker = new object();
        
        //绘图只用20个,前两行是方块刚生成时缓冲用的
        public const int Length = 22;
        public const int Width = 10;
    }
}
