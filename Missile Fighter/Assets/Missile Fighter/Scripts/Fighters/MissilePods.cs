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

        // ロックオンシステム
        private LockOnSystem lockOnSystem;


        private void Start()
        {
            lockOnSystem = GetComponentInParent<LockOnSystem>();
        }

        // 全てのミサイルポッドからミサイルを打つメソッド
        public void ShotMissile()
        {
            if (shotNextTime > Time.time)
            {
                return;
            }

            // ロックオンされているターゲットリストを取得
            List<GameObject> targetList = lockOnSystem.GetLockOnTargetList();
            
            // ロックオンしていない場合はそのまま直進で打つ
            if (targetList.Count == 0)
            {
                foreach (Transform pod in gameObject.transform)
                {
                    Instantiate(missilePrefab, pod.position, pod.rotation);
                }
            } 
            // ロックオンしている場合は、ターゲット全てに打つ
            else
            {
                foreach(GameObject target in targetList)
                {
                    foreach (Transform pod in gameObject.transform)
                    {
                        GameObject missile = Instantiate(missilePrefab, pod.position, pod.rotation);
                        missile.GetComponent<Missile>().Target = target.transform;  // ターゲット設定
                    }
                }
            }

            shotNextTime = Time.time + shotDelay;   // クール時間を新たに設定
        }
    }
}