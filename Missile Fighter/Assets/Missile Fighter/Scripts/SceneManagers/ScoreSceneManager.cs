using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MissileFighter.GlobalStageDatas;

namespace MissileFighter.SceneManagers
{
    public class ScoreSceneManager : MonoBehaviour
    {
        [SerializeField] private Text kills;
        [SerializeField] private Text survivalTime;
        [SerializeField] private Text total;


        private void Start()
        {
            kills.text = Score.Kills.ToString();

            int time = Score.GetSecondsSurvivalTime();
            int minutes = time / 60;
            int seconds = time % 60;
            survivalTime.text = minutes + ":" + seconds;

            total.text = Score.CalcTotalScore().ToString();
        }

        private void Update()
        {
            // スペースを押したらバトルシーンへ
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Battle Scene");
            }
        }
    }
}