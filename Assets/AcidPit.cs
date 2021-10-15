using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPit : MonoBehaviour
{
    bool usable = true;
    float randomDamage;
    public CapsuleCollider collider;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && usable)
        {
            usable = false;
            randomDamage = (Random.Range(1, 4)) * 2;
            
            if (Controller.Instance.coins > 0)
            {
                if (Controller.Instance.lvl2Shield)
                {
                    randomDamage -= 2;
                }
                else
                {
                    randomDamage--;
                }
                Controller.Instance.ShakeShields();
                Controller.Instance.coins--;
                Controller.Instance.coinText.text = Controller.Instance.coins.ToString();
            }
            if (GameManager.Instance && GameManager.Instance.nightmare)
            {
                randomDamage = randomDamage * 4;
            }
            if (GameManager.Instance && GameManager.Instance.hard)
            {
                randomDamage = randomDamage * 2;
            }
            else if (GameManager.Instance && GameManager.Instance.normal)
            {
                //normal damage;
            }
            else
            {
                randomDamage = randomDamage / 2;
            }
            if (randomDamage > 0)
            {
                Controller.Instance.life -= randomDamage;
                Controller.Instance.chachoalha = true;
            }
            
            collider.enabled = false;
            //GetComponent<ParticleSystem>().Stop();
            Destroy(gameObject, 2);
        }
    }


    private void Start()
    {
        transform.Rotate(270, 0, 0);
        //transform.rotation = new Quaternion(-90, 0, 0, transform.rotation.z);
        Destroy(gameObject, 5);
    }
}
