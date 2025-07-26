using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene; // ���� ������ ���ξ� ȣ��
    public GameObject title; // ����â ȣ��

    static GameManager gameManager;

    private int _currentScore = 0;

    public static GameManager Instance
    {
        get { return gameManager; } // �̱��� ����
    }

    private void Awake()
    {
        gameManager = this;
        Time.timeScale = 0.0f; // �߷� ������ ������ �Ͻ����� ��Ŵ
    }

    private void Update()
    {
        if (Input.anyKeyDown) // �ƹ�Ű�� ������ ������
        {
            title.SetActive(false); // ����â ����
            GameStart();
        }
    }

    public void GameStart()
    {
        Plane._isMoving = true;
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(MainScene);
        Debug.Log($"�������� : {_currentScore}");
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

}
