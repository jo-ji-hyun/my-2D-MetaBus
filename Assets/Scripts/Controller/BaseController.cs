using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;                             // 물리 법칙 구현를 위해 
    [SerializeField] private SpriteRenderer characterSprite;      // SpriteRenderer를 inspector창에서 조절할 수 있게 함

    //=== 이동, 바라보는 방향 초기 값 ===
    protected Vector2 _move = Vector2.zero;
    protected Vector2 _look = Vector2.zero;

    //=== 입력 받아옴 ===
    public Vector2 Move { get { return _move; } }
    public Vector2 look { get { return _look; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // 컴퍼넌트에서 값을 가져옴
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(_look);
    }

    protected virtual void FixedUpdate() // 움직임을 업데이트하기 위함
    {
        Movement(_move);
    }

    private void Movement(Vector2 direction)
    {
        direction = 5 * direction;       // 속도 조절

        _rigidbody.velocity = direction; // rigidbody에서 속도 수치 조절
    }

    // === 캐릭터가 보는 방향으로 캐릭터 뒤집기 ===
    protected virtual void Rotate(Vector2 direction)
    {
        if (direction.x > 0) // 마우스가 캐릭터의 오른쪽에 있을 때
        {
            characterSprite.flipX = false; // 기본 방향 (오른쪽)
        }
        else if (direction.x < 0) // 마우스가 캐릭터의 왼쪽에 있을 때
        {
            characterSprite.flipX = true; // 좌우 반전

        }
    }
}
