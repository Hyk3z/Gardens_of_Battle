using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ballista : MonoBehaviour
{
    bool ableToShoot = true;
    public arrow[] Arrows;
    int arrowCount = 0;
    public GameObject boltRef;
    float timer;
    public float limit;
    bool NeedToReload;
    public GameObject sword;
    public GameObject staff;
    public Animator anim;
    public GameObject fakeArrow;
    public GameObject fakeArrowTip;
    public bool isOn;
    float offDelay;
    float distanceToTarget;
    public GameObject mira;
    public Text arrowText;
    MeshRenderer FakeArrowRend;
    MeshRenderer fakeArrowTipRend;
    int m_LayerToDetect;
    public bool isDrawn;
    bool shotEarlier;
    public GameObject ArrowMesh;
    // Start is called before the first frame update

    static ballista m_Instance;
    public static ballista Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(ballista)) as ballista;
            return m_Instance;
        }
    }

    public void PlayFoot()
    {
        if (!shotEarlier)
        {
            Controller.Instance.playFootstepSound();
        }
        
    }

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
        anim = GetComponent<Animator>();
        FakeArrowRend = fakeArrow.GetComponent<MeshRenderer>();
        fakeArrowTipRend = fakeArrowTip.GetComponent<MeshRenderer>();
        m_LayerToDetect = LayerMask.GetMask("Default");
    }


    public void SwapToSword()
    {
        if (sword.GetComponent<weaponscript>().Anim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = true;
        }
        selectionScript.Instance.GetBehindIcon(0);
        anim.SetBool("Off", true);
        isOn = false;
        sword.GetComponent<Animator>().SetBool("Off", false);
    }
    public void SwapToStaff()
    {
        selectionScript.Instance.GetBehindIcon(1);
        isOn = false;
        anim.SetBool("Off", true);
        staff.GetComponent<Animator>().SetBool("Off", false);
    }

    void SwapToBazooka()
    {
        if (Controller.Instance.gotBazooka)
        {
            selectionScript.Instance.GetBehindIcon(3);
            anim.SetBool("Off", true);
            BazookaScript.Instance.GetComponent<Animator>().SetBool("Off", false);
        }

    }

    public void BecomeAbleToShoot()
    {
        if (ableToShoot)
        {
            return;
        }
            
        fakeArrow.SetActive(true);
        ableToShoot = true;
    }

    // Update is called once per frame

    public void PlayFootIfMoving()//here we`re trying to fix the walk sound problem: running while attacking
    {
        if (shotEarlier)
        {
            return;
        }
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
            
            Controller.Instance.groundFootstep.Play();
        }
        else if (Controller.Instance.onGravel)
        {
            Controller.Instance.gravelFootstep.Play();
        }
        //shotEarlier = true;
        StartCoroutine(CleanEarlyShot());
    }

    IEnumerator CleanEarlyShot()
    {
        yield return new WaitForSeconds(0.3f);
        shotEarlier = false;
    }

    void Update()
    {
        
        if (Controller.Instance.ammo < 1)
        {
            ArrowMesh.SetActive(false);
            //FakeArrowRend.enabled = false;
            //fakeArrowTipRend.enabled = false;
        }
        if (Controller.Instance.death || Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !anim.GetBool("Off"))
        {
            SwapToBazooka();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && !anim.GetBool("Off"))
        {
            SwapToMachinegun();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !anim.GetBool("Off"))
        {
            SwapToSword();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !anim.GetBool("Off"))
        {
            if (Controller.Instance.gotStaff)
            {
                SwapToStaff();
            }

        }
        if (anim.GetBool("Off"))
        {
            mira.SetActive(false);
            isDrawn = false;
            return;

        }
        anim.SetBool("AbleToShoot", ableToShoot);
        isDrawn = true;
        //SetMira();
        if (Input.GetMouseButtonUp(0) && anim.GetBool("Shooting"))
        {
            anim.SetBool("Shooting", false);
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Shoot");
        }
        if (Input.GetMouseButton(0) && ableToShoot && !anim.GetBool("Close"))
        {
            
            if (Controller.Instance.ammo > 0)
            {
                anim.SetBool("Shooting", true);
                //anim.SetTrigger("Shoot");
                fakeArrow.SetActive(false);
                Fire();
                ableToShoot = false;
            }
            else if (Controller.Instance.gotBazooka && Controller.Instance.Mushrooms > 0)
            {
                SwapToBazooka();
            }
            else if (Controller.Instance.gotStaff && staffScript.Instance.Mana > 2)
            {
                SwapToStaff();
            }
            else
            {
                
                SwapToSword();
            }
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
    }

    void Fire()
    {
        if (NeedToReload)
        {
            if (arrowCount >= Arrows.Length)
            {
                arrowCount = 0;
            }
            Arrows[arrowCount].gameObject.SetActive(true);
            Arrows[arrowCount].ResetArrow();
            NeedToReload = false;
            
        }
        
        Arrows[arrowCount].gameObject.SetActive(true);
        Arrows[arrowCount].ResetArrow();
        Arrows[arrowCount].shoot();
        Controller.Instance.ammo--;
        Controller.Instance.UpdateArrowText();
        if (Controller.Instance.ammo < 1)
        {
            fakeArrow.SetActive(false);
        }
        //arrowText.text = "" + Controller.Instance.ammo;
        arrowCount++;
        if (arrowCount > Arrows.Length)
        {
            arrowCount = 0;
        }
        
        NeedToReload = true;
    }

}
