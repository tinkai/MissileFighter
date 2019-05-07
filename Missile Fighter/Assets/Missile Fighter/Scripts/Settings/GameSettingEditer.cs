using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings.Stages;
using MissileFighter.Settings.PlayerFighter;
using MissileFighter.UI.TitleScreen;

namespace MissileFighter.Settings
{
    public class GameSettingEditer : MonoBehaviour
    {
        // ステージ情報の仮決定情報 セーブされると反映
        private StageInformation tmpStageInfo;

        // プレイヤー機体の仮決定情報
        private PlayerFighterInformation tmpFighterInfo;

        // 表示している機体番号
        private int currentFighterNum;

        // 機体に関する設定コンテンツ
        [SerializeField] private FighterInformationContents fighterInfoContets;

        //*********************************************************

        private void Start()
        {
            tmpFighterInfo = GameSetting.FighterSetting.FighterList[0];
            fighterInfoContets.GenerateFighter(tmpFighterInfo);
        }

        // ステージ選択ボタンが押された時に蓄えておく
        public void OnClickStage(StageInformation info)
        {
            tmpStageInfo = info;
        }

        // 機体エディター上の矢印ボタン direction = 1(r) or -1(l)
        public void OnClickFighterArrow(int direction)
        {
            // 配列の端ならば変更しない
            if (direction == -1 && currentFighterNum == 0 || 
                direction == 1 && currentFighterNum == GameSetting.FighterSetting.FighterList.Length - 1)
            {
                return;
            }

            // 表示する機体を変更
            currentFighterNum += direction;
            tmpFighterInfo = GameSetting.FighterSetting.FighterList[currentFighterNum];

            // 表示する機体を反映
            fighterInfoContets.ReflectStageInfo(tmpFighterInfo);
        }

        // セーブする
        public void OnClickSave()
        {
            if (tmpStageInfo != null)
            {
                GameSetting.StageSetting.Save(tmpStageInfo);
            }
            if (tmpFighterInfo != null)
            {
                GameSetting.FighterSetting.Save(tmpFighterInfo);
            }
        }

        // キャンセル
        public void OnClickCancel()
        {
            tmpStageInfo = null;
            tmpFighterInfo = null;
        }
    }
}