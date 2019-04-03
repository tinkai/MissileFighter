using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Missiles;

namespace MissileFighter.Fighters
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

        // ミサイルの発射音
        private AudioSource shotSound;

        //***********************************************************

        private void Awake()
        {
            shotSound = GetComponent<AudioSource>();
        }

        private void Start()
        {
            lockOnSystem = transform.parent.GetComponentInChildren<LockOnSystem>();
        }

        // 全てのミサイルポッドからミサイルを打つメソッド
        public void ShotMissile()
        {
            if (shotNextTime > Time.time)
            {
                return;
            }

            shotSound.PlayOneShot(shotSound.clip);  // 発射音

            // ロックオンされているターゲットリストを取得
            List<GameObject> targetList = lockOnSystem.GetLockOnTargetList();
            
            // ロックオンしていない場合はそのまま直進で打つ
            if (targetList.Count == 0)
            {
                foreach (Transform pod in gameObject.transform)
                {
                    GameObject missile = Instantiate(missilePrefab, pod.position, pod.rotation);
                    missile.GetComponent<Missile>().Fighter = GetComponentInParent<Fighter>();

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
                        missile.GetComponent<Missile>().Fighter = GetComponentInParent<Fighter>();
                        missile.GetComponent<Missile>().Target = target.transform;  // ターゲット設定
                    }
                }
            }

            shotNextTime = Time.time + shotDelay;   // クール時間を新たに設定
        }
    }
}