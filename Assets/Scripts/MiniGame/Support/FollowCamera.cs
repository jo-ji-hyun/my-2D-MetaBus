using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // === inspectorâ�� Ÿ���� ���� ===
    public Transform target;
    float _offsetX;

    void Start()
    {
        if (target == null)
            return;

        // === Ÿ����� x �Ÿ� ===
        _offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null)
            return;

        // === ������ ī�޶� ��ġ�� x �Ÿ��� ���� ===
        Vector3 pos = transform.position;
        pos.x = target.position.x + _offsetX;
        transform.position = pos;
    }
}
