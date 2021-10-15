using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    public float vz;
    public float vy;
    public float time;
    Rigidbody rigid;
    float timePassed;
    //public GameObject pit;
    bool doPit = true;
    //int randomDamage;
    //public GameObject hitPlayerSFX;
    public GameObject son;
    float randomDamage;
    void Start()
    {



        /*
        son.transform.parent = null;
        
        Destroy(gameObject, 3);
        rigid = GetComponent<Rigidbody>();
        transform.LookAt(Controller.Instance.transform.position);
        
        var distance = Vector3.Distance(transform.position, Controller.Instance.transform.position);
        vz = distance * time;
        vy = 3 / time + 0.5f * 9 * time;
        transform.LookAt(Controller.Instance.transform.position);
        //Debug.Log("Shooting");
        rigid.AddForce(0, vy * 40, 0);
        rigid.AddForce(transform.forward * vz * 55);
        Destroy(gameObject, 6);
        */
    }

    // Update is called once per frame
    void Update()
    {
        son.transform.position = transform.position;
        son.transform.LookAt(transform.position + rigid.velocity);
        //transform.Rotate(transform.right * 90);
        //transform.Translate(gameObject.transform.forward * 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            randomDamage = Random.Range(1, 4);
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
                Controller.Instance.coins--;
                Controller.Instance.ShakeShields();
            }
            if (GameManager.Instance)
            {
                if (GameManager.Instance.nightmare)
                {
                    randomDamage = randomDamage * 4;
                }
                else if (GameManager.Instance.hard)
                {
                    randomDamage = randomDamage * 2;
                }
                else if (GameManager.Instance.normal)
                {
                    //nothing
                }
                else
                {
                    randomDamage = randomDamage / 2;
                }
            }
            

            if (randomDamage > 0)
            {
                Controller.Instance.chachoalha = true;
                Controller.Instance.chachoalhaNow();
                Controller.Instance.life = Controller.Instance.life - randomDamage;
            }
            Destroy(son, 0.4f);
            Destroy(gameObject);
        }
    }

}
