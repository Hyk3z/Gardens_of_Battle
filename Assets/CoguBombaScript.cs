using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoguBombaScript : MonoBehaviour
{
    float explosionTime;
    float explosionCountDown = 3;
    float mushroomDeath = 4f;
    Rigidbody rigid;
    public GameObject particles;
    public List<GameObject> victims;
    public GameObject[] spheres;
    public ParticleSystem turboFire;
    public SphereCollider col;
    bool Count;
    public float TimerForDamage;
    public GameObject[] DeactivateWhenXploded;
    
    //GOTTA PULL THIS THING

    void Start()
    {
        
        rigid = GetComponent<Rigidbody>();
        ThrowMushroom();
    }

    public void ThrowMushroom()
    {
        transform.LookAt(Controller.Instance.aimSpot.transform.position);
        transform.parent = null;
        rigid.AddForce(transform.forward * 550);
    }

    void Update()
    {
        if (Count)
        {
            TimerForDamage += Time.deltaTime;
            if (TimerForDamage >= 0.25f)
            {
                col.enabled = false;
            }
        }
        if (Input.GetMouseButtonDown(1) && explosionTime < explosionCountDown)
        {
            explosionTime = explosionCountDown;
        }
        explosionTime += Time.deltaTime;
        if (explosionTime >= 0.4f)
        {
            rigid.constraints = RigidbodyConstraints.None;
        }
        if (explosionTime >= explosionCountDown)
        {
            
            particles.SetActive(true);
            rigid.isKinematic = true;
            
            col.enabled = true;
            foreach (var item in spheres)
            {
                item.SetActive(false);
            }
            foreach (var item in DeactivateWhenXploded)
            {
                item.SetActive(false);
            }
            Count = true;
        }
        
        if (explosionTime >= mushroomDeath)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !victims.Contains(other.gameObject))
        {
            victims.Add(other.gameObject);
        }

        if (other.CompareTag("Mob") && !victims.Contains(other.gameObject))
        {
            foreach (var item in spheres)
            {
                item.SetActive(false);
            }
            foreach (var item in DeactivateWhenXploded)
            {
                item.SetActive(false);
            }
            if (other.GetComponent<KrawScript>())
            {
                var script = other.GetComponent<KrawScript>();
                script.life -= 2;
                script.anim.SetBool("Hit", true);
                victims.Add(other.gameObject);
            }
            if (other.GetComponent<OgreScript>())
            {
                var script = other.GetComponent<OgreScript>();
                script.currentLife -= 2;
                victims.Add(other.gameObject);
                script.damaged.Play();
            }

            if (other.gameObject.GetComponent<burningHeadScript>())
            {
                var script = other.gameObject.GetComponent<burningHeadScript>();
                //victims.Add(other.gameObject);
                victims.Add(other.gameObject);
                script.life = other.gameObject.GetComponent<burningHeadScript>().life - 2;
                script.Detect();
            }
            if (other.GetComponent<QueenScript>())
            {
                var script = other.GetComponent<QueenScript>();
                script.life -= 5;
                script.anim.SetBool("Hit", true);
                victims.Add(other.gameObject);
            }
            if (other.GetComponent<PrincessScript>())
            {
                other.GetComponent<PrincessScript>().life -= 2;
                victims.Add(other.gameObject);
            }

            if (other.GetComponent<CreepyBanshee>())
            {
                other.GetComponent<CreepyBanshee>().Die();
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mob") || collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Clutter") || collision.gameObject.CompareTag("Fence") || collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("LiveTree") || collision.gameObject.CompareTag("DeadTree"))
        {
            explosionTime = explosionCountDown;
        }
    }

}
