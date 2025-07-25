using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // === 일단 비워 ===
    Animator _animator = null;
    Rigidbody2D _rigidbody = null;

    // === 점프, 속도 수치 조절===
    [SerializeField] private float flapForce = 6.0f;
    [SerializeField] private float forwardSpeed = 3.0f;

    public bool isDead = false;
    bool _isFlap = false;

    void Start()
    {
        _animator = transform.GetComponentInChildren<Animator>();  // 애니메이터는 자식한테서 가져옴
        _rigidbody = GetComponent<Rigidbody2D>();                    // Rigidbody 2D는 내꺼 씀

        // === 혹시 안될까봐 ===
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
        if (isDead) //게임 오버
        {
            //창을 띄워여함 메인씬으로 이동
        }
        else
        {
            // === 스페이스 바, 마우스 왼쪽으로 점프 호출 ===
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                _isFlap = true;
            }
        }
    }

    // === 이동 로직 ===
    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (_isFlap)                    //점프
        {
            velocity.y += flapForce;
            _isFlap = false;
        }

        _rigidbody.velocity = velocity; //속도 조절

        // === 포물선으로 떨어지도록 만듬 ===
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    // === 충돌시 사망 ===
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (isDead)
            return;

        _animator.SetTrigger("isDie");
        isDead = true;
    }
}
