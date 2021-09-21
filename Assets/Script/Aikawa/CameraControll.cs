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
        
	}
    private void FixedUpdate() {
        if(!pause && !pressFlag) CursorOff();
        if(Time.timeScale != 0.0f && !pressFlag) CursorOff();

        if(!pause){
            mainCameraObj.GetComponent<CameraMove>().enabled = true;
            if(pressFlag) CursorOn();
            else{
                testCnt+=1;
                Debug.Log(testCnt);
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
    public void CursorOn(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CursorOff(){
        Cursor.lockState = CursorLockMode.Locked;;
        Cursor.visible = false;
    }
    public void TimeScale_1(){
        Time.timeScale = 1.0f;
    }
    public void TimeScale_0(){
        Time.timeScale = 0.0f;
    }
}