using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour{
    public Slider hpSlider;
    public BossAttackHit bossAttackHit;

    public float maxHp = 50f,nowHp;
    public int damage_touchDonguri = 1;
    public int damage_touchBoss = 2;
    public int damage_bossRush = 5;
    public int damage_breath = 1;
    public int damage_hitLeftStump = 3;
    public int damage_hitRightStump = 3;

    private float cnt1 = 0, cnt2 = 0, cnt3 = 0;

    void Start(){
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }

    void Update(){
        if(bossAttackHit.hitBreath)
            Damage_Breath();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "enemy"){
            hpSlider.value -= damage_touchDonguri;
        }
        if(other.gameObject.tag == "Boss"){
            hpSlider.value -= damage_touchBoss;
        }
        if(other.gameObject.name == "BlueFlame"){
            hpSlider.value -= damage_breath;
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag=="enemy"){
            Damage_TouchDonguri();
        }
        
        if(other.gameObject.tag=="Boss"){
            Damage_TouchBoss();
        }
    }

    /*
    どんぐり、ボスに触れた時 2
    ボス攻撃（突進・ブレス・地ならし）3
    */

    public void Damage_Breath(){
        //ボスのbreath攻撃のダメージ
        cnt1 += Time.deltaTime;
        if(cnt1 > 0.2){
            hpSlider.value -= damage_breath;
            cnt1 = 0.0f;
        }
    }

    public void Damage_TouchDonguri(){
        //どんぐりに触れている時のダメージ
        cnt2 += Time.deltaTime;
        if(cnt2 > 1){
            hpSlider.value -= damage_touchDonguri;
            cnt2 = 0.0f;
        }
    }

    public void Damage_TouchBoss(){
        //ボスに触れている時のダメージ
        cnt3 += Time.deltaTime;
        if(cnt3 > 1){
            hpSlider.value -= damage_touchBoss;
            cnt3 = 0.0f;
        }
    }

    public void Damage_LeftStump(){
        hpSlider.value -= damage_hitLeftStump;
    }

    public void Damage_RightStump(){
        hpSlider.value -= damage_hitRightStump;
    }
}
