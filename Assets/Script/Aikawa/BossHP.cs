using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour{
    public Slider hpSlider;
    public float nowHp = 100, maxHp = 100;
    //private float damageCountTime = 0.0f;
    void Start() {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }
    void OnTriggerEnter(Collider other){
        if(other.tag=="lastAttack")
        Damage_03();
    }
    void Update() {
        
    }
    public void Damage_01(){
        hpSlider.value -= 1;
    }
    public void Damage_02(){
        hpSlider.value -= 3;
    }
    public void Damage_03(){
        hpSlider.value -= 10;
    }
}
