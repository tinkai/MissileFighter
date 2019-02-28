using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody missilebody;


    void Start()
    {
        missilebody = gameObject.GetComponent<Rigidbody>();

        // 機体の速力以上にする
        GameObject fighter = GameObject.Find("Player Fighter");
        missilebody.velocity = fighter.GetComponent<Rigidbody>().velocity + fighter.transform.forward * 100;
    }

    void Update()
    {
        
    }
}
