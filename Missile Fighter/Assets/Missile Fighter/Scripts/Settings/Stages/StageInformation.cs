using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Settings.Stages 
{
    [System.Serializable]
    public class StageInformation
    {
        // ステージ名
        [SerializeField] private string stageName;
        public string StageName
        {
            get { return stageName; }
        }

        // セッティング画面の参考画像
        [SerializeField] private Sprite skyboxSprite;
        public Sprite SkyboxSprite
        {
            get { return skyboxSprite; }
        }

        // バトルシーンで使用する背景画像
        [SerializeField] private Material skyboxMaterial;
        public Material SkyboxMaterial
        {
            get { return skyboxMaterial; }
        }

        // デフォルト背景基準の環境光の強さ
        [SerializeField] private float reflectionIntensity;
        public float ReflectionIntensity
        {
            get { return reflectionIntensity; }
        }
    }
}