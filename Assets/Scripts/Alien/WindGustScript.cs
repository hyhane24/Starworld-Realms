using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGustScript : MonoBehaviour
{
    private Animator animator;
    private bool gust = false;

    public GameObject trackObj;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.Log("Animator not found");

        if (trackObj == null)
            Debug.Log("Tracking object not found");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.V) && trackObj != null)
        {
            gust = true;
            //Debug.Log("Gust triggered");
        }
        else
        {
            gust = false;
            //Debug.Log("Gust not triggered");
        }
        if(!gust && trackObj != null)
        {
            this.transform.position = trackObj.transform.position;
            this.transform.rotation = trackObj.transform.rotation;
        }
    }

    void FixedUpdate()
    {
        animator.SetBool("trigger", gust);
        //Debug.Log("wind gust animator trigger = " + animator.GetBool("trigger"));
    }
}
