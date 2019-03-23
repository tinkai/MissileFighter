using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MissileFighter.GlobalDatas;
using MissileFighter.Fighters;

namespace MissileFighter.SceneManagers
{
    public class BattleSceneManager : MonoBehaviour
    {
        // バトル終了時に表示するテキスト
        [SerializeField] private Text[] results;

        //**********************************************************

        private void Update()
        {
            // エスケープで終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            StartCoroutine(EndBattle());
        }

        // バトルの終了判定と動作
        private IEnumerator EndBattle()
        {
            // クリアした場合
            if (StageData.Instance.WaveManager.IsEndWave())
            {
                Score.TimeStop = true;
                Score.IsClear = true;
                results[0].enabled = true;

                yield return new WaitForSeconds(3.0f);

                SceneManager.LoadScene("Score Scene");
            }
            // 制限時間を越した場合
            else if (Score.ElapsedTime >= StageData.Instance.LimitTime)
            {
                Score.TimeStop = true;
                results[1].enabled = true;

                yield return new WaitForSeconds(3.0f);

                SceneManager.LoadScene("Score Scene");
            }
            // 死んだ場合
            else if (StageData.Instance.Player.Fighter.IsDead)
            {
                Score.TimeStop = true;
                StageData.Instance.Player.GetComponent<FighterCameraController>().GetCurrentCamera().transform.parent = null;
                results[2].enabled = true;

                yield return new WaitForSeconds(3.0f);

                SceneManager.LoadScene("Score Scene");
            }

            yield break;
        }
    }
}