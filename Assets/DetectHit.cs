using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    public bool hit;
    private void Start()
    {
        hit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log("HIT");
            if (!hit)
            {
                hit = true;
                StartCoroutine(waiter());
            }
            

        }
    }

    IEnumerator waiter()
    {
        
        transform.Rotate(new Vector3(0, 0, 25), Space.World);
        yield return new WaitForSeconds(15);
        transform.Rotate(new Vector3(0, 0, -25), Space.World);
        hit = false;
        //Debug.Log(hit);
    }
}
