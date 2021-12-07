using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIce : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    public GameObject temp;
    public int enemyType = 0;
    float fireRate;
    float nextFire;
    Rigidbody rb;
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
        if (Vector3.Distance(target.position, transform.position) <= 20f && !hit)
        {
            isActive = true;
            transform.LookAt(target.transform.position);
            if (Physics.Raycast(transform.position, transform.forward, out rayHit, 50f) && rayHit.transform.tag != "MazeWall" && Time.time > nextFire)
            {
                Destroy(temp);
                temp = Instantiate(projectile, transform.position, transform.rotation);
                rb = temp.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 1000.0f);
                nextFire = Time.time + fireRate;
                PlayAudio();

            }
            temp.transform.LookAt(target.transform);

        }
        if (Vector3.Distance(target.position, transform.position) > 10f && temp != null)
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
        Debug.Log(child.tag);
        float normalizedTime = 0;
        float totTime = 0;
        while (normalizedTime <= 1f)
        {
            progt.x -= Time.deltaTime / 3500;
            Debug.Log(progt.x);
            child.localScale = progt;
            normalizedTime += Time.deltaTime / (duration);
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
