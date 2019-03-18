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
    }
}