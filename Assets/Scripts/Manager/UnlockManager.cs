using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static UnlockManager Instance { get; private set; }

    // === 해금될 외형의 PlayerPrefs 키 ===
    public const string DRAGON_UNLOCKED_KEY = "DragonUnlocked";

    void Awake()
    {
        // === 싱글톤 인스턴스 설정 ===
        if (Instance != null && Instance != this)
        {
            // 이미 인스턴스가 존재하면 새로 생성된 자신을 파괴 (중복 방지)
            Destroy(gameObject);
            return;
        }
        Instance = this; // 현재 인스턴스를 Instance 변수에 할당

        // === 씬 전환 시 파괴되지 않도록 설정 ===
        DontDestroyOnLoad(gameObject);

        // === 게임 시작 시 PlayerPrefs에 해당 키가 없으면 기본값(false)으로 설정 ===
        if (!PlayerPrefs.HasKey(DRAGON_UNLOCKED_KEY))
        {
            PlayerPrefs.SetInt(DRAGON_UNLOCKED_KEY, 0); // 0 = 잠김, 1 = 해금됨
        }
    }

    // === 해제 메서드 ===
    public static void UnlockOutfit(string outKey)
    {
        PlayerPrefs.SetInt(outKey, 1);      // 1로 설정하여 해금됨을 표시
        PlayerPrefs.Save();                 // 변경사항 저장
        Debug.Log(outKey + " 해금됨!");
    }

    // === 특정 키 확인 ===
    public static bool IsOutUnlocked(string Key)
    {
        return PlayerPrefs.GetInt(Key, 0) == 1; // 기본값 0 (잠김)
    }

    public void CheckAndUnlockDragonOutfit(int Score)
    {
        if (Score >= 10 && !IsOutUnlocked(DRAGON_UNLOCKED_KEY))
        {
            UnlockOutfit(DRAGON_UNLOCKED_KEY);
            Debug.Log("점수 10점 달성! 드래곤 외형 해금!");
        }
    }
}
