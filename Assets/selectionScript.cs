using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectionScript : MonoBehaviour
{

    static selectionScript m_Instance;
    public static selectionScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(selectionScript)) as selectionScript;
            return m_Instance;
        }
    }

    public GameObject[] icons;
    RawImage img;
    private void Start()
    {
        img = GetComponent<RawImage>();
        //img.enabled = false;
    }
    public void GetBehindIcon(int which)
    {
        if (!img)
        {
            img = GetComponent<RawImage>();
        }
        img.enabled = true;
        transform.position = icons[which].transform.position;
    }

}
