using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Missiles;

namespace Fighters
{
    public class LockOnSystem : MonoBehaviour
    {
        // 敵オブジェクト
        public GameObject enemy;

        // ミサイル武装
        [SerializeField] private Missile missile;

        // ロックオンターゲット ロックオン中のみ
        private GameObject target;
        public GameObject Target
        {
            get { return target; }
        }

        // ロックオン開始してからの時間
        private float lockOnElapsedTime = 0;
        public float LockOnElapsedTime
        {
            get { return lockOnElapsedTime; }
        }

        // ロックオン範囲
        [SerializeField] private float lockOnCircle = 150.0f;

        // ロックオンしているか
        private bool isLockOn;
        public bool IsLockOn
        {
            get { return isLockOn; }
        }


        private void Update()
        {
            LockOnProcess();

            // ロックオン完了時間を越したか
            if (lockOnElapsedTime >= missile.LockOnTime)
            {
                isLockOn = true;
            }
            else
            {
                isLockOn = false;
            }

        }

        // ロックオン処理
        private void LockOnProcess()
        {
            // 敵がいる場合 &&
            // カメラに表示されている場合 ※シーンビューも含まれるので注意
            if (enemy != null && enemy.GetComponent<Renderer>().isVisible)
            {
                // 敵との間に障害物がない場合
                if (Physics.Linecast(transform.position, enemy.transform.position, LayerMask.GetMask("Field")) == false)
                {
                    // カメラ座標に変換
                    Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, enemy.transform.position);
                    screenPoint.x -= (Screen.width / 2);
                    screenPoint.y -= (Screen.height / 2);

                    // ロックオンサークル内の場合
                    if (screenPoint.magnitude <= lockOnCircle)
                    {
                        target = enemy;
                        lockOnElapsedTime += Time.deltaTime;
                        return;
                    }
                }
            }

            // ロックオンできないとき
            lockOnElapsedTime = 0;
            target = null;
            isLockOn = false;
        }
    }
}