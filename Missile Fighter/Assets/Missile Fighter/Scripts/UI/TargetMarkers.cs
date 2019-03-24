using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.Fighters;

namespace MissileFighter.UI
{
    public class TargetMarkers : MonoBehaviour
    {
        // プレイヤーのロックオンシステム
        private LockOnSystem lockOnSystem;

        // プレイヤーのカメラコントローラ
        private FighterCameraController cameraController;

        // マーカーのプレハブ
        [SerializeField] private GameObject targetMarkerPrefab;
        [SerializeField] private GameObject hpBarPrefab;

        // ロックオン数だけのマーカーリスト
        private List<GameObject> markerList;
        private List<GameObject> hpBarList;

        // ロックオンの設定色
        private Color lockOnColor;
        private Color unlockOnColor;

        //***********************************************************

        private void Start()
        {
            lockOnSystem = GameObject.FindWithTag("Player").GetComponent<LockOnSystem>();
            cameraController = GameObject.FindWithTag("Player").GetComponent<FighterCameraController>();

            markerList = new List<GameObject>();
            hpBarList = new List<GameObject>();

            lockOnColor = Color.red;
            unlockOnColor = Color.green;
        }

        private void Update()
        {
            // 見えているターゲットリストを作成
            List<LockOnTargetState> visibleTargetStateList = new List<LockOnTargetState>();
            foreach (LockOnTargetState targetState in lockOnSystem.TargetStateList)
            {
                // カメラに表示されているか     ※ シーンカメラも含まれるので注意
                if (targetState.Target.GetComponent<Renderer>().isVisible)
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
                    GameObject hpBar = Instantiate(hpBarPrefab);
                    hpBar.transform.SetParent(transform, false);   // 親を自分に設定
                    hpBarList.Add(hpBar);
                }
                else if (markerList.Count > visibleTargetStateList.Count)
                {
                    // 多い場合は削除
                    Destroy(markerList[markerList.Count - 1]);
                    markerList.RemoveAt(markerList.Count - 1);
                    Destroy(hpBarList[hpBarList.Count - 1]);
                    hpBarList.RemoveAt(hpBarList.Count - 1);
                }
            }

            // マーカーの設定
            for (int i = 0; i < visibleTargetStateList.Count; i++)
            {
                // マーカーの画面上の位置を設定
                Vector2 screenPosition = cameraController.GetCurrentCamera().WorldToViewportPoint(visibleTargetStateList[i].Target.transform.position);
                //WorldToScreenPoint(cameraController.GetCurrentCamera(), visibleTargetStateList[i].Target.transform.position);
                markerList[i].transform.position = new Vector3(Screen.width * screenPosition.x, Screen.height * screenPosition.y, 0f);
                hpBarList[i].transform.position = new Vector3(Screen.width * screenPosition.x, Screen.height * screenPosition.y, 0f);

                // マーカーの色を設定
                if (visibleTargetStateList[i].IsLockOn)
                {
                    markerList[i].GetComponent<Image>().color = lockOnColor;    // ロックオン完了
                }
                else
                {
                    markerList[i].GetComponent<Image>().color = unlockOnColor;  // 画面には写っている
                }

                hpBarList[i].GetComponentInChildren<Slider>().value = (float)visibleTargetStateList[i].Target.Hp / visibleTargetStateList[i].Target.MaxHp;
            }
        }
    }
}