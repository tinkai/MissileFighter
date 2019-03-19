using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.Fighters;

namespace MissileFighter.UI {
    [RequireComponent(typeof(Slider))]

    public class HpBar : MonoBehaviour
    {
        // HPスライダー
        private Slider hpBar;

        private Fighter player;

        // プレイヤーの最大のHP
        private int maxHp;

        //*************************************************************

        private void Start()
        {
            hpBar = GetComponent<Slider>();
            player = GameObject.FindWithTag("Player").GetComponent<Fighter>();
            maxHp = player.Hp;
        }

        private void Update()
        {
            hpBar.value = (float)player.Hp / maxHp;
        }
    }
}