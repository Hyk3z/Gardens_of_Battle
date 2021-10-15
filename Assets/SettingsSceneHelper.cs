using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSceneHelper : MonoBehaviour
{
    public FMOD.Studio.Bus MusicBus;
    public FMOD.Studio.Bus MasterBus;
    public FMOD.Studio.Bus SFXBus;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Slider MasterSlider;
    public PlayerRotationScript scripto;
    
    void Start()
    {
        MusicBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");

        SFXBus.setVolume(PlayerPrefs.GetFloat("SFXVolume", 0.75f) * 1.3f);
        MusicBus.setVolume(PlayerPrefs.GetFloat("MusicVolume", 0.75f) * 1.3f);
        MasterBus.setVolume(PlayerPrefs.GetFloat("MasterVolume", 0.75f) * 1.3f);

        if (scripto)
        {
            scripto.ChangeSensivity(PlayerPrefs.GetFloat("MouseSensivity", 0.75f));
        }
        
    }

}
