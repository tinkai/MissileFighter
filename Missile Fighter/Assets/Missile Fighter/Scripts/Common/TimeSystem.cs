using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Common
{
    public class TimeSystem : MonoBehaviour
    {
        // 時間が止まっているか判定する変数
        private bool timeStop;

        //*************************************************************

        // 時間の静止と開始を交互させる
        public void ChangeTimeStop()
        {
            if (timeStop)
            {
                Time.timeScale = 1f;
                timeStop = false;
            }
            else
            {
                Time.timeScale = 0f;
                timeStop = true;
            }
        }
    }
}