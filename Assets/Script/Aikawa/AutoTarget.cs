using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTarget : MonoBehaviour
{
    public static GameObject targetOgj;
    public float targetDist = 10.0f;
    private float targetDistSave;
    public static GameObject[] targets;
    //public static float[] disTate;
    public GameObject player;
    public GameObject redRange;
    private float dist;
    private bool lockState=false;
    void Start(){
        redRange.SetActive(false);
        if(!player)
            player = GameObject.FindGameObjectWithTag("Player");
        targetDistSave = targetDist;
    }
    void Update(){
        targets = GameObject.FindGameObjectsWithTag("Boss");
        var playerPos = player.transform.position;
        AutoLockOn(playerPos);
        for(int i = 0; i < targets.Length; i++){
            var disArray = Vector3.Distance(new Vector3(
                targets[i].transform.position.x,playerPos.y,targets[i].transform.position.z) , playerPos);
            if((float)disArray<targetDistSave){
                redRange.SetActive(true);
                redRange.transform.Rotate(new Vector3(0, 0, 100*Time.deltaTime));
                break;
            }
            else{
                redRange.SetActive(false);
            }
        }
    }
    public void AutoLockOn(Vector3 playerPos){
        foreach (GameObject target in targets){
            dist = Vector3.Distance(new Vector3(target.transform.position.x,playerPos.y,target.transform.position.z) , playerPos);
            if(targetDist>dist){
                targetOgj=target;
                redRange.SetActive(true);
                targetDist = dist;
                redRange.transform.position = new Vector3(
                    targetOgj.transform.position.x,targetOgj.transform.position.y-3.0f,targetOgj.transform.position.z);
                if(lockState==true)
                    player.transform.LookAt(new Vector3(target.transform.position.x,playerPos.y,target.transform.position.z));
            }else{
                targetDist = targetDistSave;
            }
        }
    }
    public void BoosLockOn(){
        lockState=true;
    }
    public void BoosLockOff(){
        lockState=false;
    }
}
