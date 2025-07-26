using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHelper : MonoBehaviour // 메타버스 점수 UI
{
    public GameObject title;           // 설명창 호출
    public TextMeshProUGUI scoreText;  // 점수

    public void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("점수넣을 곳이 없어용");
        }
        if (title == null)
        {
            Debug.Log("점수판이 없어용");
        }
    }

    // === 게임 오버시 호출 ===
    public void ViewScoreBoard(int score)
    {
        scoreText.text = score.ToString();
        Debug.Log("최고점수 변환 중");
    }

    public void Setactive(int x)
    {
        if (x == 0)
        {
            title.SetActive(true);
        }
        else
        {
            title.SetActive(false);
        }

    }
}
