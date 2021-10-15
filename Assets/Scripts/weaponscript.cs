using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FMODUnity;

public class weaponscript : MonoBehaviour {
    bool aptoAHitting;
    public Animator Anim;
    //public AudioSource swing;
    public StudioEventEmitter hit;
    public bool goswing;
    public bool hitting;
    float hitcooldown;
    float stoptimer;
    public GameObject staff;
    public bool isDrawn = true;
    float waiter;
    Animator staffAnim;
    public int damage;
    public bool hasStaff;
    public bool heldUp;
    MeshRenderer mesh;
    public bool returnedWithEggs;
    public GameObject Ballista;
    public bool gotMachinegun;
    float swingSoundCooldown;
    float swingTimer;
    public BoxCollider firstCollider;
    public BoxCollider lastCollider;
    public List <GameObject> victims;
    public StudioEventEmitter smallWoosh;
    public StudioEventEmitter smallAntHitSound;
    public StudioEventEmitter LongSwordWoosh;
    public ParticleSystem[] antBloods;
    float AttackTime;
    int bloodIndex;
    public Transform antBloodPosition;
    
    float playerSpeed;

    static weaponscript m_Instance;

    public StudioEventEmitter longSwordAntHit;
    public StudioEventEmitter longSwordFireHeadHit;
    public StudioEventEmitter longSwordGiantHit;

    public StudioEventEmitter smallSwordAntHit;
    public StudioEventEmitter smallSwordFireHeadHit;
    public StudioEventEmitter smallSwordGiantHit;

