using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empurrador : MonoBehaviour
{
    //este objeto ficara olhando para a bola que ficara sempre a frente do player, mas nunca para cima ou para baixo.
    //Ele ira empurrar o player para seu movimento.
    //Havera outro que seguira o player, a sua frente, que mudara a altura, e outro que sempre seguira a posicao X e Z dessa.
    public GameObject refe;
    public float gravityEnforcer;
    public float jumpForce;
    public GameManager antToRotate;
    public GameObject DebugBall;
    public bool capsOn = true;
    public float x;
    public float z;
    //public GameObject capsText;
    //public GameObject runningAtive;
    //public GameObject notRunningIcon;
    public GameObject flyIcon;
    static empurrador m_Instance;
    string VerticalString;
    string HorizontalString;

    private void Start()
    {
        VerticalString = "Vertical";
        HorizontalString = "Horizontal";
        capsOn = true;
    }

    public static empurrador Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = FindObjectOfType(typeof(empurrador)) as empurrador;
            return m_Instance;
        }
    }

    private void Update()
    {
        transform.position = Controller.Instance.transform.position;
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (!capsOn)
            {
                capsOn = true;
            }
            else
            {
                //capsOn = false;
            }
        }
    }
    private void LateUpdate()
    {
        if (Controller.Instance.isMounted && GriffinKraw.Instance.rigid.velocity.magnitude > 0.3f)
        {
            GriffinKraw.Instance.antToRotate.transform.LookAt(GriffinKraw.Instance.transform.position + GriffinKraw.Instance.rigid.velocity);
            
        }
        
    }


    private void FixedUpdate()
    {
        
        if (Controller.Instance.death || Controller.Instance.StickedToHorse)
        {
            
            return;
        }
        transform.LookAt(refe.transform.position);
        z = Input.GetAxis(VerticalString);
        x = Input.GetAxis(HorizontalString);
        if (x == 0)
        {
            z = z * 1.42f;
        }
        if (z == 0)
        {
            x = x * 1.42f;
        }
        if (Input.GetKey(KeyCode.LeftShift) || capsOn)
        {
            if (capsOn)
            {
                //Destroy(capsText);
            }
            if (!Controller.Instance.isMounted)
            {
                //runningAtive.SetActive(true);
            }
            
            Controller.Instance.currentSpeed = Controller.Instance.runningSpeed;
            if (Controller.Instance.berzerkState)
            {
                Controller.Instance.currentSpeed = Controller.Instance.runningSpeed * 2;
            }
        }
        else
        {
            //runningAtive.SetActive(false);
            Controller.Instance.currentSpeed = Controller.Instance.speed;
            if (Controller.Instance.berzerkState)
            {
                Controller.Instance.currentSpeed = Controller.Instance.speed * 2;
            }
        }
        if (Controller.Instance.isMounted == false)
        {
            Controller.Instance.rigid.AddForce(transform.forward * z * Controller.Instance.currentSpeed);
            Controller.Instance.rigid.AddForce(transform.right * x * Controller.Instance.currentSpeed);
        }
        else //if mounted
        {
            GriffinKraw.Instance.rigid.AddForce(Controller.Instance.transform.forward * z * Controller.Instance.currentSpeed / 1500);
            GriffinKraw.Instance.rigid.AddForce(Controller.Instance.transform.right * x * Controller.Instance.currentSpeed / 1500);
            
            
            if (GriffinKraw.Instance.rigid.velocity.magnitude > 1)
            {
                //GriffinKraw.Instance.antToRotate.transform.LookAt(GriffinKraw.Instance.rigid.velocity * 3 + GriffinKraw.Instance.transform.localPosition);
                //DebugBall.transform.position = GriffinKraw.Instance.rigid.velocity + GriffinKraw.Instance.transform.localPosition;
                //GriffinKraw.Instance.antToRotate.GetComponent<Animator>().SetBool("Walk", true);
                
            }
            else
            {
                GriffinKraw.Instance.anim.SetBool("Walk", false);
            }
        }

        //so aplicar isso em caso de not on floor
        if (!Controller.Instance.onFloor && !Controller.Instance.onWater)
        {
            
            Controller.Instance.rigid.AddForce(transform.up * -gravityEnforcer * 18000);
        }
        if (Controller.Instance.onWater)
        {
            Controller.Instance.rigid.AddForce(transform.up * -gravityEnforcer * 7000);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && Controller.Instance.onFloor)
       //{
            //Controller.Instance.rigid.AddForce(transform.up * jumpForce*50, ForceMode.Acceleration);
        //}
        //if (Controller.Instance.onClutter)
        //{
            //Controller.Instance.rigid.AddForce(transform.up * -gravityEnforcer * 9000);
        //}
    }

    public void SwitchIcon()
    {
        if (Controller.Instance.isMounted)
        {
            flyIcon.SetActive(true);
            //runningAtive.SetActive(false);
            //notRunningIcon.SetActive(false);
        }
        else
        {
            flyIcon.SetActive(false);
            //notRunningIcon.SetActive(true);
        }
    }

}
