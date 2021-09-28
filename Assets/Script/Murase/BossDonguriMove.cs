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
    BossBreathEvent bossanim;
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
    private string breathStr = "isBreath";
    private string tackleStr = "isTackle";

    bool setVec = false;

    public float timecount;
    public int AttackSelectTime;
    public int selectAttack;
    private float dist = 0;
    private bool startBreath = false;
    private bool timeSet = false;
    private bool startStampflag = false;
    private bool startStamp = false;
    private float stunCount = 0;
    private float startTackleCount = 0;
    private int TstartTime = 4;
    private bool startTackle = false;
    public bool stopBreath = true;
    public bool isTackle = false;
    private float BafterCount = 0;

    //サウンド関係の部分
    private CriAtomSource Breath;
    public GameObject TackleSound;
    private CriAtomSource Tackle;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
        bossanim = donguri.GetComponent<BossBreathEvent>();
        particle = BparticleObj.GetComponent<ParticleSystem>();
        tparticle = TparticleObj.GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        wallcheck = wallCheckObj.GetComponent<WallCheck>();
        GameObject targetObject = target.gameObject;
        timecount = 0;
        particle.Stop();
        tparticle.Stop();
        TSetSpeed = Tspeed;

        //サウンド
        Breath = GetComponent<CriAtomSource>();
        stopBreath = true;
        Tackle = TackleSound.GetComponent<CriAtomSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stamp");
        bool isWait = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Wait");
        bool IsBreath = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Breath");

        Vector3 Ppos = new Vector3(target.position.x, 0.0f, target.position.z);
        Vector3 Epos = new Vector3(transform.position.x, 0.0f, transform.position.z);

        dist = Mathf.Sqrt(Mathf.Pow(Ppos.x - Epos.x, 2) + Mathf.Pow(Ppos.z - Epos.z, 2));

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
            if (dist <= stopDist)
            {
                selectAttack = 1;
            }
            else if(dist <= BreathDist)
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
            if (target != null && agent.enabled == true)
            {
                agent.destination = target.position;
                agent.speed = Speed;
                /*経路探索を終了するstoppingDistanceとアニメーションを遷移させるstopDistが同じ値だと
                　不具合があったので、-0.3fした距離を設定*/
                agent.stoppingDistance = stopDist - 0.3f;
            }

            if (dist <= stopDist)
            {
                //Wait
                agent.enabled = false;
                this.animator.SetBool(walkStr, false);
            }
            else
            {
                //Walk 
                agent.enabled = true;
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
                    this.animator.SetBool(stampStr, false);
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

            if (!startStampflag)
            {
                if (dist <= stopDist)
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
        }

        //Breath攻撃
        if (selectAttack == 2)
        {
            agent.enabled = false;
            this.animator.SetBool(walkStr, false);
            this.animator.SetBool(breathStr, true);

            //ブレス攻撃が始まるまでのボスの向きを変更
            if (!startBreath)
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
            
            if (bossanim.IsBreath)
            {
                if (!startBreath)
                {
                    particle.Play();
                    stopBreath = false;
         
                }  
                
                startBreath = true;
            }

            if (startBreath && !IsBreath)
            {
                this.animator.SetBool(breathStr, false);
                particle.Stop();
                stopBreath = true;
                BafterCount += Time.deltaTime;
            }

            if (BafterCount >= 1)
            {
                selectAttack = 0;
                timeSet = false;
                startBreath = false;
                BafterCount = 0;
            }
           
            /*if (bossanim.stopBreath)
            {
                particle.Stop();
            }*/


            /*if (bossanim.finishBreath)
            {
                this.animator.SetBool(breathStr, false);
                selectAttack = 0;
                timeSet = false;
                startBreath = false;
            }*/
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
                    isTackle = false;
                    tparticle.Stop();
                    Tackle.Stop();
                    rb.velocity = Vector3.zero;
                    stunCount += Time.deltaTime;
                    this.animator.SetBool(tackleStr, false);

                    if (stunCount >= TstunTime)
                    {
                        stunCount = 0;
                        rb.constraints = RigidbodyConstraints.None;
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
                    if (!isTackle)
                    {
                        Tackle.Play();
                        tparticle.Play();
                        isTackle = true;
                    }
                   
                }
            }
           
        }
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

    public void BreathSound()
    {
        //サウンド
        Breath.Play();
    }
}
