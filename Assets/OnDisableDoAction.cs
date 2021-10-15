using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableDoAction : MonoBehaviour
{
    public UnityEvent myevent;
    public void OnDisable()
    {
        myevent.Invoke();
    }
}
