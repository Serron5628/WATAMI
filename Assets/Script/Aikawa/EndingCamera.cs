using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCamera : MonoBehaviour
{
    private GameObject bossObj;
    void Start()
    {
        bossObj = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
