using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SandDeath : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [SerializeField] private GameObject player;


    private bool isActive = false;
    private bool isActiveSand = false;

    // Update is called once per frame
    void Update()
    {
       MoveinSand();
    }

    //OnTriggerEnter2D(Collider2D other)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
           isActive = true;
           Debug.Log("activate");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            isActive = false;
            Debug.Log("Not");
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
            Debug.Log("death");
            player.GetComponent<Player>().Death();
        }

        if (isActiveSand)
        {
            Debug.Log("move");
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, speed * Time.deltaTime);
        }
    }
}
