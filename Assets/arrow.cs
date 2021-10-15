using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class arrow : MonoBehaviour
{
    public float strength;
    Rigidbody rigid;
    bool shooting;
    Vector3 collisionPos;
    int damage = 2;
    public GameObject originalFather;
    //public AudioSource ReleaseSound;
    //public AudioSource HitSound;
    public bool ogreLocked;
    Quaternion startRotation;
    public bool isFromMachine;
    //public AudioSource MechanismSound;
    BoxCollider boxCol;
    public UnityEvent shootEventFromBow;
    public UnityEvent shootEventFromMachine;
    public StudioEventEmitter antHitSound;
    public ParticleSystem antBlood;
    public GameObject Mesh;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider>();
        if (isFromMachine)
        {
            rigid = GetComponent<Rigidbody>();
            Destroy(gameObject, 5);
        }
        startRotation = transform.rotation;
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        boxCol = GetComponent<BoxCollider>();
        transform.rotation = startRotation;
    }

    private void Update()
    {
        
        if (shooting)
        {
            transform.LookAt(transform.transform.position + rigid.velocity);
        }
    }

    public void shoot()
    {
        //MechanismSound.Play();
        Mesh.SetActive(true);
        //ReleaseSound.Play();
        shooting = true;
        transform.parent = null;
        if (isFromMachine)
        {
            shootEventFromMachine.Invoke();
            Destroy(gameObject, 5);
        }
        else
        {
            shootEventFromBow.Invoke();
        }
        if (!rigid)
        {
            rigid = GetComponent<Rigidbody>();
        }
        rigid.isKinematic = false;
        transform.LookAt(Controller.Instance.aimSpot.transform.position);
        rigid.AddForce(transform.forward * strength * 300);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Clutter")
        {
            boxCol.enabled = false;
            rigid.velocity = Vector3.zero;
           
            rigid.isKinematic = true;
            
        }
        else if (collision.gameObject.tag == "Mob")
        {
            rigid.isKinematic = true;
            transform.parent = collision.gameObject.transform;
            boxCol.enabled = false;
            rigid.velocity = Vector3.zero;
            antHitSound.Play();
            Mesh.SetActive(false);
            if (collision.gameObject.GetComponent<Animator>())
            {
                collision.gameObject.GetComponent<Animator>().SetBool("Hit", true);
            }
            
            if (collision.gameObject.GetComponent<KrawScript>())
            {
                var script = collision.gameObject.GetComponent<KrawScript>();
                script.detectou = true;
                script.life = script.life - damage;
                antBlood.Play();
            }
            if (collision.gameObject.GetComponent<OrcScript>())
            {
                var script = collision.gameObject.GetComponent<OrcScript>();
                //script.detectou = true;
                script.DetectNow();
                script.life = script.life - damage;
                script.hurtSFX.Play();
                antBlood.Play();
            }
            if (collision.gameObject.GetComponent<KrawExplosion>())
            {
                Debug.Log("Got Black kraww with arrow");
                var script = collision.gameObject.GetComponent<KrawExplosion>();
                script.ExplodeNow();
                antBlood.Play();
            }
            if (collision.gameObject.GetComponent<OgreScript>())
            {
                var script = collision.gameObject.GetComponent<OgreScript>();
                script.detectou = true;
                script.currentLife = script.currentLife - damage;
                script.damaged.Play();
            }
            if (collision.gameObject.GetComponent<QueenScript>())
            {
                var script = collision.gameObject.GetComponent<QueenScript>();
                script.detectou = true;
                script.life = script.life - damage;
                //collision.gameObject.GetComponent<QueenScript>().damaged.Play();
            }
            if (collision.gameObject.GetComponent<burningHeadScript>())
            {
                var script = collision.gameObject.GetComponent<burningHeadScript>();
                script.life = script.life - damage;
                script.detectou = true;
            }
            if (collision.gameObject.GetComponent<PrincessScript>())
            {
                var script = collision.gameObject.GetComponent<PrincessScript>();
                script.life = script.life - damage;
                script.detectou = true;
            }
            if (collision.gameObject.GetComponent<CreepyBanshee>())
            {
                collision.gameObject.GetComponent<CreepyBanshee>().Die();
            }
            
        }
        else
        {
            boxCol.enabled = false;
            rigid.velocity = Vector3.zero;

            rigid.isKinematic = true;
        }
    }
    public void ResetArrow()
    {
        if (!rigid)
        {
            rigid = GetComponent<Rigidbody>();
        }
        boxCol.enabled = true;
        rigid.isKinematic = true;
        
        transform.parent = originalFather.transform;
        transform.position = ballista.Instance.boltRef.transform.position;
        transform.localRotation = Quaternion.identity;
    }
}
