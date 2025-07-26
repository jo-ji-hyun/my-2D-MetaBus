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

    private bool _miniGameZone; // �̴ϰ��� ����� true
    private int _currentScore;  // ���� ����
    private int _FinalScore;    // ���� ����

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

        Time.timeScale = 0.0f; // �߷� ������ ������ �Ͻ����� ��Ŵ
    }

    private void Start()
    {
        uiHelper.Setactive(1); // �̴ϰ��� ������ ����
    }

    private void Update()
    {
        if (Input.anyKeyDown && _miniGameZone == true) // �̴ϰ��ӿ��� �ƹ�Ű�� ������ ������
        {
            GameStart();
        }
    }
    private void OnDestroy()
    {
        // GameManager ������Ʈ�� �ı��� �� �̺�Ʈ ���� ���� (Ŭ����)
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // === ���� �� �ε� ===
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == miniGameSceneName)
        {
            uiManager = FindObjectOfType<UIManager>();
            _miniGameZone = true;
            _currentScore = 0; // ���� �ʱ�ȭ
        }
        else if (scene.name == mainSceneName)
        {
            uiHelper = FindObjectOfType<UIHelper>();
            Time.timeScale = 1.0f; // �������� ����
            _miniGameZone = false;
            _FinalScore = PlayerPrefs.GetInt("FinalScore", 0);  // 0�� ���� �ҷ���

            if (_FinalScore != 0)
            {
                Debug.Log("�ְ����� ����");
                uiHelper.Setactive(0);                           // �̴ϰ��� ������ �ѱ�
                uiHelper.ViewScoreBoard(_FinalScore);
            }
        }
    }

    public void GameStart()
    {
        Plane._isMoving = true;
        _miniGameZone = false; // Update() �׸� ȣ���ϱ� ����
        Time.timeScale = 1.0f;

        uiManager.Setactive(1); // ����â ����
    }

    public void GameOver()
    {
        // === ���������� FinalScore�� �����մϴ�. ===
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
