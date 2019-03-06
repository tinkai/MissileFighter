using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fighters;

public class TargetMarker : MonoBehaviour
{
    // ロックオンシステム
    [SerializeField] private LockOnSystem lockOnSystem;

    // ロックオンの設定色
    private Color lockOnColor;
    private Color unlckOnColor;


    private void Start()
    {
        lockOnColor = Color.red;
        unlckOnColor = Color.green;
    }

    private void Update()
    {
        // ターゲットがいない場合
        if (lockOnSystem.Target == null)
        {
            // 透明にする
            this.gameObject.GetComponent<Image>().color = Color.clear;
            return;
        }

        // ロックオンマーカーの位置を決定
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, lockOnSystem.Target.transform.position);
        transform.position = new Vector3(screenPosition.x, screenPosition.y, 0f);

        // ロックオンしている場合
        if (lockOnSystem.IsLockOn)
        {
            // ロックオン完了
            this.gameObject.GetComponent<Image>().color = lockOnColor;
        }
        else
        {
            // ロックオン途中
            this.gameObject.GetComponent<Image>().color = unlckOnColor;
        }
    }
}
