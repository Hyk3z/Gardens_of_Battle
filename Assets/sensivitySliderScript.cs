using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sensivitySliderScript : MonoBehaviour
{
    public Slider slider;
    public PlayerRotationScript scripto;

    private void OnEnable()
    {
        slider.value = PlayerPrefs.GetFloat("MouseSensivity", 0.75f); //isso ainda eh soh pro slider visivel. Fazer no scene helper a aplicacao
    }

    public void ChangeSensivity()
    {
        if (slider.value > 0.1f)
        {
            
            scripto.ChangeSensivity(slider.value);
            PlayerPrefs.SetFloat("MouseSensivity", slider.value);
        }
        
    }
}
