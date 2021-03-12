using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin2 : MonoBehaviour
{
    public huge HUGE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //torque = Vector3.left;
            //float turn = Input.GetAxis("Horizontal");
            //rb.AddTorque(transform.up * torque * turn);
            //rb.AddTorque(torque, ForceMode.Acceleration);
            //rb.AddForceAtPosition(torque, ForceMode.Acceleration, transform.position);
            transform.Rotate(new Vector3(0, -10, 0));
            HUGE.hugeScale();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            //torque = Vector3.left;
            //float turn = Input.GetAxis("Horizontal");
            //rb.AddTorque(transform.up * torque * turn);
            //rb.AddTorque(torque, ForceMode.Acceleration);
            //rb.AddForceAtPosition(torque, ForceMode.Acceleration, transform.position);
            transform.Rotate(new Vector3(0, 10, 0));
            HUGE.hugeScale();
        }
        if (Input.GetKey(KeyCode.F))
        {
            HUGE.hugeScale();
        }
        if (Input.GetKey(KeyCode.R))
        {
            HUGE.ResetE();
        }
    }
}
