using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings;

namespace MissileFighter.Fighters.Player
{
    public class PlayerFighterCreator : MonoBehaviour
    {
        // プレイヤープレハブ
        private GameObject playerPrefab;

        //*************************************************************

        private void Start()
        {
            // 設定されているプレイヤー機体を作成
            playerPrefab = GameSetting.FighterSetting.CurrentFighterInfo.BattleFighter;
            Instantiate(playerPrefab, GameObject.Find("Player").transform);
        }
    }
}