using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class IceScript : MonoBehaviour
{
    public StudioEventEmitter sound;
    //public BoxCollider trigger;
    public float loopDelay;
    float delayTimer;
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            if (other.GetComponent<KrawScript>())
            {
                var script = other.GetComponent<KrawScript>();
                if (script.agent.speed > 0)
                {
                    script.agent.speed -= Time.deltaTime*2;
                    script.life -= Time.deltaTime;
                }
                
            }
            if (other.GetComponent<burningHeadScript>())
            {
                burningHeadScript otherscript = other.GetComponent<burningHeadScript>();
                otherscript.agent.speed -= Time.deltaTime * 2;
                if (otherscript.agent.speed <= 0)
                {
                    otherscript.life = 0;
                }
            }
            
        }
    }

    

    private void OnEnable()
    {
        //sound.Play();
    }

    private void Update()
    {
        /*
        if (sound.isPlaying())
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= loopDelay)
            {
                sounds[0].Play();
            }
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            delayTimer = 0;
            sounds[0].Stop();
        }
        if (!staffScript.Instance.iceMode)
        {
            sounds[0].Stop();
        }
        */
    }
    private void OnDisable()
    {
        //sound.Stop();
    }
}
