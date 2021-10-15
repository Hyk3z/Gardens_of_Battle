using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class burningHeadScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool detectou;
    public float life = 7;
    bool dead = false;
    public GameObject fire;
    float biteTimer;
    public GameObject deathSound;
    public GameObject biteSound;
    bool deathLock;
    public AudioSource painSFX;
    float previousLife;
    AudioSource speech;
    float DeathCounter;
    public Rigidbody rig;
    bool flying;
    bool deadLock;
    bool deadPooled;
    public bool fromNightmare;
    public bool fromNormal;
    public bool fromHard;
    public ParticleSystem attackParticle;
    

    public bool waitForManualDetection;
    public void Detect()
    {
        detectou = true;
        
    }

    public void TurnToFlightMode()
    {
        if (dead)
        {
            return;
        }
        detectou = true;
        flying = true;
        rig.isKinematic = false;
        agent.enabled = false;
        rig.useGravity = false;
    }
    private void Start()
    {
        speech = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        previousLife = life;

        if (GameManager.Instance && GameManager.Instance.nightmare)
        {
            if (!GameManager.Instance.nightmare)
            {
                gameObject.SetActive(false);
                return;
            }
            detectou = true;
        }
        if (fromHard)
        {
            if (GameManager.Instance && GameManager.Instance && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
            {
                gameObject.SetActive(false);
                return;
            }
        }
        if (fromNormal)
        {
            if (GameManager.Instance && !GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
            {
                gameObject.SetActive(false);
                return;
            }
        }

    }

    private void Update()
    {
        if (deadLock)
        {
            return;
        }
        if (dead && !deadLock)
        {
            fire.SetActive(false);
            if (agent.isOnNavMesh)
            {
                agent.isStopped = true;
                agent.speed = 0;
                agent.enabled = false;
            }
            
            GetComponent<Rigidbody>().isKinematic = false;
            DeathCounter += Time.deltaTime;
            if (DeathCounter >= 2)
            {
                deadLock = true;
                gameObject.SetActive(false);
            }
            return;
            //Destroy(gameObject);
        }
        
        if (detectou)
        {
            if(life < previousLife && painSFX.isPlaying == false)
            {
                painSFX.Play();
                previousLife = life;
                speech.Stop();
            }
            
            if (biteTimer >= 0)
            {
                biteTimer -= Time.deltaTime;
            }
            if (speech.isPlaying == false && painSFX.isPlaying == false)
            {
                speech.Play();
            }
            transform.LookAt(Controller.Instance.transform.position);
            if (!flying)
            {
                
                agent.destination = Controller.Instance.transform.position;
            }
            else
            {
                //transform.LookAt(transform.position + rig.velocity);
                
                    rig.AddForce(transform.forward * 20);
                
                
            }
        }
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 5 && !waitForManualDetection)
        {
            detectou = true;
        }
        if (life < 1 && !deathLock)
        {
            if (!deadPooled)
            {
                deadPooled = true;
                if (GameManager.Instance)
                {
                    GameManager.Instance.killedMonsters++;
                }
                
            }
            deathLock = true;
            deathSound.SetActive(true);
            GetComponent<AudioSource>().Stop();
            dead = true;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Griffin")) && biteTimer < 0 && !dead)
        {
            
            Controller.Instance.life--;
            Controller.Instance.chachoalha = true;
            biteTimer = 2;
            transform.Rotate(0, 180, 0);
            biteSound.SetActive(true);
            attackParticle.Play();
        }
    }

}
