using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Missiles
{
    public class Missile : MonoBehaviour
    {
        // ミサイルのリキッドボディ
        private Rigidbody missilebody;

        // ミサイルの敵ターゲット
        private Transform target;

        // ミサイルの速度
        [SerializeField] private float speed = 400.0f;

        // ミサイルの敵への誘導率
        [SerializeField] private float inductionRate = 0.1f;

        // ミサイルが誘導を始めるまでの移動方向と速度
        private Vector3 shotStartVector;

        // ミサイルの射出時の下への動き
        [SerializeField] private float shotForce = 3.0f;

        // ミサイルが誘導を始めるまでの間隔
        [SerializeField] private float guidDelayTime = 1.0f;

        // ミサイルが誘導を始める時間
        private float startGuidTime;

        

        void Start()
        {
            missilebody = gameObject.GetComponent<Rigidbody>();
            target = GameObject.Find("Anemy").transform;

            // 機体の速力にする
            shotStartVector = GameObject.Find("Player Fighter").GetComponent<Rigidbody>().velocity;
            // 機体速度と同速で下に射出
            missilebody.velocity = shotStartVector - transform.up * shotForce;

            // 誘導を始める時間を設定
            startGuidTime = Time.time + guidDelayTime;
        }

        void FixedUpdate()
        {
            if (Time.time >= startGuidTime)
            {
                GuidedTarget();
            }
            else
            {
                missilebody.AddForce(shotStartVector);
            }
        }

        // ミサイルをターゲットに誘導するメソッド
        void GuidedTarget()
        {
            // 自分自身からターゲットを見た方向を取得
            Quaternion targetDirection = Quaternion.LookRotation(target.position - transform.position);
            // 自分の向いている方向からターゲット方向へ誘導率だけ向く
            transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, inductionRate);
            // 正面に力を加える
            missilebody.AddForce(transform.forward * speed);
        }
    }
}