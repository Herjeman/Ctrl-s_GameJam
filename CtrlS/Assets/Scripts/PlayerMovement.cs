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
        if (IsGrounded())
        {
            Debug.Log("jump working");
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce); 
        }
    }

    private void Move()
    {
        _playerRb.velocity = new Vector2(_xAxis * _moveSpeed, _playerRb.velocity.y);
    }
    
    public void SetMoveAxis(float axis)
    {
        _xAxis = axis;
        Debug.Log(_xAxis);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
            other.gameObject.GetComponent<Gate>().Cycle();
        }
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, 0.1f, _whatIsGround);
    }
}
