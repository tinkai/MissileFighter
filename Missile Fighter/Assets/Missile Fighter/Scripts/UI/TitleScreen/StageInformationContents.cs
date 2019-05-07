using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.Settings;
using MissileFighter.Settings.Stages;

namespace MissileFighter.UI.TitleScreen
{
    public class StageInformationContents : MonoBehaviour
    {
        // ステージ名
        [SerializeField] private Text stageNameText;

        // ステージの参考画像
        [SerializeField] private Image stageImage;

        //*********************************************************

        // 名前と画像を反映
        public void ReflectStageInfo(StageInformation info)
        {
            stageNameText.text = info.StageName;
            stageImage.sprite = info.SkyboxSprite;

            // ボタンの動作を設定
            Button button = GetComponent<Button>();
            GameSettingEditer editor = FindObjectOfType<GameSettingEditer>();
            // 引数アリを設定する場合、ラムダ式にする必要がある
            button.onClick.AddListener(() => editor.OnClickStage(info));
        }
    }
}