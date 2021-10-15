using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerScript : MonoBehaviour {

    // Use this for initialization
    public SoundScript caminhao;
    public Animator door;
    public UnityEvent evento;
    //public GameObject caminhaoDoSom;
    //public UnityEvent firstTriggerEvent;
	void Start () {
        //caminhao = GameObject.Find("CaminhaoDoSom").GetComponent<SoundScript>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            caminhao.danger = true;
            Destroy(gameObject);
            door.SetBool("Close", true);
            evento.Invoke();
        }
    }

}
