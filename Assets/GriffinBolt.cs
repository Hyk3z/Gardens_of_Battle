using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GriffinBolt : MonoBehaviour
{
    public Rigidbody rig;
    public int damage;
    //StudioEventEmitter blast;
    private void Start()
    {
        Shoot();
        Destroy(gameObject, 4);
    }
    void Shoot()
    {
        rig.AddForce(transform.forward * 1250);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Animator>())
        {
            other.GetComponent<Animator>().SetBool("Hit", true);
            
        }

        if (other.gameObject.GetComponent<KrawScript>())
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<KrawScript>().life = other.gameObject.GetComponent<KrawScript>().life - damage;
            
        }
        if (other.gameObject.GetComponent<OgreScript>())
        {
            other.gameObject.GetComponent<OgreScript>().currentLife = other.gameObject.GetComponent<OgreScript>().currentLife - damage;

            other.gameObject.GetComponent<OgreScript>().damaged.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<QueenScript>())
        {
            other.gameObject.GetComponent<QueenScript>().detectou = true;
            other.gameObject.GetComponent<QueenScript>().life = other.gameObject.GetComponent<QueenScript>().life - damage;
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<burningHeadScript>())
        {
            other.gameObject.GetComponent<burningHeadScript>().life = other.gameObject.GetComponent<burningHeadScript>().life - damage;
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<PrincessScript>())
        {
            other.gameObject.GetComponent<PrincessScript>().life = other.gameObject.GetComponent<PrincessScript>().life - damage;
            Destroy(gameObject);
        }

        
    }

    

}
