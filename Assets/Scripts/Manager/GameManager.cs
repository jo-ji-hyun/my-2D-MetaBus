using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === 현재 씬을 찾아봐요(씬 추가시 추가해야함) ===
    [SerializeField] private string mainSceneName = "MainScene";     
    [SerializeField] private string miniGameSceneName = "MiniGameScene";

    private UIManager uiManager;
    private UIHelper uiHelper;

    private bool _miniGameStart;    // 미니게임 입장시 true
    private bool _mainGameStart;     // 메인씬(메타버스)에 있을 경우
    private int _currentScore = 0;    // 현재 점수
    private int _FinalScore = 0;       // 최종 점수

    public static GameManager Instance { get; private set; } // 싱글톤 선언

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiHelper = FindObjectOfType <UIHelper>();

        // === 싱글톤 선언 2 ===
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드

        Time.timeScale = 0.0f; // 처음 시작시
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.anyKeyDown && _miniGameStart == true) // 미니게임에서 아무키나 누르면 시작함
        {
            GameStart();
        }

        else if (Input.anyKeyDown && _mainGameStart == true)
        {
            uiHelper.Setactive(1);                         // 미니게임 점수판 끄기
        }

    }
    private void OnDestroy()
    {
        // GameManager 오브젝트가 파괴될 때 비우기
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // === 현재 씬 로드 ===
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // === 미니게임의 경우 ===
        if (scene.name == miniGameSceneName)
        {
            Time.timeScale = 0.0f; // 중력 때문에 게임을 일시정지 시킴

            uiManager = FindObjectOfType<UIManager>();
            _miniGameStart = true;
            _mainGameStart = false;
            _currentScore = 0; // 점수 초기화
        }
        // === 메인씬(메타버스)의 경우 ===
        else if (scene.name == mainSceneName)
        {
            uiHelper = FindObjectOfType<UIHelper>();
            Time.timeScale = 1.0f; // 움직임을 위해
            _mainGameStart = true;

            _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);  // 0점 부터 불러옴

            if (_FinalScore != 0) // 점수가 있을 경우
            {
                uiHelper.Setactive(0);                           // 미니게임 점수판 켜기
                uiHelper.ViewScoreBoard(_FinalScore);
            }
        }
    }

    // === 미니게임 시작 ===
    public void GameStart()
    {
        Plane._isMoving = true;
        _miniGameStart = false; // Update() 그만 호출하기 위해
        Time.timeScale = 1.0f;

        uiManager.Setactive(1); // 설명창 끄기
    }

    // === 미니게임 오버 ===
    public void GameOver()
    {
        // === 현재점수를 FinalScore로 저장합니다. ===
        PlayerPrefs.SetInt("FinalScore", _currentScore);
        PlayerPrefs.Save();

        SceneManager.LoadScene(mainSceneName); // 메인(메타버스)으로 이동
    }

    // === 점수 획득 ===
    public void AddScore(int score)
    {
        _currentScore += score;
        uiManager.UpdateScore(_currentScore);
    }

}
