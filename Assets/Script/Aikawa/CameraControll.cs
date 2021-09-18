using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraControll : MonoBehaviour {

    public Text text;
    public GameObject mainCamera,sub,endingCamera; 
    public GameObject bossObj,player;
    public Vector3 attackCameraPos;
    public GameObject wall;
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
    bool start=false,esc=true;
    string cursor;
    private CameraMove CameraCs;

    bool mousePressed = false;

    void Start () {
        endingCamera.SetActive(false);
        endingCameraDistance = 5.0f;
        CameraMoveTrue();
	}

    void OnFire(InputValue input) 
    {
        mousePressed = input.isPressed;
    }

    void OnPause(InputValue input) 
    {
        var pressed = input.isPressed;
        if (pressed) {
            if (pause) {
                pause = false;
                esc=true;
            } else {
                pause = true;
                esc=false;
            }
        }
    }

    void OnBossCameraReset(InputValue input)
    {
        var pressed = input.isPressed;
        if (pressed && bossDeath) {
            BossCameraReset();
        }
    }

	void Update () {
        start = true;
        if(pause && start && !mousePressed){
            CursorOn();
            Pause();
        }else if(!pause && start && !mousePressed){
            CursorOff();
            CameraMoveTrue();
        }
        if(esc==true&&start==true)
            Time.timeScale = 1.0f;
        else if(esc==false&&start==true)
            Time.timeScale = 0.0f;
        var bossObjPos = bossObj.transform.position;
        var playerPos = player.transform.position;
        var moveTargetPos = Vector3.Lerp(
            player.transform.position,bossObj.transform.position,targetPosRatio);
        sub.transform.position = Vector3.Lerp(
            player.transform.position,bossObj.transform.position,0.5f);
        bossDistance = Vector3.Distance(bossObjPos,endingCamera.transform.position);
        if(mousePressed)
            CursorOn();
        
        //if(Input.GetKeyDown(KeyCode.B))
        //    DestroyBoss();

        if(bossDeath==true){
            EndingCameraMove(bossObjPos,playerPos);
            UpdateCameraPos(moveTargetPos,bossObjPos);
            UpdateCharaLockAt(bossObjPos,playerPos);
        }else
            endingCamera.transform.localPosition = new Vector3(
                endingCameraDistance,endingHeight,0.0f);
        if(text)text.text = "Cursor="+cursor;
	}

    public void Pause(){
        mainCamera.GetComponent<CameraMove>().enabled=false;
    }

    public void CameraMoveTrue(){
        mainCamera.GetComponent<CameraMove>().enabled=true;
    }

    public void AttackCamera(Vector3 playerPos){
        mainCamera.transform.position=playerPos + attackCameraPos;
        mainCamera.transform.LookAt(playerPos);
    }

    public void CursorOn(){
        cursor = "ON";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CursorOff(){
        cursor = "OFF";
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
        mainCamera.GetComponent<CameraMove>().enabled=false;
        bossDeath=true;
    }

    public void BossCameraReset(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.gameObject.GetComponent<Rigidbody>().isKinematic = false; 
        endingCamera.gameObject.SetActive(false);
        wall.gameObject.SetActive(true);
        mainCamera.GetComponent<CameraMove>().enabled=true;
        bossDeath=false;
    }
    
    public void UpdateCharaLockAt(Vector3 bossObjPos, Vector3 playerPos){
        player.transform.LookAt(new Vector3(bossObjPos.x,playerPos.y,bossObjPos.z));
        bossObj.transform.LookAt(new Vector3(playerPos.x,bossObjPos.y,playerPos.z));
    }

    public void UpdateCameraPos(Vector3 moveTargetPos,Vector3 bossObjPos){
        endingCamera.transform.localPosition = new Vector3(endingCameraDistance,endingHeight,z);
        mainCamera.transform.position= endingCamera.transform.position;
        sub.transform.LookAt(
            new Vector3(bossObjPos.x,sub.transform.position.y,bossObjPos.z));
        endingCamera.transform.LookAt(moveTargetPos);
    }
}