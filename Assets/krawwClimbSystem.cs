using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class krawwClimbSystem : MonoBehaviour
{
    public GameObject[] climbSteps;

    private void Start()
    {
        for (int i = 0; i < climbSteps.Length; i++)
        {
            if (i <= climbSteps.Length)
            {
                //climbSteps[i].transform.LookAt(climbSteps[i + 1].transform.position);
            }
            
        }
    }

}
