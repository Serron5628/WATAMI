using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraControll : MonoBehaviour {
    private GameObject mainCameraObj;
    private bool pause = false;
    
    private void Start() {
        mainCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

	void Update (){
        if(Keyboard.current[Key.Escape].wasPressedThisFrame){
            if(!pause){
                mainCameraObj.GetComponent<CameraMove>().enabled = false;
                Time.timeScale = 0.0f;
                pause = true;
            }
            else{
                mainCameraObj.GetComponent<CameraMove>().enabled = true;
                Time.timeScale = 1.0f;
                pause = false;
            }
        }
        
        if(Time.timeScale == 0.0f){
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
	}
}