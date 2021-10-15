using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceDeathScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<ParticleSystem>().Stop();
            GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 3);
        }
    }
}
