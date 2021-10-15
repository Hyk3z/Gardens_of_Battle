using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using FMODUnity;

public class bazookaCollectable : MonoBehaviour
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
            selectionScript.Instance.GetBehindIcon(3);
            Controller.Instance.gotBazooka = true;
            Controller.Instance.Icons[4].SetActive(true);
            Controller.Instance.Icons[5].SetActive(true);
            Destroy(gameObject);
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
        }
    }
}
