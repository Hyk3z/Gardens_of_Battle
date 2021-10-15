using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ontriggerDoAction : MonoBehaviour
{
    bool given;
    //public bool super;
    public bool berzerk;
    public UnityEvent callEventWhenCollected;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                gameObject.SetActive(false);
                
            }
        }
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Griffin") && !given)
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.collectedItems++;
            }
            
            callEventWhenCollected.Invoke();
            given = true;
            Destroy(gameObject);
            if (!berzerk)
            {
                
                Controller.Instance.coins++;
                Controller.Instance.PlayCoinSound();
                if (Controller.Instance.coins > 19 && !Controller.Instance.lvl2Shield)
                {
                    Controller.Instance.MaxedCoins();
                }
            }
            else
            {
                //Controller.Instance.BerzerkNow();
            }
            
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
                //GameManager.Instance.objectsToDestroyByLoad.Add(gameObject.name);
            }
            

            
        }
    }
    
}
