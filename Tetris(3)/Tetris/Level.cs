using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Level
    {
        //升到下一关所需分数
        private int upScore;
        //时间间隔
        private int interval;
        //关卡名称
        private string name;

        /// <summary>
        /// 升到下一关所需分数
        /// </summary>
        public int UpScore
        {
            get { return upScore; }
        }

        /// <summary>
        /// 时间间隔
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
