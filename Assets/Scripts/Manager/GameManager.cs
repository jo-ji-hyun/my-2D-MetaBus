using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string MainScene; // 게임 오버시 메인씬 호출

    static GameManager gameManager;

    private int _currentScore = 0;

    public static GameManager Instance
    {
        get { return gameManager; } // 싱글톤 선언
    }

    private void Awake()
    {
        gameManager = this;
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
