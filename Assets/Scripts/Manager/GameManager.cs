using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene;    // 게임 오버시 메인씬 호출
    public GameObject title;     // 설명창 호출
    private UIManager uiManager;   // UI 매니저 호출

    static GameManager gameManager;

    private int _currentScore;
    private int _FinalScore = 0;
    private bool _isGameOver = false;

    public static GameManager Instance
    {
        get { return gameManager; } // 싱글톤 선언
    }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        
        Time.timeScale = 0.0f; // 중력 때문에 게임을 일시정지 시킴
    }

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "MiniGameScene")
        {
            uiManager.UpdateScore(0); // 점수 초기화
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
        if (Input.anyKeyDown) // 아무키나 누르면 시작함
        {
            title.SetActive(false); // 설명창 끄기
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
