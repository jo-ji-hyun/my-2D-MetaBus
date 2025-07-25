using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;                             // 물리 법칙 구현를 위해 
    [SerializeField] private SpriteRenderer characterSprite;      // SpriteRenderer를 inspector창에서 조절할 수 있게 함

    //=== 이동, 바라보는 방향 초기 값 ===
    protected Vector2 _move = Vector2.zero;
    protected Vector2 _look = Vector2.zero;

    //=== 입력 받아옴 ===
    public Vector2 Move { get { return _move; } }
    public Vector2 look { get { return _look; } }

    private  void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // 컴퍼넌트에서 값을 가져옴
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    private void FixedUpdate()
    {

    }
}
