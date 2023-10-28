using UnityEngine;
using UnityEngine.Events;

public class DestructiblePlatform : MonoBehaviour
{
    [SerializeField] private float _destructibleForce = 1;

    public UnityEvent DestroyPlatformEvent;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > -_destructibleForce)
        {
            DestroyPlatformEvent.Invoke();
        }
    }
}
