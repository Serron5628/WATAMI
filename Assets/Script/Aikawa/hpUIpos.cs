using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUIpos : MonoBehaviour
{
    GameObject cameraObj;
    public GameObject UIcenter,pCenter;
    void Update()
    {
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        if(cameraObj)transform.LookAt(cameraObj.transform);
        if(UIcenter){
            UIcenter.transform.position=pCenter.transform.position;
            transform.position = UIcenter.transform.position + new Vector3(0,1.5f,0);  
        }    
    }
}
