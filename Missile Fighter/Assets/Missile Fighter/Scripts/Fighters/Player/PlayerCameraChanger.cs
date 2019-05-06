using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters.Player
{
    public class PlayerCameraChanger : MonoBehaviour
    {
        // 戦闘用のカメラオブジェクト
        [SerializeField] private Camera mainCamera;

        // 後ろを向くカメラ
        [SerializeField] private Camera backCamera;

        //***********************************************************

        private void Start()
        {
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

            backCamera.enabled = false;
        }

        private void Update()
        {
            // バックカメラに変更
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (mainCamera.enabled)
                {
                    backCamera.enabled = true;
                    mainCamera.enabled = false;
                }
                else
                {
                    mainCamera.enabled = true;
                    backCamera.enabled = false;
                }
            }
        }

        // 現在使用しているカメラを渡す
        public Camera GetCurrentCamera()
        {
            if (mainCamera.enabled)
            {
                return mainCamera;
            }
            else
            {
                return backCamera;
            }
        }
    }
}