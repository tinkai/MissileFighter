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
        }

        // スコアを表示
        public IEnumerator ShowScore()
        {
            // キル数表示
            yield return StartCoroutine(ShowScoreAnim(kills, Score.Kills));
            yield return new WaitForSeconds(0.2f);

            // 残り時間を表示
            yield return StartCoroutine(ShowScoreAnim(elapsedTime, (int)Score.ElapsedTime));
            yield return new WaitForSeconds(0.2f);

            // スコア合計を表示
            yield return StartCoroutine(ShowScoreAnim(total, Score.CalcTotalScore()));
        }


        private IEnumerator ShowScoreAnim(Text text, int value)
        {
            // 大きくさせるアニメーション
            text.GetComponent<Animator>().SetTrigger("Grow");

            float time = 0.0f;
            // 1秒アニメーション
            while (true)
            {
                if ((time += Time.deltaTime) > 1.0f)
                {
                    break;
                }
                text.text = Random.Range(0, 99999).ToString("D5");
                yield return null;
            }

            AudioSource audio = text.GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
            text.text = value.ToString();
        }
    }
}