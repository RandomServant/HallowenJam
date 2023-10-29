using System;
using UnityEngine;
using UnityEngine.Events;

public class DestructiblePlatform : MonoBehaviour
{
    [SerializeField] private float _destructibleForce = 1;
    [SerializeField] private ParticleSystem _destroyEffect;

    public UnityEvent DestroyPlatformEvent;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > -_destructibleForce)
        {
            DestroyPlatformEvent.Invoke();
        }
    }

    private void Start()
    {
        DestroyPlatformEvent.AddListener(SpawnEffect);
    }
    
    private void SpawnEffect() => Instantiate(_destroyEffect, transform.position, Quaternion.identity);
}
