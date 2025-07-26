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
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            title.SetActive(false); // ����â ����
            GameStart();
        }
    }

    public void GameStart()
    {
        Plane._isMoving = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(MainScene);
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }

}
