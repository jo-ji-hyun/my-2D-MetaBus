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

}
