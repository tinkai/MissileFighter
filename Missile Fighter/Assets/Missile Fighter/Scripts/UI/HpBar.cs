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

        private Fighter fighter;

        //*************************************************************

        private void Awake()
        {
            hpBar = GetComponent<Slider>();
        }

        private void Start()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        private void Update()
        {
            hpBar.value = (float)fighter.Hp / fighter.MaxHp;
        }
    }
}