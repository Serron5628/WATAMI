using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour{
    public static bool motiObjActive = false;
    public GameObject attackMoti;
    private void Update(){
        if(motiObjActive) attackMoti.SetActive(true);
        else attackMoti.SetActive(false);
    }
    public void AttackMotiSetActive(){
        if(motiObjActive) motiObjActive = false;
        else motiObjActive = true;
    }
}
