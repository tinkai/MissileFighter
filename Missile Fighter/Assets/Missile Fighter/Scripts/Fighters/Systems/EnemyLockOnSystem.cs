using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.GlobalDatas;

namespace MissileFighter.Fighters.Systems
{
    public class EnemyLockOnSystem : LockOnSystem
    {

        // ターゲットリストを更新するメソッド 
        public override void UpdateTargetList()
        {
            base.UpdateTargetList();

            targetStateList.Add(new LockOnTargetState(StageData.Instance.Player.Fighter));
        }
    }
}