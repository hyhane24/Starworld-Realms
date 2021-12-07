using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Earth : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    public GameObject temp;
    public int enemyType = 0;
    float fireRate;
    float nextFire;
    public bool hit = false;
    AudioSource audioSource;
    public AudioClip audioClip;
    bool isActive;
    private RaycastHit rayHit;
    Vector3 progTime;

    void Start()
    {
        fireRate = 4f;
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
            transform.LookAt(target);
        }
        if (Vector3.Distance(target.position, transform.position) <= 10f && !hit)
        {
            isActive = true;

            if (Physics.Raycast(transform.position, transform.forward, out rayHit, 50f) && rayHit.transform.tag != "MazeWall" && Time.time > nextFire)
            {
                Destroy(temp);
                PlayAudio();
                temp = Instantiate(projectile, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation);
                nextFire = Time.time + fireRate;

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
        Debug.Log(other);
        if (other.gameObject.tag == "Bullet")
        {
            if (!hit)
            {
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
        Vector3 forward = transform.forward;
        transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y - 2f, target.transform.position.z));
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
        transform.LookAt(forward);
        hit = false;
        transform.GetChild(2).gameObject.SetActive(false);
        child.localScale = progTime;
        Debug.Log(child.localScale);
    }
}
