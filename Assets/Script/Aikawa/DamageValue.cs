using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageValue : MonoBehaviour
{

    Slider hpSlider;
    [SerializeField] float maxHp = 10f;
    [SerializeField] float nowHp = 10f;

    // Use this for initialization
    void Start()
    {
        hpSlider = GetComponent<Slider>();
       
        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;
        hpSlider.value = nowHp;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = nowHp;
    }

    public void Method()
    {
    }
    int cnt = 0;
    public void Attack_1()
    {
        nowHp -= 1;
    }
    public void Attack_2()
    {
        nowHp -= 3;
    }
    public void Attack_3()
    {
        nowHp -= 10;
    }
}