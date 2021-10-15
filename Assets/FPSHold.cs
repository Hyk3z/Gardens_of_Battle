using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSHold : MonoBehaviour
{
    float fps;
    public Text fpsText;
    float deltaTime;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        fps = 1.0f / deltaTime;
        Application.targetFrameRate = 300;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
