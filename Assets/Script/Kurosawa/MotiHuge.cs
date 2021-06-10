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
        transform.localScale = new Vector3(0f+plus, 1f, 1f );
        //transform.localPosition = new Vector3(-0.5f - plus, 0.5f, 0f);//(1.5f+plus*0.5f, 0, 0);-0.5f - plus
        plus = plus + 0.005f;
        if (plus > 5)
        {
            plus = 5;//餅の大きさの限界
        }

    }
    public void KeepScale()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
        transform.localPosition = new Vector3(0f, 0.25f, 0f);
    }
    public void ResetE()
    {
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);//マウス放したときに餅のサイズを０にする
        //transform.localPosition = new Vector3(1.5f, 0, 0);
        plus = 0;//サイズリセット
    }
}
