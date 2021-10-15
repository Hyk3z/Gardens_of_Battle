using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    public GameObject[] objectsToDestroy;
    private void Update()
    {
        if (Input.GetKey(KeyCode.U) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GiveAllWeapons();
        }
        if (Input.GetKey(KeyCode.I) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Controller.Instance.maxLife = 10000;
            Controller.Instance.life = 10000;
        }
    }
    public void GiveAllWeapons()
    {
        for (int i = 0; i < objectsToDestroy.Length; i++)
        {
            if (objectsToDestroy[i])
            {
                objectsToDestroy[i].SetActive(false);
            }
            
        }
        
        Controller.Instance.sword.SetActive(true);
        Controller.Instance.staff.SetActive(true);
         Controller.Instance.GotBallista = true;
        Controller.Instance.gotBazooka = true;
        Controller.Instance.gotMachinegun = true;
        Controller.Instance.gotStaff = true;
        Controller.Instance.ammo = 100;
        Controller.Instance.Mushrooms = 100;
        Controller.Instance.maxLife = 100;
        Controller.Instance.life = 100;
        Controller.Instance.CheckHealthAndHearts();
        Controller.Instance.gotGoldKey = true;
        Controller.Instance.gotBlueKey = true;
    }
}
