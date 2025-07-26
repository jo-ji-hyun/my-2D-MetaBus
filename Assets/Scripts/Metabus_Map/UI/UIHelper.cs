using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHelper : MonoBehaviour
{
    public GameObject title;           // ����â ȣ��
    public TextMeshProUGUI scoreText;  // ����

    public void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("�������� ���� �����");
        }
        if (title == null)
        {
            Debug.Log("�������� �����");
        }
    }

    // === ���� ������ ȣ�� ===
    public void ViewScoreBoard(int score)
    {
        scoreText.text = score.ToString();

    }

    public void Setactive(int x)
    {
        if (x == 0)
        {
            title.SetActive(true);
        }
        else
        {
            title.SetActive(false);
        }

    }
}
