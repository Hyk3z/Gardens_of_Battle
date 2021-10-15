using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBoolEmitter : MonoBehaviour
{
    int m_LayerToDetect;
    public float closeRange;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * closeRange);
    }

    // Update is called once per frame
    void Update()
    {
        m_LayerToDetect = LayerMask.GetMask("Default");
        Ray ray = new Ray(transform.position, transform.forward * closeRange);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * closeRange, out hit, closeRange, m_LayerToDetect))
        {
            if (ballista.Instance && ballista.Instance.anim)
            {
                ballista.Instance.anim.SetBool("Close", true);
            }
            
            
        }
        else
        {
            
            if (ballista.Instance && ballista.Instance.anim)
            {
                ballista.Instance.anim.SetBool("Close", false);
            }
            
        }
        
    }
}
