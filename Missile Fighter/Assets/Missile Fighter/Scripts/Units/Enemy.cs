using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Fighters;

namespace MissileFighter.Units
{
    [RequireComponent(typeof(Fighter))]

    public class Enemy : MonoBehaviour
    {
        // 機体
        private Fighter fighter;
        public Fighter Fighter
        {
            get { return fighter; }
        }

        // ロックオンシステム
        LockOnSystem lockOnSystem;

        // プレイヤー
        private Player player;

        // 旋回する距離
        [SerializeField] private int turnDistance = 200;

        // 旋回速度
        [SerializeField] private float turnForce = 0.05f;

        //***********************************************************

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            lockOnSystem = GetComponent<LockOnSystem>();
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        private void FixedUpdate()
        {
            // 距離による旋回制限
            if (Vector3.Distance(transform.position, player.transform.position) > turnDistance)
            {
                // プレイヤーの方向を向く
                Quaternion direction = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, direction, turnForce);
            }

            // ロックオン距離のよりもプレイヤーとの距離が離れているなら移動速度を最高速に
            if (Vector3.Distance(transform.position, player.transform.position) > GetComponent<LockOnSystem>().LockOnDistance)
            {
                fighter.AccelerationStatement = FighterStatementConstant.ACCELERATION;
            }
            else
            {
                fighter.AccelerationStatement = FighterStatementConstant.NORMAL;
            }

            // ロックオンしているなら発射
            if (lockOnSystem.GetLockOnTargetList().Count != 0)
            {
                fighter.MissilePods.ShotMissile();
            }
        }

        // 衝突判定
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player" && other.tag != "Player Weapon") { return; }

            // 衝突処理を行う
            fighter.CollisionObj(other.gameObject);
        }
    }
}