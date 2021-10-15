using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ogreDetectionScript : MonoBehaviour
{
    
    public arrow[] arrows;
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OgreScript>())
        {
            //arrows[0].ogreLocked = true;
            //arrows[1].ogreLocked = true;
            //arrows[2].ogreLocked = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<OgreScript>())
        {
            //arrows[0].ogreLocked = false;
            //arrows[1].ogreLocked = false;
            //arrows[2].ogreLocked = false;
        }
    }
    private void OnDisable()
    {
        //arrows[0].ogreLocked = false;
        //arrows[1].ogreLocked = false;
        //arrows[2].ogreLocked = false;
    }
}
