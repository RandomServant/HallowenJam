using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fan : Player
{
    [SerializeField] private GameObject Head;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRendererHead;
    private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [SerializeField] private float _maxDistanceInteraction = 5;
    [SerializeField] private float[] _pushForceforEveryLVL = new float[]{ 1, 2, 3 };

    private int _currentLVL = 0;

    protected override void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRendererHead = Head.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        HeadRotate();
        
        if(Input.GetKey(KeyCode.Mouse0))
            PushMove();
        else
            _animator.SetFloat("Blend", 0);

        if (Input.GetButtonDown("1"))
            _currentLVL = 0;
        if (Input.GetButtonDown("2"))
            _currentLVL = 1;
        if (Input.GetButtonDown("3"))
            _currentLVL = 2;
    }

    private void HeadRotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x >= transform.position.x + 0.1f)
        {
            _spriteRenderer.flipX = false;
            _spriteRendererHead.flipX = false;
        }
        else if (mousePosition.x <= transform.position.x - 0.1f)
        {
            _spriteRendererHead.flipX = true;
            _spriteRenderer.flipX = true;
        }

        if(!Head) return;
        
        Vector2 direction = mousePosition - Head.transform.position;
        
        float angle = Vector2.SignedAngle(Vector2.right * (_spriteRenderer.flipX ? -1 : 1), direction);
        Head.transform.eulerAngles = new Vector3 (0, 0, angle);
    }

    private void PushMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(Head.transform.position, Head.transform.right * 
            (_spriteRenderer.flipX ? -1 : 1), _maxDistanceInteraction, LayerMask.GetMask("Ground"));
        
        _animator.SetFloat("Blend", ((float)_currentLVL + 1) / 3);

        if (hit.collider != null)
        {
            float distance = hit.distance;
            float force = (_maxDistanceInteraction - distance) * _pushForceforEveryLVL[_currentLVL];
            
            _rigidbody2D.AddForce(-Head.transform.right * (_spriteRenderer.flipX ? -1 : 1) * force, 
                ForceMode2D.Impulse);
        }
    }
}
