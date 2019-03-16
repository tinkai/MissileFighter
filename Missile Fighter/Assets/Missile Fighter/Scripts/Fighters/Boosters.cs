using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters
{
    public class Boosters : MonoBehaviour
    {
        // ブースター単体オブジェクト配列
        private GameObject[] boosters;

        // ストップ・通常・加速時のエフェクトの大きさ
        [SerializeField] private Vector3 normalStateEffectScale;
        [SerializeField] private Vector3 accelerationStateEffectScale;
        [SerializeField] private Vector3 brakeStateEffectScale;

        //***********************************************************

        private void Start()
        {
            // ブースター配列の設定
            boosters = new GameObject[transform.childCount];
            int i = 0;
            foreach (Transform childTransform in transform)
            {
                boosters[i] = childTransform.gameObject;
                i++;
            }
        }

        // エフェクトを現在の機体の加速状態に変更
        public void ChangeEffect(int state)
        {
            Vector3 scale;  // 適用する大きさ
            switch (state)
            {
                case FighterStatementConstant.ACCELERATION:
                    scale = accelerationStateEffectScale;
                    break;
                case FighterStatementConstant.BRAKE:
                    scale = brakeStateEffectScale;
                    break;
                default:
                    scale = normalStateEffectScale;
                    break;
            }

            // 全てのブースターに適用
            for (int i = 0; i < boosters.Length; i++)
            {
                boosters[i].transform.localScale = scale;
            }
        }

    }
}