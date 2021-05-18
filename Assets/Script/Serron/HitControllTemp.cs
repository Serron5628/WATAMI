using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControllTemp : MonoBehaviour
{
    int hitCount;
    bool stickFlag;
    [SerializeField] GameObject donguri;
    [SerializeField] GameObject moti;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        stickFlag = false;

    }

    void FixedUpdate()
    {
        //HP減ったときに何かするってなったらここいじってくれればおｋ
        if(hitCount == 10)
        {
            stickFlag = true;

        }
        else if(hitCount == 20)
        {

        }

        if(stickFlag == true)
        {
            donguri.GetComponent<StickE5>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //ヒットした回数を数えてる。HP計算するなら引き算に変えた方がいい
        if(other.gameObject.tag == "Moti")
        {
            hitCount++;
            Debug.Log("hit!");
        }
        Debug.Log(hitCount);
    }
}