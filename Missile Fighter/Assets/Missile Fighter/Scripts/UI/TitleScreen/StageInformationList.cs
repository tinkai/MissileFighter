using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissileFighter.Settings;
using MissileFighter.Settings.Stages;

namespace MissileFighter.UI.TitleScreen
{
    public class StageInformationList : MonoBehaviour
    {
        // リストのコンテンツプレハブ
        [SerializeField] private GameObject infoContetsPrefab;

        //*********************************************************

        private void Start()
        {
            // ゲームセッティングに登録されているステージの情報をリストに追加
            foreach(StageInformation info in GameSetting.StageSetting.StageList)
            {
                GameObject infoContents = Instantiate(infoContetsPrefab, transform);
                infoContents.GetComponent<StageInformationContents>().ReflectStageInfo(info);
            }
        }

    }
}