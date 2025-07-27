using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // === inspector창에 타겟을 받음 ===
    public Transform target;
    float _offsetX;
    float _offsetY;

    void Start()
    {
        if (target == null)
            return;

        // === 타깃과의 x, y 거리 ===
        _offsetX = transform.position.x - target.position.x;
        _offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;

        // === 기존의 카메라 위치에 x 거리를 더함 ===
        pos.x = target.position.x + _offsetX;
        pos.y = target.position.y + _offsetY;

        transform.position = pos; // 새 위치로 이동
    }
}
