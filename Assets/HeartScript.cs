using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;

public class HeartScript : MonoBehaviour {
    Controller playerControl;
    public MeshRenderer rend;
    bool soundlock;
    AudioSource soundz;
    public UnityEvent catchEvent;
    StudioEventEmitter emitter;
	// Use this for initialization
	void Start () {
        emitter = GetComponent<StudioEventEmitter>();
        playerControl = GameObject.Find("First Person Character").GetComponent<Controller>();
        soundz = GetComponent<AudioSource>();

        

    }
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

    void Update () {
        transform.Rotate(0, 1, 0);
	}

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" || other.tag == "Griffin")
        {
            
            
            catchEvent.Invoke();
            playerControl.maxLife+=10;
            playerControl.life = playerControl.maxLife;
            playerControl.healthBarBackGround.value = playerControl.maxLife / 100;
            Destroy(GetComponent<SphereCollider>());
            Destroy(gameObject, 2);
            Destroy(rend);
            
            if (!soundlock)
            {
                emitter.Play();
                //soundz.Play();
                soundlock = true;
            }
            if (GameManager.Instance)
            {
                GameManager.Instance.collectedItems++;
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
        }
    }

}
