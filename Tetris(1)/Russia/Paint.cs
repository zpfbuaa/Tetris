using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RussiaLibrary;
namespace Russia
{
    /// <summary>
    /// 针对panel的绘图类，绘制方格和Game Over,可扩展。
    /// </summary>
    class Paint
    {
        private Graphics gra;

        public Paint(Panel targetPanel) 
        {
            gra = targetPanel.CreateGraphics();
        }

        public void FillPanel(byte[,] Bytes_TetrisByte)
        {
            for (int x = 0; x < Class_Common.Width; x++)
            {
                for (int y = 2; y < Class_Common.Length; y++)
                {
                    if (Bytes_TetrisByte[y, x] == 1)
                    {
                        DrawElement(x, y - 2, Color.Red);
                    }
                    else if (Bytes_TetrisByte[y, x] == 2)
                    {
                        DrawElement(x, y - 2, Color.Purple);
                    }
                    else
                    {
                        DrawElement(x, y - 2, Color.Azure);
                    }
                }
            }
        }

        private void DrawElement(int x, int y, Color color)
        {
            Brush bru=new SolidBrush(color);
            gra.FillRectangle(bru, x * 20, y * 20, 17, 17);
        }

        public void DrawGameOver()
        {
            gra.Clear(Color.Azure);
            gra.DrawString("Game Over", new Font(FontFamily.GenericSerif, 11), new SolidBrush(Color.Red), 60, 200);
        }
    }
}
