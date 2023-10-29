using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DuctTape : Player
{
    public LineRenderer LineRenderer;
    public Rigidbody2D RopePoint;
    
    private Rigidbody2D _rigidbody2D;
    private DistanceJoint2D _distanceJoint2D;
    private SpriteRenderer _targetSpriteRenderer;
    private SpriteRenderer _spriteRenderer;
        
    [Header("Settings")]
    [SerializeField] private float _maxDistanceInteraction = 15;
    [SerializeField] private float _horizontalSpeedAir = 1;
    [SerializeField] private float _horizontalSpeedGround = 1;
    [SerializeField] private float _verticalSpeed = 1;

    [SerializeField] private Color _targetCanFire;
    private Color _canNotFire = new Color(0,0,0,0);

    [SerializeField] private Sprite[] _sprites;

    [Header("Sounds")] 
    [SerializeField] private AudioSource _audioActivate; 
    [SerializeField] private AudioSource _audioDeactivate;

    private bool _isGlued = false;
    
    protected override void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _distanceJoint2D = GetComponent<DistanceJoint2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targetSpriteRenderer = RopePoint.GetComponent<SpriteRenderer>();

        _distanceJoint2D.enabled = false;
        LineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!_isGlued) Fire();
            else Drop();
        }
        
        MoveRight(Input.GetAxis("Horizontal"));

        if (_isGlued)
        {
            MoveUp(Input.GetAxis("Vertical"));
            int id = (int)Mathf.Ceil(3 * _distanceJoint2D.distance / _maxDistanceInteraction) - 1;
            _spriteRenderer.sprite = 
                _sprites[id >= 0 ? id : 0];
        }
        else
        {
            _spriteRenderer.sprite = _sprites[0];
            
            Vector3 bindingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                bindingPosition - transform.position, _maxDistanceInteraction, 
                LayerMask.GetMask("Ground"));

            if (hit.collider)
            {
                RopePoint.transform.position = hit.point;
                _targetSpriteRenderer.color = _targetCanFire;
            }
            else
                _targetSpriteRenderer.color = _canNotFire;
        }
        
        LineRenderer.SetPosition(0, transform.position);
        LineRenderer.SetPosition(1, RopePoint.position);
    }
    
    private void Fire()
    {
        Vector3 bindingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, 
            bindingPosition - transform.position, _maxDistanceInteraction, 
            LayerMask.GetMask("Ground"));

        if (hit.collider)
        {
            _audioActivate.Play();
            
            _isGlued = true;

            RopePoint.transform.position = hit.point;
            _distanceJoint2D.connectedBody = RopePoint;
            _distanceJoint2D.distance = Vector2.Distance(RopePoint.position, transform.position);
            _distanceJoint2D.enabled = true;
            
            LineRenderer.enabled = true;
        }
    }

    private void Drop()
    {
        _audioDeactivate.Play();
        LineRenderer.enabled = false;
        _distanceJoint2D.enabled = false;
        _distanceJoint2D.distance = 0;
        _isGlued = false;
    }

    private void MoveRight(float direction)
    {
        float horizontalSpeed = _isGlued ? _horizontalSpeedAir : _horizontalSpeedGround;
        
        _rigidbody2D.AddForce(new Vector2(direction * horizontalSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
    }
    
    private void MoveUp(float direction)
    {
        if (_distanceJoint2D.distance >= _maxDistanceInteraction)
            _distanceJoint2D.distance = _maxDistanceInteraction;
        else
            _distanceJoint2D.distance -= direction * _verticalSpeed * Time.deltaTime;
    }
}
