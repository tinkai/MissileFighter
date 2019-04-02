using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.GlobalDatas;

namespace MissileFighter.UI
{
    public class ScoreResult : MonoBehaviour
    {
        // 結果テキスト
        [SerializeField] private Text[] results;
        [SerializeField] private Text kills;
        [SerializeField] private Text elapsedTime;
        [SerializeField] private Text total;

        // スコアランキング

        //*********************************************************

        private void Start()
        {
            // ゲーム終了状態を表示 clear dead timeOver
            if (Score.IsClear)
            {
                results[0].enabled = true;
            }
            else if (Score.ElapsedTime >= StageData.Instance.LimitTime)
            {
                results[1].enabled = true;
            }
            else
            {
                results[2].enabled = true;
            }

            // キル数表示
            kills.text = Score.Kills.ToString();

            // 残り時間を表示
            int time = (int)Score.ElapsedTime;
            string minutes = (time / 60).ToString("D2");
            string seconds = (time % 60).ToString("D2");
            elapsedTime.text = minutes + ":" + seconds;

            // スコア合計を表示
            total.text = Score.CalcTotalScore().ToString();
        }
    }
}