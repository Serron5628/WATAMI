using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLockOn : MonoBehaviour
{
    public GameObject MainCamecra;
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
           GetComponent<FollowingCamera>().enemyFlag();
        }
    }

    public GameObject getTarget()
    {
        return this.Etarget;
    }

    bool testE = false;
    private void Update()
    {
        var lookAtPosE = Etarget.transform.position;
        if (!Etarget)
        {
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (testE == false) testE = true;
                else testE = false;
                GetComponent<FollowingCamera>().enemyFlag();
            }
        }
        if (testE == true)
        {
            MainCamecra.transform.LookAt(lookAtPosE);
            //MainCamecra.transform.position = new Vector3(
            //   lookAtPosE.x,
            //   lookAtPosE.y + 5.0f,
            //   lookAtPosE.z + 10.0f);
            //Debug.Log(lookAtPosE.y + 5.0f);
        }
    }
}
