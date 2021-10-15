using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcKrawwd : MonoBehaviour
{
    private void Start()
    {
        //Destroy(gameObject, 0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<OrcScript>())
        {
            other.GetComponent<OrcScript>().DetectNow();
        }
    }
}
