using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.GlobalStageDatas;

namespace MissileFighter.UI
{
    public class UiScore : MonoBehaviour
    {
        [SerializeField] private Text kills;
        [SerializeField] private Text survivalTime;

        //*********************************************************

        private void Start()
        {
            kills.text = "0";
            survivalTime.text = "0";
        }

        private void Update()
        {
            kills.text = Score.Kills.ToString();

            int time = Score.GetSecondsSurvivalTime();
            string minutes = (time / 60).ToString("D2");
            string seconds = (time % 60).ToString("D2");
            survivalTime.text = minutes + ":" + seconds;
        }
    }
}