using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateButton : MonoBehaviour
{
    public int mov;

    void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            this.transform.gameObject.SetActive(false);
            mov = 99;
        }
    }

}
