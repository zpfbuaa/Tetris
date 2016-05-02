using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    /// <summary>
    /// 对外可见的操作类，对数组进行一系列操作。
    /// </summary>
    public class Class_ControlArray
    {
        public byte[,] Bytes_TetrisByte;

        //当前操作的方块。
        public Class_PolygonBase ControlPolygon;

        //下一个方块（用于界面上提示玩家下一个方块的形状）
        public Class_PolygonBase NextControlPolygon;

        //初始化俄罗斯方块的数组,0 表示空,1 表示正在下落的方块, 2 表示已经落底,无法继续操作的方块.
        private void ResetTetrisByte()
        {
            Bytes_TetrisByte = new byte[Class_Common.Length, Class_Common.Width] { 
                                            //0 ,1, 2, 3, 4, 5, 6, 7, 8, 9
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//0
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//1
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//2
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//3
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//4
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//5
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//6
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//7
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//8
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//9
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//10
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//11
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//12
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//13
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//14
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//15
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//16
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//17
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//18
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//19
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},//20
                                            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} //21
                                         };
        }

        public Class_ControlArray() 
        {
            ResetTetrisByte();
        }

        /// <summary>
        /// 初始化当前和下一个方块,并返回当前方块初始化之后的状态。
        /// </summary>
        /// <returns>True:Continue.False:Game Over</returns>
        public bool InitPolygon() 
        {
            ControlPolygon = null;
            if (NextControlPolygon == null) 
            {
                InitNextPolygon();
            }
            ControlPolygon = NextControlPolygon;
            InitNextPolygon();
            lock (Class_Common.TetrisLocker)
            {
                return ControlPolygon.Init(Bytes_TetrisByte);
            }
        }

        //下落。
        public bool MoveDown()
        {
            return ControlPolygon.MoveDown(Bytes_TetrisByte);
        }

        //下落到最底层。
        public void MoveToEnd()
        {
            ControlPolygon.MoveToEnd(Bytes_TetrisByte);
        }

        //初始化方块形状。
        private void InitNextPolygon() 
        {
            NextControlPolygon = null;
            switch (Class_Common.GetRandomInt() % 5)
            {
                case 0:
                    NextControlPolygon = new Square();
                    break;
                case 1:
                    NextControlPolygon = new ZPolygon();
                    break;
                case 2:
                    NextControlPolygon = new LPolygon();
                    break;
                case 3:
                    NextControlPolygon = new TPolygon();
                    break;
                case 4:
                    NextControlPolygon = new IPolygon();
                    break;
            }
        }
        //左右移动。
        public void MoveLeftOrRight(string option)
        {
            ControlPolygon.MoveLeftOrRight(Bytes_TetrisByte, option);
        }
        //变形。
        public void Change()
        {
            ControlPolygon.Change(Bytes_TetrisByte);
        }
    }
}
