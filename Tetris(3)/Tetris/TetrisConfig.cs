using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public static class TetrisConfig
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static int BackPicWidth = 200;
        private static int BackPicHeight = 400;

        /// <summary>
        /// 获取背景图片
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Bitmap GetBackPic(int levelNumber)
        {
            //string fileName = Application.StartupPath + "\\Image\\BackPic" + levelNumber.ToString() + ".jpg";
            string fileName = Application.StartupPath + "\\Image\\BackPic.jpg";
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(fileName);
            }
            catch (Exception)
            {
                if (bm != null)
                    bm.Dispose();
                return TetrisResource.BackPic;
            }
            //如果图片宽高不相符，则拉伸图片
            if (bm.Width != BackPicWidth || bm.Height != BackPicHeight)
            {
                Bitmap tmpBm = bm;
                bm = new Bitmap(tmpBm, BackPicWidth, BackPicHeight);
                tmpBm.Dispose();
            }
            return bm;
        }

        /// <summary>
        /// 获取背景音乐文件名称
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetBackMusic(int levelNumber)
        {
            return Application.StartupPath + "\\Music\\Music" + levelNumber.ToString() + ".mp3";
        }

        /// <summary>
        /// 左移控制键
        /// </summary>
        public static string LeftKey
        {
            get { return config.AppSettings.Settings["Left"].Value; }
            set
            {
                config.AppSettings.Settings["Left"].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 右移控制键
        /// </summary>
        public static string RightKey
        {
            get { return config.AppSettings.Settings["Right"].Value; }
            set
            {
                config.AppSettings.Settings["Right"].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 下移控制键
        /// </summary>
        public static string DownKey
        {
            get { return config.AppSettings.Settings["Down"].Value; }
            set
            {
                config.AppSettings.Settings["Down"].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 变换控制键
        /// </summary>
        public static string TransformKey
        {
            get { return config.AppSettings.Settings["Transform"].Value; }
            set
            {
                config.AppSettings.Settings["Transform"].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 确定控制键
        /// </summary>
        public static string ConfirmKey
        {
            get { return config.AppSettings.Settings["Confirm"].Value; }
            set
            {
                config.AppSettings.Settings["Confirm"].Value = value;
                config.Save();
            }
        }

        /// <summary>
        /// 音乐开标志
        /// </summary>
        public static bool MusicOn
        {
            get { return Convert.ToBoolean(config.AppSettings.Settings["MusicOn"].Value); }
            set
            {
                config.AppSettings.Settings["MusicOn"].Value = value.ToString();
                config.Save();
            }
        }

        /// <summary>
        /// 音效开标志
        /// </summary>
        public static bool SoundOn
        {
            get { return Convert.ToBoolean(config.AppSettings.Settings["SoundOn"].Value); }
            set
            {
                config.AppSettings.Settings["SoundOn"].Value = value.ToString();
                config.Save();
            }
        }
    }
}
