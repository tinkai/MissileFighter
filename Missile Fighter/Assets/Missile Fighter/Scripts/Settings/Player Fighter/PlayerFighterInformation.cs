using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Settings.PlayerFighter
{
    [System.Serializable]
    public class PlayerFighterInformation
    {
        // 機体名
        [SerializeField] private string fighterName;
        public string FighterName
        {
            get { return fighterName; }
        }

        // 機体オブジェクト(プレハブ)
        [SerializeField] private GameObject fighterBody;
        public GameObject FighterBody
        {
            get { return fighterBody; }
        }

        // 戦闘機体オブジェクト(プレハブ)
        [SerializeField] private GameObject battleFighter;
        public GameObject BattleFighter
        {
            get { return battleFighter; }
        }
    }
}