using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destoryEffect;
    [SerializeField] private AudioSource _destroyAudio;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player)
        {
            player.Death();
        }

        Instantiate(_destoryEffect, transform.position, Quaternion.identity);
        _destroyAudio.Play();
        StartCoroutine(Destr());
    }

    private IEnumerator Destr()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
