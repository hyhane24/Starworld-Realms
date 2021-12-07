using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddHealth : MonoBehaviour
{
    public int step = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("health trigger. tag=" + other.transform.gameObject.tag);
        if (other.transform.gameObject.tag == "Player" || other.transform.gameObject.tag == "EnclosingSphere")
        {
            Debug.Log("health trigger player");
            EnclosingSphereContact enclosingSphereContact;
            if (other.transform.gameObject.tag == "Player")
                enclosingSphereContact = other.transform.GetChild(0).GetChild(0).GetComponent<EnclosingSphereContact>();
            else
                enclosingSphereContact = other.transform.GetComponent<EnclosingSphereContact>();
            Debug.Log("health trigger player trace 1");
            if (enclosingSphereContact.maxHealth != enclosingSphereContact.health)
            {
                Debug.Log("health trigger player trace 2");
                this.transform.parent.gameObject.SetActive(false);
                enclosingSphereContact.health = Math.Min(enclosingSphereContact.maxHealth, enclosingSphereContact.health + step);
                enclosingSphereContact.SetHealthText();
                //Debug.Log("Health increased");
            }
            Debug.Log("health trigger player trace 3");
        }
    }
}
