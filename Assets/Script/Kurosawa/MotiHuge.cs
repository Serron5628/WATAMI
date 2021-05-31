using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiHuge : MonoBehaviour
{
    public float plus;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hugeScale()
    {
        transform.localScale = new Vector3(0.5f, 0.01f + plus, 0.5f);
        transform.localPosition = new Vector3(-0.5f - plus, 0.5f, 0f);//(1.5f+plus*0.5f, 0, 0);-0.5f - plus
        plus = plus + 0.0005f;
        if (plus > 3)
        {
            plus = 3;//餅の大きさの限界
        }

    }

    public void ResetE()
    {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);//マウス放したときに餅のサイズを０にする
        //transform.localPosition = new Vector3(1.5f, 0, 0);
        plus = 0;//サイズリセット
    }
}
