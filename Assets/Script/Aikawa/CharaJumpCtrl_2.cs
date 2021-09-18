using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaJumpCtrl_2 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";
    public static bool HissatuAnim = false;

    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;
        if(!pressed){
            this.usagi.SetBool(usagiStr, true);
            HissatuAnim = true;
        }
        else{
            this.usagi.SetBool(usagiStr, false);
            HissatuAnim = false;
        }
    }

    void Start(){
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }
    void Update(){
    }
}
