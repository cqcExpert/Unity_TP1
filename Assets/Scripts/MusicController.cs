using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MusicController : MonoBehaviour
{
    [SerializeField] public AudioMixer Mixer;
    public static MusicController instance;
    private float currentVolume;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            
        }
        else{
            Destroy(gameObject);

        }
}
    public void Start(){
            currentVolume=PlayerPrefs.GetFloat("savedVolume");
            Mixer.SetFloat("exposedMusicParameter", Mathf.Log10(currentVolume)*20);
    }
}