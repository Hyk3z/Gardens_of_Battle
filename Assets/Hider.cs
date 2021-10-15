using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hider : MonoBehaviour
{
    public Animator anim;
    public GameObject mesh;
    public bool isFromHole;
    // Start is called before the first frame update
    private void Start()
    {
        if (!isFromHole)
        {
            HideNow();
        }
        
    }

    // Update is called once per frame
    public void HideNow()
    {
        if (Vector3.Distance(transform.position, Controller.Instance.transform.position) < 40)
        {
            AppearNow();
            return;
        }
        if (anim)
        {
            anim.enabled = false;
        }
        if (mesh)
        {
            mesh.SetActive(false);
        }
        
    }

    public void AppearNow()
    {
        
        if (anim)
        {
            anim.enabled = true;
        }
        if (mesh)
        {
            mesh.SetActive(true);
        }
        
    }
}
