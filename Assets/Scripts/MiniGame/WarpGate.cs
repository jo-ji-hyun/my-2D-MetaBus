using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //scene 전환


public class WarpGate : MonoBehaviour
{
    [SerializeField] Color GizmoColor = new Color(1, 0, 0, 0.3f); // 기즈모 컬러 r g b 투명도

    public Vector3 warpAreaSize = new Vector3(3f, 3f, 1f);

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GizmoColor;

        Gizmos.DrawCube(transform.position, warpAreaSize);
    }

    // ===플레이어 충돌시 씬전환===
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //SceneManager.LoadScene(MiniGameScene); 준비중
            Debug.Log("미니 게임 존");
        }
        else
        {
            Debug.Log("준비중");
        }
    }
}
