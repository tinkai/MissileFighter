using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // 機体を制御するリキッドボディ
    private Rigidbody fighterbody;

    // 上昇・下降・旋回に対する力
    [SerializeField] private float risingForce = 3.0f;
    [SerializeField] private float fallingForce = 1.0f;
    [SerializeField] private float rollingForce = 5.0f;


    void Start()
    {
        fighterbody = GetComponent<Rigidbody>();
    }

    // 機体の上昇メソッド
    public void Rise(float vertical)
    {
        fighterbody.AddTorque(transform.right * vertical * risingForce);
    }

    // 機体の下降メソッド
    public void Fall(float vertical)
    {
        fighterbody.AddTorque(transform.right * vertical * fallingForce);
    }

    // 機体を旋回させるメソッド
    public void Roll(float horizontal)
    {
        fighterbody.AddTorque(transform.forward * horizontal * rollingForce);
    }
}
