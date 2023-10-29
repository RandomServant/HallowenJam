using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SandDeath : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private GameObject player;

    private bool isActive = false;
    private bool isActiveSand = false;

    void Update()
    {
       MoveinSand();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            isActive = true;
            player = collision.gameObject;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            isActive = false;
        }
    }

    void MoveinSand()
    {
        if ( (transform.position.y != player.transform.position.y  || transform.position.x != player.transform.position.x) && isActive == true )
        {
            isActiveSand = true;
        }
        if ( (transform.position.y == player.transform.position.y || transform.position.x == player.transform.position.x) && isActive == true)
        {
            isActiveSand = false;
            player.GetComponent<Player>().Death();
        }
        if (!isActive)
        {
            isActiveSand = false;
        }
        if (isActiveSand)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, speed * Time.deltaTime);
        }
    }
}
