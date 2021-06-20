using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject mainCamera,sub,endingCamera; 
    public GameObject bossObj,player;
    public GameObject wall,cameraText;
    private bool bossDeath=false;
    private Vector3 moveTargetPos;
    [SerializeField] public float targetPosRatio = 0.2f;//最初に見ている位置
    [SerializeField] public float distance = 15.0f;
    [SerializeField] public float endingHeight = 5.0f;
    [SerializeField] public float endingCameraSpeed=1.0f;//endingCameraが移動する速さ
    [SerializeField] public float zoomInSpeed = 5.0f;
    [SerializeField] public float direction = 2.0f;//2なら30度
    private float endingCameraDistance,bossDistance,z;
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
            if(targetPosRatio<=1)targetPosRatio += Time.deltaTime * endingCameraSpeed;
            if(endingCameraDistance!=distance/direction)endingCameraDistance=distance/2;
            if(bossDistance-2.0f>distance)z += Time.deltaTime * zoomInSpeed;
            else if(bossDistance<distance)z -= Time.deltaTime* zoomInSpeed;
            UpdateCameraPos(moveTargetPos,bossObjPos);
            UpdateCharaLockAt(bossObjPos,playerPos);
        }else endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,0.0f);
	}
    public void DestroyBoss(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.gameObject.GetComponent<Rigidbody>().isKinematic = true; 
        endingCamera.gameObject.SetActive(true);
        wall.gameObject.SetActive(false);
        cameraText.gameObject.SetActive(false);
        mainCamera.GetComponent<Camera_02>().enabled=false;
        bossDeath=true;
    }
    public void UpdateCharaLockAt(Vector3 bossObjPos, Vector3 playerPos){
        player.transform.LookAt(new Vector3(bossObjPos.x,playerPos.y,bossObjPos.z));
        bossObj.transform.LookAt(new Vector3(playerPos.x,bossObjPos.y,playerPos.z));
    }
    public void UpdateCameraPos(Vector3 moveTargetPos,Vector3 bossObjPos){
        endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,z);
        mainCamera.transform.position= endingCamera.transform.position;
        sub.transform.LookAt(new Vector3(bossObjPos.x,sub.transform.position.y,bossObjPos.z));
        endingCamera.transform.LookAt(moveTargetPos);
    }
}