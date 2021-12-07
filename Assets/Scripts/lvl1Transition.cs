using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1Transition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided " + other);
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("lvl1");
        }
    }
}
