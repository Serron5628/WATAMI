using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageValue : MonoBehaviour
{

    Slider hpSlider;
    [SerializeField] int maxHp;
    //[SerializeField] int nowHp = 10;
    int nowHp;
    public GameObject preHPGauge;
    public Canvas objCanvas;
    private HPGauge hPGauge;


    private void Awake()
    {
        nowHp = maxHp;
    }

    void Start()
    {
        //GameObject objCanvas = GameObject.Find("Canvas");
        GameObject objHPGauge = (GameObject)Instantiate(preHPGauge, objCanvas.transform);
        hPGauge = objHPGauge.GetComponent<HPGauge>();
        hPGauge.MaxHP = maxHp;

        hpSlider = gameObject.GetComponent<Slider>();

        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;
        hpSlider.value = (float)nowHp / maxHp;
        
    }
    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.Find("Main Camera");
        GameObject.Find("Canvas").transform.LookAt(camera.transform);

        //nowHp = Mathf.FloorToInt(maxHp * hpSlider.value);
        hPGauge.HP = nowHp;
        if (nowHp >= 0)
            hpSlider.value = (float)nowHp / maxHp;
        else if (nowHp < 0)
            nowHp = 0;
        Debug.Log(hpSlider.value);
        
    }
    int cnt = 0;
    public void Method()
    {
    }
    public void Attack_1()
    {
        cnt += 1;
        Debug.Log(cnt);
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