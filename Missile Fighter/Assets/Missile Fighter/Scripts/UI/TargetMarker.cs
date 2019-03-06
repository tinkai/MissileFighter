using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fighters;

public class TargetMarker : MonoBehaviour
{
    [SerializeField] private LockOnSystem lockOnSystem;

    private void Start()
    {
        GetComponent<Image>().color = new Color(0f, 1f, 0, 1f);
    }

    private void Update()
    {
        // ターゲットがいない場合
        if (lockOnSystem.Target == null)
        {
            //ロックオンサークル外
            this.gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);//透明(非表示)
            return;
        }


        //ロックオンマーカーの位置を決定
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, lockOnSystem.Target.transform.position);
        transform.position = new Vector3(screenPosition.x, screenPosition.y, 0f);

        //ロックオンサークル内
        if (lockOnSystem.IsLockOn)
        {
            //ロックオン完了
            this.gameObject.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            //ロックオン途中
            this.gameObject.GetComponent<Image>().color = new Color(0f, 1f, 0f, 1f);
        }
    }
}
