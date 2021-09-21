using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    void Update()
    {
        if(Time.timeScale == 0.0f){
            CursorOn();
        }
        else{
            CursorOff();
        }
    }
    public void CursorOn(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CursorOff(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
