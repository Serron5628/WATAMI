using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControllTemp : MonoBehaviour
{
    int hitCount;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
    }

    void FixedUpdate()
    {
        //HP減ったときに何かするってなったらここいじってくれればおｋ
        if(hitCount == 10)
        {

        }
        else if(hitCount == 20)
        {

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