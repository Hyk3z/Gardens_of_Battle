using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class QueenScript : MonoBehaviour
{

    static QueenScript m_Instance;
    public static QueenScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(QueenScript)) as QueenScript;
            return m_Instance;
        }
    }


    public UnityEvent QueenDeathEvents;
    public GameObject acidSpit;
    public GameObject acidOrigin;
    public bool detectou;
    float spitTimer;
    public Animator anim;
    public float life;
    bool dead;
    public GameObject[] LayedEggs;
    public AudioSource deathSFX;
    public Animator rockToFall;
    public GameObject coguDeath;
    public AudioSource painSound;
    float previousLife;
    public float burnTimer;
    public ParticleSystem[] queenBurns;
    public AudioSource speechSound;
    bool startedDead;
    bool deadPooled;
    public bool burning;
    bool crossedFirstBurn;
    bool crossedSecondBurn;
    bool crossedThirdBurn;
    //float burnTimer;
    public void StartDead()
    {
        
        anim.SetBool("AlreadyDead", true);
        startedDead = true;
    }

    public void SpitAcid()
    {
        Instantiate(acidSpit, acidOrigin.transform.position, acidOrigin.transform.rotation);
    }

    public void DetectPlayer()
    {
        detectou = true;
    }

    private void Start()
    {
        if (GameManager.Instance && (GameManager.Instance.hard || GameManager.Instance.nightmare))
        {
            life = 84;
        }
        if (GameManager.Instance && !GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            life = 28; //easy
        }
        previousLife = life;
        if (PlayerPrefs.GetInt(transform.parent.name) == 1)
        {
            Destroy(transform.parent.gameObject);
            Destroy(rockToFall);
            QueenDeathEvents.Invoke();
        }
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (crossedFirstBurn)
        {
            life -= Time.deltaTime;
        }
        if (crossedSecondBurn)
        {
            life -= Time.deltaTime;
        }
        if (crossedThirdBurn)
        {
            life -= Time.deltaTime;
        }
        burnTimer += Time.deltaTime;
        if (burnTimer >= 2)
        {
            //ceaseQueenFires();
            burning = false;
        }
        if (burning)
        {
            QueenBurn();
        }
        if (startedDead)
        {
            
            return;
        }
        if (!detectou || dead)
        {
            return;
        }
        if (life < previousLife)
        {
            previousLife = life;
            if (!painSound.isPlaying)
            {
                PlayPain();
                if (life <= 0)
                {
                    QueenDeathSteps();
                }
            }
            
        }
        spitTimer += Time.deltaTime;
        if (spitTimer >= 4)
        {
            spitTimer = 0;
            anim.SetTrigger("Spit");
        }
        if (life <= 0 && !dead)
        {
            //sapivangas.Instance.waiting = true;
            //QueenDeathSteps();
        }
        if (!dead && burnTimer >= 0)
        {
                //life -= burn
                //burnTimer -= Time.deltaTime;
                //QueenBurn();
            
        }
    }
    void QueenDeathSteps()
    {
        if (!deadPooled)
        {
            deadPooled = true;
            if (GameManager.Instance)
            {
                GameManager.Instance.killedMonsters++;
            }
            
        }
        QueenDeathEvents.Invoke();
        //rockToFall.enabled = true;
        deathSFX.Play();
        dead = true;
        if (GameManager.Instance)
        {
            GameManager.Instance.discartList.Add(gameObject.transform.parent.gameObject.name);
        }
        
        if (coguDeath)
        {
            coguDeath.SetActive(false);
        }
        anim.SetTrigger("Death");
        speechSound.Stop();
        detectou = false;
        foreach (var item in LayedEggs)
        {
            if (item)
            {
                item.SetActive(true);
            }

        }
    }
    public void QueenBurn()
    {

        //burnTimer += Time.deltaTime;
        life -= Time.deltaTime * 4;
            //life -= 1f;
            if (life <= 45)
            {
            crossedFirstBurn = true;
                queenBurns[0].Play();
                life -= Time.deltaTime;
            }
            if (life <= 30)
            {
            crossedSecondBurn = true;
            queenBurns[0].Play();
                queenBurns[1].Play();
                life -= Time.deltaTime * 2;
            }
            if (life <= 15)
            {
            crossedThirdBurn = true;
            queenBurns[2].Play();
                queenBurns[3].Play();
                life -= Time.deltaTime * 2;
            }
        if (life <= 0 && !dead)
        {
            QueenDeathSteps();
        }
        
    }
    IEnumerator ceaseQueenFires()
    {
        yield return new WaitForSeconds(1.65f);
        for (int i = 0; i < queenBurns.Length; i++)
        {
            queenBurns[i].Stop();
        }
    }
    public void PlaySpeech()
    {
        if (!dead)
        {
            speechSound.Play();
        }
    }
    public void PlayPain()
    {
        if (!dead)
        {
            
            painSound.Play();
        }
    }
}
