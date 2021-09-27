using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HitControllBurn : MonoBehaviour
{
    public int hitCount;
    //HP1は第一段階のHP。第2形態とかがない敵ならこの値の設定だけでいい
    public int HP1;
    public int HP2;
    bool stickFlag;
    [SerializeField] GameObject donguri;
    public GameObject Kogane;
    public GameObject counter;
    public GameObject Burn;
    public GameObject WallCheck;
    public GameObject BurningSound;

    MotiRotate rotate;

    private CriAtomSource Enemy;
    private CriAtomSource Burning;
    // Start is called before the first frame update


    void Start()
    {
        hitCount = 0;
        stickFlag = false;
        Enemy = GetComponent<CriAtomSource>();
        rotate = Kogane.GetComponent<MotiRotate>();
        Burning = BurningSound.GetComponent<CriAtomSource>();
    }

    void FixedUpdate()
    {
        //HP減ったときに何かするってなったらここいじってくれればおｋ
        if (hitCount >= HP1)
        {
            //stickFlagがtrueになるとstickEのスクリプトを活性化
            stickFlag = true;
        }
        else if (hitCount == HP2)
        {
            //第2段階に入る処理とかはここ。

        }

        if (stickFlag == true)
        {
            donguri.GetComponent<StickE5>().enabled = true;
            Enemy.Play();
            rotate.SpeedUp();
            if (counter)
            {
                counter.GetComponent<EneDestCount>().count--;
            }
            donguri.GetComponent<EnemyPunch>().enabled = false;
            donguri.GetComponent<NavMeshAgent>().enabled = false;
            donguri.GetComponentInChildren<Animator>().enabled = false;
            donguri.GetComponent<MeshCollider>().enabled = false;
            Burn.SetActive(false);
            Burning.Stop();
            stickFlag = false;
            Destroy(WallCheck);
            Destroy(this);
            hitCount++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ヒットした回数を数えてる。
        if (other.gameObject.tag == "Moti")
        {
            hitCount++;
            //Debug.Log("hit!");
        }

    }
}