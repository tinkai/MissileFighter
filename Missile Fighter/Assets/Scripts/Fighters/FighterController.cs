using System.Collections;
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
            InputYaw();
            InputAccele();
            InputBrake();
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

        // ブレーキボタン処理
        void InputBrake()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                fighter.Brake();
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

        // 左右への旋回に関する入力処理
        void InputYaw()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                fighter.Yaw(FighterDirectionConstant.LEFT);
            }
            if (Input.GetKey(KeyCode.E))
            {
                fighter.Yaw(FighterDirectionConstant.RIGHT);
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
