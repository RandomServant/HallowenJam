using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destoryEffect; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            player.Death();
        }

        Instantiate(_destoryEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
