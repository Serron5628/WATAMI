using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaAnimation_02 : MonoBehaviour
{
    private Animator usagi;
    private string usagiStr = "isCharaAnim";
    bool CharaAnim = false;
    void Start(){
        this.usagi = GetComponent<Animator>();
        this.usagi.SetBool(usagiStr, false);
    }
    void Update(){
        if(Input.GetMouseButtonUp(0))
            CharaAnim = true;
        else
            CharaAnim = false;
        if(CharaAnim)
            this.usagi.SetBool(usagiStr, true);
        else
            this.usagi.SetBool(usagiStr, false);
    }
}
