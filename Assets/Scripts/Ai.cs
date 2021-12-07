using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    private NavMeshAgent agent;

    public float radius;
    public float Range;
    Transform target;
    AudioSource audioSource;
    bool audioPlaying = false;
    public AudioClip audioClip;
    private ShootPlayer shootPlayer;
    //private ShootIce shootIce;
    //private ShootEarth shootEarth;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameObject.tag =="Slime_Red")
        shootPlayer = GetComponent<ShootPlayer>();

        if (shootPlayer && shootPlayer.temp)
        {
            agent.isStopped = true;
        }
        else if (Vector3.Distance(target.position, transform.position) <= 12f && Vector3.Distance(target.position, transform.position) >= 9.0f)
        {
            if (!shootPlayer || (shootPlayer && !shootPlayer.temp))
            {
                Debug.Log("RabDIST-------" + Vector3.Distance(target.position, transform.position));
                transform.LookAt(target);
                agent.isStopped = true;
                transform.position += transform.forward * 3.0f * Time.deltaTime;
            }

        }
        else
        {
            agent.isStopped = false;
        }
        if (!agent.hasPath && !agent.isStopped)
        {
            //if(!audioPlaying)
            PlayAudio();
            agent.SetDestination(GetRandomPoint(transform, radius));
            //Debug.Log(agent.SetDestination(GetRandomPoint(transform, radius)));
            //Debug.Log(agent.SetDestination(GetRandomPoint(transform, radius)));
            audioPlaying = true;
        }
    }
    private void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        //audioPlaying = false;
    }
    public Vector3 GetRandomPoint(Transform point = null, float radius = 0)
    {
        Vector3 _point;

        if (RandomPoint(point == null ? transform.position : point.position, radius == 0 ? Range : radius, out _point))
        {
            Debug.DrawRay(_point, Vector3.up, Color.black, 1);

            return _point;
        }

        return point == null ? Vector3.zero : point.position;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;

        return false;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

#endif
}