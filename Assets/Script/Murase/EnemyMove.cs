using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject donguri;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    public float Speed;
    public float rotateSpeed;
    public float stopDist;

    private Animator animator;

    private string walkStr = "isWalk";
    private string panchStr = "isPanch";

    bool setVec = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Panch");

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

            //経路探索をストップした後にプレイヤーの方を向かせる
            /*if (setVec == false)
            {
                Vector3 vec = target.position - transform.position;
                Vector3 nvec = new Vector3(vec.x, transform.position.y, vec.z);
                transform.LookAt(nvec);
                setVec = true;
            }*/

            this.animator.SetBool(walkStr, false);
            this.animator.SetBool(panchStr, true);
        }
        else
        {
            this.animator.SetBool(panchStr, false);
            
            if (isAttack == false)
            {
                
                agent.enabled = true;
                obstacle.enabled = false;

                this.animator.SetBool(walkStr, true);
            }
        }
    }
}
