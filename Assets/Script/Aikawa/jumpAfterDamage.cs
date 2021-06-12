using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAfterDamage : CharaJumpCtrl_2{
    public static float attackTime=0.0f;
    public void Update(){
        if(HissatuAnim == true){
            attackTime+=Time.deltaTime;
            LastAttack();
        }
        //if(attackTime>=)
    }
    public void LastAttack(){
         Debug.Log("振り下ろし確認");
    }
}
