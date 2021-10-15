using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseKinaScript : MonoBehaviour
{
    
    public GameObject twin;
    public bool primary;

    public void activated()
    {
        twin.SetActive(true);
        gameObject.SetActive(false);
    }
    private void Start()
    {
        if (primary)
        {
            twin.SetActive(false);
        }
    }
}
