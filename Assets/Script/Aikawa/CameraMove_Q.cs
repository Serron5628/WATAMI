using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_Q : MonoBehaviour
{
    public Vector3 cameraPos;
    public GameObject playerObj;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerObj.transform.position + cameraPos;
        this.transform.LookAt(playerObj.transform);
    }
}