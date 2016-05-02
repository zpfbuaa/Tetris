using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Level
    {
        //������һ���������
        private int upScore;
        //ʱ����
        private int interval;
        //�ؿ�����
        private string name;

        /// <summary>
        /// ������һ���������
        /// </summary>
        public int UpScore
        {
            get { return upScore; }
        }

        /// <summary>
        /// ʱ����
        /// </summary>
        public int Interval
        {
            get { return interval; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public Level(string name, int score, int interval)
        {
            this.upScore = score;
            this.interval = interval;
            this.name = name;
        }
    }
}
