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
    private void Awake(){
        nowHp = maxHp;
    }
    void Start(){
        GameObject objHPGauge = (GameObject)Instantiate(preHPGauge, objCanvas.transform);
        hPGauge = objHPGauge.GetComponent<HPGauge>();
        hPGauge.MaxHP = maxHp;
        hpSlider = gameObject.GetComponent<Slider>();
        hpSlider.maxValue = maxHp;
        hpSlider.value = (float)nowHp / maxHp;
    }
    void Update(){ 
        hPGauge.HP = nowHp;
        if (nowHp >= 0) hpSlider.value = (float)nowHp / maxHp;
        else if (nowHp < 0)nowHp = 0;
    }
    public void Attack_1(){
        nowHp -= 1;
    }
    public void Attack_2(){
        nowHp -= 3;
    }
    public void Attack_3(){
        nowHp -= 10;
    }
}