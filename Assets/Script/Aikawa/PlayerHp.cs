using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour{
    public Slider hpSlider;
    public float maxHp = 50f,nowHp;
    private float damageCountTime = 0.0f;

    public BossAttackHit BAH;

    bool enemyHit;
    bool bossHit;
    bool breathHit;
    bool stumpHit;
    void Start(){
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;

        enemyHit = false;
        bossHit = false;
        breathHit = false;
        stumpHit = false;
    }
    private enum TouchObj{
        NULLTOUTCH,
        BREATH,
        STUMP,
        ENEMY,
        BOSS
    }

    private TouchObj touchObj;
    void Update(){

        breathHit = BAH.hitBreath;
        if(BAH.hitLeftStump || BAH.hitRightStump)
        {
            stumpHit = true;
        }
        else
        {
            stumpHit = false;
        }

        if (breathHit)
        {
            touchObj = TouchObj.BREATH;
            Debug.Log("BREATH");
        }
        else if (stumpHit)
        {
            touchObj = TouchObj.STUMP;
            Debug.Log("STUMP");
        }
        else if (bossHit)
        {
            touchObj = TouchObj.BOSS;
            Debug.Log("BOSS");
        }
        else if (enemyHit)
        {
            touchObj = TouchObj.ENEMY;
            Debug.Log("ENEMY");
        }
        else
        {
            touchObj = TouchObj.NULLTOUTCH;
        }

        switch (touchObj){
            case TouchObj.ENEMY:
                damageCountTime += Time.deltaTime;
                if(damageCountTime>1){
                    Damage_01();
                    damageCountTime=0.0f;
                }
                break;
            case TouchObj.BOSS:
                damageCountTime += Time.deltaTime;
                if(damageCountTime>1){
                    Damage_02();
                    damageCountTime=0.0f;
                }
                break;
            case TouchObj.NULLTOUTCH:
                damageCountTime=0.0f;
                break;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="enemy"){
            Damage_01();
            enemyHit = true;
        }else if(other.gameObject.tag=="Boss"){
            Damage_02();
            bossHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemyHit = false;
        }
        else if (other.gameObject.tag == "Boss")
        {
            bossHit = false;
        }
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
