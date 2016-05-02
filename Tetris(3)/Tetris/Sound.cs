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

        //Mic设备名称
        private string micName = "";

        /// <summary>
        /// Mic设备名称
        /// </summary>
        public string MicName
        {
            get { return micName; }
            set 
            {
                //检查文件是否存在
                if (File.Exists(value))
                { 
                    //取短路径字串格式
                    StringBuilder shortpath = new StringBuilder(80);
                    GetShortPathName(value, shortpath, shortpath.Capacity);
                    string str = shortpath.ToString();
                    //如果传入的文件与当前文件不同，则先关闭当前文件
                    if(this.micName != str)
                        this.Close();
                    this.micName = str;
                }
            }
        }

        /// <summary>
        /// 传入Mic设备名称
        /// </summary>
        /// <param name="micName"></param>
        public Sound(string micName)
        {
            MicName = micName;
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        public void Play()
        {
            mciSendString("play " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// 重复播放
        /// </summary>
        public void PlayRepeat()
        {
            mciSendString("play " + micName + " repeat", string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// 暂停播放
        /// </summary>
        public void Pause()
        {
            mciSendString("pause " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// 继续播放
        /// </summary>
        public void Resume()
        {
            mciSendString("resume " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void Stop()
        {
            mciSendString("stop " + micName, string.Empty, string.Empty.Length, 0);
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void Close()
        {
            mciSendString("close " + micName, string.Empty, string.Empty.Length, 0);
        }
    }
}