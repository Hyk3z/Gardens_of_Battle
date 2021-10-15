using FMOD;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KrawExplosion : MonoBehaviour
{
    public GameObject xPlos;
    public GameObject[] Fires;
    //public GameObject krawwGiblets;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("WallCollider"))
        {
            ExplodeNow();
            
        }
    }

    public void ExplodeNow()
    {
        StartCoroutine(ActuallyExplode());
        
    }

    IEnumerator ActuallyExplode()
    {
        //krawwGiblets.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 3)
        {
            if (GameManager.Instance && GameManager.Instance.nightmare)
            {
                if (Controller.Instance.coins > 0)
                {
                    if (Controller.Instance.lvl2Shield)
                    {
                        Controller.Instance.life -= 38;
                    }
                    else
                    {
                        Controller.Instance.life -= 39;
                    }
                    Controller.Instance.coins--;
                    Controller.Instance.ShakeShields();
                }
                
            }
            else if (GameManager.Instance && GameManager.Instance.hard)
            {
                
                if (Controller.Instance.coins > 0)
                {
                    if (Controller.Instance.lvl2Shield)
                    {
                        Controller.Instance.life -= 28;
                    }
                    else
                    {
                        Controller.Instance.life -= 29;
                    }
                    Controller.Instance.coins--;
                    Controller.Instance.ShakeShields();
                }
                else
                {
                    Controller.Instance.life -= 30;
                }
                

            }
            else if (GameManager.Instance && GameManager.Instance.normal)
            {
                

                if (Controller.Instance.coins > 0)
                {
                    if (Controller.Instance.lvl2Shield)
                    {
                        Controller.Instance.life -= 18;
                    }
                    else
                    {
                        Controller.Instance.life -= 19;
                    }
                    Controller.Instance.coins--;
                    Controller.Instance.ShakeShields();
                }
                else
                {
                    Controller.Instance.life -= 20;
                }
                
            }
            else
            {
                if (Controller.Instance.coins > 0)
                {
                    if (Controller.Instance.lvl2Shield)
                    {
                        Controller.Instance.life -= 8;
                    }
                    else
                    {
                        Controller.Instance.life -= 9;
                    }
                    Controller.Instance.coins--;
                    Controller.Instance.ShakeShields();
                }
                else
                {
                    Controller.Instance.life -= 10;
                }
                
                
            }

            Controller.Instance.chachoalha = true;
        }
        gameObject.SetActive(false);
        for (int i = 0; i < Fires.Length; i++)
        {
            Destroy(Fires[i]);
        }
        
        xPlos.transform.parent = null;
        xPlos.SetActive(true);
    }

}
