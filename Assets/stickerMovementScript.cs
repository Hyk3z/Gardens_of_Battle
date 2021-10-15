using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickerMovementScript : MonoBehaviour
{

    static stickerMovementScript m_Instance;
    public static stickerMovementScript Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(stickerMovementScript)) as stickerMovementScript;
            return m_Instance;
        }
    }
    /*
    public GameObject playerPosition;
    public Animator antAnim;
    Rigidbody rigid;
    public float speed;
    float transitionTimer;
    bool rotatedToFloor = true;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {

        if (Controller.Instance.StickedToHorse == false)
        {
            return;
        }
        if (transitionTimer < 0)
        {
            transitionTimer += Time.deltaTime;
        }
        checkFloorBelow();

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        rigid.AddForce(transform.forward * y * speed);
        rigid.AddForce(transform.up * -40);
        transform.Rotate(0, x, 0);
        checkFloorAhead();
        if (rigid.velocity.magnitude >= 0.3f || x != 0)
        {
            if (rigid.velocity.magnitude < 0.3f)
            {
                antAnim.speed = 0.4f;
            }
            else
            {
                antAnim.speed = 1;
            }
            antAnim.SetBool("Walk", true);
        }
        else
        {
            antAnim.SetBool("Walk", false);
        }
        //antAnim.transform.LookAt(transform.position + (rigid.velocity * 3));
        
    }

    void checkFloorBelow()
    {
        //put a raycast downwards, check if it collides with something in the layer horseOnly.
        int m_LayerToDetect = LayerMask.GetMask("Default");
        Ray downray = new Ray(transform.position, transform.up * -1);
        RaycastHit hitdown;
        if (Physics.Raycast(downray, out hitdown, 1, m_LayerToDetect) && transitionTimer >= 0 && !rotatedToFloor)
        {
            
            //hitdown.transform.gameObject.GetComponent<horseKinaScript>().activated();
            //Vamos ter que fazer superficies de transicao, com a rotacao desejada quando se alcanca elas. Nao superficies de andar por cima.
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            transitionTimer = -2;
            rotatedToFloor = true;
        }

    }
    void checkFloorAhead()
    {
        //put a raycast foward, check if it collides with something in the layer horseOnly.
        //If it does, turn to its rotation.
        int m_LayerToDetect = LayerMask.GetMask("HorseOnly");
        Ray ray = new Ray(transform.position, transform.forward * 1);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1 , m_LayerToDetect) && transitionTimer >= 0)
        {
            
            hit.transform.gameObject.GetComponent<horseKinaScript>().activated();
            //Vamos ter que fazer superficies de transicao, com a rotacao desejada quando se alcanca elas. Nao superficies de andar por cima.
            transform.rotation = hit.transform.rotation;
            transitionTimer = -2;
            rotatedToFloor = false;
        }
        Ray downray = new Ray(transform.position, transform.up * -4);
        RaycastHit hitdown;
        if (Physics.Raycast(downray, out hitdown, 1, m_LayerToDetect) && transitionTimer >= 0)
        {
            
            hitdown.transform.gameObject.GetComponent<horseKinaScript>().activated();
            //Vamos ter que fazer superficies de transicao, com a rotacao desejada quando se alcanca elas. Nao superficies de andar por cima.
            transform.rotation = hitdown.transform.rotation;
            transitionTimer = -2;
            rotatedToFloor = false;
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 1);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.up * -1);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.U))
        {
            Controller.Instance.GetComponent<SphereCollider>().enabled = false;
            Controller.Instance.StickedToHorse = true;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TrueFence" && Controller.Instance.StickedToHorse)
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    */
}
