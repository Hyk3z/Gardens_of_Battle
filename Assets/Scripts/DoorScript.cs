using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorScript : MonoBehaviour {
    public bool used;
    public GameObject HighLight;
    public BoxCollider box;
    float closeCounter;
    Animator tutorial;
    Animator tutorialText;
    public sapivangas sapivangas;
    SoundScript caminhao;
    BoxCollider boxCol;
    Animator anim;
    bool secondUse;
    public CheckPoint lastSavePoint;
    public StudioEventEmitter openSFX;
    public StudioEventEmitter closeSFX;

    public void CloseDoorSound()
    {
        
        closeSFX.Play();
    }
    public void OpenDoorSound()
    {
        
        openSFX.Play();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider>();
        caminhao = GameObject.Find("CaminhaoDoSom").GetComponent<SoundScript>();
        //sapivangas = GameObject.Find("Dr. Sapivangas").GetComponent<sapivangas>();
        if (GameObject.Find("TutorialText"))
        {
            tutorialText = GameObject.Find("TutorialText").GetComponent<Animator>();
            tutorial = GameObject.Find("Tutorial").GetComponent<Animator>();
        }
        
        if (GetComponent<BoxCollider>())
        {
            boxCol = GetComponent<BoxCollider>();
        }
        
    }
    public void Update()
    {

        if (!box.enabled)
        {

            closeCounter += Time.deltaTime;

            if (closeCounter >= 1 && !used)
            {
                
                box.enabled = true;
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !used && other.GetComponent<Controller>().holding == false)
        {
            if (tutorial)
            {
                tutorial.SetBool("Fade", true);
                tutorialText.SetBool("Fade", true);
            }
            
            HighLight.SetActive(false);
            sapivangas.greet = true;
            GetComponent<Animator>().enabled = true;
            used = true;
            caminhao.Sapivangas = true;
            if (boxCol)
            {
                boxCol.enabled = false;
            }
            
        }

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && other.GetComponent<Controller>().holding && !secondUse)
        {
            sapivangas.Instance.GetComponent<Animator>().SetTrigger("AcceptEggs");
            lastSavePoint.SaveGame();
            PlayerPrefs.SetInt("GotStaff", 1);
            secondUse = true;
            anim.enabled = true;
            
            sapivangas.quiet = false;
            closeCounter = 0;
            if (box)
            {
                box.enabled = false;
            }
            
            sapivangas.deliver = true;
            HighLight.SetActive(false);
            //GameObject.Find("Dr. Sapivangas").GetComponent<sapivangas>().greet = true;
            anim.SetBool("QuestDeliver", true);
            anim.SetBool("Close", false);
            used = true;
            caminhao.Sapivangas = true;
            if (boxCol)
            {
                boxCol.enabled = false;
            }
            
            sapivangas.Instance.iJustWantHimToPlaySpeechAnimation();
        }

    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && !used)
        {
            tutorial.SetBool("Fade", true);
            
            GetComponent<Animator>().enabled = true;
            used = true;
            caminhao.Sapivangas = true;
            if (boxCol)
            {
                boxCol.enabled = false;
            }
            
        }

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Q) && other.GetComponent<Controller>().holding)
        {
            GetComponent<Animator>().enabled = true;
            closeCounter = 0;
            if (box)
            {
                box.enabled = false;
            }
            
            HighLight.SetActive(false);
            sapivangas.deliver = true;
            anim.SetBool("QuestDeliver", true);
            anim.SetBool("Close", false);
            used = true;
            caminhao.Sapivangas = true;
            if (boxCol)
            {
                boxCol.enabled = false;
            }
            
        }
    }
}
