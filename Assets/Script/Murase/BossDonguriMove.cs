using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDonguriMove : MonoBehaviour
{
    public Transform target;
    public GameObject donguri;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    PlayerWarp warpScript;
    public float Speed;
    public float rotateSpeed;
    public float stopDist;
    public bool isAttack;
    public bool distant;

    private Animator animator;

    private string walkStr = "isWalk";
    private string panchStr = "isPanch";

    bool setVec = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
        GameObject targetObject = target.gameObject;
        warpScript = targetObject.GetComponent<PlayerWarp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && agent.enabled == true)
        {
            agent.destination = target.position;
            agent.speed = Speed;
            /*経路探索を終了するstoppingDistanceとアニメーションを遷移させるstopDistが同じ値だと
            　不具合があったので、-0.3fした距離を設定*/
            agent.stoppingDistance = stopDist - 0.3f;
        }

        this.animator.enabled = true;
        isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Panch");

        if (Vector3.Distance(agent.transform.position, target.position) <= stopDist)
        {
            distant = true;
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
            distant = false;

            if (isAttack == false)
            {

                agent.enabled = true;
                obstacle.enabled = false;

                this.animator.SetBool(walkStr, true);
            }
        }
    }
}
