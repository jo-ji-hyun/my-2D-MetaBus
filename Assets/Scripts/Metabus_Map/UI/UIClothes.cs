using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClothes : MonoBehaviour
{
    public GameObject clothes; // 옷장

    private bool _isopen = false; // 열려있는지 확인

    private void Start()
    {
        if (clothes != null)
        {
            _isopen = false;
            clothes.SetActive(false);
        }
    }

    public void MenuControll()
    {
        if (!_isopen)
        {
            clothes.SetActive(true);
            _isopen = true;
        }
        else
        {
            clothes.SetActive(false);
        }

    }

}
