using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acidMissile : MonoBehaviour
{
    public Rigidbody rig;
    public float speed;
    bool canDamage = true;
    public GameObject explosionSound;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    bool canUse = true;
    float randomDamage;
    void Start()
    {
        Destroy(gameObject, 5);
        transform.LookAt(Controller.Instance.transform.position);
        rig.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Griffin")) && canDamage && !Controller.Instance.death && canUse)
        {
            
            canUse = false;
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
                Controller.Instance.chachoalhaNow();
            }

            //Controller.Instance.life -= randomDamage;
            if (particle1 && particle2)
            {
                particle1.Stop();
                particle2.Stop();
            }

            
            //Destroy(gameObject);
            canDamage = false;
            //explosionSound.transform.parent = null;
            if (explosionSound)
            {
                explosionSound.SetActive(true);
            }
            
            Destroy(gameObject, 1);
        }
        
        if (other.CompareTag("Clutter") || other.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    

}
