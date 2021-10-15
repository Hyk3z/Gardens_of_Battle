using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("First Person Character");
	}
	/*
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clutter")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Clutter")
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Clutter")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    */
}
