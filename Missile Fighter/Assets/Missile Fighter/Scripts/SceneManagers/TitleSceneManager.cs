using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileFighter.SceneManagers
{
    public class TitleSceneManager : MonoBehaviour
    {
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
                SceneManager.LoadScene("Battle Scene");
            }
        }
    }
}