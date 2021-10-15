using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableDoAction : MonoBehaviour
{
    public UnityEvent evento;
    // Start is called before the first frame update
    private void OnEnable()
    {
        evento.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
