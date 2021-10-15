using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BazookaScript : MonoBehaviour
{
    public Animator anim;
    static BazookaScript m_Instance;
    public GameObject sword;
    Animator swordAnim;
    public GameObject staff;
    Animator staffAnim;
    public GameObject ballista;
    Animator ballistaAnim;
    Animator machinegunAnim;
    public GameObject fakeMushroom;
    //public GameObject aima;
    //public GameObject aimb;
    //public float powerFillAmount;
    //public Image[] powerFillers;
    float shootDelay;
    bool triggerShot;
    public static BazookaScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(BazookaScript)) as BazookaScript;
            return m_Instance;
        }
    }

    public void SwapToMachinegun()
    {
        if (Controller.Instance.gotMachinegun)
        {
            selectionScript.Instance.GetBehindIcon(4);
            anim.SetBool("Off", true);
            //Ballista.SetActive(true);
            machinegunAnim.SetBool("Off", false);
        }
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("Off"))
        {
            return;
            
            
        }
        if (shootDelay > 0)
        {
            shootDelay -= Time.deltaTime;
        }
        if (!anim.GetBool("Off") && Input.GetMouseButtonDown(0) && !triggerShot)
        {
            triggerShot = true;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        swordAnim = sword.GetComponent<Animator>();
        staffAnim = staff.GetComponent<Animator>();
        ballistaAnim = ballista.GetComponent<Animator>();
        machinegunAnim = MAchinegunScript.Instance.GetComponent<Animator>();
    }
    public GameObject coguPrefab;
    public GameObject coguStart;
    public void ShootMushroom()
    {
        coguStart.transform.LookAt(Controller.Instance.debugBall.transform.position);
        if (Controller.Instance.Mushrooms < 1)
        {
            return;
        }
        //detectar se eh o primeiro tiro a ser dado. Se for, ele passar pelo shootdelay. Se for o loop, com mouse segurado, ignorar o delay.
        if (!Input.GetMouseButton(0))
        {
            
            anim.SetBool("Fire", false); //ele esta repetindo a animacao e mandando tiro mesmo quando eu nao quero.
        }
        if ((shootDelay <= 0 && triggerShot) || (!triggerShot && Input.GetMouseButton(0)))
        {
            if (triggerShot)
            {
                triggerShot = false;
            }
            shootDelay = 0.5f;
            Instantiate(coguPrefab, coguStart.transform.position, coguStart.transform.rotation);
            Controller.Instance.Mushrooms--;
            Controller.Instance.UpdateMushroomText();
            if (Controller.Instance.Mushrooms < 1)
            {
                fakeMushroom.SetActive(false);
            }
        }
        
        
        
    }
    void SwapToStaff()
    {
        
        selectionScript.Instance.GetBehindIcon(1);
        anim.SetBool("Off", true);
        staffAnim.SetBool("Off", false);
    }

    void SwapToSword()
    {
        if (sword.GetComponent<weaponscript>().Anim.GetBool("Golden"))
        {
            sword.GetComponent<weaponscript>().lastCollider.enabled = true;
        }
        anim.SetBool("Off", true);
        swordAnim.SetBool("Off", false);
        selectionScript.Instance.GetBehindIcon(0);
    }

    void SwapToBallista()
    {
        selectionScript.Instance.GetBehindIcon(2);
        anim.SetBool("Off", true);
        ballistaAnim.SetBool("Off", false);
        ballista.SetActive(true);
    }

    private void Update()
    {
        
        
        if (!Controller.Instance.gotBazooka || Time.timeScale == 0)
        {
            return;
        }
        if (!anim.GetBool("Off") && staffAnim.GetBool("Off") == false)
        {
            
            staffAnim.SetBool("Off", true);
        }
        if (!anim.GetBool("Off") && ballistaAnim.GetBool("Off") == false)
        {
            
            ballistaAnim.SetBool("Off", true);
        }
        if (anim.GetBool("Off") || Controller.Instance.death)
        {
            shootDelay = 0;
            //Controller.Instance.miraCanvas.SetActive(true);
            //aima.SetActive(false);
            //aimb.SetActive(false);
            //powerFillers[0].gameObject.SetActive(false);
            //powerFillers[1].gameObject.SetActive(false);
            return;
        }
        //Controller.Instance.miraCanvas.SetActive(false);
        //aima.SetActive(true);
        //aimb.SetActive(true);
        if (Input.GetMouseButton(0) && !anim.GetBool("Off"))
        {
            /*
            if (powerFillAmount <= 0.3f)
            {
                powerFillAmount += Time.deltaTime;
                foreach (var item in powerFillers)
                {
                    item.gameObject.SetActive(true);
                    item.fillAmount = powerFillAmount * 3.33f;
                }
            }
            */
            if (Controller.Instance.Mushrooms > 0)
            {
                anim.SetBool("Fire", true);
            }
            else if (Controller.Instance.ammo > 0)
            {
                if (Controller.Instance.gotMachinegun)
                {
                    SwapToMachinegun();
                }
                else if (Controller.Instance.GotBallista)
                {
                    SwapToBallista();
                }
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
        else
        {
            anim.SetBool("Fire", false);
            /*
            if (powerFillAmount >= 0)
            {
                powerFillAmount -= Time.deltaTime;
                if (powerFillAmount < 0)
                {
                    powerFillAmount = 0;
                }
                foreach (var item in powerFillers)
                {
                    item.gameObject.SetActive(true);
                    item.fillAmount = powerFillAmount * 1.33f;
                }
            }
            */
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwapToSword();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !anim.GetBool("Off") && Controller.Instance.gotStaff)
        {
            SwapToStaff();
            
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !anim.GetBool("Off") && Controller.Instance.GotBallista)
        {
            SwapToBallista();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && !anim.GetBool("Off") && Controller.Instance.gotMachinegun)
        {
            SwapToMachinegun();
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
