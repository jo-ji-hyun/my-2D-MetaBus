using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene;    // ���� ������ ���ξ� ȣ��

    UIManager uiManager;
    UIHelper uIHelper;

    static GameManager gameManager;

    private bool _miniGameZone = false;
    private int _currentScore;
    private int _FinalScore = 0;

    public static GameManager Instance { get; private set; } // �̱��� ����

    private void Awake()
    {

        uiManager = FindObjectOfType<UIManager>();
        uIHelper = FindObjectOfType <UIHelper>();

        // === �̱��� ���� 2 ===
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Time.timeScale = 0.0f; // �߷� ������ ������ �Ͻ����� ��Ŵ
    }

    private void Start()
    {
        uIHelper.Setactive(1);
        string currentSceneName = SceneManager.GetActiveScene().name; // ���� Scene�� �̸��� �޾ƿ�

        if (currentSceneName == "MiniGameScene")
        {
            _miniGameZone = true;
            uiManager.UpdateScore(0); // ���� �ʱ�ȭ
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
        if (Input.anyKeyDown && _miniGameZone == true) // �̴ϰ��ӿ��� �ƹ�Ű�� ������ ������
        {
            uiManager.Setactive(1); // ����â ����
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
