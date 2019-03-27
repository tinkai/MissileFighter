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
            int num = Mathf.Clamp(waveManager.Current + 1, 1, waveManager.GetWaveLength());
            waveText.text = num.ToString() + "/" + waveManager.GetWaveLength().ToString();
        }
    }
}