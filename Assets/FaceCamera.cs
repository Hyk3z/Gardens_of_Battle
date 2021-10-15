﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("First Person Character");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
	}
}
