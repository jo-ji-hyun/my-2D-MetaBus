using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClothes : MonoBehaviour
{
    public GameObject title;

    public void OpenMenu()
    {
        title.SetActive(true);
    }

    public void ClosedMenu()
    {
        title.SetActive(false);
    }
}
