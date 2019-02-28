using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePods : MonoBehaviour
{
    // ミサイルプレハブ
    [SerializeField] private GameObject missile;

    // 次のミサイル発射時刻
    private float shotNextTime;

    // ミサイル発射のクールタイム
    [SerializeField] private float shotDelay = 1.0f;


    // 全てのミサイルポッドからミサイルを打つメソッド
    public void ShotMissile()
    {
        if (shotNextTime > Time.time)
        {
            return;
        }

        // 子要素をすべて取得
        foreach (Transform pod in gameObject.transform)
        {
            Instantiate(missile, pod.position, pod.rotation);
        }

        shotNextTime = Time.time + shotDelay;
    }
}
