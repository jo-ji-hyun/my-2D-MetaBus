using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    // === �ʱⰪ = 0 ===
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

    // === ��ֹ��� �浹�� ������ ��ֹ���ġ �������� ===
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("BackGround")) // Environment�� ���
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount - 4.5f; // �Ÿ� ����
            collision.transform.position = pos;
            return;
        }

        // === ��ֹ��� �浹�� ===
        Obstacle obstacle = collision.GetComponent<Obstacle>(); 

        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
