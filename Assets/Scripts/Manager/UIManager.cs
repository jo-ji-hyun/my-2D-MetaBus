using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour //�̴ϰ��� ���� UI
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
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void Setactive(int x)
    {
        if(x == 0)
        {
            title.SetActive(true);
        }
        else
        {
            title.SetActive(false);
        }
            
    }
}
