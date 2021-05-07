using System.Collections;
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
        if (Etarget)
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

    }

    protected void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Enemy") Etarget = null;
        if (testE == true)
        {
            testE = false;
            MainCamecra.GetComponent<FollowingCamera>().enemyFlag();
        }
    }

    public GameObject getTarget()
    {
        return this.Etarget;
    }

    bool testE = false;
    bool LookE = false;
    private void Update()
    {
        if (Etarget)
        {
            var lookAtPosE = Etarget.transform.position;
        }
        var playerPos = Player.transform.position;
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        if (Etarget)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (testE == false) testE = true;
                else testE = false;
                MainCamecra.GetComponent<FollowingCamera>().enemyFlag();
            }
        }
        if (testE == true)
        {
            LookE = true;
            //MainCamecra.transform.LookAt(lookAtPosE);
        }
        else LookE = false;
    }
    private void FixedUpdate()
    {
        if (Etarget)
        {
            var lookAtPosE = Etarget.transform.position;
            if (LookE == true) palayerCenter.transform.LookAt(lookAtPosE);
        }
    }
