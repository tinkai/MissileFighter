using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighters;

namespace Units
{
    [RequireComponent(typeof(Fighter))]

    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Fighter fighter;

        private bool isDead;
        public bool IsDead
        {
            get { return isDead; }
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