using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using UnityEditor;

public class Controller : MonoBehaviour {
    public GameObject shield2;
    public bool lvl2Shield;
    public Text lifeNumber;
    public bool gotGoldKey;
    public bool gotBlueKey;
    public Slider healthBar;
    public Slider healthBarBackGround;
    public Slider HigherBar;
    public bool holding;
    public GameObject[] lifes;
    public float life;
    public Rigidbody rigid;
    public int speed;
    public int runningSpeed;
    public int currentSpeed;
    Animator anim;
    Vector2 md;
    public bool chachoalha;
    public GameObject plane;
    bool direita;
    float shakeCounter;
    public bool death;
    public float maxLife;
    public GameObject heart4, heart4back;
    public GameObject heart5, heart5back;
    public GameObject heart6, heart6back;
    public GameObject heart7, heart7back;
    public GameObject heart8, heart8back;
    public GameObject heart9, heart9back;
    public GameObject heart10, heart10back;
    //public Text velocimetro;
    public GameObject sword;
    public Animator swordAnim;
    public bool gotStaff;
    public GameObject staff;
    public Animator staffAnim;
    public int coins;
    bool givingCoinNow;
    public float ammo;
    public Text ammoText;
    public GameObject arrowIcon;
    public bool GotBallista = false;
    public GameObject HandBallista;
    //public AudioSource CoinSound;
    public StudioEventEmitter coinSFX;
    //public AudioSource TenCoinSound;
    public StudioEventEmitter TenCoinEmitter;
    public GameObject damageFlare;
    Animator damageFlareAnim;
    public Text coinText;
    public GameObject coguBombaPrefab;
    public GameObject coguStart;
    public bool gotBazooka;
    public GameObject bazooka;
    public bool bazookaLock;
    public float Mushrooms;
    public Text MushroomText;
    public bool gotMachinegun = false;
    public GameObject deathPanel;
    public GameObject gamePanel;
    public GameObject[] Icons;
    public AudioSource berzerkLoop;
    public int berzerkSpeed;
    public bool berzerkState;
    float berzerkTimer;
    public GameObject InvisibleSphere;
    public GameObject mushroomIcon;
    public AudioSource getPotSound;
    public int storedPotions;
    public StudioEventEmitter drinkPotionSound;
    public GameObject potCanvasIcon;
    public Text potCanvasText;
    public bool gotFirstPotion;
    public bool onFloor;
    public bool onClutter;
    public GameObject lens;
    public bool isMounted = false;
    Animator ballistaAnimator;
    public GameObject miraCanvas;
    public GameObject aimSpot;
    public bool onWater;
    public bool StickedToHorse;
    public bool consumedMushTutorial;
    public GameObject debugBall;
    // Use this for initialization
    float previousLife;
    public Camera myCam;
    public MeshRenderer[] BazookaMeshes;
    public MeshRenderer[] MachineGunMeshes;
    public GameObject myLittleGriffin;
    public StudioEventEmitter grassFootstep;
    public StudioEventEmitter gravelFootstep;
    public StudioEventEmitter groundFootstep;
    public string OffString;
    public bool onGrass = true;
    public bool onGravel;
    public bool onGround;
    public float timePassed;
    float DistanceFromTarget;
    public UITweenScript shieldPulse;

    public UITweenScript shield1;

