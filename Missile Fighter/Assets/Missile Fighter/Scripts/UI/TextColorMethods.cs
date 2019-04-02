using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MissileFighter.UI
{
    public class TextColorMethods : MonoBehaviour
    {
        // 虹色に変化し続けるコルーチン
        public static IEnumerator ChangeTextColor(Text text)
        {
            float h = 0.0f; // 色相
            while (true)
            {
                h += Time.deltaTime;
                if (h > 1.0f)
                {
                    h = 0;
                }
                text.color = Color.HSVToRGB(h, 1.0f, 1.0f);

                yield return 0;
            }

        }
    }
}