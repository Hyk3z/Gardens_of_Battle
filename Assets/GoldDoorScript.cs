using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoldDoorScript : MonoBehaviour
{
    public bool isBlueKey;
    public float timeToDestroy;
    public GameObject goldKey4Anim;
    public Animator lockAnim;
    public GameObject xplos;
    public GameObject QBack;
    bool playerIsNear;
    public GameObject[] objectsToDestroy;
    public UnityEvent DoOnUnlock;
    public GameObject keyGlowUI;

    //public GameObject icon;

        

    public void startLockAnimation()
    {
        goldKey4Anim.SetActive(true);
        lockAnim.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false; 
        }
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (!isBlueKey)
            {
                if (Input.GetKeyDown(KeyCode.Q) && Controller.Instance.gotGoldKey)
                {
                    startLockAnimation();
                    
                    Destroy(gameObject, timeToDestroy);
                    for (int i = 0; i < objectsToDestroy.Length; i++)
                    {
                        Destroy(objectsToDestroy[i], timeToDestroy);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Q) && Controller.Instance.gotBlueKey)
                {
                    startLockAnimation();

                    Destroy(gameObject, timeToDestroy);
                    for (int i = 0; i < objectsToDestroy.Length; i++)
                    {
                        Destroy(objectsToDestroy[i], timeToDestroy);
                    }
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (QBack)
        {
            
            Destroy(QBack);
        }
        if (keyGlowUI)
        {
            keyGlowUI.SetActive(false);
        }
        
        DoOnUnlock.Invoke();
        xplos.gameObject.SetActive(true);
        xplos.transform.parent = null;
        
    }

}
