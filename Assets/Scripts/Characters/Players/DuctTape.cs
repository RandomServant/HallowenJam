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
        
    [Header("Settings")]
    [SerializeField] private float _maxDistanceInteraction = 15;
    [SerializeField] private float _horizontalSpeed = 1;
    [SerializeField] private float _verticalSpeed = 1;

    private bool _isGlued = false;
    
    protected override void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _distanceJoint2D = GetComponent<DistanceJoint2D>();

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

        if (_isGlued)
        {
            MoveRight(Input.GetAxis("Horizontal"));
            MoveUp(Input.GetAxis("Vertical"));
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

        if (hit.collider != null)
        {
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
        LineRenderer.enabled = false;
        _distanceJoint2D.enabled = false;
        _isGlued = false;
    }

    private void MoveRight(float direction)
    {
        _rigidbody2D.AddForce(new Vector2(direction * _horizontalSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
    }
    
    private void MoveUp(float direction)
    {
        if (_distanceJoint2D.distance >= _maxDistanceInteraction)
            _distanceJoint2D.distance = _maxDistanceInteraction;
        else
            _distanceJoint2D.distance -= direction * _verticalSpeed * Time.deltaTime;
    }
}
