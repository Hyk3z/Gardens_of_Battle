using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class InvisibleSphereScript : MonoBehaviour
{
    public GameObject player;
    float offsetZ;
    float offsetX;
    Quaternion initialRotation;
    float YStack;
    public float currentYDifference;
    public float currentY;
    void FixedUpdate()
    {

        Vector3 relativePos = (player.transform.position + new Vector3(0, 1.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        //if (Input.GetAxis("Mouse X") > 0.2f || Input.GetAxis("Mouxe X") < -0.2f)
        {
            //transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
            //transform.Translate(0, 0, 3 * Time.deltaTime * Input.GetAxis("Mouse X"));
        }
        



        //currentZDistance = transform.position.z - player.transform.position.z;
    }

    private void Start()
    {
        transform.LookAt(player.transform.position);
        initialRotation = transform.rotation;
        //transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z + 7.01f);
        offsetZ = 5;
        offsetX = 5;
    }

    

}
