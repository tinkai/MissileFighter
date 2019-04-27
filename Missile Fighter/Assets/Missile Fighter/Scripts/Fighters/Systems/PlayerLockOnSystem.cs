using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.GlobalDatas;
using MissileFighter.Units;

namespace MissileFighter.Fighters.Systems
{
    public class PlayerLockOnSystem : LockOnSystem
    {

        // ターゲットリストを更新するメソッド 
        public override void UpdateTargetList()
        {
            base.UpdateTargetList();

            // 現在のWaveが取得できなければ終了
            if (StageData.Instance.WaveManager.GetCurrentWave() == null) { return; }

            // リストに敵を設定
            Enemy[] enemys = StageData.Instance.WaveManager.GetCurrentWave().Enemys;
            foreach (Enemy enemy in enemys)
            {
                targetStateList.Add(new LockOnTargetState(enemy.Fighter));
            }
        }

        // 初回ロックオン時に音を鳴らすメソッド
        protected override void PlayLockOnAudio()
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audio.clip);
        }
    }
}