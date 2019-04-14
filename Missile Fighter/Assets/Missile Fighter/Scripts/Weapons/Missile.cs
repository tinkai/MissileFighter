using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Fighters;

namespace MissileFighter.Weapons
{
    [RequireComponent(typeof(Rigidbody))]

    public class Missile : MonoBehaviour
    {
        // ミサイルを打った戦闘機
        private Fighter fighter;
        public Fighter Fighter
        {
            set { fighter = value; }
        }

        // ミサイルのリキッドボディ
        private Rigidbody missilebody;

        // ミサイルの敵ターゲット
        private Transform target;
        public Transform Target
        {
            set { target = value; }
        }

        // ミサイルの速度
        [SerializeField] private float speed = 200.0f;

        // ミサイルの攻撃力
        [SerializeField] private int damagePower = 1;
        public int DamagePower
        {
            get { return damagePower; }
        }

        // ミサイルの生存時間
        [SerializeField] private float survivalTime = 10.0f;

        // ミサイルのロックオン時間
        [SerializeField] private float lockOnTime = 3.0f;
        public float LockOnTime
        {
            get { return lockOnTime; }
        }

        // ミサイルの敵への誘導の強さ
        [SerializeField] private float inductionForce = 10.0f;

        // ゆらぎの確率
        [SerializeField] private int blurRate = 5;

        // ゆらぎの強さ
        [SerializeField] private float blurForce = 20.0f;

        // ミサイルの爆発エフェクト
        [SerializeField] private GameObject explosionEffect;

        //***********************************************************

        private void Awake()
        {
            missilebody = GetComponent<Rigidbody>();

            // 爆発するタイミングをずらす
            survivalTime += Random.Range(-1.0f, 1.0f);
        }

        private void Start()
        {
            // 機体速度と同速で射出
            missilebody.velocity = fighter.GetComponent<Rigidbody>().velocity;
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

            // 確率によって揺らぎを起こす
            if (Random.Range(0, 100) < blurRate)
            {
                missilebody.AddTorque(new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)) * blurForce);
                return;
            }

            // 誘導
            // 自身の位置からの相手の方向を調べる 軸は自身のy軸
            Quaternion targetRot = Quaternion.LookRotation(target.position - transform.position, transform.up);
            // Inverseを掛け、自身の回転を考慮した方向を求める
            Quaternion rot = targetRot * Quaternion.Inverse(transform.rotation);
            // その角度になるには、短い回転と長い回転の2通りがある wが-の時は長い回転であるため、短い回転に変換
            // QUaternionは符号を変えても同じ角度を表せるため、成り立つ
            if (rot.w < 0)
            {
                rot.x = -rot.x;
                rot.y = -rot.y;
                rot.z = -rot.z;
                rot.w = -rot.w;
            }

            missilebody.AddTorque(new Vector3(rot.x, rot.y, rot.z) * inductionForce);
        }

        // 衝突判定
        private void OnTriggerEnter(Collider other)
        {
            // 打った本人と武器はぶつからない
            if (other.tag == fighter.tag || other.tag == tag) { return; }
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