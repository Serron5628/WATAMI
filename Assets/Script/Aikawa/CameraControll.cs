using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject mainCamera,sub,endingCamera; 
    public GameObject bossObj,player;
    public GameObject wall;
    private bool bossDeath=false;
    private Vector3 moveTargetPos;
    public float targetPosRatio = 0.2f;//最初に見ている位置
    public float distance = 20.0f;
    public float endingHeight = 5.0f;
    private float endingCameraDistance;
    private float bossDistance;
    public float endingCameraSpeed=0.3f;//endingCameraが移動する速さ
    public float zoomInSpeed = 5.0f;
    void Start () {
        endingCamera.SetActive(false);
        endingCameraDistance = 5.0f;
	}
	void Update () {
        var bossObjPos = bossObj.transform.position;
        var playerPos = player.transform.position;
        var moveTargetPos = Vector3.Lerp(player.transform.position,bossObj.transform.position,targetPosRatio);
        sub.transform.position = Vector3.Lerp(player.transform.position,bossObj.transform.position,0.5f);
        
        bossDistance = Vector3.Distance(bossObjPos,endingCamera.transform.position);
        if(Input.GetKeyDown(KeyCode.Q))DestroyBoss();
        if(bossDeath==true){
            endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,-endingCameraDistance+distance);
            if(targetPosRatio<=1)targetPosRatio += Time.deltaTime * endingCameraSpeed;
            if(bossDistance>distance+2.0f)endingCameraDistance -= Time.deltaTime * endingCameraSpeed;
            else if(bossDistance+2.0f<distance)  endingCameraDistance += Time.deltaTime * zoomInSpeed;
            UpdateCameraPos(moveTargetPos,bossObjPos);
            UpdateCharaLockAt(bossObjPos,playerPos);
        }else endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,-0.0f);
        Debug.Log(bossDistance);
	}
    public void DestroyBoss(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.gameObject.GetComponent<Rigidbody>().isKinematic = true; 
        endingCamera.gameObject.SetActive(true);
        wall.gameObject.SetActive(false);
        mainCamera.GetComponent<Camera_02>().enabled=false;
        bossDeath=true;
    }
    public void UpdateCharaLockAt(Vector3 bossObjPos, Vector3 playerPos){
        player.transform.LookAt(new Vector3(bossObjPos.x,bossObjPos.y-2.0f,bossObjPos.z));
        bossObj.transform.LookAt(new Vector3(playerPos.x,playerPos.y+2.0f,playerPos.z));
    }
    public void UpdateCameraPos(Vector3 moveTargetPos,Vector3 bossObjPos){
        mainCamera.transform.position= endingCamera.transform.position;
        sub.transform.LookAt(bossObjPos);
        endingCamera.transform.LookAt(moveTargetPos);
    }
}