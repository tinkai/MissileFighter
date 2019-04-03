using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.GlobalDatas;
using MissileFighter.Units;
using MissileFighter.Fighters;
using UnityEngine.UI;

namespace MissileFighter.Waves
{
    public class WaveManager : MonoBehaviour
    {
        // 敵の波を表すWave配列
        private Wave[] waves;

        // 現在のWave番号
        private int current;
        public int Current
        {
            get { return current; }
        }

        // プレイヤーのロックオンシステム
        private LockOnSystem playerLockOnSystem;

        //***********************************************************

        private void Start()
        {
            waves = GetComponentsInChildren<Wave>();
            // wave0以外の表示を消す
            for (int i = 1; i < waves.Length; i++)
            {
                waves[i].gameObject.SetActive(false);
            }

            playerLockOnSystem = GameObject.FindWithTag("Player").GetComponentInChildren<LockOnSystem>();
        }

        private void Update()
        {
            // 敵がいないなら次のWaveへ
            if (IsEndWave() == false && IsAllDeadEnemy())
            {
                GoToNextWave();

                // プレイヤーのロックオンシステムのターゲットを更新
                playerLockOnSystem.UpdateTargetList();
            }
        }

        // 現在のウェーブを返す
        public Wave GetCurrentWave()
        {
            if (IsEndWave()) { return null; }
            return waves[current];
        }

        // ウェーブの個数を返す
        public int GetWaveLength()
        {
            return waves.Length;
        }

        // 全てのウェーブが終了しているか
        public bool IsEndWave()
        {
            if (current == waves.Length)
            {
                return true;
            }
            return false;
        }

        // 現在のWaveの敵が全て死んでいるか確認
        private bool IsAllDeadEnemy()
        {
            foreach (Enemy enemy in waves[current].Enemys)
            {
                if (enemy.Fighter.IsDead == false)
                {
                    return false;
                }
            }
            return true;
        }

        // 次のWaveに移行するメソッド
        public void GoToNextWave()
        {
            waves[current].gameObject.SetActive(false);

            // 終了している場合
            if (++current == waves.Length)
            {
                return;
            }

            waves[current].gameObject.transform.position = StageData.Instance.Player.gameObject.transform.position;
            waves[current].gameObject.SetActive(true);
        }
    }
}