    static Controller m_Instance;
    public static Controller Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(Controller)) as Controller;
            return m_Instance;
        }
    }


    public void ShakeShields()
    {
        //Debug.Log("Should be shaking shields");
        if (shieldPulse)
        {
            shieldPulse.Shake();
        }
        
        shield1.Shake();
    }

    public void TurnToGravelFoot()
    {
        onGrass = false;
        onGround = false;
        onGravel = true;
    }
    public void TurnToDirtFoot()
    {
        onGrass = false;
        onGround = true;
        onGravel = false;
    }

    public void TurnToGrassFoot()
    {
        onGrass = true;
        onGround = false;
        onGravel = false;
    }


    

    public void playFootstepSound()
    {
        if (onGrass)
        {
            
            grassFootstep.Play();
        }
        else if (onGround)
        {
            
            groundFootstep.Play();
        }
        else if (onGravel)
        {
            gravelFootstep.Play();
        }
    }

    public void PlayPotSound()
    {
        gotFirstPotion = true;
        getPotSound.Play();
        potCanvasIcon.SetActive(true);
        potCanvasText.gameObject.SetActive(true);
        potCanvasText.text = ""+ storedPotions;
}

    void Start () {
        if (lvl2Shield)
        {
            shield2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("GotBallista") == 1)
        {
            ammo = 15;
            UpdateArrowText();
            HandBallista.SetActive(true);
            GotBallista = true;
            swordAnim.SetBool("Off", true);
            GotBallista = true;
        }
        OffString = "Off";
        QualitySettings.vSyncCount = 0; // TALVEZ DE MERDA, TIRAR ISSO SE PA
        
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            CheckHealthAndHearts();
        }
        myCam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (PlayerPrefs.GetInt("GotSword") == 1)
        {
            Icons[0].SetActive(true);
        }
        if (gotStaff)
        {
            Icons[1].SetActive(true);

        }
        if (GotBallista)
        {
            Icons[2].SetActive(true);
            Icons[3].SetActive(true);
        }
        if (gotBazooka)
        {
            Icons[4].SetActive(true);
            Icons[5].SetActive(true);
        }
        if (gotMachinegun)
        {
            Icons[6].SetActive(true);
        }

        damageFlare.SetActive(true);
        damageFlareAnim = damageFlare.GetComponent<Animator>();
        if (GameManager.Instance && GameManager.Instance.toLoad == false && SceneManager.GetActiveScene().name != "SniperMap")
        {
            ammo = 5;
            
            maxLife = 30;
            if (GameManager.Instance && GameManager.Instance.hard == false && GameManager.Instance.nightmare == false && GameManager.Instance.normal == false)
            {
                maxLife = 60;
            }
            life = maxLife;
        }
        
        Cursor.visible = false;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        swordAnim = sword.GetComponent<Animator>();
        staffAnim = staff.GetComponent<Animator>();
        ballistaAnimator = HandBallista.GetComponent<Animator>();

        previousLife = life;
        StartCoroutine(AppearAfterStart());
        lifeNumber.text = life.ToString();
        healthBar.value = life / 100;
        healthBarBackGround.value = maxLife / 100;
        if (life > 100)
        {
            healthBar.value = 1;
            healthBarBackGround.value = 1;
            if (HigherBar)
            {
                HigherBar.gameObject.SetActive(true);
                HigherBar.value = (life - 100) / 100;
            }
            
        }
    }

    IEnumerator AppearAfterStart()
    {
        
        if (gotBazooka)
        {
            for (int i = 0; i < BazookaMeshes.Length; i++)
            {
                BazookaMeshes[i].enabled = true;
            }
        }
        if (gotMachinegun)
        {
            for (int i = 0; i < MachineGunMeshes.Length; i++)
            {
                MachineGunMeshes[i].enabled = true;
            }
        }
        WaitForSeconds wfs = new WaitForSeconds(2);
        yield return wfs;
        
        for (int i = 0; i < BazookaMeshes.Length; i++)
        {
            
            BazookaMeshes[i].enabled = true;
        }
        
        for (int i = 0; i<MachineGunMeshes.Length; i++)
        {
            
            MachineGunMeshes[i].enabled = true;
        }
        //yield return null;
    }
    // Update is called once per frame


        public void AddAmmo(int quantity)
    {
        ammo += quantity;
        if (ammo > 100)
        {
            ammo = 100;
        }
        UpdateArrowText();
    }

    private void FixedUpdate()
    {
        if (lvl2Shield && !shield2.activeInHierarchy)
        {
            shield2.SetActive(true);
        }
        //Application.targetFrameRate = 30;
        
        timePassed += Time.deltaTime;
        if (death)
        {
            swordAnim.SetBool(OffString, true);
            staffAnim.SetBool(OffString, true);
            HandBallista.GetComponent<Animator>().SetBool(OffString, true);
            BazookaScript.Instance.GetComponent<Animator>().SetBool(OffString, true);
            MAchinegunScript.Instance.GetComponent<Animator>().SetBool(OffString, true);
            return;
        }
        
    }

    public void BerzerkNow()
    {
        
        berzerkTimer = 20;
        berzerkState = true;
        berzerkLoop.Play();
        //currentSpeed = berzerkSpeed;
        swordAnim.speed = 2;
        HandBallista.GetComponent<Animator>().speed = 2;
        staffAnim.speed = 2;
        BazookaScript.Instance.GetComponent<Animator>().speed = 2;
        MAchinegunScript.Instance.GetComponent<Animator>().speed = 2;

    }
    public void StopBerzerkNow()
    {
        berzerkState = false;
        berzerkTimer = 0;
        //anim.speed = 1;
        sword.GetComponent<Animator>().speed = 1;
        HandBallista.GetComponent<Animator>().speed = 1;
        staff.GetComponent<Animator>().speed = 1;
        BazookaScript.Instance.GetComponent<Animator>().speed = 1;
        MAchinegunScript.Instance.GetComponent<Animator>().speed = 1;
        berzerkLoop.Stop();
        //currentSpeed = speed;
        //berzerkLoop.Stop();
    }

    public void GetMachinegun()
    {
        if (swordAnim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = false;
        }
        Icons[6].SetActive(true);
        gotMachinegun = true;
        sword.GetComponent<Animator>().SetBool(OffString, true);
        staff.GetComponent<Animator>().SetBool(OffString, true);
        staffScript.Instance.CeaseFire();
        
        HandBallista.GetComponent<Animator>().SetBool(OffString, true);
        bazooka.GetComponent<Animator>().SetBool(OffString, true);
        MAchinegunScript.Instance.GetComponent<Animator>().SetBool(OffString, false);
        ammo += 24;
        UpdateArrowText();
    }

    public void UpdateArrowText()
    {
       ammoText.gameObject.SetActive(true);
        if (arrowIcon.activeInHierarchy == false)
        {
            arrowIcon.SetActive(true);
        }
        ammoText.text = ""+ammo;
    }

    public void GetBallista()
    {
        staffAnim.SetBool(OffString, true);
        BazookaScript.Instance.anim.SetBool(OffString, true);
        swordAnim.SetBool(OffString, true);
        
        GotBallista = true;
        HandBallista.SetActive(true);
        ammo += 15;
        UpdateArrowText();
    }

    public void PlayCoinSound()
    {
        coinText.text = "" + coins;
        coinSFX.Play();
    }

    public void ThrowCogu()
    {
        Instantiate(coguBombaPrefab, coguStart.transform.position, coguStart.transform.rotation);
    }

    public void UpdateMushroomText()
    {
        mushroomIcon.SetActive(true);
        MushroomText.gameObject.SetActive(true);
        MushroomText.text = "" + Mushrooms;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }

    public void SetMira()
    {
        
        int m_LayerToDetect = LayerMask.GetMask("Default");
        Ray ray = new Ray(transform.position, transform.forward * 100);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * 100, out hit, 100, m_LayerToDetect) && hit.transform.gameObject != myLittleGriffin)
        {
            
            debugBall.transform.position = hit.point;
            aimSpot.transform.position = hit.point;
            
        }
        else
        {
            
            debugBall.transform.position = transform.position + transform.forward * 100;
            aimSpot.transform.position = transform.position + transform.forward * 100;
        }
        
        //mira.transform.localScale = (1 + (distanceToTarget * 100000)) * Vector3.one;
    }

    public void ClearFog()
    {
        RenderSettings.fogDensity = 0.008f;
    }

    void MountNow()
    {
        GriffinKraw.Instance.mountCooldown = 0;
        swordAnim.SetBool(OffString, true);
        staffAnim.SetBool(OffString, true);
        ballistaAnimator.SetBool(OffString, true);
        BazookaScript.Instance.anim.SetBool(OffString, true);
        MAchinegunScript.Instance.anim.SetBool(OffString, true);
        GriffinKraw.Instance.rigid.isKinematic = false;
        GriffinKraw.Instance.QSign.SetActive(false);
        GriffinKraw.Instance.mountedOn = true;
        //GetComponent<SphereCollider>().enabled = false; //MUDAR ISSO POSTERIORMENTE
        isMounted = true;
        empurrador.Instance.SwitchIcon();
    }

    void giveCoinNow()
    {

        if (maxLife == 4)
        {
            //heart4back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 5)
        {
            //heart5back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 6)
        {
            //heart6back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 7)
        {
            //heart7back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 8)
        {
            //heart8back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 9)
        {
            //heart9back.SetActive(true);
            givingCoinNow = false;
        }
        if (maxLife == 10)
        {
            //heart10back.SetActive(true);
            givingCoinNow = false;
        }
    }

    public void chachoalhaNow()
    {
        damageFlareAnim.SetBool("damage", true);
        shakeCounter += Time.deltaTime;
        if (!direita)
        {
            direita = true;
            transform.Translate(transform.right * -0.05f);
        }
        else if (direita)
        {
            direita = false;
            transform.Translate(transform.right * 0.05f);
        }
        if (shakeCounter >= 0.35f)
        {
            chachoalha = false;
            shakeCounter = 0;
        }
        if (isMounted)
        {
            CheckHealthAndHearts();
        }
    }

    public void MaxedCoins()
    {
        
        TenCoinEmitter.Play();
        shieldPulse.Pulse();
        coins = 0;
        //maxLife += 10;
        //life = maxLife;
        givingCoinNow = true;
        coinText.text = "0";
        lvl2Shield = true;
        shield2.SetActive(true);
        //CheckHealthAndHearts();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Q) && !isMounted && GriffinKraw.Instance && GriffinKraw.Instance.canBeMounted && Vector3.Distance(GriffinKraw.Instance.transform.position, transform.position) < 3)
        {
            MountNow();
            
        }
        
        if (isMounted)
        {
            if (!death)
            {
                SetMira();
                transform.position = GriffinKraw.Instance.playerPos.transform.position;
            }
            else
            {
                GetComponent<SphereCollider>().enabled = true;
                rigid.drag = 0.1f;
                rigid.constraints = RigidbodyConstraints.None;
                
            }
            return;
        }
        
        if (!death && Input.GetKeyDown(KeyCode.Escape))
        {
            gamePanel.SetActive(true);
        }

        if (death)
        {
            deathPanel.SetActive(true);
            return;
        }
        
            SetMira();
        
        if (!bazookaLock && gotBazooka)
        {
            if (swordAnim.GetBool("Golden"))
            {
                sword.GetComponent<weaponscript>().lastCollider.enabled = false;
            }
            UpdateMushroomText();
            bazookaLock = true;
            BazookaScript.Instance.anim.SetBool(OffString, false);
            if (staffScript.Instance)
            {
                
                staffScript.Instance.CeaseFire();
            }
            
            swordAnim.SetBool(OffString, true);
            staffAnim.SetBool(OffString, true);
            ballistaAnimator.SetBool(OffString, true);
            Mushrooms += 8;
            UpdateMushroomText();
        }

        if (gotBazooka && Input.GetKey(KeyCode.Alpha4))
        {
            BazookaScript.Instance.anim.SetBool(OffString, false);
        }

        //if (coins > 19)
        //{
            //MaxedCoins();
            
        //}
        
        if (storedPotions > 0 && Input.GetKeyDown(KeyCode.F))
        {
            if (life < maxLife)
            {
                storedPotions--;
                life += 10;
                if (life >= maxLife)
                {
                    life = maxLife;
                }
                drinkPotionSound.Play();
                potCanvasText.text = "" + storedPotions;
            }
            
        }

        if (givingCoinNow)
        {
            giveCoinNow();
            
        }

        

        if (chachoalha)
        {
            chachoalhaNow();
            
        }

        if (previousLife != life)
        {
            previousLife = life;
            CheckHealthAndHearts();
        }

        if (death)
        {
            rigid.constraints = RigidbodyConstraints.None;
            sword.SetActive(false);
        }
        
        if (GotBallista && Input.GetMouseButton(1) && ballista.Instance && ballista.Instance.isDrawn)
        {
            //PlayerRotationScript.Instance.sensitivityX = 2;
            //PlayerRotationScript.Instance.sensitivityY = 2;

            myCam.fieldOfView = 20;
            lens.SetActive(true);
            
        }
        else
        {
            //PlayerRotationScript.Instance.sensitivityX = 5;
            //PlayerRotationScript.Instance.sensitivityY = 5;
            lens.SetActive(false);
            myCam.fieldOfView = 60;
        }

	}

    public void CheckHealthAndHearts()
    {
        //o fill aceita valores de 0 a 1. 0 eh zero, 1 eh 100. Dividir por 100 o valor do hp
        healthBar.value = life / 100;
        lifeNumber.text = life.ToString();
        if (life >= 100)
        {
            healthBar.value = 1;
            if (HigherBar)
            {
                HigherBar.gameObject.SetActive(true);
                HigherBar.value = (life - 100) / 100;
            }
            

        }
        else
        {
            if (HigherBar)
            {
                HigherBar.gameObject.SetActive(false);
            }
            
        }
        /*
        if (life == 10)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(true);
            lifes[6].SetActive(true);
            lifes[7].SetActive(true);
            lifes[8].SetActive(true);
            lifes[9].SetActive(true);
            heart10back.SetActive(true);
            heart9back.SetActive(true);
            heart8back.SetActive(true);
            heart7back.SetActive(true);
            heart6back.SetActive(true);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 9)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(true);
            lifes[6].SetActive(true);
            lifes[7].SetActive(true);
            lifes[8].SetActive(true);
            lifes[9].SetActive(false);
            heart9back.SetActive(true);
            heart8back.SetActive(true);
            heart7back.SetActive(true);
            heart6back.SetActive(true);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 8)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(true);
            lifes[6].SetActive(true);
            lifes[7].SetActive(true);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
            heart8back.SetActive(true);
            heart7back.SetActive(true);
            heart6back.SetActive(true);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 7)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(true);
            lifes[6].SetActive(true);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
            heart7back.SetActive(true);
            heart6back.SetActive(true);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 6)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(true);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
            heart6back.SetActive(true);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 5)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(true);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
            heart5back.SetActive(true);
            heart4back.SetActive(true);
        }
        if (life == 4)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(true);
            lifes[4].SetActive(false);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
            heart4back.SetActive(true);
        }

        if (life == 3)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(true);
            lifes[3].SetActive(false);
            lifes[4].SetActive(false);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
        }
        if (life == 2)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(true);
            lifes[2].SetActive(false);
            lifes[3].SetActive(false);
            lifes[4].SetActive(false);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
        }
        if (life == 1)
        {
            lifes[0].SetActive(true);
            lifes[1].SetActive(false);
            lifes[2].SetActive(false);
            lifes[3].SetActive(false);
            lifes[4].SetActive(false);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);
        }
        if (life <= 0)
        {
            death = true;
            lifes[0].SetActive(false);
            lifes[1].SetActive(false);
            lifes[2].SetActive(false);
            lifes[3].SetActive(false);
            lifes[4].SetActive(false);
            lifes[5].SetActive(false);
            lifes[6].SetActive(false);
            lifes[7].SetActive(false);
            lifes[8].SetActive(false);
            lifes[9].SetActive(false);

        }
        */
        if (life <= 0)
        {
            //rigid.drag = 8;
            //rigid.angularDrag = 0.2f;
            //rigid.mass = 70;
            death = true;
        }

            if (isMounted && death)
        {
            deathPanel.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
            onWater = false;
            onClutter = false;
        }
        
        else if (collision.gameObject.CompareTag("Clutter") && !onFloor)
        {
            onFloor = false;
            onWater = false;
            onClutter = true;
        }
        else if (collision.gameObject.CompareTag("Water") && !onFloor)
        {
            onFloor = false;
            onWater = true;
            onClutter = false;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
            
        }
        if (collision.gameObject.CompareTag("Clutter"))
        {
            onClutter = false;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            onWater = false;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
        if (collision.gameObject.CompareTag("Clutter"))
        {
            onClutter = true;
        }
    }
    //salvar direto no PlayerPrefs quando o player usar o ice pela primeira vez. Se essa variavel estiver marcada como 1, destruir o mouseTutorial e nao chamar mais. Checar isso
    //no onEnable do staff.
    public void GetStaff()
    {
        gotStaff = true;
        if (swordAnim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = false;
        }
        
        
        staff.SetActive(true);
        staffAnim.SetBool(OffString, false);
        BazookaScript.Instance.anim.SetBool(OffString, true);
        swordAnim.SetBool(OffString, true);
        GotBallista = true;
        ballistaAnimator.SetBool(OffString, true);
        //staff.GetComponent<staffScript>().ceaseFireSFX.SetActive(false);
        StartCoroutine(WaitALittleAndDeactivate(staff.GetComponent<staffScript>().ceaseFireSFX, 0f));
        if (staffScript.Instance.mouseTutorial)
        {
            staffScript.Instance.mouseTutorial.SetActive(true);
        }
        
    }
    IEnumerator WaitALittleAndDeactivate(GameObject obj, float time)
    {
        if (!staff.GetComponent<staffScript>().ceaseFireSFX.activeInHierarchy)
        {
            Debug.Log("DEACTIVATING CEASEFIRESFX BUT IT WAS INACTIVE ALREADY");
        }
        if (staff.GetComponent<staffScript>().ceaseFireSFX.activeInHierarchy)
        {
            Debug.Log("DEACTIVATING CEASEFIRESFX AND IT WAS ACTIVE");
        }
        yield return new WaitForSeconds(time);
        staff.GetComponent<staffScript>().ceaseFireSFX.SetActive(false);
    }
    public void DisableAllWeapons()
    {
        swordAnim.SetBool(OffString, true);
        ballistaAnimator.SetBool(OffString, true);
        staffAnim.SetBool(OffString, true);
        BazookaScript.Instance.anim.SetBool(OffString, true);
        MAchinegunScript.Instance.anim.SetBool(OffString, true);
    }

}
