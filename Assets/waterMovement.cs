using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterMovement : MonoBehaviour
{
    bool up = false;
    float YValue;
    float startX;
    float startZ;
    public bool acid;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.localScale.x;
        startZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!acid)
        {
            if (up)
            {
                YValue += Time.deltaTime / 1.5f;
                if (YValue > 6)
                {
                    up = false;
                }
            }
            else
            {
                YValue -= Time.deltaTime / 1.5f;
                if (YValue <= 0.1f)
                {
                    up = true;
                }
            }

            transform.localScale = new Vector3(startX, YValue, startZ);
        }
        else
        {
            //transform.Translate(transform.up * 0.001f);
            if (up)
            {
                YValue += Time.deltaTime * 4;
                if (YValue > 20)
                {
                    up = false;
                }
            }
            else
            {
                YValue -= Time.deltaTime * 4;
                if (YValue <= 0.1f)
                {
                    up = true;
                }
            }

            transform.localScale = new Vector3(startX, YValue, startZ);
        }
    }
}
