using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class StaffCollectable : MonoBehaviour
{
    public StudioEventEmitter emitter;
    private void Start()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (Controller.Instance.gotStaff)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emitter.Play();
            Controller.Instance.GetStaff();
            Destroy(gameObject);
        }
    }

}
