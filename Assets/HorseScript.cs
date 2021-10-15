using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScript : MonoBehaviour
{
    static HorseScript m_Instance;
    public Rigidbody rigid;
    public GameObject antToRotate;
    public bool onFloor;
    public static HorseScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(HorseScript)) as HorseScript;
            return m_Instance;
        }
    }

    public GameObject playerPlace;

    // Quando o player entrar no estado cavalgando, devera estar com todas as armas Off.

    private void FixedUpdate()
    {
        //just for test
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartMount();
        }
        if (Controller.Instance.isMounted)
        {
            Controller.Instance.transform.position = playerPlace.transform.position;
            SetFloorSpot();
        }
    }

    

    public void StartMount()
    {
        Controller.Instance.GetComponent<SphereCollider>().enabled = false;
        Controller.Instance.rigid.isKinematic = true;
        Controller.Instance.DisableAllWeapons();
        rigid.isKinematic = false;
        Controller.Instance.isMounted = true;
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Clutter"))
        {
            //onFloor = true;
        }
        
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Clutter"))
        {
            //onFloor = false;
        }
        
    }

    public void SetFloorSpot()
    {
        //mira.SetActive(true);
        int m_LayerToDetect = LayerMask.GetMask("Default");
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, m_LayerToDetect))
        {
            //distanceToTarget = Vector3.Distance(transform.position, hit.transform.position);
            if (hit.transform.gameObject.CompareTag("Floor"))
            {
                //transform.position = hit.point + transform.up/2;
            }
            //mira.transform.position = hit.point;

        }
        //mira.transform.localScale = (1 + (distanceToTarget * 100000)) * Vector3.one;
    }

}
