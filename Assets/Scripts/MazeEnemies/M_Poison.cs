using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Poison : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pGas;
    public GameObject poison;
    float dist;
    public GameObject player;
    bool shouldEmit = true;
    Transform target;
    public bool hit = false;
    AudioSource audioSource;
    public AudioClip audioClip;
    private RaycastHit rayHit;
    Vector3 progTime;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        progTime = transform.GetChild(2).localScale;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        dist = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(shouldEmit);
        if (dist < 7.5f && !hit)
        {
            transform.LookAt(target);
        }
        if (shouldEmit && dist < 7.5f && shouldEmit && !hit && Physics.Raycast(transform.position, transform.forward, out rayHit, 50f) && rayHit.transform.tag != "MazeWall")
        {
            shouldEmit = false;
            PlayAudio();
            pGas = Instantiate(poison, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //pGas.SetActive(true);
            shouldEmit = false;
            StartCoroutine(timer());

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

            Debug.Log("Hit is " + hit);
            if (!hit)
            {
                //GetComponent<Ai>().enabled = false;
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
        //GetComponent<Ai>().enabled = true;
        transform.GetChild(2).gameObject.SetActive(false);
        child.localScale = progTime;
        Debug.Log(child.localScale);
    }


    private IEnumerator timer()
    {

        //Change this to wait till player is away
        yield return new WaitForSeconds(5);
        if (pGas)
        {
            pGas.SetActive(false);
        }

        Destroy(pGas);
        shouldEmit = true;
    }
}
