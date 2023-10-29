using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private bool _isMoveToFirst = true;

    [SerializeField] private Transform _pointFirst;
    [SerializeField] private Transform _pointSecond;

    private Player player;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Math.Abs(transform.position.x - _pointFirst.transform.position.x) < 0.001f)
            _isMoveToFirst = false;
        else if (Math.Abs(transform.position.x - _pointSecond.transform.position.x) < 0.001f)
            _isMoveToFirst = true;
        
        transform.position = Vector2.MoveTowards(
            transform.position, 
            (_isMoveToFirst ? _pointFirst.position : _pointSecond.position), 
            _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<Player>();
        if(player)
            player.transform.SetParent(transform);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().transform.SetParent(null);
            player = null;
        }
    }
}
