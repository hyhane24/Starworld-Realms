using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggieLookAtPlayer : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(target.transform);
    }
}
