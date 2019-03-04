using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        // 機体を制御するリキッドボディ
        private Rigidbody fighterbody;

        // 機体の加速状態を表す変数
        private int accelerationStatement = FighterStatementConstant.NORMAL;
        public int AccelerationStatement
        {
            get { return accelerationStatement; }
            set { accelerationStatement = value; }
        }

        // 通常速度を保つための加速力
        [SerializeField] private float normalSpeedAcceleration = 150.0f;

        // アクセルしたときの加速力
        [SerializeField] private float acceleration = 300.0f;

        // 旋回・上昇・下降・ヨーに対する力
        [SerializeField] private float rollingForce = 5.0f;
        [SerializeField] private float risingForce = 3.0f;
        [SerializeField] private float fallingForce = 1.0f;
        [SerializeField] private float yawingForce = 0.75f;

        // ブースター
        [SerializeField] private Boosters boosters;

        // ミサイルの発射口
        [SerializeField] private MissilePods missilePods;
        public MissilePods MissilePods
        {
            get { return missilePods; }
        }


        private void Start()
        {
            fighterbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            UpdateAcceleration();
            Debug.Log(fighterbody.velocity.magnitude);
        }

        // 加速関係のUpdate
        void UpdateAcceleration ()
        {
            // 状態によって加速するか減速か決定
            // また、エフェクトも変更
            switch (accelerationStatement)
            {
                case FighterStatementConstant.ACCELERATION:
                    Acceleration();
                    boosters.ChangeEffect(FighterStatementConstant.ACCELERATION);
                    break;
                case FighterStatementConstant.BRAKE:
                    Brake();
                    boosters.ChangeEffect(FighterStatementConstant.BRAKE);
                    break;
                default:
                    NormalSpeed();
                    boosters.ChangeEffect(FighterStatementConstant.NORMAL);
                    break;
            }
        }

        // 機体の通常速度
        public void NormalSpeed()
        {
            fighterbody.AddForce(transform.forward * normalSpeedAcceleration);
        }

        // 機体の前方への加速メソッド
        public void Acceleration()
        {
            fighterbody.AddForce(transform.forward * acceleration);
        }

        // ブレーキメソッド 加速度0にする
        public void Brake()
        {
            
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
