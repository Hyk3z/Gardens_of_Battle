using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacumbaOgraScript : MonoBehaviour
{
    Rigidbody rig;
    public float speed;
    SphereCollider col;
    public AudioSource explosionSound;
    void Start()
    {
        col = GetComponent<SphereCollider>();
        rig = GetComponent<Rigidbody>();
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Controller.Instance.transform.position);
        rig.AddForce(transform.forward * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            explosionSound.Play();
            Destroy(gameObject, 1);
            col.enabled = false;
            Controller.Instance.chachoalha = true;
            Controller.Instance.life--;
        }
        if (other.CompareTag("Clutter"))
        {
            Destroy(gameObject);
            explosionSound.Play();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "OgreCaveTile")
        {
            
            Destroy(gameObject);
            explosionSound.Play();
        }
    }
}
