using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // === inspector창에 타겟을 받음 ===
    public Transform target;
    float _offsetX;
    float _offsetY;

    // === 카메라 이동 제한 ===
    [SerializeField] private float minX = 0.7384f; // 최소 X 좌표
    [SerializeField] private float maxX = 2.2984f;  // 최대 X 좌표

    [SerializeField] private float minY = 0.1798f;   // 최소 Y 좌표
    [SerializeField] private float maxY = 4.0798f;    // 최대 Y 좌표

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

        // === 1. 기존의 카메라 위치에 x, y 거리를 더함 ===
        pos.x = target.position.x + _offsetX;
        pos.y = target.position.y + _offsetY;

        // ===  2.최솟값 최대값 고정 ===
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // === 3. 새 위치 반환 ===
        transform.position = pos;
    }
}
