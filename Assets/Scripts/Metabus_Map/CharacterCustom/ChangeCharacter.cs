using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public SpriteRenderer character;

    public Sprite defaultCharacterSprite; // 기본
    public Sprite dragonCharacterSprite;  // 드래곤

    public void ChangeToDragon()
    {
        Debug.Log("캐릭변신!");
        if (character != null)
        {
            character.sprite = dragonCharacterSprite;
        }
    }
}
