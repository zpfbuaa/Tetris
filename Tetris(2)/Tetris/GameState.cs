using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// 游戏状态
    /// 分：等待开始、运行、暂停、结束
    /// </summary>
    public enum GameState
    {
        Wait,
        Run,
        Pause,
        Over,
        Deleting,
    }
}
