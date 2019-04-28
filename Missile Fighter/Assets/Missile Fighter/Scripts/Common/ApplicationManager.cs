using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Common
{
    public class ApplicationManager : MonoBehaviour
    {
        // ゲーム終了
        public void QuitApplication()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}