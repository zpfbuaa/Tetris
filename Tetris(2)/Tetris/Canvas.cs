using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Canvas
    {
        public int m_rows;
        public int m_columns;
        public int[,] m_arr;
        public int m_score;     //分数
        private Brick m_curBrick = null;
        private Brick m_nextBrick = null;
        private int m_height;    //当前高度

        public Canvas()
        {
            m_rows = 20;
            m_columns = 20;
            m_arr = new int[m_rows, m_columns];
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    m_arr[i, j] = 0;
                }
            }
            m_score = 0;
            m_height = 0;
        }

        //定时器  砖块定时下降或无法下降时生成新的砖块
        public bool Run()
        {
           //判断是否为空
            lock (m_arr)
            {
                if (m_curBrick == null && m_nextBrick == null)
                {
                    m_curBrick = Bricks.GetBrick();
                    m_nextBrick = Bricks.GetBrick();
                    m_nextBrick.RandomShape();
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1);
                    SetArrayValue();
                }
                else if (m_curBrick == null)
                {
                    m_curBrick = m_nextBrick;
                    m_nextBrick = Bricks.GetBrick();
                    m_nextBrick.RandomShape();
                    m_curBrick.SetCenterPos(m_curBrick.Appear(), m_columns / 2 - 1);
                    SetArrayValue();
                }
                else
                {
                    if (m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)
                    {
                        ClearCurBrick();
                        m_curBrick.DropMove();
                        SetArrayValue();
                    }
                    else
                    {
                        m_curBrick = null;
                        SetCurHeight();
                        ClearRow();
                    }
                }
                if (m_score >= 100)
                    return false;
                if (m_height < m_rows)
                    return true;
                else
                    return false;
            }
        }

        //根据清除当前砖块在m_arr中的值
        private void ClearCurBrick()
        {
            int centerX = m_curBrick.m_center.X;
            int centerY = m_curBrick.m_center.Y;
            for (int i = 0; i < m_curBrick.m_needfulRows; i++)
            {
                for (int j = 0; j < m_curBrick.m_needfulColumns; j++)
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 0;
                        }
                    }
                }
            }
        }

        //根据当前砖块设置m_arr的值
        public void SetArrayValue()
        {
            int centerX = m_curBrick.m_center.X;
            int centerY = m_curBrick.m_center.Y;
            for (int i = 0; i < m_curBrick.m_needfulRows; i++)
            {
                for (int j = 0; j < m_curBrick.m_needfulColumns; j++)
                {
                    int realX = m_curBrick.m_Pos.X - (centerX - i);
                    int realY = m_curBrick.m_Pos.Y - (centerY - j);
                    if (realX < 0 || realX >= m_columns || realY < 0 || realY >= m_rows)
                    {
                        continue;
                    }
                    else
                    {
                        if (m_curBrick.m_range[i, j] == 0)
                        {
                            continue;
                        }
                        else
                        {
                            m_arr[realX, realY] = 1;
                        }
                    }
                }
            }
        }
    
        //判断当前有没有填满的行，有则消除、加分
        private void ClearRow()
        {
            int clearrows = 0;
            for (int i = m_rows-m_height; i < m_rows; i++)
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 0)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull == true)
                {
                    clearrows++;
                    m_score++;
                    for (int k = 0; k < m_columns; k++)
                    {
                        m_arr[i, k] = 0;
                    }
                }
            }
            for (int i = m_rows - 1; i > m_rows - m_height - 1; i--)
            {
                bool isfull = true;
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 1)
                    {
                        isfull = false;
                        break;
                    }
                }
                if (isfull == true)
                {
                    int n = i;
                    for (int m=n-1; m>m_rows-m_height-2; m--)
                    {
                        if (n == 0)
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = 0;
                            }
                        }
                        else
                        {
                            for (int k = 0; k < m_columns; k++)
                            {
                                m_arr[n, k] = m_arr[m, k];
                            }
                            n--;
                        }
                    }
                }
            }
            m_height -= clearrows;
        }

        //计算当期高度
        private void SetCurHeight()
        {
            for (int i = 0; i < m_rows; i++)
            {
                for (int j = 0; j < m_columns; j++)
                {
                    if (m_arr[i, j] == 1)
                    {
                        m_height = m_rows - i;
                        return;
                    }
                }
            }
        }

        
        //左移
        public void BrickLeft()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanLeftMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.LeftMove();
                    SetArrayValue();
                }
            }
        }

        //右移
        public void BrickRight()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanRightMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.RightMove();
                    SetArrayValue();
                }
            }
        }

        //下移
        public void BrickDown()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanDropMove(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.DropMove();
                    SetArrayValue();
                }
            }
        }

        //变形
        public void BrickUp()
        {
            lock (m_arr)
            {
                if (m_curBrick != null && m_curBrick.CanTransform(m_arr, m_rows, m_columns) == true)
                {
                    ClearCurBrick();
                    m_curBrick.Transform();
                    SetArrayValue();
                }
            }
        }

        //
        public void DrawNewxBrick(Graphics gra, float itemwidth, float itemheight)
        {
            int[,] arr = new int[5, 5]{{0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0},
                                         {0,0,0,0,0,}};
            switch (m_nextBrick.m_needfulColumns)
            {
                case 2:
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    break;
                case 3:
                    for (int i = 1,m=0; i < 4; i++,m++)
                    {
                        for (int j = 1,n=0; j < 4; j++,n++)
                        {
                            arr[i, j] = m_nextBrick.m_range[m, n];
                        }
                    }
                    break;
                case 5:
                    arr = m_nextBrick.m_range;
                    break;
                default:
                    return;
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        gra.FillRectangle(Brushes.Red, j * itemwidth, i * itemheight, itemwidth - 2, itemheight - 2);
                    }
                }
            }
        }
    }
}
