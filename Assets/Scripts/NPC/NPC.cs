using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private GameObject player;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    public GameObject pressToTalkText;

    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (playerInRange) {
            //display press f to talk text and polay wake up animation
            anim.Play("WakeUp");
            pressToTalkText.SetActive(true);

            //diplay dialog box if button pressed
            if (Input.GetKeyUp(KeyCode.F))
            {
                if (!dialogBox.activeInHierarchy)
                {
                    pressToTalkText.SetActive(false);
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;                    
                }
                else
                {
                    dialogBox.SetActive(false);
                    //dialogText.text = dialog;
                    pressToTalkText.SetActive(true);
                }
            }
        } else {
            anim.Play("ShutDown");
            pressToTalkText.SetActive(false);
            dialogBox.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            playerInRange = true;
            player = c.gameObject;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            playerInRange = false;
            player = null;
        }
    }
}
