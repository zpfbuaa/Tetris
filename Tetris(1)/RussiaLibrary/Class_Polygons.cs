using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussiaLibrary
{
    /// <summary>
    /// 所有方块的基类，包含大部分对方块的操作方法（除了change）。
    /// </summary>
    public class Class_PolygonBase
    {
        //记录当前方块有哪几个点组成.
        protected List<KeyValuePair<int, int>> points = new List<KeyValuePair<int, int>>();

        //记录当前方块的状态,以确定变形时,各个点的位置应该怎么变.
        protected int int_State = -2;

        //初始化方块的4个点.
        public virtual bool Init(byte[,] Bytes_TetrisByte) { return true; }

        //方块变形...这块实在是有点难...还没实现好...各位高手求解俄罗斯方块的变形逻辑啊!!
        public virtual void Change(byte[,] Bytes_TetrisByte) { }

        /// <summary>
        /// 方块下移
        /// </summary>
        /// <param name="Bytes_TetrisByte"></param>
        /// <returns></returns>
        public bool MoveDown(byte[,] Bytes_TetrisByte)
        {
            if (CheckContinue(Bytes_TetrisByte, "MoveDown"))
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

        /// <summary>
        /// 获取整体数组,并操作数组中的方块左右移动.
        /// </summary>
        /// <param name="Bytes_TetrisByte"></param>
        /// <param name="option"></param>
        public void MoveLeftOrRight(byte[,] Bytes_TetrisByte, string option)
        {
            if (CheckContinue(Bytes_TetrisByte, option))
            {
                List<KeyValuePair<int, int>> newPoints = new List<KeyValuePair<int, int>>();
                foreach (KeyValuePair<int, int> point in points)
                {
                    Bytes_TetrisByte[point.Key, point.Value] = 0;
                }
                if (option == "MoveLeft")
                {
                    foreach (KeyValuePair<int, int> point in points)
                    {
                        Bytes_TetrisByte[point.Key, point.Value - 1] = 1;
                        newPoints.Add(new KeyValuePair<int, int>(point.Key, point.Value - 1));
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, int> point in points)
                    {
                        Bytes_TetrisByte[point.Key, point.Value + 1] = 1;
                        newPoints.Add(new KeyValuePair<int, int>(point.Key, point.Value + 1));
                    }
                }
                points = newPoints;
            }
        }

        //在判断方块可以下移后,使方块所有点下移一位.
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

        //方块落底,变为不可移动状态.
        private void Fasten(byte[,] Bytes_TetrisByte) 
        {
            foreach (KeyValuePair<int, int> point in points)
            {
                if (Bytes_TetrisByte[point.Key, point.Value] == 1)
                {
                    Bytes_TetrisByte[point.Key, point.Value] = 2;
                }
            }
            ClearRow(Bytes_TetrisByte);
        }

        //在方块落底之后,若有可以消除的行,在此进行消除.
        private void ClearRow(byte[,] Bytes_TetrisByte)
        {
            for (int i = 0; i < Class_Common.Length; i++)
            {
                bool needClear = true;
                for (int j = 0; j < Class_Common.Width; j++)
                {
                    if (Bytes_TetrisByte[i, j] != 2)
                    {
                        needClear = false;
                        break;
                    }
                }
                if (needClear)
                {
                    RemoveRow(Bytes_TetrisByte, i);
                }
            }
        }

        // 真正的消行.此处不是把行真正的删除,而是把此行数组点全部置为0,并不断和其上一行交换位置,直到此行被交换到数组的最上一行。
        // 此处这么处理的主要原因：当一个方块消行之后，其上面的行会随之下落一行的效果。
        private void RemoveRow(byte[,] Bytes_TetrisByte, int row)
        {
            for (int i = row; i >= 0; i--)
            {
                if (i - 1 >= 0)
                {
                    for (int j = 0; j < Class_Common.Width; j++)
                    {
                        Bytes_TetrisByte[i, j] = 0;
                        byte temp = Bytes_TetrisByte[i, j];
                        Bytes_TetrisByte[i, j] = Bytes_TetrisByte[i - 1, j];
                        Bytes_TetrisByte[i - 1, j] = temp;
                    }
                }
            }
        }

        //检测方块是否可以被移动.若超出边界或碰到已存在的方块,则返回false表示不可移动
        private bool CheckContinue(byte[,] Bytes_TetrisByte, string option)
        {
            switch (option)
            {
                case "MoveDown":
                    foreach (KeyValuePair<int, int> point in points)
                    {
                        if (point.Key + 1 > Class_Common.Length - 1 || Bytes_TetrisByte[point.Key + 1, point.Value] == 2)
                        {
                            return false;
                        }
                    }
                    break;
                case "MoveLeft":
                    foreach (KeyValuePair<int, int> point in points)
                    {
                        if (point.Value - 1 < 0 || Bytes_TetrisByte[point.Key, point.Value - 1] == 2)
                        {
                            return false;
                        }
                    }
                    break;
                case "MoveRight":
                    foreach (KeyValuePair<int, int> point in points)
                    {
                        if (point.Value + 1 > Class_Common.Width - 1 || Bytes_TetrisByte[point.Key, point.Value + 1] == 2)
                        {
                            return false;
                        }
                    }
                    break;
                default:
                    return false;
            }

            return true;
        }

        //把刚生成的方块所占据的数组中的点位设置为1，若此方块刚生成所需要占据的点位有值为2的点，则表示游戏结束。
        protected bool InitBase(byte[,] Bytes_TetrisByte, params KeyValuePair<int, int>[] initPoints) 
        {
            foreach (KeyValuePair<int, int> point in initPoints) 
            {
                if (Bytes_TetrisByte[point.Key, point.Value] == 2) 
                {
                    return false;
                }
                Bytes_TetrisByte[point.Key, point.Value] = 1;
                points.Add(point);
            }
            return true;
        }
        
        /// <summary>
        /// 对当前方块中的点进行排序，越高越靠前，越左越靠前。
        /// </summary>
        protected int SortPoints(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            if (x.Key < y.Key)
            {
                return -1;
            }
            else if (x.Key > y.Key)
            {
                return 1;
            }
            else
            {
                if (x.Value < y.Value)
                {
                    return -1;
                }
                else if (x.Value > y.Value)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        //移动到最底。
        public void MoveToEnd(byte[,] Bytes_TetrisByte)
        {
            while (MoveDown(Bytes_TetrisByte)) { }
        }
    }

}
