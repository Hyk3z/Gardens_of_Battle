using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinPolen : MonoBehaviour
{
    public Rigidbody rig;
    GameObject target;
    public int damage;
    public ParticleSystem explosionParticle;
    public GameObject xPlosion;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            target = other.gameObject;
            Destroy(GetComponent<SphereCollider>());
        }
    }

    private void Start()
    {
        Destroy(gameObject, 6);
    }

    private void Update()
    {
         if (target)
        {
            transform.LookAt(target.transform.position);
            
            
        }
        rig.AddForce(transform.forward * 30);
        if(target == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 5)
        {
            explosionParticle.gameObject.SetActive(true);
            explosionParticle.transform.parent = null;
            xPlosion.transform.parent = null;
            xPlosion.SetActive(true);
            gameObject.SetActive(false);
            /*
            if (target.GetComponent<Animator>())
            {
                target.GetComponent<Animator>().SetBool("Hit", true);

            }

            
            if (target.gameObject.GetComponent<KrawScript>())
            {
                Destroy(gameObject);
                target.gameObject.GetComponent<KrawScript>().life = target.gameObject.GetComponent<KrawScript>().life - damage;

            }
            if (target.gameObject.GetComponent<OgreScript>())
            {
                target.gameObject.GetComponent<OgreScript>().currentLife = target.gameObject.GetComponent<OgreScript>().currentLife - damage;

                target.gameObject.GetComponent<OgreScript>().damaged.Play();
                Destroy(gameObject);
            }
            if (target.gameObject.GetComponent<QueenScript>())
            {
                target.gameObject.GetComponent<QueenScript>().detectou = true;
                target.gameObject.GetComponent<QueenScript>().life = target.gameObject.GetComponent<QueenScript>().life - damage;
                Destroy(gameObject);
            }
            if (target.gameObject.GetComponent<burningHeadScript>())
            {
                target.gameObject.GetComponent<burningHeadScript>().life = target.gameObject.GetComponent<burningHeadScript>().life - damage;
                Destroy(gameObject);
            }
            if (target.gameObject.GetComponent<PrincessScript>())
            {
                target.gameObject.GetComponent<PrincessScript>().life = target.gameObject.GetComponent<PrincessScript>().life - damage;
                Destroy(gameObject);
            }
            */
        }
    }

}
