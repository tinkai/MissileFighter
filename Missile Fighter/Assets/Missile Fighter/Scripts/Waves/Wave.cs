using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

public class Wave : MonoBehaviour
{
    // 敵パーティ
    private Enemy[] enemys;
    public Enemy[] Enemys
    {
        get { return enemys; }
    }


    private void Start()
    {
        enemys = GetComponentsInChildren<Enemy>();
    }

}
