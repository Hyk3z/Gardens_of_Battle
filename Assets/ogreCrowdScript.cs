using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class ogreCrowdScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OgreScript>())
        {
            
            other.GetComponent<OgreScript>().detectou = true;
        }
    }
}
