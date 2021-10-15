using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageScript : MonoBehaviour
{
    bool playerInsOn;
    float timer = 1;
    
    void Update()
    {
        if (playerInsOn && timer >= 1)
        {
            if (Controller.Instance.coins > 0)
            {

                Controller.Instance.coins--;
                Controller.Instance.ShakeShields();
                Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
            }
            else
            {
                Controller.Instance.life--;
                Controller.Instance.chachoalha = true;
                Controller.Instance.chachoalhaNow();
            }
            timer = 0;
        }

        if (timer < 1)
        {
            timer += Time.deltaTime;
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsOn = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsOn = false;
        }
    }

}
