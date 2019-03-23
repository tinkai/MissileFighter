using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Fighters;

namespace MissileFighter.Units
{
    [RequireComponent(typeof(Fighter))]

    public class Player : MonoBehaviour
    {
        // 機体
        private Fighter fighter;
        public Fighter Fighter
        {
            get { return fighter; }
        }

        //***********************************************************

        private void Start()
        {
            fighter = GetComponent<Fighter>();
        }

        // 衝突判定
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Enemy" && other.tag != "Enemy Weapon") { return; }

            // 衝突処理を行う
            fighter.CollisionObj(other.gameObject);
        }
    }
}