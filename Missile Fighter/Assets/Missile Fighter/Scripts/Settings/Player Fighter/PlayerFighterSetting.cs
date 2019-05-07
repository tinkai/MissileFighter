using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Settings.PlayerFighter
{
    public class PlayerFighterSetting : MonoBehaviour
    {
        // 保存するkey
        private string saveKey = "PlayerFighterSetting";

        // 機体情報リスト
        [SerializeField] private PlayerFighterInformation[] fighterList;
        public PlayerFighterInformation[] FighterList
        {
            get { return fighterList; }
        }

        // 現在設定されている機体
        private PlayerFighterInformation currentFighterInfo;
        public PlayerFighterInformation CurrentFighterInfo
        {
            get { return currentFighterInfo; }
        }

        //*************************************************************

        private void Start()
        {
            // ステージ情報を保存されているものに設定
            if (PlayerPrefs.HasKey(saveKey))
            {
                string json = PlayerPrefs.GetString(saveKey);
                currentFighterInfo = JsonUtility.FromJson<PlayerFighterInformation>(json);
            }
            else
            {
                currentFighterInfo = fighterList[0];
            }
        }

        // 現在の設定されている情報をjsonに保存
        public void Save(PlayerFighterInformation info)
        {
            currentFighterInfo = info;

            // jsonに変換して、保存
            string json = JsonUtility.ToJson(currentFighterInfo);
            PlayerPrefs.SetString(saveKey, json);
        }

    }
}