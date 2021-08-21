using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossDonguriMove : MonoBehaviour
{
    public Transform target;
    public GameObject donguri;
    public GameObject particleObj;
    private ParticleSystem particle;
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

    int timecount;
    int attackCount;
    public int AttackSelectTime;
    public int selectAttack;
    private bool isParticle = false;
    private bool timeSet = false;
    private int particleCount = 0;
    private int particlePlayCount = 240;
    private bool startStampflag = false;
    private bool startStamp = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        animator = donguri.GetComponent<Animator>();
        particle = particleObj.GetComponent<ParticleSystem>();
        GameObject targetObject = target.gameObject;
        timecount = 0;
        attackCount = 0;
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttack = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Stamp");
        bool isWait = animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Wait");

        if (timeSet == false)
        {
            timecount += 1;
        }

        if (timecount >= AttackSelectTime)
        {
            //1の場合Stamp,2の場合Breath攻撃
            selectAttack = Random.Range(1, 3);
            timecount = 0;
            timeSet = true;
        }

        //行動を選択するまでの時間の行動
        if (timecount < AttackSelectTime)
        {
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
            //Breath攻撃の発生までの時間
            int preCount = 60;
            attackCount += 1;
            if (attackCount < preCount)
            {
                agent.enabled = false;
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
                    particleCount += 1;
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
}
