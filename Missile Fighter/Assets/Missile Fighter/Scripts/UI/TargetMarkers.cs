using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fighters;

namespace UI
{
    public class TargetMarkers : MonoBehaviour
    {
        // ロックオンシステム
        [SerializeField] private LockOnSystem lockOnSystem;

        // マーカーのプレハブ
        [SerializeField] private GameObject targetMarkerPrefab;

        // ロックオン数だけのマーカー
        private List<GameObject> markerList;

        // ロックオンの設定色
        private Color lockOnColor;
        private Color unlockOnColor;


        private void Start()
        {
            markerList = new List<GameObject>();

            lockOnColor = Color.red;
            unlockOnColor = Color.green;
        }

        private void Update()
        {
            // 見えているターゲットリストを作成
            List<LockOnTargetState> visibleTargetStateList = new List<LockOnTargetState>();
            foreach (LockOnTargetState targetState in lockOnSystem.TargetStateList)
            {
                if (targetState.IsVisible)
                {
                    visibleTargetStateList.Add(targetState);
                }
            }

            // ターゲットマーカーの個数を調整
            while (markerList.Count != visibleTargetStateList.Count)
            {
                if (markerList.Count < visibleTargetStateList.Count)
                {
                    // 少ない場合は作成
                    GameObject marker = Instantiate(targetMarkerPrefab);
                    marker.transform.SetParent(transform, false);   // 親を自分に設定
                    markerList.Add(marker);
                }
                else if (markerList.Count > visibleTargetStateList.Count)
                {
                    // 多い場合は削除
                    Destroy(markerList[markerList.Count - 1]);
                    markerList.RemoveAt(markerList.Count - 1);
                }
            }

            // マーカーの設定
            for (int i = 0; i < visibleTargetStateList.Count; i++)
            {
                // マーカーの画面上の位置を設定
                Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, visibleTargetStateList[i].Target.transform.position);
                markerList[i].transform.position = new Vector3(screenPosition.x, screenPosition.y, 0f);

                // マーカーの色を設定
                if (visibleTargetStateList[i].IsLockOn)
                {
                    markerList[i].GetComponent<Image>().color = lockOnColor;    // ロックオン完了
                }
                else
                {
                    markerList[i].GetComponent<Image>().color = unlockOnColor;  // 画面には写っている
                }
            }
        }
    }
}