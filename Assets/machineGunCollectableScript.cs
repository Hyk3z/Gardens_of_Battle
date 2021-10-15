using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class machineGunCollectableScript : MonoBehaviour
{
    public StudioEventEmitter emitter;
    private void Start()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
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
            selectionScript.Instance.GetBehindIcon(4);
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
            gameObject.SetActive(false);
            Controller.Instance.GetMachinegun();
            Controller.Instance.ammo += 24;
            
        }
    }
}
