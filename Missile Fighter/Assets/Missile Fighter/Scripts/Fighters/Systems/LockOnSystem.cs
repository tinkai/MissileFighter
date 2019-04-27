using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Weapons.Missiles;
using MissileFighter.Units;
using MissileFighter.GlobalDatas;

namespace MissileFighter.Fighters.Systems
{
    public class LockOnSystem : MonoBehaviour
    {
        // インスタンスの持ち主
        private Fighter fighter;

        // ロックオンターゲットの状態リスト
        protected List<LockOnTargetState> targetStateList;
        public List<LockOnTargetState> TargetStateList
        {
            get { return targetStateList; }
        }

        // ミサイル武装
        [SerializeField] private Missile missile;

        // ロックオン範囲 画面の長さが1の大きさ
        [SerializeField] private float lockOnAngle = 25.0f;
        public float LockOnAngle
        {
            get { return lockOnAngle; }
        }

        // ロックオン最大距離
        [SerializeField] private float lockOnDistance = 1500.0f;
        public float LockOnDistance
        {
            get { return lockOnDistance; }
        }

        //***********************************************************

        private void Awake()
        {
            targetStateList = new List<LockOnTargetState>();
        }

        private void Start()
        {
            fighter = transform.parent.GetComponent<Fighter>();
            UpdateTargetList();
        }

        private void Update()
        {
            LockOnProcess();
        }

        // ターゲットリストを更新するメソッド 
        public virtual void UpdateTargetList()
        {
            // 初期化
            targetStateList.Clear();
        }

        // ロックオンしているターゲットリストを返す
        public List<LockOnTargetState> GetLockOnTargetList()
        {
            List<LockOnTargetState> lockOnTargetList = new List<LockOnTargetState>();
            foreach (LockOnTargetState targetState in targetStateList)
            {
                if (targetState.LockOnRank >= 1)
                {
                    lockOnTargetList.Add(targetState);
                }
            }
            return lockOnTargetList;
        }

        // ロックオン処理
        private void LockOnProcess()
        {
            // 全ての敵を調査
            foreach (LockOnTargetState targetState in targetStateList)
            {
                // 敵が死んでいない
                // && 敵との間に障害物がない場合
                if (targetState.Target.IsDead == false
                    && Physics.Linecast(transform.position, targetState.Target.transform.position, LayerMask.GetMask("Field")) == false)
                {
                    // 自分から見た角度
                    float angle = Vector3.Angle((targetState.Target.transform.position - transform.position).normalized, transform.forward);
                    // 敵と自分の距離
                    float distance = Vector3.Distance(transform.position, targetState.Target.transform.position);

                    // ロックオンサークル内 && ロックオン射程内 の場合
                    if (angle <= lockOnAngle && distance <= lockOnDistance)
                    {
                        targetState.LockOnElapsedTime += Time.deltaTime;

                        int pastRank = targetState.LockOnRank;

                        // ロックオン段階を判定
                        for (int i = 3; i >= 0; i--)
                        {
                            if (targetState.LockOnElapsedTime >= i * missile.LockOnTime)
                            {
                                targetState.LockOnRank = i;
                                break;
                            }
                        }

                        // ロックオンランクが上がっていた場合、音を鳴らす
                        if (targetState.LockOnRank > pastRank)
                        {
                            PlayLockOnAudio();
                        }

                        continue;
                    }
                }

                // ロックオンできない場合
                targetState.LockOnElapsedTime = 0;
                targetState.LockOnRank = 0;
            }
        }

        // 初回ロックオン時に音を鳴らすメソッド 基本的にプレイヤーだけ鳴らすようにオーバーライド
        protected virtual void PlayLockOnAudio() { }
    }
}