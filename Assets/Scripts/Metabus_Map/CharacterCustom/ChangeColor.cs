using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Renderer characterRenderer; // 색깔 랜더러

    public Color defaultColor = Color.white; // 기본

    // === 색깔 정의 ===
    public Color redColor = Color.red;       
    public Color blueColor = Color.blue;

    public void ToChangeColor()
    {
        Debug.Log("컬러체인지");
        characterRenderer.material.color = redColor;
    }
}
