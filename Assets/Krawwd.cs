using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krawwd : MonoBehaviour
{
    string MobString;
    GameObject otherObject;
    private void Start()
    {
        MobString = "Mob";
        Destroy(gameObject, 0.3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob"))
        {

            if (other.GetComponent<KrawScript>())
            {
                other.GetComponent<KrawScript>().detectou = true;
            }
            else if (other.GetComponent<PrincessScript>())
            {
                other.GetComponent<PrincessScript>().detectou = true;
            }
        }
    }
}
