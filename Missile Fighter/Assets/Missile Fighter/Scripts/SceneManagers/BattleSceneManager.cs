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
            if (GlobalStageData.Instance.Player.IsDead)
            {
                SceneManager.LoadScene("Game Over Scene");
            }
            else if (GlobalStageData.Instance.WaveManager.IsEndWave())
            {
                SceneManager.LoadScene("Game Clear Scene");
            }
        }
    }
}