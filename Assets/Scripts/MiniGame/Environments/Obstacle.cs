using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // ���� ���

public class Obstacle : MonoBehaviour
{
    // === ��ֹ� ��ġ ===
    private float highPosY = 1f;
    private float lowPosY = -1f;

    // === ����� ���� ===
    private float holeSizeMin = 2.0f;
    private float holeSizeMax = 2.8f;

    // �� �Ʒ� ��ֹ� ����
    public Transform topObject;
    public Transform bottomObject;

    // === ��ֹ� ������ �Ÿ� ===
    public float widthPadding = 3.5f;

    // === ��ֹ� ���� ��ġ ���� ===
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // === ������ x ������ x���� �������� �Ÿ��� Ȯ���� ===
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
