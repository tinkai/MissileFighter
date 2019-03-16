using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Waves;
using MissileFighter.Units;

namespace MissileFighter.GlobalStageDatas
{
    public class GlobalStageData : MonoBehaviour
    {
        // 一つだけ存在するように設定
        public static GlobalStageData Instance;

        // 敵のウェーブを管理するクラス
        public WaveManager WaveManager;

        // プレイヤー
        public Player Player;

        //***********************************************************

        private void Start()
        {
            Instance = this;

            Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }
}