using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.Waves;
using MissileFighter.GlobalDatas;

namespace MissileFighter.UI {
    public class UiWaves : MonoBehaviour
    {
        // 変更するUI ?/?表記
        [SerializeField] private Text waveText;

        // 表示するウェーブマネージャー
        [SerializeField] private WaveManager waveManager;

        //*********************************************************

        private void Update()
        {
            waveText.text = (waveManager.Current + 1).ToString() + "/" + waveManager.GetWaveLength().ToString();
        }
    }
}