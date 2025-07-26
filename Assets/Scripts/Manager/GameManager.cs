using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene;    // 게임 오버시 메인씬 호출

    UIManager uiManager;
    UIHelper uIHelper;

    static GameManager gameManager;

    private bool _miniGameZone = false;
    private int _currentScore;
    private int _FinalScore = 0;

    public static GameManager Instance { get; private set; } // 싱글톤 선언

    private void Awake()
    {

        uiManager = FindObjectOfType<UIManager>();
        uIHelper = FindObjectOfType <UIHelper>();

        // === 싱글톤 선언 2 ===
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Time.timeScale = 0.0f; // 중력 때문에 게임을 일시정지 시킴
    }

    private void Start()
    {
        uIHelper.Setactive(1);
        string currentSceneName = SceneManager.GetActiveScene().name; // 현재 Scene의 이름을 받아옴

        if (currentSceneName == "MiniGameScene")
        {
            _miniGameZone = true;
            uiManager.UpdateScore(0); // 점수 초기화
        }
        else if(currentSceneName == "MainScene")
        {
            Debug.Log(_FinalScore);
            Time.timeScale = 1.0f;

            if (_FinalScore != 0)
            {
                uIHelper.Setactive(0);
                _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);
                uIHelper.ViewScoreBoard(_FinalScore);
            }

        }

    }

    private void Update()
    {
        if (Input.anyKeyDown && _miniGameZone == true) // 미니게임에서 아무키나 누르면 시작함
        {
            uiManager.Setactive(1); // 설명창 끄기
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
