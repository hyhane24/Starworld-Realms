using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed;
    private Transform player;
    private Vector3 target;
    private Rigidbody rb;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
        rb = GetComponent<Rigidbody>();

        //Set force here
        dir = (target - transform.position).normalized * 25f;
        rb.velocity = new Vector3(dir.x, dir.y, dir.z);
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
