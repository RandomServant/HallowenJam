using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
        PlayerPrefs.SetFloat("Volume", audioSrc.volume);
    }

    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
    }
}
