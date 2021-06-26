using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject mainCamera,sub,endingCamera; 
    public GameObject bossObj,player;
    public Vector3 attackCameraPos;
    public GameObject wall,cameraText;
    private bool bossDeath=false;
    private Vector3 moveTargetPos = new Vector3(0.0f,12.0f,-4.0f);
    [SerializeField] public float targetPosRatio = 0.2f;//最初に見ている位置、0ならPlayer、1ならBoss
    [SerializeField] public float distance = 15.0f;
    [SerializeField] public float endingHeight = 5.0f;
    [SerializeField] public float endingCameraSpeed=1.0f;//endingCameraが移動する速さ
    [SerializeField] public float zoomInSpeed = 5.0f;
    [SerializeField] public float direction = 2.0f;//2なら30度,正三角形の一辺を割る数にしてある
    private float endingCameraDistance,bossDistance,z;
    private bool pause=false;
    private bool attack=false;
    void Start () {
        endingCamera.SetActive(false);
        endingCameraDistance = 5.0f;
        CursorOff();
        Camera_02True();
	}
	void Update () {
        var bossObjPos = bossObj.transform.position;
        var playerPos = player.transform.position;
        var moveTargetPos = Vector3.Lerp(player.transform.position,bossObj.transform.position,targetPosRatio);
        sub.transform.position = Vector3.Lerp(player.transform.position,bossObj.transform.position,0.5f);
        bossDistance = Vector3.Distance(bossObjPos,endingCamera.transform.position);
        if(Input.GetMouseButton(0)){
            pause = true;
            AttackCamera(playerPos);
        }
        else if(Input.GetMouseButtonUp(0)){
            pause = false;
            Camera_02True();
        }
        if(Input.GetKey(KeyCode.Escape)){
            if(pause==false)
                pause = true;
            else{
                pause = false;
                Camera_02True();
            }
        }
        else if(Input.GetKeyDown(KeyCode.B))
            DestroyBoss();
        else if(Input.GetKeyDown(KeyCode.R))
            BossCameraReset();
        else if(Input.GetKeyDown(KeyCode.Alpha1))
            Camera_02True();
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            Camera_03True();
        if(bossDeath==true){
            EndingCameraMove(bossObjPos,playerPos);
            UpdateCameraPos(moveTargetPos,bossObjPos);
            UpdateCharaLockAt(bossObjPos,playerPos);
        }else
            endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,0.0f);
        if(pause==true){
            CursorOn();
            Pause();
        }
        else CursorOff();
	}
    public void Pause(){
        mainCamera.GetComponent<Camera_02>().enabled=false;
        mainCamera.GetComponent<Camera_03>().enabled=false;
    }
    public void Camera_02True(){
        mainCamera.GetComponent<Camera_02>().enabled=true;
        mainCamera.GetComponent<Camera_03>().enabled=false;
    }
    public void Camera_03True(){
        mainCamera.GetComponent<Camera_02>().enabled=false;
        mainCamera.GetComponent<Camera_03>().enabled=true;
    }
    public void AttackCamera(Vector3 playerPos){
        mainCamera.transform.position=playerPos + attackCameraPos;
        mainCamera.transform.LookAt(playerPos);
    }
    public void CursorOn(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CursorOff(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void EndingCameraMove(Vector3 bossObjPos, Vector3 playerPos){
        if(targetPosRatio<=1)
            targetPosRatio += Time.deltaTime * endingCameraSpeed;
        if(endingCameraDistance!=distance/direction)
            endingCameraDistance=distance/direction;
        if(bossDistance-2.0f>distance)
            z += Time.deltaTime * zoomInSpeed;
        else if(bossDistance<distance)
            z -= Time.deltaTime* zoomInSpeed;
    }
    public void DestroyBoss(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.gameObject.GetComponent<Rigidbody>().isKinematic = true; 
        endingCamera.gameObject.SetActive(true);
        wall.gameObject.SetActive(false);
        cameraText.gameObject.SetActive(false);
        mainCamera.GetComponent<Camera_02>().enabled=false;
        mainCamera.GetComponent<Camera_03>().enabled=false;
        bossDeath=true;
    }
    public void BossCameraReset(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.gameObject.GetComponent<Rigidbody>().isKinematic = false; 
        endingCamera.gameObject.SetActive(false);
        wall.gameObject.SetActive(true);
        cameraText.gameObject.SetActive(true);
        mainCamera.GetComponent<Camera_02>().enabled=true;
        mainCamera.GetComponent<Camera_03>().enabled=false;
        bossDeath=false;
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