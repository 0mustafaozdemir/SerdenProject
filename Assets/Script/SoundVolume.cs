using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume: MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSour;
    private float musicVolume = 1f;

    private void Start()
    {
       // audioSour = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSour.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        vol = slider.value;
        musicVolume = vol;
    }
}
