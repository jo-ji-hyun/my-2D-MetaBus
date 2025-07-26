using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("점수판이 없어용");
        }
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    // === 게임 오버시 호출 ===
    public void ViewScoreBoard(int score)
    {
        scoreText.text = score.ToString();
    }
}
