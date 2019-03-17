using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.GlobalStageDatas
{
    public class Score : MonoBehaviour
    {
        // 敵の撃破数
        public static int Kills = 0;

        // 生存時間
        public static float SurvivalTime = 0;

        //*********************************************************

        private void Update()
        {
            SurvivalTime += Time.deltaTime;
        }

        // 秒数を返すメソッド
        public static int GetSecondsSurvivalTime()
        {
            return (int)SurvivalTime;
        }

        // 総合点数を計算
        public static int CalcTotalScore()
        {
            return Kills + (int)SurvivalTime;
        }
    }
}