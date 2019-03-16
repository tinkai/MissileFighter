using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageData;
using Units;
using Fighters;

public class WaveManager : MonoBehaviour
{
    // 敵の波を表すWave配列
    private Wave[] waves;

    // 現在のWave番号
    private int currentWave;


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
        Debug.Log(waves.Length);
        // 敵がいないなら次のWaveへ
        if (IsAllDeadEnemy())
        {
            GoToNextWave();
            StageData.Units.Instance.Player.GetComponent<LockOnSystem>().UpdateEnemyList();
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
