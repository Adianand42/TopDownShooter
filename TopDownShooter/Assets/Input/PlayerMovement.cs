using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 5f;

    //Movement
    private Vector2 _movement;
    private Rigidbody2D _rb;

    //Animation Componenets
    private Animator _animator;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";

    //Idle positions
    private const string _lasthorizontal = "LastHorizontal";
    private const string _lastvertical = "LastVertical";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update() {
        //Movement
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        _rb.linearVelocity = _movement * _moveSpeed;

        //Animation Components
        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);

        //Idle Poitions
        if (_movement != Vector2.zero) {
            _animator.SetFloat(_lasthorizontal, _movement.x);
            _animator.SetFloat(_lastvertical, _movement.y);
        }
    }
}
