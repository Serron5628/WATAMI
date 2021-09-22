using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraControll : MonoBehaviour {
    private GameObject mainCameraObj;
    private bool pause = false, pressFlag = false;
    
    private void Start() {
        mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void OnFire(){
        if(!pressFlag) pressFlag = true;
        else pressFlag = false;
    }
    int testCnt = 0;
	void Update (){
        if(Keyboard.current[Key.Escape].wasPressedThisFrame){
            if(!pause){
                if(pressFlag) pressFlag = false;
                pause = true;
            }
            else pause = false;
        }
        if(!pause){
            mainCameraObj.GetComponent<CameraMove>().enabled = true;
            if(pressFlag) CursorOn();
            else{
                CursorOff();
            }
            TimeScale_1();
        }
        else{
            mainCameraObj.GetComponent<CameraMove>().enabled = false;
            CursorOn();
            TimeScale_0();
        }
        
	}
    private void FixedUpdate() {
        if(!pause && !pressFlag) CursorOff();
        if(Time.timeScale != 0.0f && !pressFlag) CursorOff();
    }
    public void CursorOn(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CursorOff(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;;
    }
    public void TimeScale_1(){
        Time.timeScale = 1.0f;
    }
    public void TimeScale_0(){
        Time.timeScale = 0.0f;
    }
}