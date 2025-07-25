using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //scene ��ȯ


public class WarpGate : MonoBehaviour
{
    [SerializeField] Color GizmoColor = new Color(1, 0, 0, 0.3f); // ����� �÷� r g b ����

    public Vector3 warpAreaSize = new Vector3(3f, 3f, 0f);

    public string MiniGameScene;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GizmoColor;

        Gizmos.DrawCube(transform.position, warpAreaSize);
    }

    // ===�÷��̾� �浹�� ����ȯ===
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(MiniGameScene))
            {
                SceneManager.LoadScene(MiniGameScene);
            }
            else
            {
                Debug.LogWarning("�̵� �Ұ�");
            }

            Debug.Log("�̴� ���� �� ����");
        }
        else
        {

        }
    }

}
