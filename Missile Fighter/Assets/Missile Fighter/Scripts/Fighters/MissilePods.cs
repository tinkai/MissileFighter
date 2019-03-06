using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Missiles;

namespace Fighters
{
    public class MissilePods : MonoBehaviour
    {
        // ミサイルプレハブ
        [SerializeField] private GameObject missilePrefab;

        // 次のミサイル発射時刻
        private float shotNextTime;

        // ミサイル発射のクールタイム
        [SerializeField] private float shotDelay = 0.5f;

        [SerializeField] private LockOnSystem lockOnSystem;


        // 全てのミサイルポッドからミサイルを打つメソッド
        public void ShotMissile()
        {
            if (shotNextTime > Time.time)
            {
                return;
            }

            // 子要素をすべて取得
            foreach (Transform pod in gameObject.transform)
            {
                GameObject missile = Instantiate(missilePrefab, pod.position, pod.rotation);
                
                // ロックオンしている場合
                if (lockOnSystem.IsLockOn)
                {
                    missile.GetComponent<Missile>().Target = lockOnSystem.Target.transform;
                }
            }

            shotNextTime = Time.time + shotDelay;
        }
    }
}