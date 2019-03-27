using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.GlobalDatas
{
    public class Score : MonoBehaviour
    {
        // 敵の撃破数
        public static int Kills;

        // 経過時間
        public static float ElapsedTime;

        // 時間を止めるか否か
        public static bool TimeStop;

        // 敵を全員倒してクリアしたか
        public static bool IsClear;

        //*********************************************************

        private void Awake()
        {
            Kills = 0;
            ElapsedTime = 0;
            TimeStop = false;
            IsClear = false;
        }

        private void Update()
        {
            if (TimeStop == false)
            {
                ElapsedTime += Time.deltaTime;
            }
        }

        // 総合点数を計算
        public static int CalcTotalScore()
        {
            if (IsClear)
            {
                // キル数 + 余った時間 + 全時間分(生き残ることができるから)
                return Kills * 1000 + (StageData.Instance.LimitTime - (int)ElapsedTime) * 100 + StageData.Instance.LimitTime * 10;
            }
            else
            {
                // キル数 + 生き延びた時間
                return Kills * 1000 + (int)ElapsedTime * 10;
            }
        }
    }
}