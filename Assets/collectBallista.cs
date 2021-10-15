using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class collectBallista : MonoBehaviour
{
    public StudioEventEmitter emitter;
    private void Awake()
    {
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            emitter.Play();
            selectionScript.Instance.GetBehindIcon(2);
            Controller.Instance.Icons[2].SetActive(true);
            Controller.Instance.Icons[3].SetActive(true);
            
            Controller.Instance.GetBallista();
            gameObject.SetActive(false);
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
        }
    }
}
