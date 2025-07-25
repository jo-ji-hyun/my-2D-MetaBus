using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;                             // ���� ��Ģ ������ ���� 
    [SerializeField] private SpriteRenderer characterSprite;      // SpriteRenderer�� inspectorâ���� ������ �� �ְ� ��

    //=== �̵�, �ٶ󺸴� ���� �ʱ� �� ===
    protected Vector2 _move = Vector2.zero;
    protected Vector2 _look = Vector2.zero;

    //=== �Է� �޾ƿ� ===
    public Vector2 Move { get { return _move; } }
    public Vector2 look { get { return _look; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // ���۳�Ʈ���� ���� ������
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        Rotate(_look);
    }

    protected virtual void FixedUpdate() // �������� ������Ʈ�ϱ� ����
    {
        Movement(_move);
    }

    private void Movement(Vector2 direction)
    {
        direction = 5 * direction;       // �ӵ� ����

        _rigidbody.velocity = direction; // rigidbody���� �ӵ� ��ġ ����
    }

    // === ĳ���Ͱ� ���� �������� ĳ���� ������ ===
    protected virtual void Rotate(Vector2 direction)
    {
        if (direction.x > 0) // ���콺�� ĳ������ �����ʿ� ���� ��
        {
            characterSprite.flipX = false; // �⺻ ���� (������)
        }
        else if (direction.x < 0) // ���콺�� ĳ������ ���ʿ� ���� ��
        {
            characterSprite.flipX = true; // �¿� ����

        }
    }
}
