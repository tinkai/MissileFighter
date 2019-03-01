using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class FighterCameraController : MonoBehaviour
    {
        // カメラオブジェクト
        [SerializeField] private GameObject thirdPersonCamera;  // 通常視点
        [SerializeField] private GameObject firstPersonCamera;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                // 現在のactive状態から反転 
                thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
                firstPersonCamera.SetActive(!firstPersonCamera.activeInHierarchy);
            }
        }
    }
}