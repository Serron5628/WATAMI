using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaAnimation_02 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isCharaAnim";
    bool CharaAnim = false;

    void OnFire(InputValue input)
    {
        var pressed = input.isPressed;
        CharaAnim = !pressed;
    }

    void Start(){
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }
    void Update(){
        if(CharaAnim)
            this.usagi.SetBool(usagiStr, true);
        else
            this.usagi.SetBool(usagiStr, false);
    }
}
