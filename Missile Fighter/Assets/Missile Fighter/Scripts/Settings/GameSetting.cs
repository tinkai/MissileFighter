using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings.Stages;

namespace MissileFighter.Settings 
{
    public class GameSetting : MonoBehaviour
    {
        // ステージの背景などの情報  バトルシーンへ渡す
        public static StageSetting StageSetting;

        //*********************************************************

        private void Awake()
        {
            StageSetting = GetComponent<StageSetting>();
        }

        // ゲーム設定を全て反映
        public static void ReflectSetting()
        {
            StageSetting.ReflectSetting();
        }
    }
}