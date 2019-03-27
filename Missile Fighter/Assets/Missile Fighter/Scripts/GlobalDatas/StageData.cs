using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Waves;
using MissileFighter.Units;

namespace MissileFighter.GlobalDatas
{
    public class StageData : MonoBehaviour
    {
        // 一つだけ存在するように設定
        public static StageData Instance;

        // 制限時間
        public int LimitTime = 300;

        // 敵のウェーブを管理するクラス
        public WaveManager WaveManager;

        // プレイヤー
        public Player Player;

        //***********************************************************

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }
}