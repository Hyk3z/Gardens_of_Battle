using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    bool playerOn;
    public Animator anim;
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOn = false;
        }
    }


    private void Update()
    {
        if (!playerOn)
        {
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Go");
            Controller.Instance.rigid.AddForce(transform.up * force);
        }
    }

}
