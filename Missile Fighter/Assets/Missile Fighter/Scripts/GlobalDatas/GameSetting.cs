using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.GlobalDatas {
    public class GameSetting : MonoBehaviour
    {
        // 背景画像
        public static Material skyboxMaterial;

        // SkyboxMaterialの反射の強さ 強いほど明るくなる
        public static float reflectionIntensity;

        // 背景画像の配列
        [SerializeField] private Material[] skyboxMaterials;

        // 反射の強さ配列
        [SerializeField] private float[] reflectionIntensitys;

        // 現在設定されている配列番地
        [SerializeField] private int current;

        //*********************************************************

        private void Awake()
        {
            skyboxMaterial = skyboxMaterials[current];
            reflectionIntensity = reflectionIntensitys[current];
        }
    }
}