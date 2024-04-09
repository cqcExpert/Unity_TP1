using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] public AudioMixer Mixer;
    [SerializeField] public Slider musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("savedVolume"))
        {
            LoadSlider();
        }
        else
        {
            SetMusicVolume();
        }
    }


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        Mixer.SetFloat("exposedMusicParameter", Mathf.Log10(volume)*20);
        



        //Stores volume value
        PlayerPrefs.SetFloat("savedVolume",volume);



    }
        public void LoadSlider()
    {
        musicSlider.value=PlayerPrefs.GetFloat("savedVolume");

        SetMusicVolume();
    }
}


