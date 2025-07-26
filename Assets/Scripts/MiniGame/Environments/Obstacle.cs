using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; // 랜덤 사용

public class Obstacle : MonoBehaviour
{
    // === 장애물 위치 ===
    private float highPosY = 1.5f;
    private float lowPosY = -1.5f;

    // === 통과할 구멍 ===
    private float holeSizeMin = 3.5f;
    private float holeSizeMax = 5.0f;

    // 위 아래 장애물 들고옴
    public Transform topObject;
    public Transform bottomObject;

    // === 장애물 사이의 거리 ===
    public float widthPadding = 3.5f;

    // === GameManager 선언 ===
    GameManager gameManager;
    public void Start()
    {
        gameManager = GameManager.Instance;
    }

    // === 장애물 랜덤 위치 설정 ===
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // === 마지막 x 값에서 x값을 증가시켜 거리를 확보함 ===
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    // === 플레이어가 지나갈 경우 점수 획득 ===
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(1);
        }

    }
}
