﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MissileFighter.SceneManagers
{
    public class GameClearSceneManager : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title Scene");
            }
        }
    }
}