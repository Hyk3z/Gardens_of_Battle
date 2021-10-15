using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggScript : MonoBehaviour {
    public GameObject[] brothers;
    public GameObject[] copy;
    public GameObject highlight;
    public GameObject sword;
    public GameObject ballista;
    public GameObject[] lights;
    Controller playercontrol;
    public GameObject doorlight;
    bool hold;
	// Use this for initialization
	void Start () {
        playercontrol = GameObject.Find("First Person Character").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hold)
        {
            
        }
        
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !hold)
        {
            playercontrol.holding = true;
            lights[0].SetActive(false);
            lights[1].SetActive(true);
            //sword.SetActive(false);
            //sword.GetComponent<Animator>().SetBool("Off", true);
            //ballista.GetComponent<Animator>().SetBool("Off", true);
            hold = true;
            foreach (var eggz in copy)
            {
                eggz.SetActive(true);
            }
            foreach (var eggs in brothers)
            {
                Destroy(eggs);
            }
            doorlight.SetActive(true);
            
            Destroy(highlight);
            Destroy(gameObject);
            
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !hold)
        {
            doorlight.SetActive(true);
            playercontrol.holding = true;
            lights[0].SetActive(false);
            lights[1].SetActive(true);
            //sword.GetComponent<weaponscript>().Anim.SetBool("Off", true);
            //sword.SetActive(false);
            hold = true;
            foreach (var eggz in copy)
            {
                eggz.SetActive(true);
            }
            foreach (var eggs in brothers)
            {
                Destroy(eggs);
            }
            
            Destroy(highlight);
            Destroy(gameObject);
            sapivangas.Instance.quiet = false;
        }
    }

    public void DropEgg()
    {

    }

}
