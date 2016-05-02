using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tetris
{
    public class HighScore
    {
        static List<HighScore> highScoreList;
        static string fileName = "Score.dat";

        public static List<HighScore> HighScoreList
        {
            get
            {
                if (highScoreList == null)
                {
                    highScoreList = new List<HighScore>();
                    //��ȡ�߷��ļ�
                    StreamReader sr = null;
                    if (File.Exists(fileName))
                    {
                        try
                        {
                            //���ļ�
                            sr = File.OpenText(fileName);
                            //��ȡ������list������
                            string str = sr.ReadLine();
                            int i = 0;
                            while (str != null && i < 10)
                            {
                                string[] tmp = str.Split(',');
                                highScoreList.Add(new HighScore(tmp[0], Convert.ToInt32(tmp[1])));
                                str = sr.ReadLine();
                                i++;
                            }
                        }
                        catch (Exception)
                        { }
                        finally
                        {
                            if (sr != null)
                                sr.Close();
                        }
                    }
                }
                return highScoreList;
            }
        }

        /// <summary>
        /// ȡ���������а��е�ֵ
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static int Rank(int score)
        {
            highScoreList = HighScoreList;
            if (highScoreList.Count > 0)
            {
                int i;
                for (i = highScoreList.Count; i > 0 && score > highScoreList[i-1].Score ; i--)
                { }
                return ++i;
            }
            else
                return 1;
        }

        /// <summary>
        /// ����������б���
        /// </summary>
        /// <param name="index"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        public static void Insert(int order, string name, int score)
        {
            highScoreList = HighScoreList;
            if(highScoreList.Count >= order - 1)
            {
                highScoreList.Insert(order - 1, new HighScore(name, score));
            }
        }

        public static void Save()
        { 
            if(highScoreList.Count > 0)
            {
                StreamWriter sw = null;
                try
                {
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    sw = File.CreateText(fileName);
                    for(int j = 0; j < highScoreList.Count && j < 10; j++)
                        sw.WriteLine(highScoreList[j].name + "," + highScoreList[j].score);
                }
                catch (Exception)
                { }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
            }
        }

        public static string HighScoreListToString()
        {
            highScoreList = HighScoreList;
            string str = "";
            for (int i = 0; i < highScoreList.Count && i < 10; i++)
            {
                str += "��" + (i + 1).ToString() + "����" + String.Format("{0,6}", highScoreList[i].name) + "    " + String.Format("{0:D6}", highScoreList[i].score) + "\r\n";
            }

            return str;
        }

        string name;
        int score;
        
        public string Name
        {
            get { return this.name; }
        }

        public int Score
        {
            get { return this.score; }
        }

        public HighScore(string name, int score)
        {
            this.name = name;
            if (this.name == "")
                this.name = " ";
            this.score = score;
        }
    }
}
