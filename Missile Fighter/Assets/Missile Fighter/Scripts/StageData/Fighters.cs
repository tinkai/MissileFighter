using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StageData
{
    public class Fighters : MonoBehaviour
    {
        public static Fighters Instance;

        public List<GameObject> Enemys;


        private void Start()
        {
            Instance = this;

            Enemys = new List<GameObject>();

            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy"));
            Enemys.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
}