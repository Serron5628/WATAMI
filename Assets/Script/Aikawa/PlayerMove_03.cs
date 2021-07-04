using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_03 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 3.0f;
    private void start(){
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        float x =  Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rb.AddForce(x , 0 , z );
    }
}