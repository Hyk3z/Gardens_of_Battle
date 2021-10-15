using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinXplosionDamage : MonoBehaviour
{
    bool ableToDamage = true;
    public void OnTriggerEnter(Collider other)
    {
        if (!ableToDamage)
        {
            return;
        }
        if (other.GetComponent<PrincessScript>() || other.GetComponent<KrawScript>() || other.GetComponent<burningHeadScript>() || other.GetComponent<KrawExplosion>() || other.GetComponent<OrcScript>())
        {
            
            
            if (other.GetComponent<PrincessScript>())
            {
                
                other.GetComponent<PrincessScript>().life -= 10;
            }
            if (other.GetComponent<KrawScript>())
            {
                other.GetComponent<KrawScript>().life -= 10;
            }
            if (other.GetComponent<burningHeadScript>())
            {
                other.GetComponent<burningHeadScript>().life -= 10;
            }
            if (other.GetComponent<KrawExplosion>())
            {
                
                other.transform.GetComponent<KrawExplosion>().ExplodeNow();
            }
            if (other.GetComponent<OrcScript>())
            {
                
                other.GetComponent<OrcScript>().life -= 10;
                //other.GetComponent<OrcScript>().DieNow();
            }
        }
    }

    IEnumerator UnableToDoDamage()
    {
        yield return new WaitForSeconds(0.5f);
        ableToDamage = false;
    }

    private void Start()
    {
        StartCoroutine(UnableToDoDamage());
        Destroy(gameObject, 1);
    }
}
