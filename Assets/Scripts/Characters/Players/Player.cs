using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject UIPlayer;
    [SerializeField] private GameObject WindowDeath;

    [SerializeField] private float _forceHitForAudio;

    [Header("Sounds")] 
    [SerializeField] private AudioSource _audioSourceGroundHit;
    [SerializeField] private AudioSource _audioSourceDeath;

    protected virtual void Start()
    {
        Time.timeScale = 1f;
        UIPlayer.SetActive(true);
        WindowDeath.SetActive(false);
    }

    public void Death()
    {
        _audioSourceDeath.Play();
        
        UIPlayer.SetActive(false);
        WindowDeath.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _audioSourceGroundHit.volume = other.relativeVelocity.magnitude / _forceHitForAudio;
        _audioSourceGroundHit.Play();
    }
}
