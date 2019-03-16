using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileFighter.SceneManagers
{
    public class TitleSceneManager : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("Battle Scene");
        }
    }
}