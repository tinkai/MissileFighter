using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighters;

namespace Missiles
{
    [RequireComponent(typeof(Rigidbody))]

    public class Missile : MonoBehaviour
    {
        // ミサイルを打った戦闘機
        private GameObject fighter;

        // ミサイルのリキッドボディ
        private Rigidbody missilebody;

        // ミサイルの敵ターゲット
        private Transform target;
        public Transform Target
        {
            set { target = value; }
        }

        // ミサイルの速度
        [SerializeField] private float speed = 400.0f;

        // ミサイルの生存時間
        [SerializeField] private float survivalTime = 10.0f;

        // ミサイルのロックオン時間
        [SerializeField] private float lockOnTime = 5.0f;
        public float LockOnTime
        {
            get { return lockOnTime; }
        }

        // ミサイルの敵への誘導率
        [SerializeField] private float inductionRate = 0.1f;

        // ミサイルの爆発エフェクト
        [SerializeField] private GameObject explosionEffect;


        private void Awake()
        {
            missilebody = gameObject.GetComponent<Rigidbody>();

            fighter = GameObject.FindWithTag("Player");
            // 機体速度と同速で下に射出
            missilebody.velocity = GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity;
        }

        private void Update()
        {
            // 生存時間処理
            survivalTime -= Time.deltaTime;
            if (survivalTime <= 0)
            {
                Explosion();
            }
        }

        private void FixedUpdate()
        {
            // 敵の方を向いて、正面に力を加える
            GuidedTarget();
            missilebody.AddForce(transform.forward * speed);
        }

        // ミサイルをターゲットに誘導するメソッド
        void GuidedTarget()
        {
            // ターゲットがいない場合 || アクティブではない
            if (target == null || target.gameObject.activeInHierarchy == false) { return; }


            // 自分自身からターゲットを見た方向を取得
            Quaternion targetDirection = Quaternion.LookRotation(target.position - transform.position);
            // 自分の向いている方向からターゲット方向へ誘導率だけ向く
            transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, Random.Range(0.05f, inductionRate));
        }

        // 衝突判定
        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == fighter.tag || other.tag == (fighter.tag + " Weapon")) { return; }
            Explosion();
        }

        // ミサイルの爆発・削除
        void Explosion()
        {
            // 爆発エフェクトを動作させて削除
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 3.0f);
            Destroy(gameObject);
        }
    }
}