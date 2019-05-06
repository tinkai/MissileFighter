using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters.Player
{
    public class PlayerFighterCreator : MonoBehaviour
    {
        // プレイヤープレハブ
        public GameObject playerPrefab;

        //*************************************************************

        private void Start()
        {
            Instantiate(playerPrefab, GameObject.Find("Player").transform);
        }
    }
}