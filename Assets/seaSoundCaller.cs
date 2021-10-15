using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class seaSoundCaller : MonoBehaviour
{
    public StudioEventEmitter seaEmitter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            seaEmitter.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            seaEmitter.Stop();
        }
    }
}
