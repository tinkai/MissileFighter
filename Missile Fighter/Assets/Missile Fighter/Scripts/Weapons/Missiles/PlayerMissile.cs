using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Weapons.Missiles
{
    public class PlayerMissile : Missile
    {
        public override void UpdatePerformance(int n)
        {
            switch (n)
            {
                case 3:
                    speed *= 2;
                    inductionForce *= 2;
                    damagePower = 3;
                    GetComponent<TrailRenderer>().startColor = Color.blue;
                    break;
                case 2:
                    speed *= 1.5f;
                    inductionForce *= 1.5f;
                    damagePower = 2;
                    GetComponent<TrailRenderer>().startColor = Color.yellow;
                    break;
                case 1:
                    GetComponent<TrailRenderer>().startColor = Color.red;
                    break;
            }
        }
    }
}