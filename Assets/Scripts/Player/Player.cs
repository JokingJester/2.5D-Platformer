using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _pressedJumpButton;
    private Vector3 _moveDirection;

    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Movement(Vector3 direction)
    {
        if(_controller.isGrounded == true)
        {
            _moveDirection = direction;
            _moveDirection *= _speed;
            if (_pressedJumpButton == true)
            {
                _moveDirection.y = _jumpHeight;
                _pressedJumpButton = false;
            }
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    public void Jump()
    {
        _pressedJumpButton = true;
    }
}
