using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Renderer characterRenderer; // 색깔 랜더러

    public Color defaultColor = Color.white; // 기본 미니게임 이후 원래색으로 돌아옴

    // === 색깔 정의 ===
    public Color redColor = Color.red;       
    public Color blackColor = Color.black;

    private bool _default = true;

    void Start()
    {
        // 게임 시작 시 캐릭터의 초기 색상을 defaultColor
        if (characterRenderer != null)
        {
            characterRenderer.material.color = defaultColor;
            _default = true;
        }
    }

    public void ToChangeColorRed() // 색깔 체인지 빨강
    {
        if (_default == true) 
        {
            characterRenderer.material.color = redColor;
            _default = false;
        }
        else
        {
            characterRenderer.material.color = defaultColor;
            _default = true;
        }

    }

    public void ToChangeColorBlack() // 색깔 체인지 블랙
    {
        if (_default == true)
        {
            characterRenderer.material.color = blackColor;
            _default = false;
        }
        else
        {
            characterRenderer.material.color = defaultColor;
            _default = true;
        }
    }
}
