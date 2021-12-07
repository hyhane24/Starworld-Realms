using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRootMotionControlScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    //private bool isGrounded;
    private GameObject enclosingSphere;
    private EnclosingSphereContact enclosingSphereContact;

    private GameObject fire;
    private Animator fireAnimator;
    private bool firing = false;
    private FiringScript firingScript;

    private float translationalInput = 0f;
    private float rotationalInput = 0f;

    public float forwardInputFilter = 5f;
    public float turnInputFilter = 5f;

    public float forwardSpeedLimit = 10f;

    public float animationSpeed = 1.0f;
    public float fastModifier = 1.0f;

    private float h = 0;
    private float v = 0;

    public float horizThreshold = 0.1f;
    public float verThreshold = 0.1f;

    private bool jumping = false;
    private bool back = false;

    void Start()
    {

    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.Log("Animator not found");

        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("Rigidbody not found");

        enclosingSphere = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        if (enclosingSphere == null)
            Debug.Log("Enclosing sphere not found");

        enclosingSphereContact = enclosingSphere.GetComponent<EnclosingSphereContact>();
        if (enclosingSphereContact == null)
            Debug.Log("Enclosing sphere contact script not found");

        fire = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        if (fire == null)
            Debug.Log("Fire obj not found");

        fireAnimator = fire.GetComponent<Animator>();
        if (fireAnimator == null)
            Debug.Log("Fire animator not found");

        firingScript = fire.GetComponent<FiringScript>();
        if (firingScript == null)
            Debug.Log("Firing script not found");

        animator.applyRootMotion = true;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        /* if (v > 0.1)
             animator.SetBool("hop", true);
         else if (enclosingSphereContact.GetIsGrounded())
             animator.SetBool("hop", false);
        */
        if (h > horizThreshold || h < -horizThreshold)
        {
            h = h * Mathf.Sqrt(1f - 0.5f * v * v);
            rotationalInput = Mathf.Lerp(rotationalInput, h, Time.deltaTime * turnInputFilter);
        }
        else
        {
            rotationalInput = 0;
        }

        if (v > verThreshold && !back)
        {
            v = v * Mathf.Sqrt(1f - 0.5f * h * h);
            translationalInput = Mathf.Clamp(Mathf.Lerp(translationalInput, v, fastModifier * Time.deltaTime * forwardInputFilter), -forwardSpeedLimit, forwardSpeedLimit);
        } 
        else
        {
            translationalInput = 0f;
        }

        if (enclosingSphereContact.GetIsGrounded()) //Change modes only when grounded
        {
            jumping = false;
            /*if (Input.GetKey(KeyCode.LeftShift))
            {
                fastModifier = 2;
                //Debug.Log("Fast mode");
            }
            else
            {
                fastModifier = 0.5f;
                //Debug.Log("Reg mode");
            }*/

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("In jump code");
                //rb.AddForce(new Vector3(0, 10, 0) * thrust, ForceMode.Impulse);
                enclosingSphereContact.ForceSetIsGrounded(false);
                jumping = true;
            }
        }

        if(enclosingSphereContact.GetIsGrounded() && Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right jump time!");
        }
        if (enclosingSphereContact.GetIsGrounded() && Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left jump time!");
        }

        /*       if (Input.GetKey(KeyCode.Space))
               {
                   firing = true;
                   //Debug.Log("Firing");
               }
               else
               {
                   firing = false;
                   //Debug.Log("Not firing");
               }
        */
        //Debug.Log("h= " + h + ", v=" + v);
    }

    void FixedUpdate()
    {

        animator.speed = fastModifier * animationSpeed;
        //Debug.Log("animator.speed=" + animator.speed);

        //if (translationalInput < 0)
        //    translationalInput = 0;
        animator.SetFloat("velx", rotationalInput);
        animator.SetFloat("vely", translationalInput);
        animator.SetBool("jumping", jumping);
        animator.SetBool("back", Input.GetAxisRaw("Vertical") < 0f);
        animator.Update(Time.deltaTime);

        fireAnimator.SetBool("trigger", Input.GetMouseButton(0) && firingScript.GetNumBullets()>0);
        fireAnimator.Update(Time.deltaTime);
        //Debug.Log("trigger = " + fireAnimator.GetBool("trigger"));
    }


    void OnAnimatorMove()
    {
        Debug.Log("OnAnimMove");
        Vector3 newRootPosition;
        Quaternion newRootRotation;

        if (enclosingSphereContact.GetIsGrounded())
        {
            //Debug.Log("Grounded");
            newRootPosition = animator.rootPosition;
        }
        else
        {
            //Debug.Log("Not grounded");
            newRootPosition = new Vector3(animator.rootPosition.x, this.transform.position.y, animator.rootPosition.z);
        }

        newRootRotation = animator.rootRotation;

        rb.MovePosition(newRootPosition);
        rb.MoveRotation(newRootRotation);

        //Debug.Log("newRootPosition= " + newRootPosition + ", newRootRotation=" + newRootRotation);
    }
}