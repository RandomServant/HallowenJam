using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    private AudioSource audioSrc;
    [SerializeField] private Slider slider;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
        if (slider != null)
        {
            slider.value = audioSrc.volume;
        }

    }

    void Update()
    {
        audioSrc.volume = PlayerPrefs.GetFloat("Volume");
        //slider.value = audioSrc.volume;
    }

    public void SetVolume(float vol)
    {
        PlayerPrefs.SetFloat("Volume", vol);
    }
}
