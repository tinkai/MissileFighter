using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Settings.Stages
{
    public class StageSetting : MonoBehaviour
    {
        // 保存するkey
        private string saveKey = "StageSetting";

        // 登録するステージリスト
        [SerializeField] private StageInformation[] stageList;
        public StageInformation[] StageList
        {
            get { return stageList; }
        }

        // 現在設定されているステージ情報
        private StageInformation currentStageInfo;

        //*********************************************************

        private void Start()
        {
            // ステージ情報を保存されているものに設定
            if (PlayerPrefs.HasKey(saveKey))
            {
                string json = PlayerPrefs.GetString(saveKey);
                currentStageInfo = JsonUtility.FromJson<StageInformation>(json);
            }
            else
            {
                currentStageInfo = stageList[0];
            }
        }

        // 現在の設定されている情報をjsonに保存
        public void Save(StageInformation info)
        {
            currentStageInfo = info;

            // jsonに変換して、保存
            string json = JsonUtility.ToJson(currentStageInfo);
            PlayerPrefs.SetString(saveKey, json);
        }

        // ステージ情報を設定
        public void ReflectSetting()
        {
            // ゲーム設定の背景や反射を反映
            RenderSettings.skybox = currentStageInfo.SkyboxMaterial;
            DynamicGI.UpdateEnvironment();
            RenderSettings.reflectionIntensity = currentStageInfo.ReflectionIntensity;
        }
    }
}