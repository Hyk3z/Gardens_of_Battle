using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
//ing System.Runtime.Remoting.Lifetime;

public class CarrapatinhoScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    float timeSinceAttacked;
    bool dead;
    public BoxCollider box1;
    public BoxCollider box2;
    //public float life;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void DieNow()
    {
        dead = true;
        box2.enabled = false;
        box1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            anim.SetBool("isMoving", true);
            agent.destination = Controller.Instance.transform.position;
            timeSinceAttacked += Time.deltaTime;
        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.SetBool("IsDead", true);
            GetComponent<CarrapatinhoScript>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && timeSinceAttacked > 1 && !dead)
        {
            AttackPlayer();
        }
    }
    void AttackPlayer()
    {
        anim.SetTrigger("Attack");
        timeSinceAttacked = 0;
        if (Controller.Instance.coins > 0)
        {
            Controller.Instance.coins--;
            Controller.Instance.ShakeShields();
        }
        else
        {
            Controller.Instance.chachoalhaNow();
            Controller.Instance.life--;
        }
        

    }
}
