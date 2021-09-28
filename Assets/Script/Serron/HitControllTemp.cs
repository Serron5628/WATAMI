using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitControllTemp : MonoBehaviour
{
    public int hitCount;
    //HP1は第一段階のHP。第2形態とかがない敵ならこの値の設定だけでいい
    public int HP1;
    public int HP2;
    bool stickFlag;
    [SerializeField] GameObject donguri;
    public GameObject Kogane;
    public GameObject counter;

    MotiRotate rotate;

    public GameObject moti0;
    bool SmashOn;
    MotiBend_Anim MBA;

    public GameObject kogane_wait;
    CharaJumpCtrl_2 CJC_2;
    bool CanBlend;

    private CriAtomSource Enemy;
    // Start is called before the first frame update


    void Start()
    {
        hitCount = 0;
        stickFlag = false;
        Enemy = GetComponent<CriAtomSource>();
        rotate = Kogane.GetComponent<MotiRotate>();
        CanBlend = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
    }

    void FixedUpdate()
    {
        //HP減ったときに何かするってなったらここいじってくれればおｋ
        if(hitCount >= HP1)
        {
            //stickFlagがtrueになるとstickEのスクリプトを活性化
            stickFlag = true;
        }
        else if(hitCount == HP2)
        {
            //第2段階に入る処理とかはここ。

        }

        if(stickFlag == true)
        {
            donguri.GetComponent<StickE5>().enabled = true;
            Enemy.Play();
            rotate.SpeedUp();
            if (counter)
            {
                counter.GetComponent<EneDestCount>().count--;
            }
            donguri.GetComponent<EnemyMove>().enabled = false;
            donguri.GetComponent<NavMeshAgent>().enabled = false;
            donguri.GetComponentInChildren<Animator>().enabled = false;
            stickFlag = false;
            Destroy(this);
            hitCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CanBlend = kogane_wait.GetComponent<CharaJumpCtrl_2>().CanBlend;
        //ヒットした回数を数えてる。
        if (other.gameObject.tag == "Moti")
        {
            
            if (CanBlend)
            {
                hitCount++;
                //Debug.Log("hit!");
            }

        }
        
    }
}