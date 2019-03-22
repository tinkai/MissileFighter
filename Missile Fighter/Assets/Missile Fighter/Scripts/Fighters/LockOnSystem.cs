using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Missiles;
using MissileFighter.Units;
using MissileFighter.GlobalStageDatas;

namespace MissileFighter.Fighters
{
    public class LockOnSystem : MonoBehaviour
    {
        // ロックオンターゲットの状態リスト
        private List<LockOnTargetState> targetStateList;
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

        private void Start()
        {
            targetStateList = new List<LockOnTargetState>();

            UpdateTargetList();
        }

        private void Update()
        {
            LockOnProcess();
        }

        // ターゲットリストを更新するメソッド
        public void UpdateTargetList()
        {
            targetStateList.Clear();

            // プレイヤーの時
            if (tag == "Player")
            {
                Enemy[] enemys = GlobalStageData.Instance.WaveManager.GetCurrentWave().Enemys;
                foreach (Enemy enemy in enemys)
                {
                    targetStateList.Add(new LockOnTargetState(enemy.Fighter));
                }
            }
            // 敵の時
            else if (tag == "Enemy")
            {
                targetStateList.Add(new LockOnTargetState(GlobalStageData.Instance.Player.Fighter));
            }
        }

        // ロックオンしているターゲットリストを返す
        public List<GameObject> GetLockOnTargetList()
        {
            List<GameObject> lockOnTargetList = new List<GameObject>();
            foreach(LockOnTargetState targetState in targetStateList)
            {
                if (targetState.IsLockOn)
                {
                    lockOnTargetList.Add(targetState.Target.gameObject);
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
                if (targetState.Target.GetComponent<Fighter>().IsDead == false
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

                        // 武器のロックオン時間を超えたら、完全なロックオン
                        if (targetState.LockOnElapsedTime >= missile.LockOnTime)
                        {
                            targetState.IsLockOn = true;
                        }
                        else
                        {
                            targetState.IsLockOn = false;
                        }

                        continue;
                    }
                }

                // ロックオンできない場合
                targetState.LockOnElapsedTime = 0;
                targetState.IsLockOn = false;
            }
        }
    }
}