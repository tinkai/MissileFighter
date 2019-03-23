using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters
{
    public class LockOnTargetState
    {
        // ロックオンファイター
        public Fighter Target;

        // ロックオン開始してからの時間
        public float LockOnElapsedTime = 0;

        // ロックオンしているか
        public bool IsLockOn;

        //***********************************************************

        // コンストラクタ
        public LockOnTargetState(Fighter target)
        {
            Target = target;
        }
    }
}