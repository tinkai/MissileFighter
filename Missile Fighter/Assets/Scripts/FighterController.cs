using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    // 操作する戦闘機
    [SerializeField] private Fighter fighter;


    // 描画前に呼ばれるUpdate
    void FixedUpdate()
    {
        InputRoll();
        InputVertical();
    }

    // 旋回に関する入力処理
    void InputRoll()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        fighter.Roll(-horizontal);
    }

    // 上昇下降に関する入力処理
    void InputVertical()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical >= 0)
        {
            fighter.Fall(vertical);
        }
        else
        {
            fighter.Rise(vertical);
        }
    }
}
