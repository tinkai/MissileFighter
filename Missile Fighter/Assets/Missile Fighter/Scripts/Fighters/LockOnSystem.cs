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

        // ロックオン最大距離
        [SerializeField] private float lockOnDistance = 500.0f;

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
                    target = enemy;

                    // カメラ座標に変換
                    Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, enemy.transform.position);
                    screenPoint.x -= (Screen.width / 2);
                    screenPoint.y -= (Screen.height / 2);

                    // 敵と自分の距離
                    float distance = Vector3.Distance(gameObject.transform.position, enemy.transform.position);

                    // ロックオンサークル内 && ロックオン射程内 の場合
                    if (screenPoint.magnitude <= lockOnCircle && distance <= lockOnDistance)
                    {
                        lockOnElapsedTime += Time.deltaTime;
                        return;
                    }
                    else
                    {
                        lockOnElapsedTime = 0;
                        return;
                    }
                }
            }

            // 画面内にいない場合 || 障害物がある場合
            lockOnElapsedTime = 0;
            target = null;
        }
    }
}