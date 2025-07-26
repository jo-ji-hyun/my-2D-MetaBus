using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === ���� ���� ã�ƺ���(�� �߰��� �߰��ؾ���) ===
    [SerializeField] private string mainSceneName = "MainScene";     
    [SerializeField] private string miniGameSceneName = "MiniGameScene";

    private UIManager uiManager;
    private UIHelper uiHelper;

    private bool _miniGameStart;    // �̴ϰ��� ����� true
    private bool _mainGameStart;     // ���ξ�(��Ÿ����)�� ���� ���
    private int _currentScore = 0;    // ���� ����
    private int _FinalScore = 0;       // ���� ����

    public static GameManager Instance { get; private set; } // �̱��� ����

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiHelper = FindObjectOfType <UIHelper>();

        // === �̱��� ���� 2 ===
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε�

        Time.timeScale = 0.0f; // ó�� ���۽�
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.anyKeyDown && _miniGameStart == true) // �̴ϰ��ӿ��� �ƹ�Ű�� ������ ������
        {
            GameStart();
        }

        else if (Input.anyKeyDown && _mainGameStart == true)
        {
            uiHelper.Setactive(1);                         // �̴ϰ��� ������ ����
        }

    }
    private void OnDestroy()
    {
        // GameManager ������Ʈ�� �ı��� �� ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // === ���� �� �ε� ===
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // === �̴ϰ����� ��� ===
        if (scene.name == miniGameSceneName)
        {
            Time.timeScale = 0.0f; // �߷� ������ ������ �Ͻ����� ��Ŵ

            uiManager = FindObjectOfType<UIManager>();
            _miniGameStart = true;
            _mainGameStart = false;
            _currentScore = 0; // ���� �ʱ�ȭ
        }
        // === ���ξ�(��Ÿ����)�� ��� ===
        else if (scene.name == mainSceneName)
        {
            uiHelper = FindObjectOfType<UIHelper>();
            Time.timeScale = 1.0f; // �������� ����
            _mainGameStart = true;

            _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);  // 0�� ���� �ҷ���

            if (_FinalScore != 0) // ������ ���� ���
            {
                uiHelper.Setactive(0);                           // �̴ϰ��� ������ �ѱ�
                uiHelper.ViewScoreBoard(_FinalScore);
            }
        }
    }

    // === �̴ϰ��� ���� ===
    public void GameStart()
    {
        Plane._isMoving = true;
        _miniGameStart = false; // Update() �׸� ȣ���ϱ� ����
        Time.timeScale = 1.0f;

        uiManager.Setactive(1); // ����â ����
    }

    // === �̴ϰ��� ���� ===
    public void GameOver()
    {
        // === ���������� FinalScore�� �����մϴ�. ===
        PlayerPrefs.SetInt("FinalScore", _currentScore);
        PlayerPrefs.Save();

        SceneManager.LoadScene(mainSceneName); // ����(��Ÿ����)���� �̵�
    }

    // === ���� ȹ�� ===
    public void AddScore(int score)
    {
        _currentScore += score;
        uiManager.UpdateScore(_currentScore);
    }

}
