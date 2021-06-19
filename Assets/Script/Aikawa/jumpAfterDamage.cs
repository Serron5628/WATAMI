using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAfterDamage : CharaJumpCtrl_2{
    public GameObject lastAttack;
    public static float attackTime=0.0f,motiTime=0.0f;
    public static bool attackFlag,bigMotiFlag;
    public void Start(){
        attackFlag = false;
        lastAttack.SetActive(false);
    }
    public void Update(){
        if(Input.GetMouseButtonUp(0))attackFlag=true;
        if(attackTime>=1.0f){
            SuperAttack();
            lastAttack.SetActive(true);
        }
        if(attackTime>=2.0f){
            attackFlag=false;
            lastAttack.SetActive(false);
        }

        if(attackFlag == true)attackTime+=Time.deltaTime;
        else attackTime = 0.0f;
    }
    public void SuperAttack(){
    }
}
