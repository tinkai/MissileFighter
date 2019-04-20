using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MissileFighter.Common;

namespace MissileFighter.SceneManagers
{
    public class TitleSceneManager : MonoBehaviour
    {
        // バトルシーンへ遷移するボタンのテキストオブジェクト
        [SerializeField] private GameObject tapText;

        //*********************************************************

        private void Start()
        {
            // タイトルのキャンバスだけをアクティブ
            FindObjectOfType<CanvasManager>().ActiveOnlyCanvas("Title Canvas");
        }

        private void Update()
        {
            // エスケープで終了
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        // バトルシーンへ遷移するボタン処理
        public void OnClickBattleStart()
        {
            StartCoroutine(TransitionBattleScene());
        }

        // バトルシーンへ遷移
        public IEnumerator TransitionBattleScene()
        {
            // アニメーション・オーディオのスタート
            tapText.GetComponent<Animator>().SetTrigger("Tap");
            AudioSource tapAudio = tapText.GetComponent<AudioSource>();
            tapAudio.PlayOneShot(tapAudio.clip);

            yield return new WaitForSeconds(1.0f);

            SceneManager.LoadScene("Battle Scene");
        }
    }
}