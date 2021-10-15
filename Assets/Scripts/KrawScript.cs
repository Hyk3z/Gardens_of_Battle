using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;


public class KrawScript : MonoBehaviour {
    public float burnTimer;
    public bool burning;
    public ParticleSystem myBurn;
    public ParticleSystem myBurn2;
    public bool playerfodido;
    public bool warrior;
    float fade;
    public float life = 2;
    public NavMeshAgent agent;
    bool cycle;
    public GameObject inicio;
    public GameObject fim;
    public Animator anim;
    public bool detectou;
    GameObject player;
    public bool atacando;
    public bool dano;
    public bool aptoADarDano = true;
    public bool aptoAAtacar = true;
    float cooldown;
    public StudioEventEmitter audios;
    public StudioEventEmitter damage;
    public GameObject damageFlare;
    float recover;
    alarmscript alarme;
    public float range;
    Vector3 attackPos;
    public bool enabledToMove = true;
    public bool unableToAttack = false;
    public AudioSource burnSound;
    public GameObject[] positions;
    public int positionIndex;
    float xRot;
    public bool ranged;
    public GameObject acidSpit;
    float spitTimer;
    float startSpeed;
    public bool fromHole;
    public GameObject deathScream;
    bool dead;
    public GameObject Krawwd;
    bool KraawdLock;
    public bool climbing;
    public List<GameObject> climbingSteps;
    int climbIndex;
    public krawwClimbSystem currentClimbSystem;
    float upSpeed;
    float initialSpeed;
    Rigidbody rig;
    public bool cold;
    float coldTimer;
    int mask;
    bool shouldAnimate;
    public int rangeToBeSeen;
    //public bool hiddenByDistance;
    //public bool isFromUnderground;
    //public Hider hider;
    public GameObject spitOrigin;
    public bool isFromHole;
    public string playerString;
    public string RangedString;
    bool deadPooled;
    float randomDamage;
    public bool fromNormal;
    public bool fromHard;
    public bool fromNightmare;
    bool angryLock;
    public GameObject deathSFX;
    public bool isWarrior;
    public StudioEventEmitter detectSFX;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToBeSeen);
        
    }
    private void Awake()
    {
        
    }
    
    void Start()
    {
        
        if (GameManager.Instance && GameManager.Instance.nightmare)
        {
            //detectou = true;
        }
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

        if (!isFromHole && GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                gameObject.SetActive(false);
            }


        }
        mask = LayerMask.GetMask(playerString);
        rig = GetComponent<Rigidbody>();
        
        //damageFlare = GameObject.Find("DamageFlare"); // trocar para uma referencia publica
        //audios = GetComponent<AudioSource>();
        player = Controller.Instance.gameObject; 
        //anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        startSpeed = agent.speed;

        upSpeed = agent.speed / 8;
        if (positions.Length > 0 && positions[0] != null)
        {
            
            agent.destination = positions[0].transform.position;
        }
        if (ranged)
        {
            anim.SetBool(RangedString, true);
        }
        if (isWarrior)
        {
            life = 6;
            
        }
        if (isWarrior)
        {
            anim.SetBool("Warrior", true);
            agent.speed = agent.speed * 1.5f;
        }
    }

    private void OnEnable()
    {
        if (!agent)
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator updator()
    {
        yield return null;
    }

    

	void Update () {
        if (cold)
        {
            if (agent.speed > 0)
            {
                agent.speed -= Time.deltaTime;
                
            }
            
        }
        if (Time.timeScale == 0)
        {
            return;
        }
        
        if (!angryLock && detectou)
        {
            angryLock = true;
            audios.Play();

        }
        if (QueenScript.Instance && QueenScript.Instance.life < 1)
        {
            detectou = true;
        }

        if (agent.velocity.magnitude > 0.2f)
        {
            anim.SetBool("Walk", true);
            anim.SetFloat("Blend", agent.velocity.magnitude/4);
            
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        
        if (detectou)
        {
            //if (hider)
            //{
                //hider.AppearNow();
            //}
            
            if (!KraawdLock)
            {
                Instantiate(Krawwd, transform.position, transform.rotation);
                KraawdLock = true;
            }
            if (agent.isOnNavMesh)
            {
                
                agent.destination = player.transform.position;
            }
            
        }
        int radius = 5;
        
        var viuPlayer = Physics.OverlapSphere(gameObject.transform.position, radius, mask); //area de reconhecimento de mobs
        if (viuPlayer.Length != 0)
        {
            if (detectSFX)
            {
                detectSFX.Play();
                Destroy(detectSFX);
            }
            
            detectou = true;
            if (!angryLock)
            {
                audios.Play();

            }

        }
        if (!detectou && life > 0)
        {
            return;
        }
        
        if (!enabledToMove)
        {
                attackPos = transform.position;
            if (agent.isOnNavMesh)
            {
                agent.destination = transform.position;
            }
                
            if (agent.isOnNavMesh)
            {
                agent.isStopped = true;
            }
                
                
        }
        else
        {
            if (agent.isOnNavMesh)
            {
                agent.isStopped = false;
            }
            
        }
        if (burning)
        {
            BurnSteps();
            
        }
        else
        {
            burnSound.Stop();
            myBurn.Stop();
            myBurn2.Stop();
        }
        burnTimer += Time.deltaTime;
        if (burnTimer >= 2)
        {
            myBurn.Stop();
            myBurn2.Stop();
            burning = false;
        }
        
        if (life > 0)
        {
            GetHitOrNot();
            
            if (detectou)
            {
                AttackSteps();
            }
            
            if (dano)
            {
                TakeDamage();
                

            }
            
            if (!atacando)
            {
                anim.SetBool("Attack", false);
            }
        }
        else
        {
            Die();
            if (!deadPooled && GameManager.Instance)
            {
                deadPooled = true;
                GameManager.Instance.killedMonsters++;
            }
        }
        if (ranged && detectou)
        {
            CheckRangeAndSpit();
        }
        if (playerfodido)
        {
            agent.isStopped = true;
        }
        else
        {
            if (agent.isOnNavMesh)
            {
                agent.isStopped = false;
            }
            
        }
        if (enabledToMove == false)
        {
            moveTimer += Time.deltaTime;
        }
        if (moveTimer >= 2)
        {
            moveTimer = 0;
            enabledToMove = true;
        }
        //transform.rotation = agent.

    }
    float moveTimer;
    void Die()
    {
        fade += Time.deltaTime;
        if (fade >= 1.2f)
        {
            damage.Stop();
            audios.Stop();
        }
        anim.SetBool("Death", true);
        if (!dead)
        {
            //monsterDetection.Instance.hitColliders.Remove(GetComponent<BoxCollider>());
            //monsterDetection.Instance.shownMonsters.Remove(gameObject);
            deathSFX.SetActive(true);
            dead = true;
        }
        
        
        if (GameManager.Instance)
        {
            GameManager.Instance.discartList.Add(gameObject.name);

        }
        
        
        
        
        agent.velocity = new Vector3(0, 0, 0);
        if (agent.isOnNavMesh)
        {
            agent.isStopped = true;
        }
        
        Destroy(GetComponent<Rigidbody>());
        GetComponent<BoxCollider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());

        agent.enabled = false;
        if (fade >= 2.3)
        {
            Destroy(audios);
            Destroy(damage);
            Destroy(anim);
            Destroy(agent);
            Destroy(GetComponent<KrawScript>());
            //Destroy(gameObject, 5);
            //monsterDetection.Instance.shownMonsters.Remove(gameObject);
            gameObject.SetActive(false);
            
            //Destroy(gameObject);
        }
    }

    void BurnSteps()
    {
        if (!myBurn.isPlaying)
        {
            myBurn.Play();
            myBurn2.Play();
            if (!burnSound.isPlaying)
            {
                burnSound.Play();
            }

        }
        life -= Time.deltaTime * 3;
    }

    void AttackSteps()
    {
        if (cooldown >= 1.5f)
        {
            aptoADarDano = true;
        }
        else
        {
            cooldown += Time.deltaTime;
        }


        if (anim.GetBool("Attack"))
        {
            enabledToMove = false;
        }
        else
        {
            //enabledToMove = true;
        }
    }

    public void CheckRangeAndSpit()
    {
        
            if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 10)
            {
                anim.SetBool("Attack", true);
                agent.speed = 0;
                transform.LookAt(Controller.Instance.transform.position);
            }
            else
            {
                agent.speed = startSpeed;
            }
        
    }

    void GetHitOrNot()
    {
        if (isWarrior)
        {
            return;
        }
        if (anim.GetBool("Hit"))
        {
            recover += Time.deltaTime;
            if (recover >= 0.2f)
            {
                anim.SetBool("Hit", false);
                recover = 0;
            }
        }
    }

    void TakeDamage() //this is actually for player damage-taking from the ant.
    {
        
        transform.LookAt(player.transform.position);
        if (aptoADarDano && !anim.GetBool("Hit"))
        {
            if (warrior)
            {
                range = 88;
            }
            var Playerfodido = Physics.OverlapSphere(gameObject.transform.position, range, LayerMask.GetMask("Player"));
            if (Playerfodido.Length != 0 && !unableToAttack)
            {
                if (warrior)
                {
                    agent.stoppingDistance = 0;
                    agent.updateRotation = false;
                    agent.velocity = Vector3.zero;

                }
                damage.Play();
                
                aptoADarDano = false;
                cooldown = 0;
                randomDamage = (Random.Range(1, 4)) * 2;
                if (Controller.Instance.coins > 0)
                {
                    randomDamage--;
                    Controller.Instance.coins--;
                    Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
                    Controller.Instance.ShakeShields();
                }
                if (GameManager.Instance && GameManager.Instance.nightmare)
                {
                    randomDamage = randomDamage * 4;
                }
                if (GameManager.Instance && GameManager.Instance.hard)
                {
                    randomDamage = randomDamage * 2;
                }
                else if (GameManager.Instance && GameManager.Instance.normal)
                {
                    //normal damage;
                }
                else
                {
                    randomDamage = randomDamage / 2;
                }
                if (randomDamage > 0)
                {
                    Controller.Instance.life -= randomDamage;
                }
                
                //Controller.Instance.life--;

                Controller.Instance.chachoalha = true;
                if (warrior)
                {
                    
                    Controller.Instance.rigid.AddForce(transform.forward * 1000000);
                }
                //if (damageFlare)
                //damageFlare.GetComponent<Animator>().SetBool("damage", true);
            }

        }
    }
    public void ShootAcid()
    {
        if (ranged)
        {
            Instantiate(acidSpit, spitOrigin.transform.position, spitOrigin.transform.rotation);
        }
        else
        {
            dano = true;
        }
    }

    public void DoDamage()
    {
        if (!isWarrior)
        {
            if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 2)
            {
                Controller.Instance.chachoalhaNow();
                randomDamage = (Random.Range(1, 4)) * 2;
                if (isWarrior)
                {
                    randomDamage = randomDamage * 2;
                }
                if (Controller.Instance.coins > 0)
                {
                    if (Controller.Instance.lvl2Shield)
                    {
                        randomDamage -= 2;
                    }
                    else
                    {
                        randomDamage--;
                    }

                    Controller.Instance.ShakeShields();
                    Controller.Instance.coins--;
                    Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
                }

                if (randomDamage > 0)
                {
                    Controller.Instance.life -= randomDamage;
                }

                
                damage.Play();
                enabledToMove = true;
            }
        }
        if (isWarrior)
        {
            if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 5)
            {
                Controller.Instance.chachoalhaNow();
                randomDamage = (Random.Range(1, 4)) * 2;
                if (isWarrior)
                {
                    randomDamage = randomDamage * 2;
                }
                if (Controller.Instance.coins > 0)
                {
                    randomDamage--;
                    Controller.Instance.ShakeShields();
                    Controller.Instance.coins--;
                    Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
                }

                Controller.Instance.life -= randomDamage;
                damage.Play();
                enabledToMove = true;
                
                Controller.Instance.rigid.AddForce(transform.forward * 200000);
                Controller.Instance.rigid.AddForce(transform.up * 10000);
            }
        }
        
    }

    public void DetectPlayer()
    {
        detectou = true;
    }

    bool reverse;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Position"  && !detectou && positions.Length > 0)
        {
            
            if (other.gameObject == positions[positionIndex])
            {
                if (reverse)
                {
                    positionIndex--;
                }
                else
                {
                    positionIndex++;
                }
                
                if (positionIndex >= positions.Length)
                {
                    reverse = true;
                    positionIndex -= 2;
                    
                }
                if (positionIndex <= -1)
                {
                    reverse = false;
                    positionIndex += 2;

                }
                if (positions[positionIndex])
                {
                    agent.destination = positions[positionIndex].transform.position;
                }
                
            }
        }

        

        
        //if (other.tag == "Position"  && !detectou)
        //{
        //    cycle = false;
        //}
    }
    public void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Griffin") && aptoAAtacar)
        {
            anim.SetBool("Attack", true);
            atacando = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && aptoAAtacar)
        {
            anim.SetBool("Attack", false);
        }
    }

    

}
