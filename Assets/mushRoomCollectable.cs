using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class mushRoomCollectable : MonoBehaviour
{
    public GameObject[] toFade;
    bool usable = true;
    public StudioEventEmitter emitter;
    private void Awake()
    {
       
        
    }

    private void Start()
    {
        if (GameManager.Instance)
        {
            if (GameManager.Instance.toLoad)
            {
                if (PlayerPrefs.GetInt(gameObject.name) == 1)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Griffin")) && usable && Controller.Instance.Mushrooms < 50)
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
            
            Controller.Instance.Mushrooms += 3;
            if (Controller.Instance.Mushrooms > 50)
            {
                Controller.Instance.Mushrooms = 50;
            }
            Controller.Instance.UpdateMushroomText();
            //Destroy(gameObject);
            //Destroy(gameObject);
            foreach (var item in toFade)
            {
                item.SetActive(false);
            }
            Destroy(gameObject, 3);
            usable = false;
            //GetComponent<AudioSource>().Play();
            emitter.Play();
            BazookaScript.Instance.fakeMushroom.SetActive(true);
        }
        
        
    }
}
