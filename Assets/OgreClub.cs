using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreClub : MonoBehaviour
{
    public bool canDoDamage = true;
    //CAMINHAO DE RIPA NO PLAYER
    float cooldown = 1;
    bool used = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!canDoDamage || used)
            {
                return;
            }
            GetComponent<AudioSource>().Play();
            Controller.Instance.chachoalha = true;
            Controller.Instance.life--;
            //Controller.Instance.GetComponent<Rigidbody>().AddForce(transform.up * 600);
            Controller.Instance.GetComponent<Rigidbody>().AddForce(transform.forward * -600);
            used = true;
            cooldown = 0;
        }
    }
    private void Update()
    {
        if (used)
        {
            cooldown += Time.deltaTime;
            if (cooldown >= 1)
            {
                used = false;
            }
        }
        
    }

}
