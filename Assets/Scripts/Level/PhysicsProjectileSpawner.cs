using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnEverySecond;

    [SerializeField] private GameObject _projectile;
    
    void Start()
    {
        StartCoroutine(SpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnEverySecond);
            Instantiate(_projectile, transform.position, Quaternion.identity);
        }
    }
}
