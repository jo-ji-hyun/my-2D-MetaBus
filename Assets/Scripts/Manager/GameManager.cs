using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene;    // ���� ������ ���ξ� ȣ��
    public GameObject title;     // ����â ȣ��
    private UIManager uiManager;   // UI �Ŵ��� ȣ��

    static GameManager gameManager;

    private int _currentScore;
    private int _FinalScore = 0;
    private bool _isGameOver = false;

    public static GameManager Instance
    {
        get { return gameManager; } // �̱��� ����
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        
        Time.timeScale = 0.0f; // �߷� ������ ������ �Ͻ����� ��Ŵ
    }

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MiniGameScene")
        {
            uiManager.UpdateScore(0); // ���� �ʱ�ȭ
        }
        else if(currentSceneName == "MainScene")
        {
            if(_isGameOver)
            {
                _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);
                uiManager.ViewScoreBoard(_FinalScore);
                title.SetActive(true);
            }

        }

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
        _isGameOver = true;
        PlayerPrefs.SetInt("FinalScore", _currentScore);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene(MainScene);
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        uiManager.UpdateScore(_currentScore);
    }

}
