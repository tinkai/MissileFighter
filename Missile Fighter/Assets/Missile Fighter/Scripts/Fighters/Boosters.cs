using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters
{
    public class Boosters : MonoBehaviour
    {
        // ブースターの持ち主
        private Fighter fighter;

        // ブースター単体オブジェクト配列
        private GameObject[] boosters;

        // ブースターの状態
        private int statement;

        // ストップ・通常・加速時のエフェクトの大きさ
        [SerializeField] private Vector3 normalStateEffectScale;
        [SerializeField] private Vector3 accelerationStateEffectScale;
        [SerializeField] private Vector3 brakeStateEffectScale;

        // 加速時の効果音
        private AudioSource boosterAudio;

        // ストップ・通常・加速時の効果音の大きさ
        [SerializeField] private float normalVolume;
        [SerializeField] private float brakeVolume;
        [SerializeField] private float accelerationVolume;

        //***********************************************************

        private void Start()
        {
            fighter = GetComponentInParent<Fighter>();

            // ブースター配列の設定
            boosters = new GameObject[transform.childCount];
            int i = 0;
            foreach (Transform childTransform in transform)
            {
                boosters[i] = childTransform.gameObject;
                boosters[i].transform.localScale = normalStateEffectScale;
                i++;
            }

            statement = fighter.AccelerationStatement;

            boosterAudio = GetComponent<AudioSource>();
            boosterAudio.volume = normalVolume;
        }

        private void Update()
        {
            UpdateEffect();
        }

        // エフェクトを現在の機体の加速状態に変更
        public void UpdateEffect()
        {
            // 同じなら終了
            if (fighter.AccelerationStatement == statement) { return; }

            // 状態の更新
            statement = fighter.AccelerationStatement;

            // 適用する大きさの決定
            Vector3 scale;  
            switch (statement)
            {
                case FighterStatementConstant.ACCELERATION:
                    boosterAudio.volume = accelerationVolume;
                    scale = accelerationStateEffectScale;
                    break;
                case FighterStatementConstant.BRAKE:
                    boosterAudio.volume = brakeVolume;
                    scale = brakeStateEffectScale;
                    break;
                default:
                    boosterAudio.volume = normalVolume;
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