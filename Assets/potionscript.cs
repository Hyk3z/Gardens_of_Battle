using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Security.Cryptography;
using UnityEngine.UI;

public class potionscript : MonoBehaviour {
    Controller playerControl;
    //AudioSource soundz;

    public StudioEventEmitter emitter;
    public MeshRenderer rend1;
    public MeshRenderer rend2;
    bool soundlock;
    public SphereCollider sphereCol;
    public StudioEventEmitter drinkPotion;
    bool usable = true;
    public bool isManaPotion;
    public staffScript staff;
    public Slider manaFiller;
    // Use this for initialization
    void Start () {
        playerControl = Controller.Instance;
        //soundz = GetComponent<AudioSource>();
        rend1 = GetComponent<MeshRenderer>();
        if (GameManager.Instance && GameManager.Instance.toLoad)
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                Destroy(gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 1, 0);
	}
    public void OnTriggerEnter(Collider other)
    {
        if (!usable)
        {
            return;
        }
        if (other.tag == "Player" || other.tag == "Griffin")
        {
            
            if (isManaPotion && staff.Mana < 10)
            {
                usable = false;
                drinkPotion.Play();
                staff.Mana += 2;
                manaFiller.value = staff.Mana / 10;
                if (staff.Mana > 10)
                {
                    staff.Mana = 10;
                }
                Destroy(sphereCol);
                Destroy(gameObject, 1);
                Destroy(rend1);
                Destroy(rend2);
                if (!soundlock)
                {

                    //soundz.Play();
                    soundlock = true;
                }
                if (GameManager.Instance)
                {
                    GameManager.Instance.collectedItems++;
                    GameManager.Instance.discartList.Add(gameObject.name);
                }
            }
            if (!isManaPotion && playerControl.life < playerControl.maxLife)
            {
                usable = false;
                drinkPotion.Play();
                playerControl.life += 10;
                if (playerControl.life > playerControl.maxLife)
                {
                    playerControl.life = playerControl.maxLife;
                }
                Destroy(sphereCol);
                Destroy(gameObject, 1);
                Destroy(rend1);
                Destroy(rend2);
                if (!soundlock)
                {
                    
                    //soundz.Play();
                    soundlock = true;
                }
                if (GameManager.Instance)
                {
                    GameManager.Instance.collectedItems++;
                    GameManager.Instance.discartList.Add(gameObject.name);
                }
                
            }
            else//in case player has max health and is going to store this potion
            {
                if (!isManaPotion && Controller.Instance.storedPotions < 20)
                {
                    usable = false;
                    emitter.Play();
                    playerControl.storedPotions++;
                    playerControl.PlayPotSound();
                    Destroy(sphereCol);
                    Destroy(gameObject);
                    Destroy(rend1);
                    Destroy(rend2);
                    if (GameManager.Instance)
                    {
                        GameManager.Instance.discartList.Add(gameObject.name);
                    }
                    
                }
                
                
            }
            
        }
    }

}
