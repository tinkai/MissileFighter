using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Units;

namespace MissileFighter.Fighters
{
    public class LockOnTargetState
    {
        // 敵オブジェクト
        public Enemy Target;

        // プレイヤーから見えているか
        public bool IsVisible;

        // ロックオン開始してからの時間
        public float LockOnElapsedTime = 0;

        // ロックオンしているか
        public bool IsLockOn;

        //***********************************************************

        // コンストラクタ
        public LockOnTargetState(Enemy target)
        {
            Target = target;
        }
    }
}