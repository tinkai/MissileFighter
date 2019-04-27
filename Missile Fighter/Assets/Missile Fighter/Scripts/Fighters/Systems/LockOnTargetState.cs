using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters.Systems
{
    public class LockOnTargetState
    {
        // ロックオンファイター
        public Fighter Target;

        // ロックオン開始してからの時間
        public float LockOnElapsedTime = 0;

        // ロックオン状態
        public int LockOnRank;

        //***********************************************************

        // コンストラクタ
        public LockOnTargetState(Fighter target)
        {
            Target = target;
        }
    }
}