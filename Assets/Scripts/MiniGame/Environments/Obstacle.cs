using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // ���� ���

public class Obstacle : MonoBehaviour
{
    // === ��ֹ� ��ġ ===
    private float highPosY = 1.5f;
    private float lowPosY = -1.5f;

    // === ����� ���� ===
    private float holeSizeMin = 3.5f;
    private float holeSizeMax = 5.0f;

    // �� �Ʒ� ��ֹ� ����
    public Transform topObject;
    public Transform bottomObject;

    // === ��ֹ� ������ �Ÿ� ===
    public float widthPadding = 3.5f;

    // === GameManager ���� ===
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameManager.Instance;
    }

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

    // === �÷��̾ ������ ��� ���� ȹ�� ===
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(1);
        }

    }
}
