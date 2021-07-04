using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTarget : MonoBehaviour
{
    public static GameObject targetOgj;
    public float targetDist = 20.0f;
    private float targetDistSave;
    public static GameObject[] targets;
    public GameObject player;
    private float dist;
    private bool lockState=false;
    void Start(){
        if(!player)
            player = GameObject.FindGameObjectWithTag("Player");
        targetDistSave = targetDist;
    }
    void Update(){
        var playerPos = player.transform.position;
        AutoLockOn(playerPos);
    }
    public void AutoLockOn(Vector3 playerPos){
        targets = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject target in targets){
            Vector3 targetPos = new Vector3(target.transform.position.x,playerPos.y,target.transform.position.z);
            dist = Vector3.Distance(targetPos , playerPos);
            Debug.DrawLine(new Vector3(
                target.transform.position.x,playerPos.y,target.transform.position.z),
                playerPos, Color.blue, 0f, false);
            if(targetDist>dist){
                targetOgj=target;
                targetDist = dist;
                if(lockState==true)
                    player.transform.LookAt(targetPos);
            }else
                targetDist = targetDistSave;
        }
        Debug.Log(targetOgj);
    }
    public void BoosLockOn(){
        lockState=true;
    }
    public void BoosLockOff(){
        lockState=false;
    }
}
