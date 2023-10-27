using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DuctTape : MonoBehaviour
{
    public Transform FirePoint;
    
    private Rigidbody2D _rigidbody2D;
        
    [Header("Settings")]
    [SerializeField] private float _maxDistanceInteraction = 15;

    private bool _isGlued = false;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!_isGlued) Fire();
            else Drop();
            Debug.Log(_isGlued);
        }
    }
    
    private void Fire()
    {
        Vector3 bindingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, 
            bindingPosition - FirePoint.position, _maxDistanceInteraction, 
            LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            _isGlued = true;
        }
    }

    private void Drop()
    {
        
        
        _isGlued = false;
    }
}
