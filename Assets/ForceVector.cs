using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceVector : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target.transform.position);
        target.GetComponent<Rigidbody>().AddForce(transform.forward * 60000);
        target.GetComponent<Rigidbody>().AddForce(transform.up * 20000);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
