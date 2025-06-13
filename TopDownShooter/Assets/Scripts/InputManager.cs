using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static Vector2 Movement;

        private PlayerInput _playerInput;
        private InputAction _moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake() {
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
    }

    // Update is called once per frame
    public void Update() {
        Movement = _moveAction.ReadValue<Vector2>();
    }
}
