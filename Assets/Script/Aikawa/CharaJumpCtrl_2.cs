using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaJumpCtrl_2 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";

    void OnFire(InputValue input)
    {
        bool pressed = input.isPressed;
        if (!pressed)
        {
            this.usagi.SetBool(usagiStr, true);
        }
        else
        {
            this.usagi.SetBool(usagiStr, false);
        }
    }

    void Start(){
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }
    void Update(){
    }
}
