using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _playerRb;
    private PlayerInput _playerIp;
    private float _xAxis;

    [SerializeField] private int _jumpForce, _moveSpeed;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerIp = GetComponent<PlayerInput>();
    }
    

    public void Jump()
    {
        Debug.Log("jump working");
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);
    }

    public void MoveRight()
    {
        _playerRb.AddForce(new Vector3(_moveSpeed * 100, 0, 0 ),ForceMode.Force);
    }
    
    public void MoveLeft()
    {
        _playerRb.AddForce(new Vector3(-_moveSpeed * 100, 0, 0 ),ForceMode.Force);
    }
}
