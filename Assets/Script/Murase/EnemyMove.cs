using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove: MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject donguri;
    public GameObject wallcheckObj;
    Rigidbody rb;
    WallCheck wallcheck;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    public float Speed;
    public float rotateSpeed;
    public float stopDist;
    public float searchDist;

    private Animator animator;
    private string walkStr = "isWalk";
    private string panchStr = "isPanch";
    private string rollStr = "isRoll";

    private bool isRoll = false;
    private bool startRollattack = false;
    public float RpreCount;
    private float count = 0;
    private bool startCount = false;
    public float Rspeed;
    public float RAddSpeed;
    public float RMaxSpeed;
    public float stuntime;
    public float stuncount;
    private bool startStuncount = false;
    float SetSpeed;

    bool setVec = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (wallcheckObj != null)
        {
            wallcheck = wallcheckObj.GetComponent<WallCheck>();
        }
        GameObject targetObject = target.gameObject;
        SetSpeed = Rspeed;
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Panch");
        bool isWait = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Wait");
        bool isRollstart = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Rolling");

        if (Vector3.Distance(agent.transform.position, target.position) <= searchDist && !isRoll)
        {
            if (target != null && agent.enabled == true)
            {
                agent.destination = target.position;
                agent.speed = Speed;
                /*経路探索を終了するstoppingDistanceとアニメーションを遷移させるstopDistが同じ値だと
                　不具合があったので、-0.3fした距離を設定*/
                agent.stoppingDistance = stopDist - 0.3f;
            }

            if (Vector3.Distance(agent.transform.position, target.position) <= stopDist)
            {
                agent.enabled = false;
                this.animator.SetBool(walkStr, false);
                startCount = true;
                startRollattack = true;
                //obstacle.enabled = true;      
            }
            else
            {
                if (!startRollattack)
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

        if (startCount)
        {
            count += Time.deltaTime;
        }

        if (count >= RpreCount)
        {
            this.animator.SetBool(rollStr, true);
            isRoll = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            if (isRollstart)
            {                    
                Rspeed += RAddSpeed;
                Rspeed = Mathf.Clamp(Rspeed, 0, RMaxSpeed);
                rb.velocity = Vector3.zero;
                rb.velocity = transform.forward * Rspeed;
            }
            
        }
        else
        {
            if (startRollattack)
            {
                float speed = 0.03f;
                Vector3 vec = target.position - transform.position;
                Vector3 nvec = new Vector3(vec.x, transform.position.y, vec.z);
                Quaternion rotation = Quaternion.LookRotation(nvec);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
                //transform.LookAt(nvec);
                Vector3 enemyVec = transform.eulerAngles;
                enemyVec.x = 0.0f;
                enemyVec.z = 0.0f;

                transform.eulerAngles = enemyVec;
                setVec = true;
            }
        }

        if (isRoll)
        {
            if (wallcheckObj != null)
            {
                if (wallcheck.touchWall == true)
                {
                    count = 0;
                    startCount = false;
                    this.animator.SetBool(rollStr, false);
                    rb.constraints = RigidbodyConstraints.None;
                    rb.velocity = Vector3.zero;
                    rb.isKinematic = true;
                    startRollattack = false;
                    Rspeed = SetSpeed;
                    startStuncount = true;
                }
            }
        }

        if (startStuncount)
        {
            stuncount += Time.deltaTime;

            if (stuncount >= stuntime)
            {
                stuncount = 0;
                isRoll = false;
                startStuncount = false;
            }
        }
    }
}
