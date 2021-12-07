using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
    //To implement Stealth, Hazardous poison when close, Force field when close, Racing, Boss
{
    public Transform target;
    public GameObject projectile;
    public GameObject temp;
    public int enemyType = 0;
    float fireRate;
    float nextFire;
    DetectHit detect;
    bool isActive;
    public bool hit;
    AudioSource audioSource;
    public AudioClip audioClip;
    private RaycastHit rayHit;
    Vector3 progTime;
    void Start()
    {
        if (enemyType == 0) fireRate = 3.0f;
        else fireRate = 0.5f;
        nextFire = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        hit = false;
        audioSource = GetComponent<AudioSource>();
        progTime = transform.GetChild(2).localScale;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //Set distance here
        if (hit == true && temp) Destroy(temp);
        //hit = true;
        if (Vector3.Distance(target.position, transform.position) <=15f && !hit && Physics.Raycast(transform.position, transform.forward, out rayHit, 50f) && rayHit.transform.tag != "MazeWall")
        {
            isActive = true;
            gameObject.transform.LookAt(target.transform);
            if (Time.time > nextFire)
            {
                PlayAudio();
                Destroy(temp);
                temp = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), transform.rotation);
                //temp.transform.parent = transform.parent;
                
                nextFire = Time.time + fireRate;

            }
            if (temp)
            {
                temp.transform.position = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
            }
            temp.transform.LookAt(target.transform);
            
        }
        if(Vector3.Distance(target.position, transform.position) > 15f && temp != null)
        {
            Destroy(temp);
        } 


    }

    private void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Bullet")
        {
            //hit = true;
            //Debug.Log("HIT 1231"+hit);
            //hit = true;
            Debug.Log("Hit is " + hit);
            if (!hit)
            {
                GetComponent<Ai>().enabled = false;
                hit = true;
                StartCoroutine(waiter());
            }

            Debug.Log("Hit is " + hit);
        }
    }

    IEnumerator waiter()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        float duration = 7.0f;
        Vector3 progt = progTime;
        //Debug.Log(progt);
        transform.Rotate(new Vector3(25.0f, 0, 0), Space.World);
        Transform child = transform.GetChild(2);
        //Debug.Log(child.tag);
        float normalizedTime = 0;
        float totTime = 0;
        while (normalizedTime <= 1f)
        {
            progt.x -= Time.deltaTime / 70;
            Debug.Log(progt.x);
            child.localScale = progt;
            normalizedTime += Time.deltaTime / duration;
            //totTime += Time.deltaTime;
            yield return null;
        }
        //Debug.Log(normalizedTime/10);
        //yield return new WaitForSeconds(7);
        transform.Rotate(new Vector3(-25.0f, 0, 0), Space.World);
        hit = false;
        GetComponent<Ai>().enabled = true;
        transform.GetChild(2).gameObject.SetActive(false);
        child.localScale = progTime;
        Debug.Log(child.localScale);
    }


}
