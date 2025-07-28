using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public SpriteRenderer character;

    public Sprite defaultCharacterSprite; // 기본
    public Sprite dragonCharacterSprite;  // 드래곤

    private bool _default = true; // 원래대로 돌리기 위해 bool형식 이용

    public void ChangeToDragon() // 변신!
    {
        if (character != null)
        {
            if (_default == true) 
            {
                character.sprite = dragonCharacterSprite;
                _default = false;
            }
            else
            {
                character.sprite = defaultCharacterSprite;
                _default = true;
            }
        }
    }
}
