using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoFillScript : MonoBehaviour
{
    public bool isStaff;
    public bool isCrossbow;
    public bool isBazooka;
    public bool isMachinegun;
    float fillAmount;
    Image img;
    public Animator staffAnim;
    staffScript staffScript;
    public RawImage backGround;
    Animator bazookaAnim;
    Animator machineGunAnim;

    private void Start()
    {
        staffAnim = Controller.Instance.staff.GetComponent<Animator>();
        staffScript = staffAnim.GetComponent<staffScript>();
        bazookaAnim = BazookaScript.Instance.GetComponent<Animator>();
        machineGunAnim = MAchinegunScript.Instance.GetComponent<Animator>();
        img = GetComponent<Image>();
    }
    

    private void Update()
    {
        if (isStaff && Controller.Instance.gotStaff)
        {
            img.fillAmount = staffScript.Mana / 10;
            if (staffScript.Mana < 1)
            {
                backGround.color = Color.gray;
            }
            else
            {
                backGround.color = Color.white;
            }
        }
        if (isCrossbow && Controller.Instance.GotBallista)
        {
            
            img.fillAmount = (Controller.Instance.ammo / 100) * 1f;
            if (Controller.Instance.ammo < 1)
            {
                backGround.color = Color.gray;
            }
            else
            {
                backGround.color = Color.white;
            }
            //O maximo de flechas eh 100 no inicio. Entao, divide-se por 100.
        }
        if (isBazooka && Controller.Instance.gotBazooka)
        {
            img.fillAmount = Controller.Instance.Mushrooms / 50;
            if (Controller.Instance.Mushrooms < 1)
            {
                backGround.color = Color.gray;
            }
            else
            {
                backGround.color = Color.white;
            }

        }
        if (isMachinegun && Controller.Instance.gotMachinegun)
        {
            img.fillAmount = Controller.Instance.ammo / 100;
            if (Controller.Instance.ammo < 1)
            {
                backGround.color = Color.gray;
            }
            else
            {
                backGround.color = Color.white;
            }
        }
    }

}
