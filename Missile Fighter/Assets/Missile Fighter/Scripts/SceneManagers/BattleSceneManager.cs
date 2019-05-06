using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MissileFighter.Common;
using MissileFighter.Settings;
using MissileFighter.GlobalDatas;
using MissileFighter.Fighters.Systems;
using MissileFighter.Fighters.Player;

namespace MissileFighter.SceneManagers
{
    public class BattleSceneManager : MonoBehaviour
    {
        // バトル終了時に表示するテキスト
        [SerializeField] private Text[] results;

        // カウントダウン用テキスト・音源
        [SerializeField] private Text countdownText;
        private AudioSource countdownAudio;

        //**********************************************************

        private void Awake()
        {
            countdownAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            // ゲーム設定を反映
            GameSetting.ReflectSetting();

            FindObjectOfType<CanvasManager>().ActiveOnlyCanvas("Battle Canvas");
            StartCoroutine(Countdown());
        }

        private void Update()
        {
            // エスケープで終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            StartCoroutine(EndBattle());
        }

        // 最初の3秒のカウントダウン
        private IEnumerator Countdown()
        {
            // スコアに関する時間を停止
            Score.TimeStop = true;
            // ロックオンシステムを無効化
            GameObject.FindWithTag("Player").GetComponentInChildren<LockOnSystem>().enabled = false;

            // 音を鳴らす
            countdownAudio.PlayOneShot(countdownAudio.clip);
            // 3秒カウントダウン
            for (int i = 3; i > 0; i--)
            {
                countdownText.text = i.ToString();
                yield return new WaitForSeconds(1.0f);  // 1秒待つ
            }

            countdownText.enabled = false;  // カウントダウンの表示を消す

            // ゲームを開始する
            Score.TimeStop = false;
            GameObject.FindWithTag("Player").GetComponentInChildren<LockOnSystem>().enabled = true;
            StageData.Instance.WaveManager.StartWave();
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
                StageData.Instance.Player.GetComponent<PlayerCameraChanger>().GetCurrentCamera().transform.parent = null;
                results[2].enabled = true;

                yield return new WaitForSeconds(3.0f);

                SceneManager.LoadScene("Score Scene");
            }

            yield break;
        }
    }
}