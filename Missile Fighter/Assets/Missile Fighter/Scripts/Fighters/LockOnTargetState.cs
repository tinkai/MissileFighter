using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class LockOnTargetState
    {
        // 敵オブジェクト
        public GameObject Target;

        // プレイヤーから見えているか
        public bool IsVisible;

        // ロックオン開始してからの時間
        public float LockOnElapsedTime = 0;

        // ロックオンしているか
        public bool IsLockOn;


        // コンストラクタ
        public LockOnTargetState(GameObject target)
        {
            Target = target;
        }
    }
}