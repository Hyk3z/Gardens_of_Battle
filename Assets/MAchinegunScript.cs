using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAchinegunScript : MonoBehaviour
{

    

    public Animator anim;
    public GameObject arrow;
    public GameObject shootOrigin;
    public GameObject staff;
    Animator staffAnim;
    public GameObject sword;
    Animator swordAnim;
    public GameObject ballista;
    Animator ballistaAnim;
    public GameObject bazooka;
    Animator bazookaAnim;
    public GameObject[] fakeArrows;
    public GameObject mira;
    float distanceToTarget;
    bool isFiring;
    static MAchinegunScript m_Instance;
    int fakeIndex;
    //public GameObject cylinder;


    public static MAchinegunScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(MAchinegunScript)) as MAchinegunScript;
            return m_Instance;
        }
    }

    public void SwapToSword()
    {
        if (sword.GetComponent<weaponscript>().Anim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = true;
        }
        selectionScript.Instance.GetBehindIcon(0);
        anim.SetBool("Off", true);
        swordAnim.SetBool("Off", false);
    }
    public void SwapToStaff()
    {
        
        if (Controller.Instance.gotStaff)
        {
            selectionScript.Instance.GetBehindIcon(1);
            anim.SetBool("Off", true);
            staffAnim.SetBool("Off", false);
        }
        
    }
    public void SwapToBallista()
    {
        if (Controller.Instance.GotBallista)
        {
            ballista.SetActive(true);
            ballista.SetActive(true);
            
            selectionScript.Instance.GetBehindIcon(2);
            anim.SetBool("Off", true);
            ballistaAnim.SetBool("Off", false);
        }

    }
    public void SwapToBazooka()
    {
        if (Controller.Instance.gotBazooka)
        {
            selectionScript.Instance.GetBehindIcon(3);
            anim.SetBool("Off", true);
            bazookaAnim.SetBool("Off", false);
            
        }

    }

    public void StartFiring()
    {
        //cylinder.transform.Rotate(cylinder.transform.up * 1);
    }

    public void ShootArrow()
    {
        if (!anim.GetBool("Fire") || Controller.Instance.death)
        {
            return;
        }
        if (Controller.Instance.ammo < 1)
        {
            return;
        }
        var currentArrow = Instantiate(arrow, shootOrigin.transform.position, shootOrigin.transform.rotation);
        currentArrow.GetComponent<arrow>().isFromMachine = true;
        currentArrow.GetComponent<arrow>().originalFather = shootOrigin;
        currentArrow.GetComponent<arrow>().shoot();
        Controller.Instance.ammo--;
        Controller.Instance.UpdateArrowText();
        fakeArrows[fakeIndex].SetActive(false);
        fakeIndex++;
        if (fakeIndex >= fakeArrows.Length)
        {
            fakeIndex = 0;
            for (int i = 0; i < fakeArrows.Length; i++)
            {
                fakeArrows[i].SetActive(true);
            }
        }
    }

    private void Start()
    {
        //anim = GetComponent<Animator>();
        //mudar tudo isso pra variaveis publicas
        swordAnim = sword.GetComponent<Animator>();
        ballistaAnim = ballista.GetComponent<Animator>();
        staffAnim = staff.GetComponent<Animator>();
        bazookaAnim = bazooka.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Controller.Instance.gotMachinegun || Time.timeScale == 0)
        {
            return;
        }
        if (Controller.Instance.death || anim.GetBool("Off") || Controller.Instance.death)
        {
            if (ballistaAnim.GetBool("Off"))
            {
                //mira.SetActive(false);
            }
            mira.SetActive(false);
            return;
        }
        
        //SetMira();
        if (!anim.GetBool("Off") && Input.GetMouseButton(0))
        {
            if (Controller.Instance.ammo > 0)
            {
                anim.SetBool("Fire", true);
                //isFiring = true;
                //StartFiring();
            }
            else
            {
                if (Controller.Instance.Mushrooms > 0 && Controller.Instance.gotBazooka)
                {
                    SwapToBazooka();
                }

                else if (Controller.Instance.gotStaff && staff.GetComponent<staffScript>().Mana > 2)
                {
                    
                        SwapToStaff();
                    
                }
                else
                {
                    SwapToSword();
                }
            }
        }
        else
        {
            anim.SetBool("Fire", false);
        }
        if (Controller.Instance.ammo < 1)
        {
            foreach (var item in fakeArrows)
            {
                item.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapToSword();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Controller.Instance.gotStaff)
            {
                SwapToStaff();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Controller.Instance.GotBallista)
            {
                SwapToBallista();
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Controller.Instance.gotBazooka)
            {
                SwapToBazooka();
                //anim.SetBool("Off", true);
                //bazooka.GetComponent<Animator>().SetBool("Off", false);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < fakeArrows.Length; i++)
            {
                fakeArrows[i].SetActive(true);

            }
            fakeIndex = 0;
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

    public void PlayFoot()
    {
        Controller.Instance.playFootstepSound();
    }
}
