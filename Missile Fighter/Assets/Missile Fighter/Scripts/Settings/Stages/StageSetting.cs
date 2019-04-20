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
        private StageInformation stageInfo;
        public StageInformation StageInfo
        {
            get { return stageInfo; }
        }

        //*********************************************************

        private void Start()
        {
            // ステージ情報を保存されているものに設定
            if (PlayerPrefs.HasKey(saveKey))
            {
                string json = PlayerPrefs.GetString(saveKey);
                stageInfo = JsonUtility.FromJson<StageInformation>(json);
            }
            else
            {
                stageInfo = stageList[0];
            }
        }

        // 現在の設定されている情報をjsonに保存
        public void Save(StageInformation info)
        {
            stageInfo = info;

            // jsonに変換して、保存
            string json = JsonUtility.ToJson(stageInfo);
            PlayerPrefs.SetString(saveKey, json);
        }

        // ステージ情報を設定
        public void ReflectSetting()
        {
            // ゲーム設定の背景や反射を反映
            RenderSettings.skybox = stageInfo.SkyboxMaterial;
            DynamicGI.UpdateEnvironment();
            RenderSettings.reflectionIntensity = stageInfo.ReflectionIntensity;
        }
    }
}