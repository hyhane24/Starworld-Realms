using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    public void Start()
    {
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided " + other);
        if (other.tag == "Player")
        {
            //Debug.Log("You win!");
            //gameObject.SetActive(false);
            SceneManager.LoadScene("level3");
            Time.timeScale = 1f;
        }
    }
}
