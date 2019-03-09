using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Missiles;

namespace Fighters
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

        // ロックオン範囲
        [SerializeField] private float lockOnCircle = 150.0f;

        // ロックオン最大距離
        [SerializeField] private float lockOnDistance = 5000.0f;


        private void Start()
        {
            targetStateList = new List<LockOnTargetState>();
            List<GameObject> enemys = StageData.Fighters.Instance.Enemys;

            foreach (GameObject enemy in enemys)
            {
                targetStateList.Add(new LockOnTargetState(enemy));
            }
        }

        private void Update()
        {
            LockOnProcess();
        }

        // ロックオンしているターゲットリストを返す
        public List<GameObject> GetLockOnTargetList()
        {
            List<GameObject> lockOnTargetList = new List<GameObject>();
            foreach(LockOnTargetState targetState in targetStateList)
            {
                if (targetState.IsLockOn)
                {
                    lockOnTargetList.Add(targetState.Target);
                }
            }
            return lockOnTargetList;
        }

        // ロックオン処理
        private void LockOnProcess()
        {
            // 敵がいない場合は、何もしない
            if (StageData.Fighters.Instance.Enemys.Count == 0) { return; }

            // 全ての敵を調査
            foreach (LockOnTargetState targetState in targetStateList)
            {
                // カメラに表示されている場合 ※シーンビューも含まれるので注意
                if (targetState.Target.GetComponent<Renderer>().isVisible)
                {
                    // 敵との間に障害物がない場合
                    if (Physics.Linecast(transform.position, targetState.Target.transform.position, LayerMask.GetMask("Field")) == false)
                    {
                        targetState.IsVisible = true;   // 見えている

                        // カメラ座標に変換
                        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, targetState.Target.transform.position);
                        screenPoint.x -= (Screen.width / 2);
                        screenPoint.y -= (Screen.height / 2);

                        // 敵と自分の距離
                        float distance = Vector3.Distance(gameObject.transform.position, targetState.Target.transform.position);

                        // ロックオンサークル内 && ロックオン射程内 の場合
                        if (screenPoint.magnitude <= lockOnCircle && distance <= lockOnDistance)
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
                }

                // 画面内にいない場合 || 障害物がある場合
                targetState.IsVisible = false;
                targetState.LockOnElapsedTime = 0;
                targetState.IsLockOn = false;
            }
        }
    }
}