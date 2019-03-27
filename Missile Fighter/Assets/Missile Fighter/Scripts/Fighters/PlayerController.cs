using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters
{
    public class PlayerController : MonoBehaviour
    {
        // 操作する戦闘機
        private Fighter fighter;

        //***********************************************************

        private void Awake()
        {
            fighter = GetComponent<Fighter>();
        }

        private void FixedUpdate()
        {
            InputRoll();
            InputPitch();
            InputYaw();
            InputAcceleration();
            InputShotMissile();
        }

        // 加速ボタン処理
        void InputAcceleration()
        {
            // 機体の加速状態をボタン入力に応じて変更させる
            if (Input.GetKey(KeyCode.LeftShift))
            {
                fighter.AccelerationStatement = FighterStatementConstant.ACCELERATION;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                fighter.AccelerationStatement = FighterStatementConstant.BRAKE;
            }
            else
            {
                fighter.AccelerationStatement = FighterStatementConstant.NORMAL;
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
