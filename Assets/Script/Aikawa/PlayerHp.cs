using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour{
    public Slider hpSlider;
    public float maxHp = 50f,nowHp;
    private float damageCountTime = 0.0f;
    void Start(){
        //hpSlider = GetComponent<Slider>();
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
    }
    private enum TouchObj{
        NULLTOUTCH,
        ENEMY,
        BOSS
    }
    private TouchObj touchObj;
    void Update(){
        damageCountTime += Time.deltaTime;
        switch(touchObj){
            case TouchObj.ENEMY:
                if(damageCountTime>1){
                    Damage_01();
                    damageCountTime=0.0f;
                }
                break;
            case TouchObj.BOSS:
                if(damageCountTime>1){
                    Damage_02();
                    damageCountTime=0.0f;
                }
                break;
        }
    }
    private void OnTriggerEnter(Collider other) {
        damageCountTime=0.0f;
        if(other.gameObject.tag=="enemy")
            Damage_01();
        else if(other.gameObject.tag=="Boss")
            Damage_02();
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag=="enemy")
            touchObj = TouchObj.ENEMY;
        else if(other.gameObject.tag=="Boss")
            touchObj = TouchObj.BOSS;
        else
            touchObj = TouchObj.NULLTOUTCH;
    }
    public void Damage_01(){
        hpSlider.value -= 1;
    }
    public void Damage_02(){
        hpSlider.value -= 3;
    }
    public void Damage_03(){
        
    }
}
