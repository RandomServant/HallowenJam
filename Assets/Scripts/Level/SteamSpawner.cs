using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private float _startEverySecond = 1;

    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        StartCoroutine(StartSteam());
    }

    private IEnumerator StartSteam()
    {
        while (true)
        {
            yield return new WaitForSeconds(_startEverySecond);
            _particleSystem.Play();
            _audioSource.Play();
        }
    }
}
