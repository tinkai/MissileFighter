using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // ミサイルのリキッドボディ
    private Rigidbody missilebody;

    // ミサイルの敵ターゲット
    private Transform target;

    // ミサイルの敵への誘導率
    [SerializeField] private float inductionRate = 1.0f;

    // ミサイルの射出時の下への動き
    [SerializeField] private float shotForce = 10.0f;


    void Start()
    {
        missilebody = gameObject.GetComponent<Rigidbody>();
        target = GameObject.Find("Anemy").transform;

        // 機体の速力にする
        GameObject fighter = GameObject.Find("Player Fighter");
        // 下に射出
        missilebody.velocity = fighter.GetComponent<Rigidbody>().velocity + fighter.transform.up * (-shotForce);
    }

    void Update()
    {
        GuidedTarget();
    }

    void GuidedTarget()
    {
        Quaternion targetDirection = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, inductionRate);
        missilebody.AddForce(transform.forward * 100);
    }
}
