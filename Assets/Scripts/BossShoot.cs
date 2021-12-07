using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Transform target;
    public GameObject projectile;
    public GameObject temp, temp1, temp2, temp3, temp4;
    public int enemyType = 0;
    public float fireRate = 3f;
    float nextFire;
    Rigidbody rb,rb1,rb2,rb3,rb4;
    public bool hit = false;
    bool isActive;
    float dist;
    AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        nextFire = Time.time;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        dist = Vector3.Distance(target.position, transform.position);
        Debug.Log(target.name);
        Debug.Log(dist);
        //Set distance here
        if (dist <= 50f && !hit)
        {
            isActive = true;
            gameObject.transform.LookAt(target.transform);
            if (Time.time > nextFire)
            {
                Destroy(temp);
                Destroy(temp1);
                Destroy(temp2);
                Destroy(temp3);
                Destroy(temp4);
                PlayAudio();
                temp = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation);
                temp.transform.LookAt(target);
                rb = temp.GetComponent<Rigidbody>();
                rb.velocity = temp.transform.forward * 40f;
                //

                temp1 = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation * Quaternion.Euler(0, -20, 0));
                temp1.transform.LookAt(target);


                rb1 = temp1.GetComponent<Rigidbody>();
                rb1.velocity = temp1.transform.forward * 35.0f;

                temp2 = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation * Quaternion.Euler(0, 20, 0));
                temp2.transform.LookAt(target);
                rb2 = temp2.GetComponent<Rigidbody>();
                rb2.velocity = temp2.transform.forward * 40.0f;

                //temp3 = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.rotation);
                //temp3.transform.LookAt(target);
                //rb3 = temp3.GetComponent<Rigidbody>();
                //rb3.velocity = temp3.transform.forward * 20.0f;





                nextFire = Time.time + fireRate;

            }
            temp.transform.LookAt(target.transform);

        }
        if (Vector3.Distance(target.position, transform.position) > 50f && temp != null)
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

}
