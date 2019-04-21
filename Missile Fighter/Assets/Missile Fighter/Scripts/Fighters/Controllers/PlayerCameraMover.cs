using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileFighter.Fighters.Controllers
{
    public class PlayerCameraMover : MonoBehaviour
    {
        // カメラターゲット
        [SerializeField] private Transform target;

        // カメラとターゲットの初期位置の差
        private Vector3 offset;

        //*********************************************************

        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void FixedUpdate()
        {
            // ターゲットから見たオフセット位置で求める
            Vector3 localOffset = target.forward * offset.z + target.up * offset.y;
            // ターゲットの位置に合わせる
            transform.position = target.position + localOffset;

            // ターゲットの方向を調べる
            Quaternion targetDirection = Quaternion.LookRotation(target.position + target.forward * 50 - transform.position, target.up);
            // ターゲット方向を線形補間で向く
            transform.rotation = Quaternion.Lerp(transform.rotation, targetDirection, Time.deltaTime * 15);
        }
    }
}