using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAfterDamage : CharaJumpCtrl_2{
    public static bool attack = false;
    public void FixedUpdate(){
        
        if(HissatuAnim == false){
            Debug.Log("振り下ろし確認");
            if(attack==true)LastAttack();
        }else{

        }
    }
    public void LastAttack(){

    }
    public void WaitAttack(){

    }
}
