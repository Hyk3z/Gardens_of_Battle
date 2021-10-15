using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpit : MonoBehaviour
{
    public float vz;
    public float vy;
    public float time;
    Rigidbody rigid;
    float timePassed;
    public GameObject pit;
    bool doPit = true;
    int randomDamage;
    public GameObject hitPlayerSFX;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Griffin"))
        {
            hitPlayerSFX.transform.parent = null;
            hitPlayerSFX.SetActive(true);
            randomDamage = (Random.Range(1, 4)) * 2;
            if (Controller.Instance.coins > 0)
            {
                if (Controller.Instance.lvl2Shield)
                {
                    randomDamage -= 2;
                }
                else
                {
                    randomDamage -= 1;
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
                //Debug.Log("Acid spit in easy damage");
                randomDamage = randomDamage / 2;
            }
            
            if (randomDamage > 0)
            {
                Controller.Instance.life -= randomDamage;
                Controller.Instance.chachoalha = true;
            }
            //Controller.Instance.life-=randomDamage;
            
            doPit = false;
            //Controller.Instance.chachoalha = true;
            //Controller.Instance.TurnFlareOn();
            //Controller.Instance.GetComponent<Animator>().SetBool("damage", true);
        }
        else
        {
            //Debug.Log("Collided with " + other.gameObject.name);
            if (!other.GetComponent<KrawScript>() && other.gameObject.name != "Floor" && other.gameObject.tag != "WallCollider" && timePassed > 1)
            {
                
                Destroy(gameObject);
            }
            if (other.gameObject.tag == "Floor" && timePassed > 0.8f && doPit)
            {
                Instantiate(pit, transform.position, Quaternion.identity);
                doPit = false;
            }
        }
        if (other.CompareTag("Clutter"))
        {
            
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        timePassed += Time.deltaTime;
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        transform.LookAt(Controller.Instance.transform.position);
        //inserir aqui a equacao de disparo do tipo canhao
        var distance = Vector3.Distance(transform.position, Controller.Instance.transform.position);
        vz = distance * time;
        vy = 3 / time + 0.5f * 9 * time;
        transform.LookAt(Controller.Instance.transform.position);
        //Debug.Log("Shooting");
        rigid.AddForce(0, vy * 40, 0);
        rigid.AddForce(transform.forward * vz * 55);
        Destroy(gameObject, 6);
    }
}
