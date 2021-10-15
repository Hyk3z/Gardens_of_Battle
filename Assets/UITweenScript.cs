using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenScript : MonoBehaviour
{
    
    public void Pulse()
    {
        iTween.PunchScale(gameObject, new Vector3 (0.5f,0.5f,0.5f), 1);
    }

    public void Shake()
    {
        //Debug.Log("Shaking");
        iTween.PunchRotation(gameObject, transform.forward*10, 0.5f);
    }

}
