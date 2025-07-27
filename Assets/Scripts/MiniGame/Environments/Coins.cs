using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Coins : MonoBehaviour
{
    // === 코인 위치 ===
    [SerializeField] private float highPosY = 1.5f;
    [SerializeField] private float lowPosY = -1.5f;

    // === 코인 사이의 거리 ===
    public float widthPadding = 12.0f;

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
            SpawnCoin(_lastCoinPosition);
        }
        else
        {
            SpawnCoin(_lastCoinPosition + new Vector3 (widthPadding, 0));
        }

    }

    // === 코인 랜덤 위치 설정 ===
    public void SpawnCoin(Vector3 coinPosition)
    {
        // === 마지막 x 값에서 x값을 증가시켜 거리를 확보함 ===
        Vector3 placePosition = coinPosition + new Vector3(widthPadding, 0);
        
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition;
    }
}
