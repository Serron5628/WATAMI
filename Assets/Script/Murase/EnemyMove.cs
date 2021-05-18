using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    public float Speed;
    public float stopDist;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && agent.enabled == true)
        {
            agent.destination = target.position;
            agent.speed = Speed;
            agent.stoppingDistance = stopDist;
        }

        if (Vector3.Distance(agent.transform.position, target.position) <= stopDist)
        {
            agent.enabled = false;
            obstacle.enabled = true;
        }
        else
        {
            agent.enabled = true;
            obstacle.enabled = false;
        }
    }
}
