using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIceBarrage : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    public GameObject temp, temp1,temp2,temp3,temp4;
    public int enemyType = 0;
    float fireRate;
    float nextFire;
    Rigidbody rb,rb1,rb2,rb3,rb4;
    public bool hit = false;
    bool isActive;
    AudioSource audioSource;
    public AudioClip audioClip;
    private RaycastHit rayHit;
    Vector3 progTime;

    void Start()
    {
        fireRate = 3f;
        nextFire = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        progTime = transform.GetChild(2).localScale;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (hit == true && temp) Destroy(temp);
        //Set distance here
        if (Vector3.Distance(target.position, transform.position) <= 15f && !hit)
        {
            
            isActive = true;
            gameObject.transform.LookAt(target.transform);
            if (Physics.Raycast(transform.position, transform.forward, out rayHit, 50f) && rayHit.transform.tag != "MazeWall" && Time.time > nextFire)
            {
                Destroy(temp);
                Destroy(temp1);
                Destroy(temp2);
                Destroy(temp3);
                Destroy(temp4);
                temp = Instantiate(projectile, transform.position, transform.rotation);
                rb = temp.GetComponent<Rigidbody>();
                rb.velocity = temp.transform.forward * 100.0f;
                
                temp1 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -10, 0));
                rb1 = temp1.GetComponent<Rigidbody>();
                rb1.velocity = temp1.transform.forward * 100.0f;
                
                temp2 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 10, 0));
                rb2 = temp2.GetComponent<Rigidbody>();
                rb2.velocity = temp2.transform.forward * 100.0f;
                
                temp3 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, -20, 0));
                rb3 = temp3.GetComponent<Rigidbody>();
                rb3.velocity = temp3.transform.forward * 100.0f;
                
                temp4 = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 20, 0));
                rb4 = temp4.GetComponent<Rigidbody>();
                rb4.velocity = temp4.transform.forward * 100.0f;

                nextFire = Time.time + fireRate;
                PlayAudio();

            }
            //temp.transform.LookAt(target.transform);

        }
        if (Vector3.Distance(target.position, transform.position) > 15f && temp != null)
        {
            Destroy(temp);
            Destroy(temp1);
            Destroy(temp2);
            Destroy(temp3);
            Destroy(temp4);
        }


    }

    private void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
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
            //Debug.Log(progt.x);
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
        //Debug.Log(child.localScale);
    }

}
