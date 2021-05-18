using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP_Slider : MonoBehaviour
{
    Slider hpSlider;
    public float maxHp = 5f;
    public float nowHp = 5f;

    // Use this for initialization
    void Start()
    {
        hpSlider = GetComponent<Slider>();

        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;
        //スライダーの現在値の設定
        hpSlider.value = nowHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}