using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour{
    public static GameObject targetOgj;
    public GameObject playerParent;
    public float targetDist = 10.0f;
    private float targetDistSave,time=0.0f;
    private int attackWay=1;
    public static GameObject[] targets;
    public GameObject player;
    public GameObject redRange;
    public GameObject arrowObj;
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
        var playerPos = player.transform.position;
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
        if(!(Input.GetMouseButton(0)))
            time += Time.deltaTime;
        else
            time = 0.0f;
        if(time>2.0f||mode!=4)
            arrowObj.SetActive(false);
        switch(attackWay){
            case 1:
                mode=1;
                break;
            case 2:
                mode=2;
                targets = GameObject.FindGameObjectsWithTag("Boss");
                AutoLockOn(playerPos);
                RangeRote(playerPos);
                break;
            case 3:
                mode=3;
                CameraForwardAttack(cameraForward);
                break;
            case 4:
                mode=4;
                AttackTowardsTheArrow(playerPos,cameraForward);
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
    public void RangeRote(Vector3 playerPos){
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
    }
    public void CameraForwardAttack(Vector3 moveForward){
        if(lockState==true)
            player. transform.rotation = Quaternion.LookRotation(moveForward);
    }
    public void AttackTowardsTheArrow(Vector3 playerPos, Vector3 cameraForward){
        if(Input.GetMouseButton(0))
            arrowObj.SetActive(true);
        if(Input.GetMouseButtonDown(0))
            arrowObj. transform.rotation = Quaternion.LookRotation(cameraForward);
        Vector3 arrowForward = Vector3.Scale(
            arrowObj.transform.forward, new Vector3(1, 0, 1)).normalized;
        arrowObj.transform.position = new Vector3(playerPos.x, 1,playerPos.z);
        if(Input.GetKey(KeyCode.Q))
            arrowObj.transform.Rotate(new Vector3(0, -200*Time.deltaTime,0));
        if(Input.GetKey(KeyCode.E))
            arrowObj.transform.Rotate(new Vector3(0, 200*Time.deltaTime,0));
        if(lockState==true)
            player. transform.rotation = Quaternion.LookRotation(arrowForward);
    }
    public void BossAttack(){
        lockState=true;
        playerParent.GetComponent<PlayerMove>().enabled=false;
    }
    public void BossAttacked(){
        lockState=false;
        playerParent.GetComponent<PlayerMove>().enabled=true;
    }
}
