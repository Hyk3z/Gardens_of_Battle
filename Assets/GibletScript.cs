using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibletScript : MonoBehaviour
{
    public Rigidbody rigid;
    private void Awake()
    {
        Destroy(gameObject, 2);
        //rigid = GetComponent<Rigidbody>();
        //transform.LookAt(transform.parent.transform.position);
        transform.parent = null;
        //rigid.AddForce(transform.forward * -1.5f);
    }
}
