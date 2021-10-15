using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyScript : MonoBehaviour
{
    public bool goldKey;
    public bool blueKey;
    public GameObject QTuto;
    public GameObject Icon;
    public UnityEvent onCollectEvent;
    public GameObject keyGlowUI;


    private void Start()
    {
        if (goldKey)
        {
            Debug.Log("this key is golden");
        }
        if (blueKey)
        {
            Debug.Log("this key is blue");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onCollectEvent.Invoke();
            if (goldKey)
            {
                keyGlowUI.SetActive(true);
                Controller.Instance.gotGoldKey = true;
                if (QTuto)
                {
                    QTuto.SetActive(true);
                }
                
                Destroy(gameObject);
            }
            if (blueKey)
            {
                Controller.Instance.gotBlueKey = true;
                if (QTuto)
                {
                    QTuto.SetActive(true);
                }
                Destroy(gameObject);
            }
            Icon.SetActive(true);
        }
    }

}
