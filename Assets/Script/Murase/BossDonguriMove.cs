using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDonguriMove : MonoBehaviour
{
    public Transform target;
    public GameObject donguri;
    public GameObject BparticleObj;
    public GameObject TparticleObj;
    public GameObject wallCheckObj;
    private ParticleSystem particle;
    private ParticleSystem tparticle;
    NavMeshAgent agent;
    NavMeshObstacle obstacle;
    Rigidbody rb;
    WallCheck wallcheck;
    public float Speed;
    public float rotateSpeed;
    public float stopDist;
    public float searchDist;
    public float BreathDist;
    public float Tspeed;
    public float TAddSpeed;
    public float TMaxSpeed;
    public int TstunTime;
    float TSetSpeed;

    private Animator animator;
    private string walkStr = "isWalk";
    private string stampStr = "isStamp";
    private string tackleStr = "isTackle";

    bool setVec = false;

    public float timecount;
    float attackCount;
    public int AttackSelectTime;
    public int selectAttack;
    private bool isParticle = false;
    private bool timeSet = false;
    private float particleCount = 0;
    private int particlePlayCount = 4;
    private bool startStampflag = false;
    private bool startStamp = false;
    private float stunCount = 0;
    private float startTackleCount = 0;
    private int TstartTime = 4;
    private bool startTackle = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
        particle = BparticleObj.GetComponent<ParticleSystem>();
        tparticle = TparticleObj.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        wallcheck = wallCheckObj.GetComponent<WallCheck>();
        GameObject targetObject = target.gameObject;
        timecount = 0;
        attackCount = 0;
        particle.Stop();
        tparticle.Stop();
        TSetSpeed = Tspeed;
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stamp");
        bool isWait = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Wait");

        if (timeSet == false)
        {
            timecount += Time.deltaTime;
        }

        if (timecount >= AttackSelectTime)
        {
            //1の場合足踏み攻撃(Stamp),2の場合ブレス攻撃(Breath),3の場合突進攻撃(Tackle)
            //selectAttack = Random.Range(1, 4);
            //selectAttack = 2;
            timecount = 0;
            timeSet = true;
            if (Vector3.Distance(agent.transform.position, target.position) <= stopDist)
            {
                selectAttack = 1;
            }
            else if(Vector3.Distance(agent.transform.position, target.position) <= BreathDist)
            {
                //ブレス攻撃を実行するかどうか
                bool attackflag = changeAttack(50);

                if (attackflag == true)
                {
                    selectAttack = 0;
                    timecount = 0;
                    timeSet = false;
                }
                else
                {
                    selectAttack = 2;
                }
            }
            else
            {
                //突進攻撃を実行するかどうか
                bool attackflag = changeAttack(60);

                if (attackflag == true)
                {
                    selectAttack = 0;
                    timecount = 0;
                    timeSet = false;
                }
                else
                {
                    selectAttack = 3;
                }
            }
        }

        //行動を選択するまでの時間の行動
        if (selectAttack == 0)
        {
            agent.enabled = true;

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
                //Wait
                this.animator.SetBool(walkStr, false);
            }
            else
            {
                //Walk       
                this.animator.SetBool(walkStr, true);
            }
        }

        if (startStampflag == true)
        {
            if (isAttack == true)
            {
                startStamp = true;
            }
            else
            {
                if (startStamp == true)
                {
                    timeSet = false;
                    selectAttack = 0;
                    startStampflag = false;
                    startStamp = false;
                }
            }
        }

        //Stamp攻撃
        if (selectAttack == 1)
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
                //obstacle.enabled = true;

                //Waitモーション時にプレイヤーの方を向かせる
                if (isWait == true)
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

                this.animator.SetBool(walkStr, false);
                this.animator.SetBool(stampStr, true);

                startStampflag = true;
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

        //Breath攻撃
        if (selectAttack == 2)
        {
            this.animator.SetBool(walkStr, false);
            agent.enabled = false;
            //Breath攻撃の発生までの時間
            int preCount = 1;
            attackCount += Time.deltaTime;
            if (attackCount < preCount)
            {
                float speed = 0.03f;
                Vector3 vec = target.position - transform.position;
                Vector3 nvec = new Vector3(vec.x, transform.position.y, vec.z);
                Quaternion rotation = Quaternion.LookRotation(nvec);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);
                
                Vector3 enemyVec = transform.eulerAngles;
                enemyVec.x = 0.0f;
                enemyVec.z = 0.0f;

                transform.eulerAngles = enemyVec;
            }
            else
            {
                if (isParticle == false)
                {
                    particle.Play();
                    isParticle = true;
                }  
                else
                {
                    particleCount += Time.deltaTime;
                }
            }


            if (particleCount >= particlePlayCount)
            {
                particle.Stop();
                attackCount = 0;
                particleCount = 0;
                selectAttack = 0;
                isParticle = false;
                timeSet = false;
                agent.enabled = true;
            }
        }

        //Tackle攻撃
        if (selectAttack == 3)
        {
            agent.enabled = false;
            startTackleCount += Time.deltaTime;

            if (startTackleCount >= TstartTime)
            {
                startTackle = true;
            }
            else
            {
                this.animator.SetBool(walkStr, false);
                startTackle = false;

                float speed = 0.03f;
                Vector3 vec = target.position - transform.position;
                Vector3 nvec = new Vector3(vec.x, transform.position.y, vec.z);
                Quaternion rotation = Quaternion.LookRotation(nvec);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

                Vector3 enemyVec = transform.eulerAngles;
                enemyVec.x = 0.0f;
                enemyVec.z = 0.0f;

                transform.eulerAngles = enemyVec;
            }

            if (startTackle)
            {
                if (wallcheck.touchWall == true)
                {
                    tparticle.Stop();
                    rb.velocity = Vector3.zero;
                    stunCount += Time.deltaTime;
                    this.animator.SetBool(tackleStr, false);

                    if (stunCount >= TstunTime)
                    {
                        stunCount = 0;
                        rb.constraints = RigidbodyConstraints.None;
                        agent.enabled = true;
                        rb.isKinematic = true;
                        startTackle = false;
                        Tspeed = TSetSpeed;
                        selectAttack = 0;
                        startTackleCount = 0;
                        timeSet = false;
                    }
                }
                else
                {
                    this.animator.SetBool(walkStr, false);
                    this.animator.SetBool(tackleStr, true);
                    rb.isKinematic = false;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;

                    Tspeed += TAddSpeed;
                    Tspeed = Mathf.Clamp(Tspeed, 0, TMaxSpeed);
                    rb.velocity = Vector3.zero;
                    rb.velocity = transform.forward * Tspeed;
                    tparticle.Play();
                }
            }
           
        }

        /*if (Vector3.Distance(agent.transform.position, target.position) <= searchDist)
        {

            if (target != null && agent.enabled == true)
            {
                agent.destination = target.position;
                agent.speed = Speed;
                //経路探索を終了するstoppingDistanceとアニメーションを遷移させるstopDistが同じ値だと
                //不具合があったので、-0.3fした距離を設定
                agent.stoppingDistance = stopDist - 0.3f;
            }

            if (Vector3.Distance(agent.transform.position, target.position) <= stopDist)
            {
                agent.enabled = false;
                //obstacle.enabled = true;

                //Waitモーション時にプレイヤーの方を向かせる
                if (isWait == true)
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
        }*/
    }

    private bool changeAttack(int rate)
    {
        if ((Random.value * 100f) < rate)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
