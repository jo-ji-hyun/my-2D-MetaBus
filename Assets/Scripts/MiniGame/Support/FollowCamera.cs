using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // === inspector창에 타겟을 받음 ===
    public Transform target;
    float _offsetX;

    void Start()
    {
        if (target == null)
            return;

        // === 타깃과의 x 거리 ===
        _offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null)
            return;

        // === 기존의 카메라 위치에 x 거리를 더함 ===
        Vector3 pos = transform.position;
        pos.x = target.position.x + _offsetX;
        transform.position = pos;
    }
}
