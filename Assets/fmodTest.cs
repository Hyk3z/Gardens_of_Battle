using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class fmodTest : MonoBehaviour
{
    StudioEventEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //emitter.Play();
        }
    }
}
