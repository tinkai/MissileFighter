using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Common
{
    public class CanvasManager : MonoBehaviour
    {
        // キャンバス配列
        private Canvas[] canvases;

        //*********************************************************

        private void Start()
        {
            // シーン内のキャンバスを全て取得
            canvases = FindObjectsOfType<Canvas>();
        }

        // 指定したキャンバスのみをアクティブにするメソッド
        public void ActiveOnlyCanvas(Canvas target)
        {
            foreach (Canvas canvas in canvases)
            {
                canvas.gameObject.SetActive(false);
            }
            target.gameObject.SetActive(true);
        }

        // キャンバス名によってアクティブにするメソッド
        public void ActiveOnlyCanvas(string name)
        {
            Canvas canvas = GameObject.Find(name).GetComponent<Canvas>();
            if (canvas == null) { return; }
            ActiveOnlyCanvas(canvas);
        }

        // 与えられたキャンバスをアクティブにするメソッド
        public void ActiveCanvas(Canvas canvas)
        {
            canvas.gameObject.SetActive(true);
        }

        // 与えられたメソッドを非アクティブにするメソッド
        public void InactiveCanvas(Canvas canvas)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}