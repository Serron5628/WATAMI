using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitControllTemp : MonoBehaviour
{
    int hitCount;
    //HP1は第一段階のHP。第2形態とかがない敵ならこの値の設定だけでいい
    public int HP1;
    public int HP2;
    bool stickFlag;
    [SerializeField] GameObject donguri;
    public GameObject Kogane;
    public GameObject counter;

    MotiRotate rotate;

    private CriAtomSource Enemy;
    // Start is called before the first frame update


    void Start()
    {
        hitCount = 0;
        stickFlag = false;
        Enemy = GetComponent<CriAtomSource>();
        rotate = Kogane.GetComponent<MotiRotate>();
    }

    void FixedUpdate()
    {
        //HP減ったときに何かするってなったらここいじってくれればおｋ
        if(hitCount == HP1)
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
            if (counter == true)
            {
                counter.GetComponent<EneDestCount>().count--;
                Destroy(this);
            }
            donguri.GetComponent<EnemyMove>().enabled = false;
            donguri.GetComponent<NavMeshAgent>().enabled = false;
            donguri.GetComponentInChildren<Animator>().enabled = false;
            stickFlag = false;
            hitCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ヒットした回数を数えてる。
        if(other.gameObject.tag == "Moti")
        {
            hitCount++;
            //Debug.Log("hit!");
        }
        
    }
}