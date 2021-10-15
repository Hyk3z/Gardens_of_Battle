using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDetection : MonoBehaviour
{

    static monsterDetection m_Instance;
    public static monsterDetection Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(monsterDetection)) as monsterDetection;
            return m_Instance;
        }
    }

    public Collider[] hitColliders;
    float checkingDistance;
    WaitForSeconds wfs;
    public List<GameObject> shownMonsters;
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 40);
    }
    private void Start()
    {
        wfs = new WaitForSeconds(1.5f);
        StartCoroutine(WaitAndCheckMonstersAround());
    }
    

    IEnumerator WaitAndCheckMonstersAround()
    {
        yield return wfs;
        DoChecking();
        yield return null;

    }

    void DoChecking()
    {
        return;
        
        hitColliders = Physics.OverlapSphere(transform.position, 40);
        
        foreach (var hitCollider in hitColliders)
        {
            
            if (!hitCollider.CompareTag("Mob"))
            {
                
                //return;
            }
            else
            {
                
                if (!shownMonsters.Contains(hitCollider.gameObject) && hitCollider.GetComponent<Hider>())
                {
                    hitCollider.GetComponent<Hider>().AppearNow();
                    shownMonsters.Add(hitCollider.gameObject);
                }

            }
        }

        for (int i = 0; i < shownMonsters.Count; i++)
        {
            if (shownMonsters[i])
            {
                if (Vector3.Distance(transform.position, shownMonsters[i].transform.position) > 40)
                {
                    shownMonsters[i].GetComponent<Hider>().HideNow();
                    shownMonsters.Remove(shownMonsters[i]);
                }
            }
            
        }
        /*
        foreach (var item in shownMonsters)
        {
            if (Vector3.Distance(transform.position, item.transform.position) > 40)
            {
                item.GetComponent<Hider>().HideNow();
                shownMonsters.Remove(item);
            }
        }
        */
        StartCoroutine(WaitAndCheckMonstersAround());
    }
    

}
