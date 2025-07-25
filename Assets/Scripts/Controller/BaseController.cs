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
        direction = 5 * direction;

        _rigidbody.velocity = direction; // rigidbody���� �ӵ� ��ġ ����
    }

    // ĳ���Ͱ� ���� �������� ĳ���� ������
    private void Rotate(Vector2 direction) 
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterSprite.flipX = isLeft;
    }
}
