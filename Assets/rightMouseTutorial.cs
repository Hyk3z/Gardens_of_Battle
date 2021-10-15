using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightMouseTutorial : MonoBehaviour
{
    Transform originalFather;
    float alpha = 1;
    bool fade;
    SpriteRenderer rend;
    private void Awake()
    {
        if (Controller.Instance.consumedMushTutorial)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        originalFather = transform.parent;
        transform.parent = null;
    }
    private void Update()
    {
        if (originalFather)
        {
            transform.position = new Vector3(originalFather.position.x + 0.3f, originalFather.position.y + 0.3f, originalFather.position.z + 0.3f);
        }
        else
        {
            Destroy(gameObject);
        }
        transform.LookAt(Controller.Instance.transform.position);
        if (Input.GetMouseButtonDown(1))
        {
            
            Controller.Instance.consumedMushTutorial = true;
            Destroy(gameObject);
        }
        
        
    }

}
