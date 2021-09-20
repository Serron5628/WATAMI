using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public GameObject boss;
    [SerializeField]
    GameObject mochi;
    [SerializeField]
    float mochiLength;
    [SerializeField]
    int enemyCount;
    public int childMochi;

    [SerializeField]
    int point;
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        if (mochi == null)
        {
            mochi = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = mochi.transform.childCount;
        Debug.Log(enemyCount - childMochi);
    }

    void OnTriggerEnter(Collider other)
    {
        //どうしようか考えてる
        if (other.gameObject == boss)
        {
            mochiLength = this.gameObject.GetComponent<CapsuleCollider>().height;
            //式は仮置きぃ
            point += (int)mochiLength + enemyCount;
            Debug.Log(point);
        }
    }
}
