using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.Settings;
using MissileFighter.Settings.PlayerFighter;

namespace MissileFighter.UI.TitleScreen
{
    public class FighterInformationContents : MonoBehaviour
    {
        // 機体名テキスト
        [SerializeField] private Text fighterNameText;

        // コンテンツ上に表示されるオブジェクト 回転させる
        private GameObject fighter;

        //*************************************************************

        private void Update()
        {
            fighter.transform.Rotate(fighter.transform.up * 90 * Time.deltaTime);
        }

        // 機体を生成
        public void GenerateFighter(PlayerFighterInformation info)
        {
            fighterNameText.text = info.FighterName;
            fighter = Instantiate(info.FighterBody, transform);

            // 位置や回転、大きさを設定
            fighter.transform.localPosition = new Vector3(-113, 0, -368);
            fighter.transform.rotation = Quaternion.Euler(new Vector3(20, 180, 0));
            fighter.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }

        // 名前と機体を反映
        public void ReflectStageInfo(PlayerFighterInformation info)
        {
            Destroy(fighter);   // 現在の機体プレハブを削除

            GenerateFighter(info);
        }
    }
}