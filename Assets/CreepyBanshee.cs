using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreepyBanshee : MonoBehaviour
{
    public bool detectou;
    AudioSource scream;
    NavMeshAgent agent;
    float damageCooldown;
    Animator anim;
    bool invisible;
    BoxCollider col;
    float fadeTimer;
    public GameObject deathScream;

    public void Die()
    {
        deathScream.transform.parent = null;
        deathScream.SetActive(true);
        gameObject.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        scream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!detectou)
        {
            if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 10)
            {
                anim.SetBool("Spook", true);
                detectou = true;
            }
            return;
        }
        //transform.LookAt(Controller.Instance.transform.position);
        agent.SetDestination(Controller.Instance.transform.position);
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 3 && !invisible)
        {
            
            if (!scream.isPlaying)
            {
                scream.Play();
                
            }
            if (damageCooldown <= 0)
            {
                Controller.Instance.chachoalha = true;
                Controller.Instance.life--;
                damageCooldown = Random.Range(8, 16);
                fadeTimer = 2.5f;
            }
        }
        
        if (damageCooldown > 0)
        {
            
            
            damageCooldown -= Time.deltaTime;
            if (damageCooldown <= 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                invisible = false;
                col.enabled = true;
            }
        }
        if (fadeTimer > 0) //desaparecendo para aparecer de novo depois
        {
            fadeTimer -= Time.deltaTime;
            if (fadeTimer <= 0)
            {
                transform.localScale = new Vector3(0, 0, 0);
                invisible = true;
                col.enabled = false;
            }
        }
    }
}
