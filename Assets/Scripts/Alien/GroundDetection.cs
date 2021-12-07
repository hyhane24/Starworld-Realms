using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log("Ground trigger enter: " + other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "ground")
        {
            Debug.Log("Ground trigger");
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

//        Debug.Log("Ground trigger exit: " + other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "ground")
        {
            Debug.Log("Ground trigger exit");
            isGrounded = false;
        }
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void ForceSetIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }
}
