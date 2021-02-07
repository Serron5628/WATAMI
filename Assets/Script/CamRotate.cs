using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public GameObject Cam;

    void Start()
    {
        if (Cam == null)
        {
            Cam = Camera.main.gameObject;
        }
    }

    
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Cam.transform.localEulerAngles.y, 0);
    }
}