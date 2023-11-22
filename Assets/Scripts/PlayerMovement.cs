using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    public float MoveSpeed = 0.1f;
    private Vector2 _moveDirection;
    private CharacterController _controller;

    [SerializeField] private List<Vector2> _spawnPositions;
    
    public void Movement(InputAction.CallbackContext context)
    {
        if (!IsOwner) return;
        
        MovementServerRpc(context.ReadValue<Vector2>().y);
    }

    public override void OnNetworkSpawn()
    {
        transform.position = _spawnPositions[(int)OwnerClientId];
    }

    private void Update()
    {
        _controller.Move(_moveDirection * MoveSpeed);
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    [ServerRpc(RequireOwnership = false)]
    private void MovementServerRpc(float yDirection)
    {
        _moveDirection = new Vector2(0, yDirection);
    }
}
