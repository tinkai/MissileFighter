using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MissileFighter.UI.ScoreScreen;

namespace MissileFighter.SceneManagers
{
    public class ScoreSceneManager : MonoBehaviour
    {
        // スコア結果とランキング
        [SerializeField] ScoreResult scoreResult;
        [SerializeField] ScoreRanking scoreRanking;

        //*********************************************************

        private IEnumerator Start()
        {
            // ランキングはスコアを発表し終えるまで消しとく
            scoreRanking.gameObject.SetActive(false);
            yield return StartCoroutine(scoreResult.ShowScore());
            scoreRanking.gameObject.SetActive(true);
            // Fade in
            scoreRanking.GetComponent<Animator>().SetTrigger("Showed Score");
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