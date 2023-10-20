using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 0.1f;
    private Vector2 _moveDirection;
    private CharacterController _controller;
    
    public void Movement(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        Debug.Log(_moveDirection);
    }

    private void Update()
    {
        _controller.Move(_moveDirection * MoveSpeed);
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
}
