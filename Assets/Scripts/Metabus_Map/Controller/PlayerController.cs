using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera _camera; // 카메라

    protected override void Start()
    {
       base.Awake();          // Awake부터 불러옴
       _camera = Camera.main;  // 카메라 = 메인카메라
    }

    protected override void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 좌우
        float vertical = Input.GetAxisRaw("Vertical");       // 상하

        _move = new Vector2(horizontal, vertical).normalized; // 대각선

        // === 마우스 찾기 ===
        Vector2 _mouselook = Input.mousePosition;          
        Vector2 _worldmouse = _camera.ScreenToWorldPoint(_mouselook);
        _look = (_worldmouse - (Vector2)transform.position).normalized;

        Rotate(_look);
    }


}
