using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings.Stages;
using MissileFighter.Settings.PlayerFighter;

namespace MissileFighter.Settings 
{
    public class GameSetting : MonoBehaviour
    {
        // ステージの背景などの情報  バトルシーンへ渡す
        public static StageSetting StageSetting;

        // プレイヤーの機体情報
        public static PlayerFighterSetting FighterSetting;

        //*********************************************************

        private void Awake()
        {
            StageSetting = GetComponent<StageSetting>();
            FighterSetting = GetComponent<PlayerFighterSetting>();
        }

        // ゲーム設定を全て反映
        public static void ReflectSetting()
        {
            StageSetting.ReflectSetting();
        }
    }
}