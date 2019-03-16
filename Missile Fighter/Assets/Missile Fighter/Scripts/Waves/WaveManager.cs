using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.GlobalStageDatas;
using MissileFighter.Units;
using MissileFighter.Fighters;

namespace MissileFighter.Waves
{
    public class WaveManager : MonoBehaviour
    {
        // 敵の波を表すWave配列
        private Wave[] waves;

        // 現在のWave番号
        private int currentWave;

        //***********************************************************

        private void Start()
        {
            waves = GetComponentsInChildren<Wave>();
            for (int i = 1; i < waves.Length; i++)
            {
                waves[i].gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            // 敵がいないなら次のWaveへ
            if (IsAllDeadEnemy())
            {
                GoToNextWave();
                GlobalStageData.Instance.Player.GetComponent<LockOnSystem>().UpdateEnemyList();
            }
        }

        public Wave GetCurrentWave()
        {
            return waves[currentWave];
        }

        // 現在のWaveの敵が全て死んでいるか確認
        private bool IsAllDeadEnemy()
        {
            foreach (Enemy enemy in waves[currentWave].Enemys)
            {
                if (enemy.IsDead == false)
                {
                    return false;
                }
            }

            return true;
        }

        // 次のWaveに移行するメソッド
        public void GoToNextWave()
        {
            waves[currentWave].gameObject.SetActive(false);

            if (currentWave++ == waves.Length)
            {
                return;
            }

            waves[currentWave].gameObject.SetActive(true);
        }
    }
}