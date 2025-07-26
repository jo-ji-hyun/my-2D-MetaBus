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

    private bool _miniGameZone; // 미니게임 입장시 true
    private int _currentScore;  // 현재 점수
    private int _FinalScore;    // 최종 점수

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

        Time.timeScale = 0.0f; // 중력 때문에 게임을 일시정지 시킴
    }

    private void Start()
    {
        uiHelper.Setactive(1); // 미니게임 점수판 끄기
    }

    private void Update()
    {
        if (Input.anyKeyDown && _miniGameZone == true) // 미니게임에서 아무키나 누르면 시작함
        {
            GameStart();
        }
    }
    private void OnDestroy()
    {
        // GameManager 오브젝트가 파괴될 때 이벤트 구독 해제 (클린업)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // === 현재 씬 로드 ===
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == miniGameSceneName)
        {
            uiManager = FindObjectOfType<UIManager>();
            _miniGameZone = true;
            _currentScore = 0; // 점수 초기화
        }
        else if (scene.name == mainSceneName)
        {
            uiHelper = FindObjectOfType<UIHelper>();
            Time.timeScale = 1.0f; // 움직임을 위해
            _miniGameZone = false;
            _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);  // 0점 부터 불러옴

            if (_FinalScore != 0)
            {
                Debug.Log("최고점수 저장");
                uiHelper.Setactive(0);                           // 미니게임 점수판 켜기
                uiHelper.ViewScoreBoard(_FinalScore);
            }
        }
    }

    public void GameStart()
    {
        Plane._isMoving = true;
        _miniGameZone = false; // Update() 그만 호출하기 위해
        Time.timeScale = 1.0f;

        uiManager.Setactive(1); // 설명창 끄기
    }

    public void GameOver()
    {
        // === 현재점수를 FinalScore로 저장합니다. ===
        PlayerPrefs.SetInt("FinalScore", _currentScore);
        PlayerPrefs.Save();

        SceneManager.LoadScene(mainSceneName);
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        uiManager.UpdateScore(_currentScore);
    }

}
