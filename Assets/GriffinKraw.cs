using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GriffinKraw : MonoBehaviour
{
    public Transform playerPos;
    static GriffinKraw m_Instance;
    public Transform antToRotate;
    public Transform lookToVelocity;
    public GameObject tutorial;
    public bool playerOnRange;
    public GameObject QSign;
    public bool canBeMounted;
    public AudioSource flyNoise;
    public GameObject GameMenu;
    public GameObject PanelTutorial;
    public Text tutorialText;
    bool tutorialLock;
    bool secondsTutorialLock;
    public GameObject dropSpot;
    public float mountCooldown;
    public GameObject missilePrefab;
    string IdleString;
    string FloorString;
    string PlayerString;
    string FadeString;
    public static GriffinKraw Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(GriffinKraw)) as GriffinKraw;
            return m_Instance;
        }
    }

    public bool mountedOn;
    public Animator anim;
    public Rigidbody rigid;
    bool up;
    public float upForce;
    float x;
    float z;
    public bool onFloor;
    public GameObject queenDeath;
    public GameObject BoltPrefab;
    //public Transform shootOrigin;
    bool shoot;
    bool missile;
    float spitCooldown;
    public GameObject missileOrigin;

    private void Start()
    {
        IdleString = "Idle";
        FloorString = "Floor";
        PlayerString = "Player";
        FadeString = "Fade";
    }

    void ShowGriffinTutorial()
    {
        queenDeath.GetComponent<ParticleSystem>().Stop();
        
        PanelTutorial.SetActive(true);
        PanelTutorial.GetComponent<Animator>().SetBool(FadeString, false);
        tutorialText.GetComponent<Animator>().SetBool(FadeString, false);
        tutorialText.text = "Hold SPACE key to take off. Use the Mouse buttons to shoot.";
    }
    void ShootMissile()
    {
        Instantiate(missilePrefab, missileOrigin.transform.position, missileOrigin.transform.rotation);
        //Instantiate(missilePrefab, missileOrigin.transform.position, missileOrigin.transform.rotation);
    }
    void ShootBolt()
    {
        Instantiate(BoltPrefab, missileOrigin.transform.position, missileOrigin.transform.rotation);
    }

    private void FixedUpdate()
    {
        
        if (!mountedOn)
        {
            return;
        }
        up = Input.GetKey(KeyCode.Space);
        shoot = Input.GetMouseButton(0);
        missile = Input.GetMouseButton(1);
        if (up && transform.position.y < 60)
        {
            rigid.AddForce(transform.up * upForce/1.5f);
        }
        if (shoot && spitCooldown >= 1)
        {
            spitCooldown = 0;
            ShootBolt();
        }
        if (missile && spitCooldown >= 1)
        {
            spitCooldown = 0;
            ShootMissile();
        }
        if (spitCooldown < 1)
        {
            spitCooldown += Time.deltaTime;
        }
    }

    
    private void Update()
    {
        if (!mountedOn || Controller.Instance.death)
        {
            if (Controller.Instance.death)
            {
                rigid.isKinematic = true;
            }
            return;
        }
        else if (!tutorialLock)
        {
            tutorialLock = true;
            ShowGriffinTutorial();
        }

        if (mountCooldown < 0.3f)
        {
            mountCooldown += Time.deltaTime;
        }

        if (onFloor)
        {
            if (rigid.velocity.magnitude < 0.3f)
            {
                anim.SetBool(IdleString, true);
                if (flyNoise.isPlaying)
                {
                    flyNoise.Stop();
                }
                
            }
            
        }
        else
        {
            anim.SetBool(IdleString, false);
            if (!flyNoise.isPlaying)
            {
                flyNoise.Play();
                if (!secondsTutorialLock)
                {
                    PanelTutorial.GetComponent<Animator>().SetBool(FadeString, true);
                    tutorialText.GetComponent<Animator>().SetBool(FadeString, true);
                    secondsTutorialLock = true;
                }
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMenu.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(FloorString) && mountedOn)
        {
            onFloor = true;
        }
        if (other.CompareTag(PlayerString) && canBeMounted)
        {
            playerOnRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(FloorString))
        {
            onFloor = false;
        }
        if (other.CompareTag(PlayerString) && canBeMounted)
        {
            playerOnRange = false;
        }
    }
    public void EnableToMount()
    {
        canBeMounted = true;
        QSign.SetActive(true);
    }

    

}
