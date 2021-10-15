using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KrawBomb : MonoBehaviour
{
    public bool detectou;
    public Animator anim;
    public Rigidbody rigid;
    bool detectLock;
    public float force;
    public NavMeshAgent agent;
    public GameObject antToRoll;
    
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (!detectou && Vector3.Distance(Controller.Instance.transform.position, transform.position) < 5)
        {
            detectou = true;
        }
        if (detectou)
        {
            if (agent.velocity.magnitude > 0.3f)
            {
                anim.SetBool("Walk", true);

            }
            else
            {
                anim.SetBool("Walk", false);
            }
            //antToRoll.transform.Rotate(1, 0, 0);
            if (agent)
            {
                if (agent.isOnNavMesh)
                {
                    agent.destination = Controller.Instance.gameObject.transform.position;
                }
                
            }
            
            if (!detectLock)
            {
                //anim.SetBool("Roll", true);
                detectLock = true;
                if (rigid)
                {
                    rigid.isKinematic = false;
                }
                
            }
            
            //transform.LookAt(Controller.Instance.transform.position);
            //rigid.AddForce(transform.forward * force);
        }
    }
    public void DetectNow()
    {
        detectou = true;
        
    }
    

}
