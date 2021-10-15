using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class arrowCollectable : MonoBehaviour
{
    BoxCollider box;
    public GameObject ponta;
    StudioEventEmitter pickSound;
    private void Start()
    {
        pickSound = GetComponent<StudioEventEmitter>();
        box = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        //transform.Rotate(0, 1, 0);
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

    public void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Griffin")) && Controller.Instance.ammo < 100)
        {
            if (GameManager.Instance)
            {
                GameManager.Instance.discartList.Add(gameObject.name);
            }
            
            //GetComponent < AudioSource>().Play();
            pickSound.Play();
            Controller.Instance.AddAmmo(1);
            //Controller.Instance.ammo++;
            box.enabled = false;
            //GetComponent<MeshRenderer>().enabled = false;
            gameObject.SetActive(false);
            foreach (var item in transform)
            {
                ponta.SetActive(false);
            }

            Controller.Instance.HandBallista.GetComponent<ballista>().ArrowMesh.SetActive(true);
            //Controller.Instance.HandBallista.GetComponent<ballista>().fakeArrow.GetComponent<MeshRenderer>().enabled = true;
            //Controller.Instance.HandBallista.GetComponent<ballista>().fakeArrowTip.GetComponent<MeshRenderer>().enabled = true;

            foreach (var item in MAchinegunScript.Instance.fakeArrows)
            {
                item.SetActive(true);
            }
        }
    }
}
