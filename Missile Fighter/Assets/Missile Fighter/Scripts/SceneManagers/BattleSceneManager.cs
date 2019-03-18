using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MissileFighter.GlobalStageDatas;

namespace MissileFighter.SceneManagers
{
    public class BattleSceneManager : MonoBehaviour
    {
        private void Update()
        {
            // エスケープで終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (GlobalStageData.Instance.Player.Fighter.IsDead)
            {
                SceneManager.LoadScene("Score Scene");
            }
            else if (GlobalStageData.Instance.WaveManager.IsEndWave())
            {
                SceneManager.LoadScene("Score Scene");
            }
        }
    }
}