    public static weaponscript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(weaponscript)) as weaponscript;
            return m_Instance;
        }
    }

    public void PlayFootIfMoving()//here we`re trying to fix the walk sound problem: running while attacking
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            return;
        }
        if (Controller.Instance.onGrass)
        {
            Controller.Instance.grassFootstep.Play();
        }
        else if (Controller.Instance.onGround)
        {
            //Debug.Log("OnGroundPlaying");
            Controller.Instance.groundFootstep.Play();
        }
        else if (Controller.Instance.onGravel)
        {
            Controller.Instance.gravelFootstep.Play();
        }
    }


    public void PlayKrawwSmallImpact()
    {
        smallAntHitSound.Play();
    }

    public void PlayWoosh()
    {
        if (!Input.GetMouseButton(0))
        {
            //return;
        }
        if (!Anim.GetBool("Golden"))
        {
            //Debug.Log("Playing small sword sound");
            smallWoosh.Play();
        }
        else
        {
           // Debug.Log("Playing big sword sound");
           if (aptoAHitting)
            {
                LongSwordWoosh.Play();
            }
            
        }
    }
    


    //public GameObject swordAim;

        public void ChangeColliders()
    {
        firstCollider.enabled = false;
        lastCollider.enabled = true;
    }

    public void SwapToMachinegun()
    {
        if (Controller.Instance.gotMachinegun)
        {
            lastCollider.enabled = false;
            selectionScript.Instance.GetBehindIcon(4);
            Anim.SetBool("Off", true);
            //Ballista.SetActive(true);
            MAchinegunScript.Instance.GetComponent<Animator>().SetBool("Off", false);
        }
    }
    // Use this for initialization
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        
    }

    void Start () {
        if (GameManager.Instance)
        {
            GameManager.Instance.discartList.Add("GotSword");
        }
        
        Controller.Instance.Icons[0].SetActive(true);
        mesh = GetComponent<MeshRenderer>();
        if (damage == 0)
        {
            damage = 2;
        }
        Anim = GetComponent<Animator>();
        staffAnim = staff.GetComponent<Animator>();
        //swing = GetComponent<AudioSource>();
        swingSoundCooldown = 0.2f;
        swingTimer = swingSoundCooldown;
	}
	
    public void SwapToStaff()
    {
        lastCollider.enabled = false;
        if (Controller.Instance.gotStaff)
        {
            lastCollider.enabled = false;
            selectionScript.Instance.GetBehindIcon(1);
            staffAnim.SetBool("Off", false);
            Anim.SetBool("Off", true);
        }
        
    }

    public void SwapToBallista()
    {
        lastCollider.enabled = false;
        if (Controller.Instance.GotBallista)
        {
            lastCollider.enabled = false;
            Ballista.SetActive(true);
            
            selectionScript.Instance.GetBehindIcon(2);
            Anim.SetBool("Off", true);
            
            Ballista.SetActive(true);
            Ballista.GetComponent<Animator>().SetBool("Off", false);
        }
        
    }
    public void SwapToBazooka()
    {
        lastCollider.enabled = false;
        if (Controller.Instance.gotBazooka && Controller.Instance.death == false)
        {
            lastCollider.enabled = false;
            selectionScript.Instance.GetBehindIcon(3);
            Anim.SetBool("Off", true);
            BazookaScript.Instance.anim.SetBool("Off", false);
        }

    }

    public void playFoot()
    {
        Controller.Instance.playFootstepSound();
    }
    void Update () {
        
        if (Controller.Instance.death || Time.timeScale == 0 || Anim.GetBool(Controller.Instance.OffString))
        {
            return;
        }
        if (Controller.Instance.gotBazooka && Input.GetKeyDown(KeyCode.Alpha4))
        {
            
            SwapToBazooka();
        }


        if (returnedWithEggs)
        {
            Anim.SetBool(Controller.Instance.OffString, false);
            returnedWithEggs = false;
        }
            
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && !Anim.GetBool(Controller.Instance.OffString))
        {
           
            SwapToStaff();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !Anim.GetBool(Controller.Instance.OffString))
        {
            SwapToBallista();
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5) && !Anim.GetBool(Controller.Instance.OffString) && Controller.Instance.gotMachinegun)
        {
            SwapToMachinegun();
        }

        if (!isDrawn)
        {
            waiter += Time.deltaTime;
            if (waiter >= 0.2f && hasStaff)
            {
                waiter = 0;
                isDrawn = true;
            }
            
        }
        
        if (stoptimer < 0)
        {
            Time.timeScale = 0.9f;
            stoptimer += Time.deltaTime;
            if (stoptimer > 0)
            {
                Time.timeScale = 1;
            }
        }

        //fazer um array de victims que seja limpo sempre que aptoAHitting fique true, no caso da greatsword.

        if (!aptoAHitting)
        {
            hitcooldown += Time.deltaTime;
            if (hitcooldown >= 0.2f) //talvez isso bugue nos combos, vamos ver
            {
                aptoAHitting = true;
                victims.Clear();
                hitcooldown = 0;
            }
        }
        /*
        if (goswing && !smallWoosh.IsPlaying())
        {
            
            if (!smallWoosh.IsPlaying() && !Anim.GetBool("Golden"))
            {
                smallWoosh.Play();
                //swing.Play();
            }
            else if (Anim.GetBool("Golden") && swingTimer >= swingSoundCooldown - 0.1f)
            {
                swingTimer = 0;
                //swing.Play();
                
            }
        }
        if (swingTimer < swingSoundCooldown)
        {
            swingTimer += Time.deltaTime;
        }
        */
        if (AttackTime > 0) 
        {
            //AttackTime -= Time.deltaTime;
        }
        
        //if (AttackTime <= 0)
        //{
        if (!Input.GetMouseButton(0))
        {
            Anim.SetBool("attack", false);
        }
            
        //}
        
		if (Input.GetMouseButtonDown(0))
        {
            //AttackTime = 0.3f;
            Anim.Play("ComboHit1", 0);
            Anim.SetTrigger("SwingNow");
            Anim.SetBool("attack", true);
        }

        playerSpeed = Controller.Instance.rigid.velocity.magnitude;
        if(empurrador.Instance.x != 0 || empurrador.Instance.z != 0)
        {
            if (!empurrador.Instance.capsOn)
            {
                Anim.SetBool("PlayerWalking", true);
                Anim.SetBool("PlayerRunning", false);
            }
            if (empurrador.Instance.capsOn)
            {
                Anim.SetBool("PlayerWalking", true);
                Anim.SetBool("PlayerRunning", true);
            }
        }
        
        else
        {
            Anim.SetBool("PlayerRunning", false);
            Anim.SetBool("PlayerWalking", false);
        }
    }

    void BloodPooling()
    {
        
        antBloods[bloodIndex].transform.position = antBloodPosition.position;
        antBloods[bloodIndex].Play();
        antBloods[bloodIndex].transform.parent = null;
        bloodIndex++;
        if (bloodIndex >= antBloods.Length)
        {
            bloodIndex = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mob" && hitting)
        {
            
            if (aptoAHitting)
            {
                if (other.GetComponent<KrawScript>())
                {
                    other.GetComponent<KrawScript>().anim.SetBool("Hit", true);
                    //other.GetComponent<Animator>().Play("KrawHit", 0);
                    //hit.Play();
                    other.gameObject.GetComponent<KrawScript>().life = other.gameObject.GetComponent<KrawScript>().life - damage;
                    
                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        
                        
                        longSwordAntHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }
                    
                }
                if (other.GetComponent<CarrapatinhoScript>())
                {
                    other.GetComponent<CarrapatinhoScript>().anim.SetBool("Hit", true);
                    //other.GetComponent<Animator>().Play("KrawHit", 0);
                    //hit.Play();
                    //other.gameObject.GetComponent<CarrapatinhoScript>().life = other.gameObject.GetComponent<CarrapatinhoScript>().life - damage;
                    other.gameObject.GetComponent<CarrapatinhoScript>().DieNow();

                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();


                        longSwordAntHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }
                
                if (other.GetComponent<CarrapatoScript>())
                {
                    other.GetComponent<CarrapatoScript>().anim.SetBool("Hit", true);
                    //other.GetComponent<Animator>().Play("KrawHit", 0);
                    //hit.Play();
                    //other.gameObject.GetComponent<CarrapatinhoScript>().life = other.gameObject.GetComponent<CarrapatinhoScript>().life - damage;
                    other.gameObject.GetComponent<CarrapatoScript>().life -= 2;

                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();


                        longSwordAntHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }
                
                if (other.GetComponent<OrcScript>())
                {
                    if (other.GetComponent<OrcScript>().life <= 0)
                    {
                        return;
                    }
                    
                    other.GetComponent<OrcScript>().anim.SetTrigger("Hit");

                    other.gameObject.GetComponent<OrcScript>().life -= 2;
                    other.GetComponent<OrcScript>().hurtSFX.Play();
                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();


                        longSwordGiantHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }

                if (other.gameObject.GetComponent<OgreScript>())
                {
                    other.gameObject.GetComponent<OgreScript>().currentLife = other.gameObject.GetComponent<OgreScript>().currentLife - damage;
                    if (Anim.GetBool("Golden"))
                    {
                        longSwordGiantHit.Play();
                    }
                    else
                    {
                        smallSwordGiantHit.Play();
                    }
                }
                if (other.gameObject.GetComponent<burningHeadScript>())
                {
                    other.gameObject.GetComponent<burningHeadScript>().life = other.gameObject.GetComponent<burningHeadScript>().life - damage;
                    if (Anim.GetBool("Golden"))
                    {
                        longSwordFireHeadHit.Play();
                    }
                    else
                    {
                        smallSwordFireHeadHit.Play();
                    }
                }
                if (other.gameObject.GetComponent<PrincessScript>())
                {
                    BloodPooling();
                    other.gameObject.GetComponent<PrincessScript>().life = other.gameObject.GetComponent<PrincessScript>().life - damage;
                    if (Anim.GetBool("Golden"))
                    {
                        //BloodPooling();
                        longSwordAntHit.Play();
                    }
                    else
                    {
                        smallSwordAntHit.Play();
                    }
                }
                if (other.gameObject.GetComponent<CreepyBanshee>())
                {
                    other.gameObject.GetComponent<CreepyBanshee>().Die();
                    hit.Play();
                }
                
                stoptimer = -0.2f;
                aptoAHitting = false;
            }
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Mob" && hitting)
        {
            
            
            if (aptoAHitting && !Anim.GetBool("Golden"))
            {
                //SetDamage();
                stoptimer = -0.2f;
                if (other.GetComponent<Animator>())
                {
                    other.GetComponent<Animator>().SetBool("Hit", true);
                    //hit.Play();
                    //PlayKrawwSmallImpact();
                }
                
                if (other.gameObject.GetComponent<KrawScript>())
                {
                    other.GetComponent<KrawScript>().anim.SetTrigger("BeingHit");
                    other.GetComponent<KrawScript>().anim.SetBool("Hit", true);
                    other.gameObject.GetComponent<KrawScript>().life = other.gameObject.GetComponent<KrawScript>().life - damage;
                    smallSwordAntHit.Play();
                    BloodPooling();
                }
                
                if (other.GetComponent<CarrapatinhoScript>())
                {
                    other.GetComponent<CarrapatinhoScript>().anim.SetBool("Hit", true);
                    //other.GetComponent<Animator>().Play("KrawHit", 0);
                    //hit.Play();
                    //other.gameObject.GetComponent<CarrapatinhoScript>().life = other.gameObject.GetComponent<CarrapatinhoScript>().life - damage;
                    other.gameObject.GetComponent<CarrapatinhoScript>().DieNow();

                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();


                        longSwordAntHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }

                if (other.GetComponent<CarrapatoScript>())
                {
                    other.GetComponent<CarrapatoScript>().anim.SetBool("Hit", true);
                    //other.GetComponent<Animator>().Play("KrawHit", 0);
                    //hit.Play();
                    //other.gameObject.GetComponent<CarrapatinhoScript>().life = other.gameObject.GetComponent<CarrapatinhoScript>().life - damage;
                    other.gameObject.GetComponent<CarrapatoScript>().life -= 2;

                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();


                        longSwordAntHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }

                if (other.GetComponent<OrcScript>())
                {
                    if (other.GetComponent<OrcScript>().life <= 0)
                    {
                        return;
                    }
                    other.GetComponent<OrcScript>().anim.SetTrigger("Hit");
                    
                    other.gameObject.GetComponent<OrcScript>().life -= 2;

                    if (Anim.GetBool("Golden"))
                    {
                        //Debug.Log("Playing particle");
                        other.GetComponent<OrcScript>().hurtSFX.Play();
                        BloodPooling();


                        longSwordGiantHit.Play();
                    }
                    else
                    {
                        //Debug.Log("Playing particle");
                        BloodPooling();
                        smallSwordAntHit.Play();
                    }

                }

                if (other.gameObject.GetComponent<OgreScript>())
                {
                    other.gameObject.GetComponent<OgreScript>().currentLife = other.gameObject.GetComponent<OgreScript>().currentLife - damage;

                    other.gameObject.GetComponent<OgreScript>().damaged.Play();
                    //hit.Play();
                    smallSwordGiantHit.Play();
                }
                if (other.gameObject.GetComponent<QueenScript>())
                {
                    other.gameObject.GetComponent<QueenScript>().detectou = true;
                    other.gameObject.GetComponent<QueenScript>().life = other.gameObject.GetComponent<QueenScript>().life - damage;
                    hit.Play();
                    smallSwordAntHit.Play();
                }
                if (other.gameObject.GetComponent<burningHeadScript>())
                {
                    other.gameObject.GetComponent<burningHeadScript>().life = other.gameObject.GetComponent<burningHeadScript>().life - damage;
                    smallSwordFireHeadHit.Play();
                }
                if (other.gameObject.GetComponent<PrincessScript>())
                {
                    
                    other.gameObject.GetComponent<PrincessScript>().life = other.gameObject.GetComponent<PrincessScript>().life - damage;
                    smallSwordAntHit.Play();
                }
                
                //Debug.Log("HITOU");
                aptoAHitting = false;
            }
            if (Anim.GetBool("Golden"))
            {
                //inserir cada mob novo em um array que vai ser limpo no aptoAHitting. Fazer isso tambem no OnTriggerEnter.
                if (!victims.Contains(other.gameObject))
                {
                    victims.Add(other.gameObject);
                    stoptimer = -0.2f;
                    if (other.GetComponent<Animator>())
                    {
                        other.GetComponent<Animator>().SetBool("Hit", true);
                        
                    }

                    if (other.gameObject.GetComponent<KrawScript>())
                    {
                        other.gameObject.GetComponent<KrawScript>().life = other.gameObject.GetComponent<KrawScript>().life - damage;
                        longSwordAntHit.Play();
                        BloodPooling();
                        smallSwordAntHit.Play();
                        
                    }

                    if (other.GetComponent<OrcScript>())
                    {
                        if (other.GetComponent<OrcScript>().life <= 0)
                        {
                            return;
                        }
                        other.GetComponent<OrcScript>().anim.SetTrigger("Hit");
                        other.GetComponent<OrcScript>().hurtSFX.Play();
                        other.gameObject.GetComponent<OrcScript>().life -= 2;

                        if (Anim.GetBool("Golden"))
                        {
                            //Debug.Log("Playing particle");
                            BloodPooling();


                            longSwordGiantHit.Play();
                        }
                        else
                        {
                            //Debug.Log("Playing particle");
                            BloodPooling();
                            smallSwordAntHit.Play();
                        }

                    }

                    if (other.gameObject.GetComponent<OgreScript>())
                    {
                        other.gameObject.GetComponent<OgreScript>().currentLife = other.gameObject.GetComponent<OgreScript>().currentLife - damage;

                        other.gameObject.GetComponent<OgreScript>().damaged.Play();
                        longSwordGiantHit.Play();
                    }
                    if (other.gameObject.GetComponent<QueenScript>())
                    {
                        other.gameObject.GetComponent<QueenScript>().detectou = true;
                        other.gameObject.GetComponent<QueenScript>().life = other.gameObject.GetComponent<QueenScript>().life - damage;
                        longSwordAntHit.Play();
                    }
                    if (other.gameObject.GetComponent<burningHeadScript>())
                    {
                        other.gameObject.GetComponent<burningHeadScript>().life = other.gameObject.GetComponent<burningHeadScript>().life - damage;
                        longSwordFireHeadHit.Play();
                    }
                    if (other.gameObject.GetComponent<PrincessScript>())
                    {
                        BloodPooling();
                        other.gameObject.GetComponent<PrincessScript>().life = other.gameObject.GetComponent<PrincessScript>().life - damage;
                        longSwordAntHit.Play();
                    }

                    //Debug.Log("HITOU");
                    aptoAHitting = false;
                }

            }
            
            //hitting = false;
        }
    }
}
