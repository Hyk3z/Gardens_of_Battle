using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class krawwHole : MonoBehaviour
{
    public int howManyMonsters;
    public GameObject spawnedObject;
    public GameObject bombObjectForLast;
    public float SecondsPerKraww;
    float spawnTimer;
    bool startSpawn;
    int enemyIndex;
    public bool isForGroundAnt;
    public bool isForFlyAnt;
    public bool isForBombAnt;
    public GameObject spawnPosition;
    public bool SpawnAtStart;
    public bool SpawnABombLast;
    public UnityEvent spawnEvent;
    //public bool spawnAtStart;

    //public bool infinite;
    private void Start()
    {
        if (GameManager.Instance && !GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            //howManyMonsters = 1;
        }
        if (GameManager.Instance && GameManager.Instance.normal)
        {
            //nothing
        }
        if (GameManager.Instance && GameManager.Instance.hard)
        {
            //howManyMonsters += 3;
        }
        if (GameManager.Instance && GameManager.Instance.nightmare)
        {
            //howManyMonsters += 6;
        }
        if (spawnedObject.transform.GetChild(0).GetComponent<KrawScript>())
        {
            //isForGroundAnt = true;
        }
        else if (spawnedObject.GetComponent<PrincessScript>())
        {
            //isForGroundAnt = true;
        }
        if (SpawnAtStart)
        {
            SpawnEnemies();
        }
    }
    public void SpawnEnemies()
    {
        //spawnTimer = SecondsPerKraww;
        //startSpawn = true;
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(spawnProcess());
        }
        
    }

    IEnumerator spawnProcess()
    {
        WaitForSeconds wfs = new WaitForSeconds(SecondsPerKraww);
        yield return wfs;
        var currentAnt = Instantiate(spawnedObject, spawnPosition.transform.position, spawnPosition.transform.rotation);
        spawnEvent.Invoke();
        if (isForGroundAnt)
        {
            //currentAnt.transform.GetChild(0).GetComponent<Hider>().AppearNow();
            currentAnt.transform.GetChild(0).GetComponent<KrawScript>().detectou = true;
            currentAnt.transform.GetChild(0).GetComponent<KrawScript>().isFromHole = true;
            
            //currentAnt.transform.GetChild(0).GetComponent<NavMeshAgent>().destination = Controller.Instance.transform.position;
        }
        else if (isForFlyAnt)
        {
            //currentAnt.transform.GetChild(0).GetComponent<Hider>().isFromHole = true;
            //currentAnt.transform.GetChild(0).GetComponent<Hider>().AppearNow();
            currentAnt.transform.GetChild(0).GetComponent<PrincessScript>().detectou = true;
            currentAnt.transform.GetChild(0).GetComponent<PrincessScript>().isFromHole = true;
        }
        else if (isForBombAnt)
        {
            currentAnt.GetComponent<KrawBomb>().detectou = true;
        }
        enemyIndex ++;
        checkIfMore();
    }
    void checkIfMore()
    {
        if (enemyIndex < howManyMonsters)
        {
            StartCoroutine(spawnProcess());
        }
        else
        {
            if (SpawnABombLast)
            {
                var currentAnt = Instantiate(bombObjectForLast, spawnPosition.transform.position, spawnPosition.transform.rotation);
                currentAnt.GetComponent<KrawBomb>().detectou = true;
            }
            GetComponent<krawwHole>().enabled = false;
        }
    }

    

}
