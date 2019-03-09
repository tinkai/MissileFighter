using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighters;

public class Player : MonoBehaviour
{
    [SerializeField] private Fighter fighter;


    // 衝突処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player Weapon") { return; }
        fighter.Dead();
    }
}
