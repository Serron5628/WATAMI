using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIpos : MonoBehaviour
{
    GameObject cameraObj;
    public GameObject UIcenter,pCenter;
    public Vector3 uIPos = new Vector3(0,2.0f,0);
    void Update()
    {
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        if(cameraObj)transform.LookAt(cameraObj.transform);
        if(UIcenter){
            UIcenter.transform.position=pCenter.transform.position;
            transform.position = UIcenter.transform.position + uIPos;  
        }    
    }
}
