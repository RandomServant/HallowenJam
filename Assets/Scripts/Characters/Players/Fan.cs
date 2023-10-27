using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fan : MonoBehaviour
{
    public GameObject Head;

    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    private void HeadRotate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(!Head) return;
        
        Vector2 direction = mousePosition - Head.transform.position;
        
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Head.transform.eulerAngles = new Vector3 (0, 0, angle);
    }
}
