using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClothes : MonoBehaviour
{
    public GameObject clothes; // 옷장

    private bool _isopen = false; // 열려있는지 확인

    public ChangeColor _changeColor;

    private void Start() 
    {
        if (clothes != null)
        {
            _isopen = false;
            clothes.SetActive(false);
        }
    }

    public void MenuControll() // 메뉴 껏다 키기 버튼
    {
        if (_isopen == false)
        {
            clothes.SetActive(true);
            _isopen = true;
        }
        else
        {
            clothes.SetActive(false);
            _isopen = false;
        }

    }

    public void ChangeColorControllR() // 색깔 바꾸기 버튼 R
    {
        if(_changeColor != null)
           _changeColor.ToChangeColorRed();
    }

    public void ChangeColorControllB() // 색깔 바꾸기 버튼 B
    {
        if (_changeColor != null)
            _changeColor.ToChangeColorBlack();
    }
}
