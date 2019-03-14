using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighters;

namespace Units
{
    [RequireComponent(typeof(Fighter))]

    public class Player : MonoBehaviour
    {
        private Fighter fighter;


        private void Start()
        {
            fighter = GetComponent<Fighter>();
        }

        // 衝突処理
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player Weapon") { return; }
            fighter.Explosion();
        }
    }
}