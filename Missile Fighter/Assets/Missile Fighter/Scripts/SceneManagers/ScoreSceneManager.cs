using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MissileFighter.GlobalDatas;

namespace MissileFighter.SceneManagers
{
    public class ScoreSceneManager : MonoBehaviour
    {
        // 結果テキスト
        [SerializeField] private Text[] results;
        [SerializeField] private Text kills;
        [SerializeField] private Text elapsedTime;
        [SerializeField] private Text total;

        //*********************************************************

        private void Start()
        {
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

            kills.text = Score.Kills.ToString();

            int time = (int)Score.ElapsedTime;
            string minutes = (time / 60).ToString("D2");
            string seconds = (time % 60).ToString("D2");
            elapsedTime.text = minutes + ":" + seconds;

            total.text = Score.CalcTotalScore().ToString();
        }

        private void Update()
        {
            // エスケープで終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // クリックを押したらバトルシーンへ
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title Scene");
            }
        }
    }
}