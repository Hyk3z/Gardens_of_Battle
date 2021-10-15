using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class griffinboltorigin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Controller.Instance.debugBall.transform.position);
    }
}
