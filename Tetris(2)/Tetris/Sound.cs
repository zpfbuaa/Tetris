using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Tetris
{
    public class Sound
    {
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string m_strCmd, string m_strReceive, int m_v1, int m_v2);

        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);

        //Mic�豸����
        private string micName = "";

        /// <summary>
        /// Mic�豸����
        /// </summary>
        public string MicName
        {
            get { return micName; }
            set 
            {
                //����ļ��Ƿ����
                if (File.Exists(value))
                { 
                    //ȡ��·���ִ���ʽ
                    StringBuilder shortpath = new StringBuilder(80);
                    GetShortPathName(value, shortpath, shortpath.Capacity);
                    string str = shortpath.ToString();
                    //���������ļ��뵱ǰ�ļ���ͬ�����ȹرյ�ǰ�ļ�
                    if(this.micName != str)
                        this.Close();
                    this.micName = str;
                }
            }
        }

        /// <summary>
        /// ����Mic�豸����
        /// </summary>
        /// <param name="micName"></param>
        public Sound(string micName)
        {
            MicName = micName;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void Play()
        {
            mciSendString("play " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// �ظ�����
        /// </summary>
        public void PlayRepeat()
        {
            mciSendString("play " + micName + " repeat", string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// ��ͣ����
        /// </summary>
        public void Pause()
        {
            mciSendString("pause " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void Resume()
        {
            mciSendString("resume " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void Stop()
        {
            mciSendString("stop " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// �ر��ļ�
        /// </summary>
        public void Close()
        {
            mciSendString("close " + micName, string.Empty, string.Empty.Length, 0);
        }
    }
}