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
        if (!UnlockManager.IsOutUnlocked(UnlockManager.DRAGON_UNLOCKED_KEY)) // 키 확인
        {
            Debug.LogWarning("드래곤 외형은 아직 해금되지 않았습니다!");
            return; // 해금되지 않았으면 함수 종료
        }

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
