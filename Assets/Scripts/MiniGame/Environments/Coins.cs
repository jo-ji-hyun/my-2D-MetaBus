using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Coins : MonoBehaviour
{
    // === 코인 위치 ===
    [SerializeField] private float highPosY = 1.0f;
    [SerializeField] private float lowPosY = -1.0f;

    // === 장애물 사이의 거리 ===
    public float widthPadding = 4.0f;

    // === 코인의 위치 저장 ===
    private Vector3 _lastCoinPosition;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance; // 게임 매니저 참조
    }

    private void FixedUpdate()
    {
        _lastCoinPosition = transform.position; // 마지막 위치 저장
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(1);
            Debug.Log("코인먹음");
        }
        SpawnCoin(_lastCoinPosition);
    }

    // === 코인 랜덤 위치 설정 ===
    private void SpawnCoin(Vector3 lastPosition)
    {
        // === 마지막 x 값에서 x값을 증가시켜 거리를 확보함 ===
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        
        placePosition.y = Mathf.Clamp(placePosition.y, lowPosY, highPosY);
        transform.position = placePosition;
    }
}
