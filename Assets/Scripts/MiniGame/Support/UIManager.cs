using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour //미니게임 점수 UI
{
    public GameObject title;           // 설명창 호출
    public TextMeshProUGUI scoreText;  // 점수

    public void Start()
    {

    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void Setactive(int x)
    {
        if(x == 0)
        {
            title.SetActive(true);
        }
        else
        {
            title.SetActive(false);
        }
            
    }
}
