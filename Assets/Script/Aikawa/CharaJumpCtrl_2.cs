using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaJumpCtrl_2 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isHissatu";
    public static bool HissatuAnim = false;
    void Start(){
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }
    void Update(){
        if(Input.GetMouseButtonUp(0))HissatuAnim = true;
        else if(Input.GetMouseButton(0)) HissatuAnim = false;
    }
    void FixedUpdate(){
        if (HissatuAnim)this.usagi.SetBool(usagiStr, true);
        else if (HissatuAnim == false)this.usagi.SetBool(usagiStr, false);
    }
}
