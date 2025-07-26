using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //scene 전환


public class WarpGate : MonoBehaviour
{
    [SerializeField] Color GizmoColor = new Color(1, 0, 0, 0.3f); // 기즈모 컬러 r g b 투명도

    public Vector3 warpAreaSize = new Vector3(3f, 3f, 0f);

    public string MiniGameScene;

    private bool _isPlayerInArea = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GizmoColor;

        Gizmos.DrawCube(transform.position, warpAreaSize);
    }

    // === 플레이어가 기즈모에 들어옴 ===
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerInArea = true;
           Debug.Log("이동을 위해 F키를 누르세요.");
        }
    }

    // === F키 입력시 미니게임 입장 ===
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerInArea == true)
        {
            SceneManager.LoadScene(MiniGameScene);
        }
    }
}
