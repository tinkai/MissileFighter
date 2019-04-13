using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissileFighter.GlobalDatas;

namespace MissileFighter.UI
{
    public class ScoreRanking : MonoBehaviour
    {
        // ランキングテキスト配列
        [SerializeField] private Text[] rankingText;

        // ランキングのkey
        private string[] keys = {"first", "second", "third"};

        //**********************************************************

        private void Start()
        {
            //PlayerPrefs.DeleteAll();    // ランキングデータ削除
            // ランキングを更新
            int score = Score.CalcTotalScore();
            for (int i = 0; i < keys.Length; i++)
            {
                // まだランキングがない場合は、追加
                if (PlayerPrefs.HasKey(keys[i]) == false) {
                    PlayerPrefs.SetInt(keys[i], score);
                    rankingText[i].GetComponent<Animator>().SetBool("New High Score", true);
                    break;
                }

                // 新規スコアの方が大きければ、ランキングを更新して終了
                if (score > PlayerPrefs.GetInt(keys[i]))
                {
                    // ランキングの最後尾から１つ前に書き換え
                    for (int j = keys.Length - 1; j > i; j--)
                    {
                        PlayerPrefs.SetInt(keys[j], PlayerPrefs.GetInt(keys[j-1]));
                    }
                    // 新規スコアを反映
                    PlayerPrefs.SetInt(keys[i], score);
                    rankingText[i].GetComponent<Animator>().SetBool("New High Score", true);
                    break;
                }
            }

            // テキストに値を表示
            for (int i = 0; i < rankingText.Length; i++)
            {
                // ランキングに存在するならその値を設定
                if (PlayerPrefs.HasKey(keys[i]))
                {
                    rankingText[i].text = PlayerPrefs.GetInt(keys[i]).ToString();
                }
                else
                {
                    rankingText[i].text = "0";
                }
            }
        }
    }
}