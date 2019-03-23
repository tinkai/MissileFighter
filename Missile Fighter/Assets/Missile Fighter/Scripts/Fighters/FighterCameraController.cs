using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters
{
    public class FighterCameraController : MonoBehaviour
    {
        // 戦闘用のカメラオブジェクト
        [SerializeField] private GameObject[] cameras;

        // 現在の戦闘カメラ番号
        private int currentCamera = 0;

        // 後ろを向くカメラ
        [SerializeField] private GameObject backCamera;

        //***********************************************************

        private void Update()
        {
            // 戦闘用カメラ変更
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                // 現在のカメラを移動
                currentCamera = (currentCamera + 1) % cameras.Length;
                for (int i = 0; i < cameras.Length; i++)
                {
                    if (i == currentCamera)
                    {
                        cameras[i].SetActive(true);
                    }
                    else
                    {
                        cameras[i].SetActive(false);
                    }
                }
            }

            // バックカメラ変更
            if (Input.GetKey(KeyCode.B))
            {
                backCamera.SetActive(true);
                cameras[currentCamera].SetActive(false);
            }
            else
            {
                cameras[currentCamera].SetActive(true);
                backCamera.SetActive(false);
            }
        }

        public Camera GetCurrentCamera()
        {
            if (backCamera.activeInHierarchy)
            {
                return backCamera.GetComponent<Camera>();
            }
            else
            {
                return cameras[currentCamera].GetComponent<Camera>();
            }
        }
    }
}