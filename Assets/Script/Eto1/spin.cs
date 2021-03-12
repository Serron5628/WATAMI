using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public huge HUGE;
    Vector3 torque;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        torque = Vector3.zero;
        if(Input.GetKey(KeyCode.S))
        {
            torque = Vector3.left;
            //float turn = Input.GetAxis("Horizontal");
            //rb.AddTorque(transform.up * torque * turn);
            rb.AddTorque(torque, ForceMode.Acceleration);
            //rb.AddForceAtPosition(torque, ForceMode.Acceleration, transform.position);
            HUGE.hugeScale();
        }
        
    }
}
