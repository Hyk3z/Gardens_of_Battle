using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessScript : MonoBehaviour
{
    public Rigidbody rig;
    public bool detectou;
    public float speed;
    public GameObject acidSpid;
    float acidCooldown = -1;
    public float life = 2;
    bool deathLock;
    public Animator anim;
    public GameObject deathSound;
    public bool burning;
    float deathCounter;
    public AudioSource burnSound;
    public ParticleSystem myBurn;
    public float burnTimer;
    WaitForSeconds wfs;
    public GameObject flySFX;
    public bool isFromHole;
    bool deadPooled;
    public bool fromNightmare;
    public bool fromNormal;
    public bool fromHard;
    string IdleString;
    bool KraawdLock;
    public GameObject Krawwd;
    bool detectLock;
    public bool lamp;
    public GameObject deathSFX;

    void Start()
    {
        if (lamp)
        {
            speed = speed * 2;
        }
        IdleString = "Idle";
        if (GameManager.Instance && GameManager.Instance.nightmare)
        {
            detectou = true;
            
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
            if (GameManager.Instance && GameManager.Instance && !GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
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
        wfs = new WaitForSeconds(1);
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(waitAndCheckPlayer());
        }
        
        //anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        if (!detectou)
        {
            rig.useGravity = true;
            rig.isKinematic = true;
            anim.SetBool(IdleString, true);
        }
    }

    void GoDeath()
    {
        deathSFX.SetActive(true);
        deathCounter += Time.deltaTime;
        if (deathCounter >= 2)
        {
            Destroy(anim);
            Destroy(GetComponent<PrincessScript>());
            burnSound.Stop();
            myBurn.Stop();
            burning = false;
            gameObject.SetActive(false);
            if (!deadPooled)
            {
                deadPooled = true;
                if(GameManager.Instance)
                {
                    GameManager.Instance.killedMonsters++;
                }
                
            }
        }
    }

    IEnumerator waitAndCheckPlayer()
    {
        while (!deathLock)
        {
            yield return wfs;
            if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 10 && !deathLock && !detectou)
            {
                detectou = true;
                
            }
        }
        
    }

    void DieNowPrincess()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.discartList.Add(gameObject.name);
        }

        flySFX.SetActive(false);
        anim.SetBool("Dead", true);
        if (rig)
        {
            rig.isKinematic = false;
            rig.useGravity = true;
        }
        
        deathLock = true;
        deathSound.SetActive(true);
        GetComponent<AudioSource>().Stop();
    }

    void FirstDetectionSteps()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
        flySFX.SetActive(true);
        anim.SetBool("Idle", false);
        rig.isKinematic = false;
        rig.useGravity = false;
        detectLock = true;
    }

    void FightUpdtate()
    {
        //movement
        transform.LookAt(Controller.Instance.transform.position);
        rig.AddForce(transform.forward * speed);
        transform.LookAt(transform.position + rig.velocity);

        //attack
        if (detectou && Vector3.Distance(Controller.Instance.transform.position, transform.position) < 20f && acidCooldown < 0)
        {
            Instantiate(acidSpid, transform.position, transform.rotation);
            acidCooldown = 1.5f;
        }
        if (acidCooldown >= 0)
        {
            acidCooldown -= Time.deltaTime;
        }
    }


    void FixedUpdate()
    {
        if (deathLock)
        {
            
            GoDeath();
            return;
        }
        
        if (detectou)
        {
            if (!KraawdLock)
            {
                Instantiate(Krawwd, transform.position, transform.rotation);
                KraawdLock = true;
            }
            
        }

        
        
        if (life <= 0 && !deathLock)
        {

            DieNowPrincess();
            
        }
        
        if (detectou && life > 0)
        {
            if (!detectLock)
            {
                FirstDetectionSteps();
            }
            FightUpdtate();
            
        }
        

        
        if (burning)
        {
            BurnSteps();

        }
        else
        {
            burnSound.Stop();
            myBurn.Stop();
        }

        if (burning)
        {
            burnTimer += Time.deltaTime;
            if (burnTimer >= 2)
            {
                myBurn.Stop();
                burning = false;
            }
        }
        

    }

    void BurnSteps()
    {
        //colocar a particula de fogo e seu som no objeto.
        if (!myBurn.isPlaying)
        {
            myBurn.Play();
            if (!burnSound.isPlaying)
            {
                burnSound.Play();
            }

        }
        life -= Time.deltaTime;
    }

}
