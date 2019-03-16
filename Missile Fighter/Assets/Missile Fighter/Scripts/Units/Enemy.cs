using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Fighters;

namespace MissileFighter.Units
{
    [RequireComponent(typeof(Fighter))]

    public class Enemy : MonoBehaviour
    {
        // 機体
        private Fighter fighter;

        // 死んだか
        private bool isDead;
        public bool IsDead
        {
            get { return isDead; }
        }

        //***********************************************************

        private void Start()
        {
            fighter = GetComponent<Fighter>();
        }

        // 衝突処理
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy Weapon") { return; }
            Dead();
        }

        // 死亡処理
        void Dead()
        {
            isDead = true;
            fighter.Explosion();
            gameObject.SetActive(false);    // 表示を消す
        }
    }
}