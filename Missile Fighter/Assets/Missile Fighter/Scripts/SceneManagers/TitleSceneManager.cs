using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileFighter.SceneManagers
{
    public class TitleSceneManager : MonoBehaviour
    {
        // tap to start テキストオブジェクト
        [SerializeField] private GameObject tapText;

        // tap時の音
        [SerializeField] private AudioSource tapAudio;

        //*********************************************************

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
                // アニメーション・オーディオのスタート
                tapText.GetComponent<Animator>().SetTrigger("Tap");
                tapAudio.PlayOneShot(tapAudio.clip);

                StartCoroutine(TapScreen());
            }
        }

        // タップ時の音が鳴りやむまで待った後、シーン遷移
        private IEnumerator TapScreen()
        {
            yield return new WaitForSeconds(1.0f);

            SceneManager.LoadScene("Battle Scene");
        }
    }
}