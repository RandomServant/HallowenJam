using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Toy : Player
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    [Header("Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private float _maxClickTime;
    [SerializeField] private float _speedUpdateClickTime;
    [SerializeField] private float _jumpForce;
    
    private float _currentClickTime;
    private float _direction = 1;

    protected override void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            UpdateClickTime();
            Rotate(Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            Move();

            if (Input.GetButtonDown("Jump")) 
                Jump();
        }
    }

    private void UpdateClickTime()
    {
        _currentClickTime += _speedUpdateClickTime * Time.deltaTime;
        
        if (_currentClickTime >= _maxClickTime)
            _currentClickTime = _maxClickTime;
    }

    private void Move()
    {
        _animator.SetBool("Run", true);
        
        _currentClickTime -= _speedUpdateClickTime * Time.deltaTime;

        if (_currentClickTime <= 0)
        {
            _currentClickTime = 0;
            _animator.SetBool("Run", false);
            return;
        }
        
        _rigidbody2D.AddForce(_speed * _direction * transform.right, ForceMode2D.Force);
    }

    private void Rotate(float direction)
    {
        if (direction != 0)
            _direction = direction;
        else 
            return;
        
        var scale = transform.localScale;

        transform.localScale = new Vector3(Mathf.Abs(scale.x) * _direction, scale.y, scale.z);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(_jumpForce * _currentClickTime * transform.up, ForceMode2D.Impulse);
        _currentClickTime = 0;
    }
}
