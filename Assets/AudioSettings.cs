using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public FMOD.Studio.Bus MusicBus;
    public FMOD.Studio.Bus SFXBus;
    public FMOD.Studio.Bus MasterBus;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Slider MasterSlider;

    // Start is called before the first frame update
    void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        MusicBus = FMODUnity.RuntimeManager.GetBus ("bus:/Master/Music");
        SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
    }

    public void ChangeSFXVolume()
    {
        
        SFXBus.setVolume(SFXSlider.value*1.3f);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
    public void ChangeMusicVolume()
    {
        
        MusicBus.setVolume(MusicSlider.value * 1.3f);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
    }
    public void ChangeMasterVolume()
    {

        MasterBus.setVolume(MasterSlider.value * 1.3f);
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
    }
}
