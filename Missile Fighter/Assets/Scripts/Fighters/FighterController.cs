﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighters
{
    public class FighterController : MonoBehaviour
    {
        // 操作する戦闘機
        [SerializeField] private Fighter fighter;


        // 描画前に呼ばれるUpdate
        void FixedUpdate()
        {
            InputRoll();
            InputPitch();
            InputAccele();
            InputShotMissile();
        }

        // 加速ボタン処理
        void InputAccele()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                fighter.Acceleration();
            }
        }

        // 旋回に関する入力処理
        void InputRoll()
        {
            if (Input.GetKey(KeyCode.A))
            {
                fighter.Roll(FighterDirectionConstant.LEFT);
            }
            if (Input.GetKey(KeyCode.D))
            {
                fighter.Roll(FighterDirectionConstant.RIGHT);
            }
        }

        // 上昇下降に関する入力処理
        void InputPitch()
        {
            if (Input.GetKey(KeyCode.W))
            {
                fighter.Pitch(FighterDirectionConstant.DOWN);
            }
            if (Input.GetKey(KeyCode.S))
            {
                fighter.Pitch(FighterDirectionConstant.UP);
            }
        }

        // ミサイルボタン処理
        void InputShotMissile()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fighter.MissilePods.ShotMissile();
            }
        }
    }
}
