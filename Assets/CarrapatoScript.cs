using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrapatoScript : MonoBehaviour
{
    public GameObject spawnPrefab;
    public bool detectou;
    public float timeBetweenSpawns;
    public GameObject spawnPosition;
    public Animator anim;
    bool started;
    public float life;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DieNow()
    {
        dead = true;
        StopCoroutine(spawnCicle());
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 1)
        {
            DieNow();
        }
        if (Vector3.Distance(Controller.Instance.transform.position, gameObject.transform.position) < 10 && !detectou && !dead)
        {
            detectou = true;
        }
        if (detectou && !dead)
        {
            //transform.LookAt(Controller.Instance.transform.position);
            if (!started)
            {
                StartCoroutine(spawnCicle());
                started = true;
            }
            
        }
        if (dead)
        {
            anim.SetBool("IsDead", true);
        }
    }

    IEnumerator spawnCicle()
    {
        yield return new WaitForSeconds(3);
        Instantiate(spawnPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
        anim.SetTrigger("Attack");
        if (!dead)
        {
            StartCoroutine(spawnCicle());
        }
        
    }



}
