using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using UnityEngine.ParticleSystemJobs;


public class staffScript : MonoBehaviour
{
    public StudioEventEmitter flameThrowEmitter;
    static staffScript m_Instance;
    public static staffScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(staffScript)) as staffScript;
            return m_Instance;
        }
    }
    bool ceased;
    public bool sendFire;
    public Animator anim;
    public ParticleSystem particles;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public bool isDrawn = true;
    public GameObject sword;
    public bool callSword;
    float waiter;
    public BoxCollider boxCol;
    Animator swordanim;
    public GameObject ballista;
    public AudioSource flamethrow;
    public bool playFlameThrow;
    public GameObject fireForTree;
    public float Mana = 10;
    //public Image manaBar;
    //public GameObject manaText;
    //public GameObject manaBarObj;
    float timeBurning;
    public GameObject fireSpread;
    public GameObject[] objectsToEnableOnStart;
    Animator swordAnim;
    Animator ballistaAnim;
    Animator bazookaAnim;
    bool iconLock;
    Animator machinegunAnim;
    public Light orbLight;
    public Light iceLight;
    public bool iceMode;
    public ParticleSystem iceAttackParticle1;
    public ParticleSystem iceAttackParticle2;
    public GameObject IceAttackTrigger;
    public StudioEventEmitter iceStart;
    bool iceLock;
    public GameObject iceSphere;
    public GameObject fireSphere;
    bool flamethrowing;
    public GameObject mouseTutorial;
    bool savedIce;
    //float soundCooldown = 0;
    //public StudioEventEmitter startEmitter;
    public StudioEventEmitter trueSound;
    public GameObject coldTutorial;
    bool alreadyShowedTutorialOnce;
    private FMODUnity.StudioEventEmitter emitter;
    bool isPlayingFire;
    float flametimer;
    public GameObject manaBackGround;
    public GameObject manaFill;
    Slider manaSlider;
    public GameObject powerIcon;
    public GameObject ceaseFireSFX;
    public void SwapToMachinegun()
    {
        if (Controller.Instance.gotMachinegun)
        {
            selectionScript.Instance.GetBehindIcon(4);
            anim.SetBool("Off", true);
            MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", false);
            
        }
    }
    void Start()
    {
        Controller.Instance.Icons[1].SetActive(true);
        manaSlider = manaFill.GetComponent<Slider>();
        swordanim = sword.GetComponent<weaponscript>().Anim;
        boxCol = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        swordAnim = sword.GetComponent<Animator>();
        ballistaAnim = ballista.GetComponent<Animator>();
        bazookaAnim = BazookaScript.Instance.GetComponent<Animator>();
        machinegunAnim = MAchinegunScript.Instance.GetComponent<Animator>();
    }

    public void SwapToSword()
    {
        
        ceaseFireSFX.SetActive(true);
        CeaseFire();
        if (sword.GetComponent<weaponscript>().Anim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = true;
        }
        selectionScript.Instance.GetBehindIcon(0);
        swordanim.SetBool("Off", false);
        anim.SetBool("Off", true);
    }
    public void SwapToBallista()
    {
        
        ceaseFireSFX.SetActive(true);
        CeaseFire();
        if (Controller.Instance.GotBallista)
        {
            ballista.SetActive(true);
            
            selectionScript.Instance.GetBehindIcon(2);
            ballista.SetActive(true);
            ballistaAnim = ballista.GetComponent<Animator>();
            ballistaAnim.SetBool("Off", false);
            anim.SetBool("Off", true);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("IceDone") == 1)
        {
            Destroy(mouseTutorial);
            savedIce = true;
        }
        
    }

    void SwapToBazooka()
    {
        Debug.Log("activating ceaseFireSFX from here");
        ceaseFireSFX.SetActive(true);
        CeaseFire();
        if (Controller.Instance.gotBazooka)
        {
            selectionScript.Instance.GetBehindIcon(3);
            anim.SetBool("Off", true);
            bazookaAnim.SetBool("Off", false);
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !anim.GetBool("Off"))
        {
            SwapToSword();

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !anim.GetBool("Off"))
        {
            SwapToBallista();

        }
        if (anim.GetBool("Off"))
        {
            manaBackGround.SetActive(false);
            manaFill.SetActive(false);
            powerIcon.SetActive(false);
            orbLight.gameObject.SetActive(false);
            iceLight.gameObject.SetActive(false);
            if (sendFire)
            {
                Debug.Log("activating ceaseFireSFX from here");
                ceaseFireSFX.SetActive(true);
                CeaseFire();
            }
            if (mouseTutorial && mouseTutorial.activeInHierarchy)
            {
                mouseTutorial.SetActive(false);
            }
            
            return;
        }
        else
        {
            manaBackGround.SetActive(true);
            manaFill.SetActive(true);
            powerIcon.SetActive(true);
            /*if (!savedIce && !mouseTutorial.activeInHierarchy)
            {
                mouseTutorial.SetActive(true);
            }
            */
            orbLight.gameObject.SetActive(true);
        }
        if (Controller.Instance.gotStaff == false || Time.timeScale == 0)
        {
            return;
        }
        if (!anim.GetBool("Off") && !iconLock)
        {
            iconLock = true;
            selectionScript.Instance.GetBehindIcon(1);
            
        }
        else
        {
            iconLock = false;
        }
        
        if (Controller.Instance.gotBazooka && Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwapToBazooka();
        }

        if (callSword)
        {
            callSword = false;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && !anim.GetBool("Off"))
        {
            SwapToSword();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !anim.GetBool("Off"))
        {
            SwapToBallista();

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !anim.GetBool("Off") && Controller.Instance.gotBazooka)
        {
            anim.SetBool("Off", true);
            bazookaAnim.SetBool("Off", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && !anim.GetBool("Off") && Controller.Instance.gotMachinegun)
        {
            SwapToMachinegun();
        }
        if (!isDrawn)
        {
            waiter += Time.deltaTime;
            if (waiter >= 0.45f)
            {
                waiter = 0;
                
                isDrawn = true;
                
            }
            
        }
        if (flametimer > 0)
        {
            flametimer -= Time.deltaTime;
        }
        if ((Input.GetMouseButton(0) /*|| Input.GetMouseButton(1)*/) && Controller.Instance.death == false && Mana > 0 && !anim.GetBool("Off"))
        {
            ceased = false;
            if (Input.GetMouseButton(0))
            {
                if (!flamethrowing)
                {
                    //SetParameter(emitter.EventInstance, "Enemy", 1.0f);
                    //trueSound.EventInstance.setParameterByName("SoltarBotaoFogo", 0);
                    //trueSound.SetParameter("SoltarBotaoFogo", 0);
                    if (!isPlayingFire)
                    {
                        ceaseFireSFX.SetActive(false);
                        trueSound.Play();
                        flametimer = 1;
                        isPlayingFire = true;
                        ceaseFireSFX.SetActive(false);
                    }
                    
                    
                    flamethrowing = true;
                }
                
                
                fireSphere.SetActive(true);
                iceSphere.SetActive(false);
                iceMode = false;
                anim.SetBool("Flaming", true);
                Mana -= Time.deltaTime;
                orbLight.intensity = 4.4f;
                manaSlider.value = Mana / 10;

            }
            /*
            if (Input.GetMouseButton(1))
            {
                fireSphere.SetActive(false);
                iceSphere.SetActive(true);
                if (!savedIce)
                {
                    savedIce = true;
                    PlayerPrefs.SetInt("IceDone", 1);
                    if (mouseTutorial && mouseTutorial.activeInHierarchy)
                    {
                        mouseTutorial.SetActive(false);
                    }
                }
                if (GameManager.Instance)
                {
                    GameManager.Instance.discartList.Add("ColdTutorial");
                }
                coldTutorial.SetActive(false);
                iceMode = true;
                anim.SetBool("Flaming", true);
                Mana -= Time.deltaTime;
                iceLight.gameObject.SetActive(true);
                iceLight.intensity = 4.4f;
                //fazer com que o mouseTutorial nao fique ativo quando staff estiver off. Fazer voltar a ativar se estiver `off false` E TAMBEM savedIce false
            }*/
        }
        else if (!ceased)
        {
            ceased = true;
            if (Mana < 10)
            {
                /*orbLight.intensity = 1.8f;
                iceLight.intensity = 1.8f;
                Mana += Time.deltaTime;
                manaSlider.value = Mana / 10;
                */
            }
            else
            {
                orbLight.intensity = 2.2f;
                iceLight.intensity = 2.2f;
                Mana = 10;
                manaSlider.value = 1;
            }
            Debug.Log("activating ceaseFireSFX from here");
            ceaseFireSFX.SetActive(true);
            anim.SetBool("Flaming", false);
        }
        if (sendFire)
        {
            if (iceMode)
            {
                /*
                timeBurning += Time.deltaTime;
                if (!particles.isPlaying && timeBurning >= 0.4f)
                {
                    if (!iceLock)
                    {
                        iceAttackParticle1.Play();
                        iceAttackParticle2.Play();
                        iceLock = true;
                    }
                    
                    IceAttackTrigger.SetActive(true);
                    //particles.Play();
                    //particle2.Play();
                }
                */
            }
            else
            {
                timeBurning += Time.deltaTime;
                if (!particles.isPlaying && timeBurning >= 0.4f)
                {
                    boxCol.enabled = true;
                    particles.Play();
                    particle2.Play();
                    particle3.Play();
                }
            }
            
            
        }
        else
        {
            if (isPlayingFire)
            {
                
                if (flametimer <= 0)
                {
                    Debug.Log("activating ceaseFireSFX from here");
                    ceaseFireSFX.SetActive(true);
                    CeaseFire();
                }
                
            }
            
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            iceLock = false;
            //iceStart.Play();
            
        }
        if (empurrador.Instance.x != 0 || empurrador.Instance.z != 0)
        {
            anim.SetBool("Walking", true);
            if (empurrador.Instance.capsOn)
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
        if (!alreadyShowedTutorialOnce && PlayerPrefs.GetInt("ColdTutorial") != 1)
        {
            coldTutorial.SetActive(true);
            alreadyShowedTutorialOnce = true;
        }

        if (Input.GetMouseButton(0) && Mana <= 0)
        {
            SwapToSword();
        }

    }

    public void playFoot()
    {
        Controller.Instance.playFootstepSound();
    }

    

    public void CeaseFire()
    {
        //ceaseFireSFX.SetActive(true);
        isPlayingFire = false;
        flamethrowing = false;
        //trueSound.Stop();
        //trueSound.SetParameter("SoltarBotaoFogo", 1);

        
        trueSound.Stop();

        flamethrow.Stop();
        sendFire = false;
        timeBurning = 0;
        boxCol.enabled = false;
        particles.Stop();
        particle2.Stop();
        particle3.Stop();
        iceAttackParticle1.Stop();
        iceAttackParticle2.Stop();
        IceAttackTrigger.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mob" && other.GetComponent<KrawScript>())
        {
            KrawScript otherscript = other.GetComponent<KrawScript>();
            otherscript.burning = true;
            otherscript.burnTimer = 0;
            
        }
        if (other.tag == "Mob" && other.GetComponent<OrcScript>())
        {
            OrcScript otherscript = other.GetComponent<OrcScript>();
            otherscript.life -= Time.deltaTime;
            if (!otherscript.myBurn.isPlaying)
            {
                otherscript.myBurn.Play();
            }
            
            //otherscript.burnTimer = 0;

        }
        if (other.tag == "Mob" && other.GetComponent<KrawExplosion>())
        {
            Debug.Log("Got Black kraww with fire");
            
            other.GetComponent<KrawExplosion>().ExplodeNow();
            //antBlood.Play();
        }

        if (other.tag == "Mob" && other.GetComponent<burningHeadScript>() && iceMode)
        {
            
            //otherscript.burnTimer = 0;

        }
        if (other.tag == "Mob" && other.GetComponent<PrincessScript>())
        {
            PrincessScript otherscript = other.GetComponent<PrincessScript>();
            otherscript.burning = true;
            otherscript.burnTimer = 0;

        }
        if (other.tag == "Mob" && other.GetComponent<OgreScript>())
        {
            OgreScript ogreScript = other.GetComponent<OgreScript>();
            ogreScript.burning = true;
            ogreScript.burnTimer = 0;
        }

        if (other.tag == "Mob" && other.GetComponent<CreepyBanshee>())
        {
            other.GetComponent<CreepyBanshee>().Die();
        }

        if (other.tag == "Mob" && other.GetComponent<QueenScript>())
        {
            other.GetComponent<QueenScript>().burnTimer = 0;
            other.GetComponent<QueenScript>().burning = true;
        }

        if (other.tag == "DeadTree" || other.tag == "Fence")
        {
            other.tag = "Untagged";
            Destroy(other.gameObject, 5);
            var thisFire = Instantiate(fireForTree, other.transform.position, Quaternion.identity);
            thisFire.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            thisFire.transform.Rotate(-90, 0, 0);
            Destroy(thisFire, 5);
            if (other.CompareTag("DeadTree"))
            {
                if (other.transform.GetChild(0))
                other.transform.GetChild(0).gameObject.SetActive(true);
            }
            //thisFire.transform.parent = other.transform;
        }
        if (other.tag == "LiveTree")
        {
            other.tag = "Untagged";
            Destroy(other.transform.parent.transform.parent.gameObject, 5);
            var thisFire = Instantiate(fireForTree, other.transform.position, Quaternion.identity);
            thisFire.transform.Rotate(-90, 0, 0);
            Destroy(thisFire, 5);
            //thisFire.transform.parent = other.transform;
        }
        if (other.tag == "WoodHouse")
        {
            other.tag = "Untagged";
            Destroy(other.gameObject, 5);
            var thisFire = Instantiate(fireForTree, other.transform.position, Quaternion.identity);
            thisFire.transform.localScale = thisFire.transform.localScale * 2;
            thisFire.transform.Rotate(-90, 0, 0);
            Destroy(thisFire, 5);
            //thisFire.transform.parent = other.transform;
            if (other.transform.parent.name == "Laboratorio")
            {
                sapivangas.Instance.Flee();
            }
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Mob")
        {
            if (other.GetComponent<OrcScript>())
            {
                other.GetComponent<OrcScript>().myBurn.Stop();
            }
        }
    }


}
