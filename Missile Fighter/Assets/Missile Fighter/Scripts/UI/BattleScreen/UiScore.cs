using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.GlobalDatas;

namespace MissileFighter.UI.BattleScreen
{
    public class UiScore : MonoBehaviour
    {
        [SerializeField] private Text kills;
        [SerializeField] private Text remainingTime;

        //*********************************************************

        private void Start()
        {
            kills.text = "0";
            remainingTime.text = "0";
        }

        private void Update()
        {
            kills.text = Score.Kills.ToString();

            // 残り時間を表示
            int time = StageData.Instance.LimitTime - (int)Score.ElapsedTime;
            string minutes = (time / 60).ToString("D2");
            string seconds = (time % 60).ToString("D2");
            remainingTime.text = minutes + ":" + seconds;

            // 1分以内は赤に変更
            if (StageData.Instance.LimitTime - (int)Score.ElapsedTime <= 60)
            {
                remainingTime.color = Color.red;
            }
        }
    }
}