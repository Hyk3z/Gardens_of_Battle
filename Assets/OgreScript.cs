using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class OgreScript : MonoBehaviour
{
    public float currentLife;
    public int maxLife = 5;
    public bool detectou = false;
    NavMeshAgent agent;
    public Animator anim;
    public Transform[] spots;
    int currentSpotToFollow;
    float idleTimeBetweenSpots = 3;
    bool allowedToMove = true;
    float initialSpeed;
    public bool burning;
    public float burnTimer;
    float deathTime = 5;
    public OgreClub damageClub;
    bool playedAware = false;
    public AudioSource attackSFX;
    public AudioSource footSFX;
    public AudioSource speech;
    float speechTimer;
    public AudioSource damaged;
    public AudioSource death;
    public ParticleSystem myBurn;
    public UnityEvent OnDeathEvents;
    bool dead;
    public bool isFemale;
    public OgreScript[] gados;
    public bool gadando;
    public GameObject fireBall;
    public float fireballCooldown;
    public OgreScript[] ogreFriends;
    bool detectionEventLock;
    public UnityEvent detectionEvent;
    bool deadPooled;
    public bool fromNightmare;
    public bool fromNormal;
    public bool fromHard;
    public GameObject OgreCrowd;
    public void PlayFootSFX()
    {
        footSFX.Play();
    }

    public void AttackSFX()
    {
        attackSFX.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            detectou = true;
        }
    }

    // Start
    public void Detect()
    {
        detectou = true;
        foreach (var item in ogreFriends)
        {
            if (item.gameObject.activeInHierarchy && !item.detectou)
            {
                item.detectou = true;
            }
            
        }
    }
    //is called before the first frame update
    void Start()
    {

        if (fromNightmare)
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
            if (GameManager.Instance && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
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

        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                OnDeathEvents.Invoke();
                Destroy(gameObject);
            }
        }
        agent = GetComponent<NavMeshAgent>();
        initialSpeed = agent.speed;
        if (spots.Length > 0)
        {
            transform.LookAt(spots[currentSpotToFollow]);
            agent.destination = spots[0].transform.position;
        }
        anim = GetComponent<Animator>();
        currentLife = maxLife;
    }

    public void EnterGadoMode()
    {
        if (!gadando)
        {
            gadando = true;
            agent.speed = agent.speed * 2;
            anim.speed = 2;
            speech.pitch = speech.pitch / 1.5f;
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!detectou)
        {
            return;
        }
        if (detectou && !detectionEventLock)
        {
            foreach (var item in ogreFriends)
            {
                if (item.gameObject.activeInHierarchy)
                {
                    
                    item.GetComponent<OgreScript>().detectou = true;
                }
                
            }
            Instantiate(OgreCrowd, transform.position, transform.rotation);
            detectionEventLock = true;
            detectionEvent.Invoke();
        }
        if (anim.GetBool("Dead"))
        {
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                gameObject.SetActive(false);
                OnDeathEvents.Invoke();
            }
            dead = true;
            if (!deadPooled)
            {
                deadPooled = true;
                GameManager.Instance.killedMonsters++;
            }
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
            return;
        }
        if (dead)
        {
            return;
        }
        if (!detectou)
        {
            if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 5 && !detectou)
            {
                Detect();
            }
            if (spots.Length > 0)
            {
                
                if (transform.position == agent.destination)
                {
                    idleTimeBetweenSpots -= Time.deltaTime;
                    if (idleTimeBetweenSpots <= 0)
                    {
                        idleTimeBetweenSpots = 3;
                        
                        if (currentSpotToFollow < spots.Length-1)
                        {
                            currentSpotToFollow++;
                        }
                        else
                        {
                            currentSpotToFollow = 0;
                        }
                        agent.destination = spots[currentSpotToFollow].transform.position;
                    }
                    
                }
            }
        }
        if (detectou)
        {
            
            if (!playedAware)
            {
                
                GetComponent<AudioSource>().Play();
                playedAware = true;
            }
            if (playedAware && speechTimer < 3 && speech.isPlaying == false)
            {
                speechTimer += Time.deltaTime;
                if (speechTimer > 3 )
                {
                    speech.Play();
                }
                
            }

            if (!isFemale)
            {
                agent.destination = Controller.Instance.transform.position;
                if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 1.3f)
                {
                    //transform.LookAt(Controller.Instance.transform.position);
                    anim.SetBool("Attacking", true);
                    agent.speed = 0;
                }
                else
                {
                    anim.SetBool("Attacking", false);
                    agent.speed = initialSpeed;
                }
            }
            if (isFemale) //^and has detected
            {
                anim.SetBool("Attacking", true);
                transform.LookAt(Controller.Instance.transform.position);

                for (int i = 0; i < gados.Length; i++)
                {
                    gados[i].Detect();
                    gados[i].EnterGadoMode();
                    
                }
                if (fireballCooldown <= 0)
                {
                    fireballCooldown = 1; 
                    Instantiate(fireBall, transform.position, transform.rotation);
                }
                else
                {
                    fireballCooldown -= Time.deltaTime;
                }

                //gados.GadoMode = true;
            }
            
        }
        
        if (agent.velocity.magnitude > 1f)
        {
            
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (currentLife < 1)
        {
            OnDeathEvents.Invoke();
            speech.Stop();
            death.Play();
            damageClub.canDoDamage = false;
            anim.SetBool("Dead", true);
            agent.speed = 0;
            agent.isStopped = true;
        }

        if (burning)
        {
            if (!myBurn.isPlaying)
            {
                if (damaged.isPlaying == false)
                {
                    damaged.Play();
                }
                myBurn.Play();
            }
            burnTimer += Time.deltaTime;
            currentLife -= Time.deltaTime;
            if (burnTimer >= 2)
            {
                burning = false;
                myBurn.Stop();
            }
        }

    }
}
