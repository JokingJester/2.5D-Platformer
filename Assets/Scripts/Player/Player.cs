using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _pressedJumpButton;
    private Vector3 _moveDirection;

    [SerializeField] private Animator _anim;
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
            _anim.SetBool("Jump", false);
            _moveDirection = direction;
            _anim.SetFloat("Speed", Mathf.Abs(_moveDirection.z));
            _moveDirection *= _speed;
            var rotation = transform.rotation;
            if (_moveDirection.z != 0)
                rotation.y = _moveDirection.z < 0 ? 180 : 0;
            transform.rotation = rotation;

            if (_pressedJumpButton == true)
            {
                _anim.SetBool("Jump", false);
                _anim.SetBool("Jump", true);
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

    public void GrabLedge(Vector3 handPos)
    {
        _controller.enabled = false;
        _anim.SetBool("GrabLedge", true);
        _anim.SetFloat("Speed", 0);
        transform.position = handPos;
    }
}
