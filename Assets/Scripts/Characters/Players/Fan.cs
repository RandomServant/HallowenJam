using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fan : Player
{
    public GameObject Head;

    private Rigidbody2D _rigidbody2D;

    [Header("Settings")]
    [SerializeField] private float _maxDistanceInteraction = 5;
    [SerializeField] private float _pushForce = 5;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        HeadRotate();
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
            PushMove();
    }

    private void HeadRotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(!Head) return;
        
        Vector2 direction = mousePosition - Head.transform.position;
        
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Head.transform.eulerAngles = new Vector3 (0, 0, angle);
    }

    private void PushMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(Head.transform.position, Head.transform.right, 
            _maxDistanceInteraction, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            float distance = hit.distance;
            float force = (_maxDistanceInteraction - distance) * _pushForce;
            
            _rigidbody2D.AddForce(-Head.transform.right * force, ForceMode2D.Impulse);
        }
    }
}
