using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;
using UnityEngine.UIElements;

public class OrcScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    float attackTimer;
    bool attacking;
    public float life;
    bool dead;
    public bool isShaman;
    public OrcScript myShaman;
    public List <OrcScript> deadOrcs;
    public ParticleSystem fire;
    public CapsuleCollider physicalCollider;
    public CapsuleCollider triggerCollider;
    float spellCoolDown;
    public StudioEventEmitter deathSFX;
    public StudioEventEmitter hurtSFX;
    public StudioEventEmitter attackHitSFX;
    public StudioEventEmitter ressurectVO;
    public bool detectou;
    public StudioEventEmitter detectSFX;
    public GameObject orcKrawwdPrefab;
    bool countedLock;
    public ParticleSystem myBurn;
    public GameObject fakeJava;
    public GameObject javaPrefab;
    public GameObject shootOrigin;
    public bool isShooter;
    public bool isPale;
    float randomDamage;
    public StudioEventEmitter idleSFX;
    public StudioEventEmitter angrySFX;
    public StudioEventEmitter RespawnSFX;

    // Start is called before the first frame update
    private void Start()
    {
        if (isShooter)
        {
            anim.SetBool("isShooter", true);
        }
        if (idleSFX)
        {
            idleSFX.Play();
        }
        if (detectou)
        {
            angrySFX.Play();
        }
    }

    

    IEnumerator appearSpearAgain()
    {
        yield return new WaitForSeconds(0.5f);
        fakeJava.SetActive(true);
    }

    public void ShootJava()
    {
        fakeJava.SetActive(false);
        Instantiate(javaPrefab, shootOrigin.transform.position, shootOrigin.transform.rotation);
        StartCoroutine(appearSpearAgain());
    }


    IEnumerator disappearAfterAWhile()
    {
        
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    public void DetectNow()
    {
        if (detectou)
        {
            return;
        }
        if (idleSFX)
        {
            Destroy(idleSFX.gameObject);
        }
        
        detectou = true;
        if (angrySFX)
        {
            angrySFX.Play();
        }
        
        Instantiate(orcKrawwdPrefab, transform.position, transform.rotation);
        if (detectSFX != null)
        {
            detectSFX.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myBurn.isPlaying && Controller.Instance.staffAnim.GetBool("Off"))
        {
            myBurn.Stop();
        }
        if (isShaman)
        {
            if (deadOrcs.Count > 0 && !dead)
            {
                transform.LookAt(deadOrcs[0].transform.position);
            }
        }
        if (dead)
        {
            if ((!isShaman && myShaman && myShaman.dead) || (!isShaman && !myShaman))
            {
                if (!countedLock)
                {
                    if (GameManager.Instance)
                    {
                        GameManager.Instance.killedMonsters++;
                        countedLock = true;
                    }
                }
                StartCoroutine(disappearAfterAWhile());
            }
            if (isShaman)
            {
                if (!countedLock)
                {
                    if (GameManager.Instance)
                    {
                        GameManager.Instance.killedMonsters++;
                        countedLock = true;
                    }
                }
                StartCoroutine(disappearAfterAWhile());
            }
            return;
        }
        if (!detectou && !dead)
        {
            if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 7)
            {
                DetectNow();
            }
            return;
            
        }
        
    agent.SetDestination(Controller.Instance.transform.position);
            if (isShaman)
            {
                    if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 10)
                    {
                        agent.isStopped = true;
                    }
                    else
                    {
                        agent.isStopped = false;
                    }
            }
            if (isShooter)
        {
            if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 20)
            {
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
        }
        
        if (agent.velocity.magnitude > 0.3f)
        {
            anim.SetBool("Running", true);
            //transform.LookAt(agent.velocity + transform.position);
        }
        else
        {
            //transform.LookAt(Controller.Instance.transform.position);
            
            anim.SetBool("Running", false);
        }
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 1.6f && attackTimer <= 0)
        {
            transform.LookAt(Controller.Instance.transform.position);
            anim.SetTrigger("Attack");
            
            if (!attacking)
            {
                
                
                attacking = true;
                attackTimer = 1f;
            }
            
        }
        if (Vector3.Distance(Controller.Instance.transform.position, transform.position) < 20 && detectou && isShooter)
        {
            transform.LookAt(Controller.Instance.transform.position);
            anim.SetTrigger("Shoot");
        }
        if (attackTimer > 0)
        {
            
            attackTimer -= Time.deltaTime;
        }
        if (attacking && attackTimer <= 0)
        {
            attacking = false;
            //CauseDamage();
        }



        if (life <= 0)
        {
            agent.destination = transform.position;
            agent.speed = 0;
            
            DieNow();
            //Destroy(gameObject, 2);
        }

        if (deadOrcs.Count > 0 && isShaman && spellCoolDown <= 0)
        {
            spellCoolDown = 2;
            
            fire.Play();
            anim.SetTrigger("CastSpell");
            ressurectVO.Play();
        }
        if (spellCoolDown > 0)
        {
            spellCoolDown -= Time.deltaTime;
        }
    }

    public void CastRessurection()
    {
        fire.Play();
        deadOrcs[0].fire.Play();
        
        transform.LookAt(deadOrcs[0].transform.position);
        //transform.LookAt(deadOrcs[0].gameObject.transform.position);
        deadOrcs[0].anim.SetTrigger("Ressurect");
        deadOrcs[0].RespawnSFX.Play();
        deadOrcs.Remove(deadOrcs[0]);
    }


    public void RessurectNow()
    {
        //Debug.Log(gameObject.name + " is playing ressurectionSound");
        //RespawnSFX.Play();
        if (angrySFX)
        {
            angrySFX.Play();
        }
        
        agent.speed = 3.5f;
        
        physicalCollider.enabled = true;
        triggerCollider.enabled = true;
        life = 5;
        anim.SetBool("Death", false);
        dead = false;
        if (isPale)
        {
            agent.speed = 5;
            life = 12;
        }
    }

    

    public void DieNow()
    {
        if (angrySFX)
        {
            angrySFX.Stop();
        }
        
        myBurn.Stop();
        deathSFX.Play();
        if (dead)
        {
            return;
        }
        physicalCollider.enabled = false;
        triggerCollider.enabled = false;
        if (!isShaman && myShaman && !myShaman.deadOrcs.Contains(this))
        {
            myShaman.deadOrcs.Add(this);
        }
        dead = true;
        anim.SetBool("Death", true);
        if (isShaman)
        {
            ressurectVO.Stop();
        }
    }

    public void CauseDamage()
    {
        
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 1.6f)
        {
            

            randomDamage = Random.Range(3, 5);
            if (isPale)
            {
                randomDamage = Random.Range(5, 7);
            }
            if (Controller.Instance.coins > 0)
            {
                if (Controller.Instance.lvl2Shield)
                {
                    randomDamage = randomDamage - 2;
                }
                else
                {
                    randomDamage = randomDamage - 1;
                }
                Controller.Instance.ShakeShields();
                Controller.Instance.coins--;
                Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
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
            attackHitSFX.Play();
            
            if (randomDamage > 0)
            {
                Controller.Instance.life -= randomDamage;
                Controller.Instance.chachoalha = true;
                Controller.Instance.chachoalhaNow();
            }
            
        }
    }

}
