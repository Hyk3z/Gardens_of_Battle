using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByScenario : MonoBehaviour
{
    //public GameObject drown;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Controller.Instance.chachoalha = true;
            Controller.Instance.life = 0;
            //drown.SetActive(true);
        }
    }
}
