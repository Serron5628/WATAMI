﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLockOn : MonoBehaviour
{
    public GameObject MainCamecra;
    public GameObject Player;
    public GameObject palayerCenter;
    private GameObject Etarget;

    protected void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Enemy") Etarget = c.gameObject;
    }

    float distanceE;
    private void OnTriggerStay(Collider other)
    {
        Vector3 enemyPos = Etarget.transform.position;
        Ray ray = new Ray(enemyPos, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanceE))
        {
            float dist = Vector3.Distance(enemyPos, hit.point);
            if (distanceE > dist) distanceE = dist;
            Debug.Log(distanceE);
        }
        else
            Debug.DrawLine(enemyPos, transform.position, Color.magenta, 0f, false);
    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy") Etarget = null;
        if (testE == true)
        {
            testE = false;
            MainCamecra.GetComponent<FollowingCamera>().enemyFlag();
            MainCamecra.GetComponent<FollowingCamera>().enemyFlagDistance();
        }
    }

    public GameObject getTarget()
    {
        return this.Etarget;
    }

    bool testE = false;
    float Kyori;
    private void Update()
    {
        var lookAtPosE = Etarget.transform.position;
        var playerPos = Player.transform.position;
        //Kyori = Vector3.Distance(playerPos, lookAtPosE);
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if (Etarget)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (testE == false) testE = true;
                else testE = false;
                MainCamecra.GetComponent<FollowingCamera>().enemyFlag();
                palayerCenter.GetComponent<centerLockOn>().centerLock();
            }
        }
        if (testE == true)
        {
            MainCamecra.transform.LookAt(lookAtPosE);
            palayerCenter.transform.LookAt(lookAtPosE);
            //MainCamecra.transform.position = new Vector3(
            //    playerPos.x,
            //    playerPos.y + 5.0f,
            //    playerPos.z);
        }
    }
}
