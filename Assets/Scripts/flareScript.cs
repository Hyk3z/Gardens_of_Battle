using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flareScript : MonoBehaviour {
    Animator anim;
    float fade;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool("damage"))
        {
            fade += Time.deltaTime;
            if (fade >= 0.3f)
            {
                anim.SetBool("damage", false);
                fade = 0;
            }
            
        }
	}
}
