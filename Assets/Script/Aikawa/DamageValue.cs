using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageValue : MonoBehaviour
{
    Slider hpSlider;
    [SerializeField] int maxHp;
    int nowHp;
    public GameObject preHPGauge;
    public Canvas objCanvas;
    private HPGauge hPGauge;
    GameObject objHPGauge;
    private void Awake(){
        nowHp = maxHp;
    }
    void Start(){
        objHPGauge = (GameObject)Instantiate(preHPGauge, objCanvas.transform);
        hPGauge = objHPGauge.GetComponent<HPGauge>();
        hPGauge.MaxHP = maxHp;
        hpSlider = gameObject.GetComponent<Slider>();
        hpSlider.maxValue = maxHp;
        hpSlider.value = (float)nowHp / maxHp;
    }
    void Update(){ 
        hPGauge.HP = nowHp;
        hpSlider.value = (float)nowHp / maxHp;
    }
    public void Attack(){
        
    }
    public void Attack_1(){
        if (nowHp >= 1)nowHp -= 1;
    }
    public void Attack_2(){
        if (nowHp >= 3)nowHp -= 3;
    }
    public void Attack_3(){
        if (nowHp >= 10)nowHp -= 10;
    }
}