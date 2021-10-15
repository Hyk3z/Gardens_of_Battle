using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstedModifier : MonoBehaviour
{
    public bool ground;
    public void OnTriggerStay(Collider other)
    {
        if (ground && other.CompareTag("Player"))
        {
            Controller.Instance.onGround = true;
            Controller.Instance.onGrass = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (ground && other.CompareTag("Player"))
        {
            Controller.Instance.onGround = false;
            Controller.Instance.onGrass = true;
        }
    }

}
