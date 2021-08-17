using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDonguriMove : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject donguri;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    public float Speed;
    public float rotateSpeed;
    public float stopDist;
    public float searchDist;
    private Animator animator;
    private string walkStr = "isWalk";
    private string stampStr = "isStamp";

    bool setVec = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = donguri.GetComponent<Animator>();
        if(!playerObj)playerObj = GameObject.FindGameObjectWithTag("Player");
        obstacle = GetComponent<NavMeshObstacle>();
    }
    void Update()
    {
        Vector3 playerPos = playerObj.transform.position;
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stamp");
        bool isWait = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Wait");

        if (Vector3.Distance(agent.transform.position, playerPos) <= searchDist)
        {
            if (agent.enabled == true)
            {
                agent.destination = playerPos;
                agent.speed = Speed;
                /*経路探索を終了するstoppingDistanceとアニメーションを遷移させるstopDistが同じ値だと
                　不具合があったので、-0.3fした距離を設定*/
                agent.stoppingDistance = stopDist - 0.3f;
            }

            if (Vector3.Distance(agent.transform.position, playerPos) <= stopDist)
            {
                agent.enabled = false;
<<<<<<< HEAD
                obstacle.enabled = true;
=======
                //obstacle.enabled = true;

>>>>>>> master
                //Waitモーション時にプレイヤーの方を向かせる
                if (isWait == true)
                {
                    float speed = 0.03f;
                    Vector3 vec = playerPos - transform.position;
                    Vector3 nvec = new Vector3(vec.x, transform.position.y, vec.z);
                    Quaternion rotation = Quaternion.LookRotation(nvec);
                    transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
                    Vector3 enemyVec = transform.eulerAngles;
                    enemyVec.x = 0.0f;
                    enemyVec.z = 0.0f;
                    transform.eulerAngles = enemyVec;
                    setVec = true;
                }
                this.animator.SetBool(walkStr, false);
                this.animator.SetBool(stampStr, true);
            }
            else
            {
                this.animator.SetBool(stampStr, false);
                if (isAttack == false)
                {
                    agent.enabled = true;
                    //obstacle.enabled = false;

                    this.animator.SetBool(walkStr, true);
                }
            }      
        }
        else
        {
            this.agent.enabled = false;
            this.animator.SetBool(walkStr, false);
        }
    }
}
