using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRb;
    private CircleCollider2D _playerFeet;
    private PlayerInput _playerIp;
    private float _xAxis;
    
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private int _jumpForce, _moveSpeed;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerIp = GetComponent<PlayerInput>();
        _playerFeet = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Jump()
    {
        Debug.Log("jump working");
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);
    }

    private void Move()
    {
        if (IsGrounded())
        {
            _playerRb.velocity = new Vector2(_xAxis * _moveSpeed, _playerRb.velocity.y);
        }
    }
    
    public void SetMoveAxis(float axis)
    {
        _xAxis = axis;
        Debug.Log(_xAxis);
    }
    
    public bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, 0.1f, _whatIsGround);
    }
    
    // public void MoveRight()
    // {
    //     _playerRb.AddForce(new Vector3(_moveSpeed * 100, 0, 0 ),ForceMode.Force);
    // }
    //
    // public void MoveLeft()
    // {
    //     _playerRb.AddForce(new Vector3(-_moveSpeed * 100, 0, 0 ),ForceMode.Force);
    // }
}
