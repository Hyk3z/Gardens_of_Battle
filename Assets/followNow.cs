using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followNow : MonoBehaviour
{
    public GameObject target;
    public bool followY;

    private void Update()
    {
        if (!target)
        {
            Destroy(gameObject);
            return;
        }
        if (!followY)
        {
            transform.position = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        }
        else
        {
            transform.position = target.transform.position;
        }
    }

    

}
