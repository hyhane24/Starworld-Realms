using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject coin;
    public Animator anim;

   void OnTriggerEnter(Collider other)
   {
       
       if (other.transform.gameObject.tag == "Player")
       {
           anim = gameObject.GetComponent<Animator>();
            coin.SetActive(false);
            anim.SetBool("move", true);
       
       //this.transform.gameObject.SetActive(false);
       
   }

   }
}
