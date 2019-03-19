using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Fighters;
using MissileFighter.GlobalStageDatas;
using MissileFighter.Missiles;

namespace MissileFighter.Units
{
    [RequireComponent(typeof(Fighter))]

    public class Enemy : MonoBehaviour
    {
        // 機体
        private Fighter fighter;
        public Fighter Fighter
        {
            get { return fighter; }
        }

        // プレイヤー
        private Player player;

        //***********************************************************

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        private void Update()
        {
            fighter.MissilePods.ShotMissile();
        }
    }
}