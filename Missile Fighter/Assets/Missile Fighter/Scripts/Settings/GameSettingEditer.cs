using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings.Stages;

namespace MissileFighter.Settings
{
    public class GameSettingEditer : MonoBehaviour
    {
        // ステージ情報の仮決定情報 セーブされると反映
        private StageInformation tmpStageInfo;

        //*********************************************************

        // ステージ選択ボタンが押された時に蓄えておく
        public void OnClickStage(StageInformation info)
        {
            tmpStageInfo = info;
        }

        // セーブする
        public void OnClickSave()
        {
            if (tmpStageInfo != null)
            {
                GameSetting.StageSetting.Save(tmpStageInfo);
            }
        }

        // キャンセル
        public void OnClickCancel()
        {
            tmpStageInfo = null;
        }
    }
}