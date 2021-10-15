using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sapivangas : MonoBehaviour {

    static sapivangas m_Instance;
    public static sapivangas Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(sapivangas)) as sapivangas;
            return m_Instance;
        }
    }

    public GameObject HighLight;
    public bool greet;
    bool greetLock;
    public Animator anim;
    float timer;
    public bool explain;
    public AudioSource explainSound;
    public AudioSource deliverSound;
    bool deliverLock;
    public bool deliver;
    public bool explainLock;
    public GameObject sword;
    float swordcounter;
    public AudioSource greetsound;
    bool soundLock;
    GameObject Cogumelo;
    public GameObject cogudeath;
    float delivercounter;
    bool locker;
    public GameObject[] eggs;
    SoundScript caminhao;
    public bool gaveStaff;
    public GameObject staff;
    bool enoughStaff;
    public bool quiet;
    public GameObject ballista;
    public bool waiting;
    float deliverAnimationDelay;
    bool thislock;
    bool ended;
    bool deliverSoundLock;
    public GameObject fleeSpeech;
    float countForJetpack;
    public GameObject normalPortal;
    public UnityEvent QuestCompleteEvents;
    bool WaitingSpeechToFlee = false;
    //public bool iJustWantHimToPlaySpeechAnimation;

    public void iJustWantHimToPlaySpeechAnimation()
    {
        
        deliverAnimationDelay += Time.deltaTime;
        if (deliverAnimationDelay >= 2 && !thislock)
        {
            
            thislock = true;
            anim.Play("Idle");
            anim.SetBool("Locker", false);
            anim.SetBool("Deliver", true);
        }
        
    }

    // Use this for initialization
    void Start () {
        caminhao = GameObject.Find("CaminhaoDoSom").GetComponent<SoundScript>();
        Cogumelo = GameObject.Find("Cogumelo");
        //cogudeath = ;
        //anim = GetComponent<Animator>();
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            gameObject.SetActive(false);
        }
	}
	
    public void GiveStaff()
    {
        if (!enoughStaff)
        {
            QuestCompleteEvents.Invoke();
            
            staff.SetActive(true);
            sword.GetComponent<weaponscript>().hasStaff = true;
            //sword.SetActive(false);
            sword.GetComponent<Animator>().SetBool("Off", true);
            ballista.GetComponent<Animator>().SetBool("Off", true);
            BazookaScript.Instance.GetComponent<Animator>().SetBool("Off", true);
            MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", true);
            staff.GetComponent<Animator>().SetBool("Off", false);
            
            sword.GetComponent<weaponscript>().SwapToStaff();
            //gaveStaff = false;
            enoughStaff = true;
            selectionScript.Instance.GetBehindIcon(1);
        }
    }

    public void Flee()
    {
        if (fleeSpeech.GetComponent<AudioSource>().isPlaying == false)
        {
            
            normalPortal.SetActive(false);
            fleeSpeech.SetActive(true);
            WaitingSpeechToFlee = true;
            countForJetpack = 3f;
        }
    }
    // Update is called once per frame
    void Update () {

        if (WaitingSpeechToFlee && fleeSpeech.GetComponent<AudioSource>().isPlaying == false) //trocar a fleeSpeech por audioSource e referenciar again
        {
            anim.SetBool("Flee", true);
        }

        //if (countForJetpack > 0)
        {
            //countForJetpack -= Time.deltaTime;
            if (countForJetpack <= 0)
            {
                //anim.SetBool("Flee", true);
            }
        }
        if (ended)
        {
            return;
        }
        if (quiet && !waiting)
        {
            return;
        }
        
        if (locker)
        {
            anim.SetBool("Locker", true);
        }
        if (deliverLock && !locker && waiting)
        {
            
            delivercounter += Time.deltaTime;
            if (delivercounter >= 1)
            {
                if (!deliverSound.isPlaying)
                {
                    foreach (var egg in eggs)
                    {
                        egg.SetActive(false);
                    }
                    if (!deliverSoundLock)
                    {
                        deliverSound.Play();
                        deliverSoundLock = true;
                    }
                    
                    
                }
                
            }
            
        }
        if (delivercounter >= 1 && waiting)
        {
            anim.SetBool("Locker", true);
            //delivercounter += Time.deltaTime;
            if (delivercounter >= 17)
            {
                //GiveStaff();
                
                staff.SetActive(true);
                Controller.Instance.gotStaff = true;
                staff.GetComponent<Animator>().SetBool("Off", false);
                sword.GetComponent<Animator>().SetBool("Off", true);
                ballista.GetComponent<Animator>().SetBool("Off", true);
                BazookaScript.Instance.GetComponent<Animator>().SetBool("Off", true);
                MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", true);
                waiting = false;
                ended = true;
            }
        }

        if (deliver && !deliverLock)
        {
            
            caminhao.questDeliver = true;
            deliverLock = true;
        }
        if (explainLock && !waiting)
        {
            swordcounter += Time.deltaTime;
            if (swordcounter >= 11)
            {
                if (cogudeath)
                {
                    cogudeath.SetActive(true);
                }
                if (Cogumelo)
                Cogumelo.SetActive(false);
                
                if (!soundLock)
                {
                    sword.SetActive(true);
                    selectionScript.Instance.GetBehindIcon(0);
                    quiet = true;
                }
                
                if (swordcounter >= 16 && !soundLock && !waiting)
                {
                    soundLock = true;
                    caminhao.questBegin = true;
                    
                }
            }
            
        }
		if (greet && !greetLock)
        {
            GetComponent<SphereCollider>().enabled = true;
            
            timer += Time.deltaTime;
            if (timer >= 0.2f)
            {
                anim.SetBool("Greeting", true);
            }
            if (timer >= 0.85f)
            {
                greetsound.Play();
                anim.SetBool("Greeting", false);
                greetLock = true;
                
            }
            
        }
        if (greet && greetLock && !explainLock)
        {
            timer += Time.deltaTime;
            if (timer >= 3.5f)
            {
                HighLight.SetActive(true);
            }
        }
        if (explain)
        {
            
            explain = false;
            anim.SetBool("Explain", true);
        }

	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !explainLock)
        {
            HighLight.SetActive(false);
            greetsound.Stop();
            explainSound.Play();
            explainLock = true;
            explain = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !explainLock)
        {
            HighLight.SetActive(false);
            greetsound.Stop();
            explainSound.Play();
            explainLock = true;
            explain = true;
        }
    }
}
