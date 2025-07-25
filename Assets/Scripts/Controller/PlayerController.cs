using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;                             // ���� ��Ģ ������ ���� 
    [SerializeField] private SpriteRenderer characterSprite;      // SpriteRenderer�� inspectorâ���� ������ �� �ְ� ��

    //=== �̵�, �ٶ󺸴� ���� �ʱ� �� ===
    protected Vector2 _move = Vector2.zero;
    protected Vector2 _look = Vector2.zero;

    //=== �Է� �޾ƿ� ===
    public Vector2 Move { get { return _move; } }
    public Vector2 look { get { return _look; } }

    private  void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // ���۳�Ʈ���� ���� ������
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
