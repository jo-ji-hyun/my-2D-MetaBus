using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator _animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;

    public bool isDead = false;
    bool _isFlap = false;

    void Start()
    {
        _animator = transform.GetComponentInChildren<Animator>();  // �ִϸ����ʹ� �ڽ����׼� ������
        _rigidbody = GetComponent<Rigidbody2D>();                    // Rigidbody 2D�� ���� ��

        // === Ȥ�� �ȵɱ�� ===
        if (_animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead)
        {
            //â�� �������
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // �����̽� ��, ���콺 �������� ���� 
            {
                _isFlap = true;
            }
        }
    }

    // === �̵� ���� ===
    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (_isFlap)
        {
            velocity.y += flapForce;
            _isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    // === �浹�� ��� ===
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (isDead)
            return;

        _animator.SetTrigger("isDie");
        isDead = true;
    }
}
