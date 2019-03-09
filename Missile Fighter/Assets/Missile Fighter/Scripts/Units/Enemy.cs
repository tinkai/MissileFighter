using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighters;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Fighter fighter;


    // 衝突処理
    private void OnTriggerEnter(Collider other)
    {
        fighter.Dead();
    }
}
