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
        [SerializeField] private float lockOnCircle = 0.25f;

        // ロックオン最大距離
        [SerializeField] private float lockOnDistance = 1500.0f;

        //***********************************************************

        private void Start()
        {
            targetStateList = new List<LockOnTargetState>();
            Enemy[] enemys = GlobalStageData.Instance.WaveManager.GetCurrentWave().Enemys;

            foreach (Enemy enemy in enemys)
            {
                targetStateList.Add(new LockOnTargetState(enemy));
            }
        }

        private void Update()
        {
            LockOnProcess();
        }

        // エネミーリストを更新するメソッド
        public void UpdateEnemyList()
        {
            targetStateList.Clear();

            if (GlobalStageData.Instance.WaveManager.IsEndWave()) { return; }

            Enemy[] enemys = GlobalStageData.Instance.WaveManager.GetCurrentWave().Enemys;

            foreach (Enemy enemy in enemys)
            {
                targetStateList.Add(new LockOnTargetState(enemy));
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
                // && カメラに表示されている場合 ※シーンビューも含まれるので注意
                // && 敵との間に障害物がない場合
                if (targetState.Target.GetComponent<Enemy>().Fighter.IsDead == false
                    && targetState.Target.GetComponent<Renderer>().isVisible 
                    && Physics.Linecast(transform.position, targetState.Target.transform.position, LayerMask.GetMask("Field")) == false)
                {
                    targetState.IsVisible = true;   // 見えている

                    // カメラ中心からの距離
                    Vector2 screenPoint = Camera.main.WorldToViewportPoint(targetState.Target.transform.position);                     screenPoint.x -= 0.5f;
                    screenPoint.x *= 1.5f;  // ロックオンの円をy軸と同じ長さくらいに 16:9の時だけ？ 16 / 9 = 1.77...じゃない？                     screenPoint.y -= 0.6f;
                    float screenDistance = Mathf.Sqrt(Mathf.Pow(screenPoint.x, 2) + Mathf.Pow(screenPoint.y, 2));

                    // 敵と自分の距離
                    float distance = Vector3.Distance(gameObject.transform.position, targetState.Target.transform.position);

                    // ロックオンサークル内 && ロックオン射程内 の場合
                    if (screenDistance <= lockOnCircle && distance <= lockOnDistance)
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
                    else
                    {
                        targetState.LockOnElapsedTime = 0;
                        targetState.IsLockOn = false;
                        continue;
                    }
                }

                // 画面内にいない場合 || 障害物がある場合
                targetState.IsVisible = false;
                targetState.LockOnElapsedTime = 0;
                targetState.IsLockOn = false;
            }
        }
    }
}