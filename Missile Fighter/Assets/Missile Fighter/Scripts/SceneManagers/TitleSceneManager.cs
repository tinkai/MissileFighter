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
            // スペースを押したらバトルシーンへ
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Battle Scene");
            }
        }
    }
}