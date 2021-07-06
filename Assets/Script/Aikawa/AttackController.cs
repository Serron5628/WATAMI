﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour{
    public static GameObject targetOgj;
    public float targetDist = 10.0f;
    private float targetDistSave;
    private int attackWay=1;
    public static GameObject[] targets;
    public GameObject player;
    public GameObject redRange;
    public Text modeTaxt;
    private int mode=1;
    private float dist;
    private bool lockState=false;
    bool a_flag;
    float a_color;
    void Start(){
        redRange.SetActive(false);
        if(!player)
            player = GameObject.FindGameObjectWithTag("Player");
        targetDistSave = targetDist;
        TextColor();
    }
    void TextColor(){
        a_flag = true;
        a_color = 1;
    }
    void Update(){
        modeTaxt.text = "MODE : " + mode;
        var inputHorizontal = Input.GetAxisRaw("Horizontal");
        var inputVertical = Input.GetAxisRaw("Vertical");
        var cameraForward = Vector3.Scale(
            Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        var moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            attackWay=1;
            TextColor();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            attackWay=2;
            TextColor();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            attackWay=3;
            TextColor();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            attackWay=4;
            TextColor();        
        }          
        switch(attackWay){
            case 1:
                mode=1;
                break;
            case 2:
                mode=2;
                targets = GameObject.FindGameObjectsWithTag("Boss");
                var playerPos = player.transform.position;
                AutoLockOn(playerPos);
                for(int i = 0; i < targets.Length; i++){
                    var disArray = Vector3.Distance(new Vector3(
                        targets[i].transform.position.x,playerPos.y,
                        targets[i].transform.position.z) , playerPos);
                    if((float)disArray<targetDistSave){
                        redRange.SetActive(true);
                        redRange.transform.Rotate(new Vector3(0, 0, 100*Time.deltaTime));
                        break;
                    }
                    else{
                        redRange.SetActive(false);
                    }
                }
                break;
            case 3:
                mode=3;
                CameraForwardAttack(cameraForward);
                break;
            case 4:
                mode=4;
                break;
        }
        if(attackWay!=2)
            redRange.SetActive(false);
        if (a_flag) {
            modeTaxt.color = new Color (0, 0, 0, a_color);
            a_color -=  Time.deltaTime;
            if (a_color < 0) {
                a_color = 0;
                a_flag = false;
            }
        }
    }
    public void AutoLockOn(Vector3 playerPos){
        foreach (GameObject target in targets){
            dist = Vector3.Distance(new Vector3(
                target.transform.position.x,playerPos.y,
                target.transform.position.z) , playerPos);
            if(targetDist>dist){
                targetOgj=target;
                redRange.SetActive(true);
                targetDist = dist;
                redRange.transform.position = new Vector3(
                    targetOgj.transform.position.x,
                    targetOgj.transform.position.y-3.0f,
                    targetOgj.transform.position.z);
                if(lockState==true)
                    player.transform.LookAt(new Vector3(
                        target.transform.position.x,
                        playerPos.y,
                        target.transform.position.z));
            }else{
                targetDist = targetDistSave;
            }
        }
    }
    public void CameraForwardAttack(Vector3 moveForward){
        if(lockState==true)
            player. transform.rotation = Quaternion.LookRotation(moveForward);
    }
    public void BoosAttack(){
        lockState=true;
    }
    public void BossAttacked(){
        lockState=false;
    }
}
