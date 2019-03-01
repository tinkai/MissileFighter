using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        // 機体を制御するリキッドボディ
        private Rigidbody fighterbody;

        // 最高スピード
        [SerializeField] private float maxSpeed = 300.0f;

        // 前方への加速力
        [SerializeField] private float acceleration = 200.0f;

        // 旋回・上昇・下降・ヨーに対する力
        [SerializeField] private float rollingForce = 5.0f;
        [SerializeField] private float risingForce = 3.0f;
        [SerializeField] private float fallingForce = 1.0f;
        [SerializeField] private float yawingForce = 0.75f;

        // ミサイルの発射口
        [SerializeField] private MissilePods missilePods;
        public MissilePods MissilePods
        {
            get { return missilePods; }
        }


        void Start()
        {
            fighterbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            //Debug.Log(fighterbody.velocity.magnitude);
        }

        // 機体の前方への加速メソッド
        public void Acceleration()
        {
            fighterbody.AddForce(transform.forward * acceleration);
            fighterbody.velocity = Vector3.ClampMagnitude(fighterbody.velocity, maxSpeed);  // 最高速度制限
        }

        // 機体をz軸に旋回させるメソッド  左右どちらに傾くか
        public void Roll(int direction)
        {
            if (direction == FighterDirectionConstant.LEFT)
            {
                fighterbody.AddTorque(transform.forward * rollingForce);
            }
            else if (direction == FighterDirectionConstant.RIGHT)
            {
                fighterbody.AddTorque(transform.forward * (-rollingForce));
            }
        }

        // 機体をx軸に旋回させるメソッド  先端を上げるか下げるか
        public void Pitch(int direction)
        {
            if (direction == FighterDirectionConstant.UP)
            {
                fighterbody.AddTorque(transform.right * (-risingForce));
            }
            else if (direction == FighterDirectionConstant.DOWN)
            {
                fighterbody.AddTorque(transform.right * fallingForce);
            }
        }

        // 機体をy軸に旋回させるメソッド  左右どちらを向くか
        public void Yaw(int direction)
        {
            if (direction == FighterDirectionConstant.LEFT)
            {
                fighterbody.AddTorque(transform.up * (-yawingForce));
            }
            else if (direction == FighterDirectionConstant.RIGHT)
            {
                fighterbody.AddTorque(transform.up * yawingForce);
            }
        }
    }
}
