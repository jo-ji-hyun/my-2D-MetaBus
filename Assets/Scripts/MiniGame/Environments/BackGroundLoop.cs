using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    // === 초기값 = 0 ===
    public float numBgCount = 1f;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    // === 장애물과 충돌시 마지막 장애물위치 다음으로 ===
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BackGround")) // Environment일 경우
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount - 4.5f; // 거리 조절
            collision.transform.position = pos;
            return;
        }

        // === 장애물과 충돌시 ===
        Obstacle obstacle = collision.GetComponent<Obstacle>(); 

        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
